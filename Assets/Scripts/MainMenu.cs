using UnityEditor;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _menuOptions = null;

    public void Start()
    {
        GameManager.Instance.SetSceneToUnload("MainMenu");
        AudioManager.Instance.PlayMainMenuMusic();
    }

    public void OpenBattleSelector()
    {
        _menuOptions.SetActive(false);
        UIManager.Instance.OpenBattleSelector();
        AudioManager.Instance.PlayClick();
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
