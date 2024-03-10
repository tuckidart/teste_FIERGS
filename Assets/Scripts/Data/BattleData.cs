using UnityEngine;

[CreateAssetMenu(fileName = "Battle Data", menuName = "FIERGS/Game Elements/Battle Data")]
public class BattleData : ScriptableObject
{
    [SerializeField]
    private Sprite _background = null;
    public Sprite Background => _background;

    [Space]

    [SerializeField]
    private EnemyData _enemyData = null;
    public EnemyData EnemyData => _enemyData;
    [SerializeField]
    private PlayerData _playerData = null;
    public PlayerData PlayerData => _playerData;

    [Space]

    [SerializeField, Min(0)]
    private int _xpToUnlock = 0;
    public int XPToUnlock => _xpToUnlock;
    [SerializeField, Min(1)]
    private int _xpReward = 1;
    public int XPReward => _xpReward;
}
