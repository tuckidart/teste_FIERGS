using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class ClearPlayerPrefs
{
    [MenuItem("FIERGS/Saves/Clear Player Prefs")]
    public static void Clear()
    {
        PlayerPrefs.DeleteAll();
    }
}
