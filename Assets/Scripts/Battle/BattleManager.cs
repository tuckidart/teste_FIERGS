using UnityEngine;

public class BattleManager
{
    private static BattleManager _instance = null;
    public static BattleManager Instance
    {
        private set { _instance = value; }
        get
        {
            _instance ??= new BattleManager();

            return _instance;
        }
    }

    private EnemyData _enemyData;
    public EnemyData EnemyData => _enemyData;

    private PlayerData _playerData;
    public PlayerData PlayerData => _playerData;

    private int _xpReward = 0;
    public int XPReward => _xpReward;

    private Sprite _background = null;
    public Sprite Background => _background;

    public void CreateBattle(BattleData data)
    {
        _playerData = data.PlayerData;
        _enemyData = data.EnemyData;
        _xpReward = data.XPReward;
        _background = data.Background;
    }
}
