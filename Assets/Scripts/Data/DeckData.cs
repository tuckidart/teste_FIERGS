using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Deck Data", menuName = "FIERGS/Game Elements/Deck Data")]
public class DeckData : ScriptableObject
{
    [SerializeField]
    private List<CardData> _cards = new List<CardData>();
    public List<CardData> Cards => _cards;
}
