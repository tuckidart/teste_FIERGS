using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField]
    private SpriteRenderer _renderer = null;
    [SerializeField]
    private ParticleSystem _blood = null;

    private List<Effect> _effects = new List<Effect>();
    private Effect _currentEffect = null;

    public void SetEnemy(EnemyData data)
    {
        _renderer.sprite = data.Sprite;

        _maxHp = data.MaxHP;
        _currentHp = data.MaxHP;
        _maxArmor = data.MaxArmor;

        for (int i = 0; i < data.EffectDatas.Count; i++)
        {
            Effect effect = new Effect(data.EffectDatas[i]);
            _effects.Add(effect);
        }

        UpdateStatsValues();
    }

    public void ChooseNextEffect()
    {
        int rnd = Random.Range(0, _effects.Count);
        _currentEffect = _effects[rnd];
    }

    public void UseEffect()
    {
        BattleMaestro.Instance.ApplyEffect(_currentEffect, this);
    }

    public override void ReceiveDamage(int damage, bool pierce = false)
    {
        base.ReceiveDamage(damage, pierce);
        _blood.Play();
    }
}
