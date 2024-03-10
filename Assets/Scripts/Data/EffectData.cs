using UnityEngine;

[System.Serializable]
public class EffectData
{
    [SerializeField]
    private EEffect _effectType = EEffect.Heal;
    public EEffect EffectType => _effectType;
    [SerializeField]
    private ETarget _target = ETarget.Other;
    public ETarget Target => _target;
    [SerializeField, Min(1)]
    private int _value = 1;
    public int Value => _value;
}
