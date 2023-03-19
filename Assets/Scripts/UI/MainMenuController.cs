using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] PlayableDirector _showMenuDirector;
    [SerializeField] PlayableDirector _hideMenuDirector;

    public event Action OnPlayClicked;

    public void PlayClicked()
    {
        Hide();
        OnPlayClicked.Invoke();
    }

    public void QuitClicked()
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
