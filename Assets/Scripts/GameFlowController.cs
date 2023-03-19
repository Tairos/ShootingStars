using UnityEngine;

public class GameFlowController : MonoBehaviour
{
    [SerializeField] MainMenuController _mainMenuController;
    [SerializeField] GameplayController _gamePlayController;

    void Awake()
    {
        _mainMenuController.OnPlayClicked += MainMenu_OnPlayClicked;
    }

    void MainMenu_OnPlayClicked()
    {
        _gamePlayController.Play();
    }
}
