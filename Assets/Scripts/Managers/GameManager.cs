using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } = null;

    private string _sceneToUnload = "MainMenu";
    public string SceneToUnload => _sceneToUnload;

    void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;

        SceneManager.LoadSceneAsync("Systems", LoadSceneMode.Additive);
    }

    public void SetSceneToUnload(string scene) => _sceneToUnload = scene;
}
