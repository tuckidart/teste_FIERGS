using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private Animator _characterAnimator = null;
    [SerializeField]
    private Animator _statsAnimator = null;

    [SerializeField]
    private StatsView _statsView = null;

    protected int _maxHp = 0;
    protected int _currentHp = 0;
    protected int _maxArmor = 0;
    protected int _currentArmor = 0;

    public void ReceiveDamage(int damage, bool pierce = false)
    {
        if (_currentArmor > 0 && !pierce)
        {
            _statsAnimator.Play("ArmorDown");
            int armorAux = _currentArmor;
            _currentArmor = Mathf.Max(_currentArmor - damage, 0);
            damage -= armorAux - _currentArmor;
        }

        _currentHp = Mathf.Max(_currentHp - damage, 0);
        _statsAnimator.Play("Damage");
        AudioManager.Instance.PlayDamage();
    }

    public void Heal(int hp)
    {
        _currentHp = Mathf.Min(_currentHp + hp, _maxHp);
        _statsAnimator.Play("Heal");
        AudioManager.Instance.PlayHeal();
    }

    public void GainArmor(int armor)
    {
        _currentArmor = Mathf.Min(_currentArmor + armor, _maxArmor);
        _statsAnimator.Play("ArmorUp");
        AudioManager.Instance.PlayArmor();
    }

    public void PlayAttack() => _characterAnimator.Play("Attack");

    public bool IsDead() => _currentHp == 0;

    public void UpdateStatsValues() => _statsView.UpdateStatsValues(_currentHp, _maxHp, _currentArmor, _maxArmor);
}
