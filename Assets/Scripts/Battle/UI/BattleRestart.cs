using UnityEngine.SceneManagement;
using UnityEngine;

public class BattleRestart : MonoBehaviour
{
    public void RestartBattle()
    {
        UIManager.Instance.CloseCurrentUIs();

        SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(GameManager.Instance.SceneToUnload);
    }
}
