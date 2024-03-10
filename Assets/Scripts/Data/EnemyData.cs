using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "FIERGS/Game Elements/Enemy Data")]
public class EnemyData : CharacterData
{
    [SerializeField]
    private Sprite _sprite = null;
    public Sprite Sprite => _sprite;
    [SerializeField]
    private List<EffectData> _effectDatas = null;
    public List<EffectData> EffectDatas => _effectDatas;
}
