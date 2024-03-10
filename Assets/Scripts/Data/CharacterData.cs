using UnityEngine;

public class CharacterData : ScriptableObject
{
    [SerializeField]
    private string _id = "";
    public string ID => _id;
    [SerializeField]
    private int _maxHp = 0;
    public int MaxHP => _maxHp;
    [SerializeField]
    private int _maxArmor = 0;
    public int MaxArmor => _maxArmor;
}
