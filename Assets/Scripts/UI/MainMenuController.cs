using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] PlayableDirector _showMenuDirector;
    [SerializeField] PlayableDirector _hideMenuDirector;

    public void OnPlayClicked()
    {
        Hide();
    }

    public void OnQuitClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
    }

    public void Hide()
    {
        _showMenuDirector.Stop();
        _hideMenuDirector.time = 0;
        _hideMenuDirector.Play();
    }

    public void Show()
    {
        _hideMenuDirector.Stop();
        _showMenuDirector.time = 0;
        _showMenuDirector.Play();
    }
}
