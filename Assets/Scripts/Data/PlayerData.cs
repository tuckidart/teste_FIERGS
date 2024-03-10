using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "FIERGS/Game Elements/Player Data")]
public class PlayerData : CharacterData
{
    [SerializeField]
    private DeckData _deckData = null;
    public DeckData DeckData => _deckData;
}