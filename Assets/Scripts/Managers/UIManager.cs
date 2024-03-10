using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Variables

    public static UIManager Instance { get; private set; } = null;

    [SerializeField]
    private TextMeshProUGUI _resultTitle = null;
    [SerializeField]
    private GameObject[] _resultUis = null;

    [Space]

    [SerializeField]
    private GameObject[] _battleSelectorUis = null;

    private List<GameObject> _currentUis = new List<GameObject>();

    #endregion

    #region Unity Methods

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;
    }

    #endregion

    #region Result Methods

    public void OpenResult(bool isVictory)
    {
        _resultTitle.text = "VICTORY!";

        if (!isVictory)
        {
            _resultTitle.text = "DEFEAT!";
        }

        for (int i = 0; i < _resultUis.Length; i++)
        {
            GameObject ui = _resultUis[i];
            ui.SetActive(true);
            _currentUis.Add(ui);
        }
    }

    #endregion

    #region Battle Selection Methods

    public void OpenBattleSelector()
    {
        for (int i = 0; i < _battleSelectorUis.Length; i++)
        {
            GameObject ui = _battleSelectorUis[i];
            ui.SetActive(true);
            _currentUis.Add(ui);
        }
    }

    #endregion

    #region Other Methods

    public void CloseCurrentUIs()
    {
        if (_currentUis.Count == 0)
            return;

        for (int i = 0; i < _currentUis.Count; i++)
        {
            _currentUis[i].SetActive(false);
        }

        _currentUis.Clear();
    }

    #endregion
}
