public class Effect
{
    private EEffect _effectType = EEffect.Heal;
    public EEffect EffectType => _effectType;

    private ETarget _target = ETarget.Other;
    public ETarget Target => _target;

    private int _value = 1;
    public int Value => _value;

    public Effect(EffectData data)
    {
        _effectType = data.EffectType;
        _target = data.Target;
        _value = data.Value;
    }
}
