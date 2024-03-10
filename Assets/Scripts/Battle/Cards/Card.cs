using UnityEngine;

public class Card
{
    private Sprite _sprite;
    public Sprite Sprite => _sprite;
    private string _title;
    public string Title => _title;
    private string _description;
    public string Description => _description;
    private int _cost;
    public int Cost => _cost;

    private Effect _effect = null;
    public Effect Effect => _effect;

    private CardData _data;
    public CardData Data => _data;

    public Card(CardData data)
    {
        _data = data;
        _sprite = data.Sprite;
        _title = data.ID;
        _description = data.Description;
        _cost = data.Cost;

        _effect = new Effect(data.EffectData);
    }
}
