using UnityEditor;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _menuOptions = null;
    [SerializeField]
    private GameObject _howToPlay = null;

    public void Start()
    {
        GameManager.Instance.SetSceneToUnload("MainMenu");
        AudioManager.Instance.PlayMainMenuMusic();

        OpenMainMenu();
    }

    public void OpenBattleSelector()
    {
        _menuOptions.SetActive(false);
        UIManager.Instance.OpenBattleSelector();
        AudioManager.Instance.PlayClick();
    }

    public void OpenMainMenu()
    {
        _menuOptions.SetActive(true);
        _howToPlay.SetActive(false);
        AudioManager.Instance.PlayClick();
    }

    public void OpenHowToPlay()
    {
        _menuOptions.SetActive(false);
        _howToPlay.SetActive(true);
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
