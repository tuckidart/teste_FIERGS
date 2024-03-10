using UnityEngine;

public enum EEffect
{
    Heal,
    Armor,
    Damage,
    Pierce,
}

public enum ETarget
{
    Other,
    Self
}

[CreateAssetMenu(fileName = "Card Data", menuName = "FIERGS/Game Elements/Card Data")]
public class CardData : ScriptableObject
{
    [SerializeField]
    private string _id = "";
    public string ID => _id;
    [SerializeField]
    private string _description = "";
    public string Description => _description;
    [SerializeField]
    private Sprite _sprite = null;
    public Sprite Sprite => _sprite;
    [SerializeField, Min(0)]
    private int _cost = 1;
    public int Cost => _cost;

    [SerializeField]
    private EffectData _effectData = null;
    public EffectData EffectData => _effectData;
}
