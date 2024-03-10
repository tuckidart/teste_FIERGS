using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    private GameObject _cardViewPrefab = null;

    [Space]

    [SerializeField]
    private CustomLayoutGroup _customLayoutGroup = null;

    private List<Card> _drawDeck = null;
    private List<Card> _discardDeck = null;

    private static int _maxHandCards = 4;
    private int _cardsInHand = 0;

    public void Initialize(DeckData deckData)
    {
        _drawDeck = new List<Card>();
        _discardDeck = new List<Card>();

        foreach (CardData cardData in deckData.Cards)
        {
            Card card = new Card(cardData);
            _drawDeck.Add(card);
        }

        Shuffle();
    }

    public void DrawHand()
    {
        for (int i = 0; i < _maxHandCards; i++)
        {
            DrawCard();
        }
    }

    public void DrawCard()
    {
        if (_cardsInHand >= _maxHandCards)
        {
            return;
        }

        if (_drawDeck.Count == 0)
        {
            if (_discardDeck.Count == 0)
            {
                return;
            }

            foreach (Card card in _discardDeck)
            {
                _drawDeck.Add(card);
            }

            _discardDeck.Clear();
            Shuffle();
        }

        GameObject go = _customLayoutGroup.GetInactiveChild();
        if (go == null)
        {
            go = Instantiate(_cardViewPrefab, transform);
        }

        CardView cardView = go.GetComponent<CardView>();

        cardView.SetDataValues(_drawDeck[0]);
        _drawDeck.RemoveAt(0);

        _customLayoutGroup.AddChild(cardView);

        go.SetActive(true);
        cardView.ChangeState(ECardState.DRAWN);
        _cardsInHand++;

        _customLayoutGroup.UpdateLayout();
    }

    public void DiscardCard(CardView view)
    {
        _discardDeck.Add(view.Card);
        _customLayoutGroup.RemoveChild(view);
        _cardsInHand--;
    }

    private void Shuffle()
    {
        int n = _drawDeck.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Card card = _drawDeck[k];
            _drawDeck[k] = _drawDeck[n];
            _drawDeck[n] = card;
        }
    }
}
