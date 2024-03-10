using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class BattleLoader : MonoBehaviour
{
    [SerializeField]
    private BattleData _battleData = null;
    [SerializeField]
    private Button _button = null;

    private void OnEnable()
    {
        int xp = PlayerPrefs.GetInt("xp");
        if (xp >= _battleData.XPToUnlock)
        {
            _button.interactable = true;
        }
    }

    public void LoadBattle()
    {
        UIManager.Instance.CloseCurrentUIs();

        BattleManager.Instance.CreateBattle(_battleData);

        SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(GameManager.Instance.SceneToUnload);
    }
}
