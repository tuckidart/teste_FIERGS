using UnityEngine;
using TMPro;

public class StatsView : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _hp = null;
    [SerializeField]
    TextMeshProUGUI _armor = null;

    public void UpdateStatsValues(int hp, int maxHp, int armor, int maxArmor)
    {
        string text = string.Concat(hp.ToString(), "/", maxHp.ToString());
        _hp.text = text;

        text = string.Concat(armor.ToString(), "/", maxArmor.ToString());
        _armor.text = text;
    }
}
