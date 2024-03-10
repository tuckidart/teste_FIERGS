using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        UIManager.Instance.CloseCurrentUIs();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
