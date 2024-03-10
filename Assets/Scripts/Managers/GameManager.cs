using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } = null;

    public string SceneToUnload = "MainMenu";

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
}
