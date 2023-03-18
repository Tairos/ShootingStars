using UnityEditor;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void OnPlayClicked()
    {
        Debug.Log("PLAY");
    }

    public void OnQuitClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
    }
}
