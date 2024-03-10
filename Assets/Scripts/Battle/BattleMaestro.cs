using UnityEngine;
using TMPro;

public class BattleMaestro : MonoBehaviour
{
    public static BattleMaestro Instance { get; private set; } = null;

    [SerializeField]
    private SpriteRenderer _background = null;

    [Space]

    [SerializeField]
    private TextMeshProUGUI _powerInfo = null;
    [SerializeField]
    private TextMeshProUGUI _turnInfo = null;
    [SerializeField]
    private Animator _turnInfoAnimator = null;

    [SerializeField]
    private Player _player = null;
    [SerializeField]
    private Enemy _enemy = null;

    private bool _canPlay = false;
    public bool CanPlay => _canPlay;

    private bool _isPlayerTurn = false;
    public bool IsPlayerTurn => _isPlayerTurn;
    public void ChangeTurnOwner() => _isPlayerTurn = !_isPlayerTurn;

    private int _power = 0;
    private static int _maxPower = 3;

    private int _xpReward = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameManager.Instance.SceneToUnload = "Battle";

        _background.sprite = BattleManager.Instance.Background;

        _player.SetPlayer(BattleManager.Instance.PlayerData);
        _enemy.SetEnemy(BattleManager.Instance.EnemyData);
        _xpReward = BattleManager.Instance.XPReward;

        AudioManager.Instance.PlayBattleMusic();

        _player.Hand.DrawHand();

        StartPlayerTurn();
    }

    private void RestorePower()
    {
        _power = _maxPower;
        UpdatePowerInfo();
    }

    private void UpdatePowerInfo() => _powerInfo.text = _power.ToString();

    private void CallTurnInfo(bool playerTurn)
    {
        if (playerTurn)
        {
            _turnInfo.text = "Player Turn!";
        }
        else
        {
            _turnInfo.text = "Enemy Turn!";
        }

        _turnInfoAnimator.Play("TurnInfo");
    }

    public void EndPlayerTurn()
    {
        if (!_canPlay)
            return;

        AudioManager.Instance.PlayEndTurn();

        _canPlay = false;
        CallTurnInfo(false);

        Invoke("StartEnemyTurn", 2f);
    }

    private void StartEnemyTurn()
    {
        _enemy.ChooseNextEffect();
        _enemy.UseEffect();

        Invoke("StartPlayerTurn", 2f);
    }

    private void StartPlayerTurn()
    {
        if (_player.IsDead())
            return;

        CallTurnInfo(true);
        _player.Hand.DrawHand();
        _canPlay = true;
        RestorePower();
    }

    public void PlayCard(CardView view)
    {
        if (_power < view.Card.Cost)
        {
            view.ChangeState(ECardState.RECALL);
            AudioManager.Instance.PlayError();
            return;
        }

        _power -= view.Card.Cost;
        UpdatePowerInfo();

        ApplyEffect(view.Card.Effect, _player);
        _player.Hand.DiscardCard(view);
        view.gameObject.SetActive(false);
    }

    public void ApplyEffect(Effect effect, Character perpetrator)
    {
        Character target = _enemy;
        if ((perpetrator is Player && effect.Target == ETarget.Self) ||
            (perpetrator is Enemy && effect.Target == ETarget.Other))
        {
            target = _player;
        }

        switch (effect.EffectType)
        {
            case EEffect.Heal:
                target.Heal(effect.Value);
                break;
            case EEffect.Damage:
                target.ReceiveDamage(effect.Value);
                perpetrator.PlayAttack();
                break;
            case EEffect.Pierce:
                target.ReceiveDamage(effect.Value, true);
                perpetrator.PlayAttack();
                break;
            case EEffect.Armor:
                target.GainArmor(effect.Value);
                break;
        }

        _player.UpdateStatsValues();
        _enemy.UpdateStatsValues();

        CheckBattleEnd();
    }

    private void CheckBattleEnd()
    {
        if (_enemy.IsDead())
        {
            PlayerPrefs.SetInt("xp", _xpReward);
            UIManager.Instance.OpenResult(true);
        }
        else if (_player.IsDead())
        {
            UIManager.Instance.OpenResult(false);
        }
    }
}
