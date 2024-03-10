using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private Hand _hand = null;

    public Hand Hand => _hand;

    public void SetPlayer(PlayerData data)
    {
        _maxHp = data.MaxHP;
        _currentHp = data.MaxHP;
        _maxArmor = data.MaxArmor;

        Hand.Initialize(data.DeckData);

        UpdateStatsValues();
    }
}
