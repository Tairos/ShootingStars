using UnityEngine;

public class GameFlowController : MonoBehaviour
{
    [SerializeField] MainMenuController _mainMenuController;
    [SerializeField] GameplayController _gamePlayController;

    void Awake()
    {
        _mainMenuController.OnPlayClicked += MainMenu_OnPlayClicked;
        _gamePlayController.OnLeaderboardFormSubmitted += GoToMainMenu;
    }

    void MainMenu_OnPlayClicked()
    {
        _gamePlayController.Play();
    }

    void GoToMainMenu()
    {
        _mainMenuController.Show();
    }

    void OnDestroy()
    {
        _mainMenuController.OnPlayClicked -= MainMenu_OnPlayClicked;
        _gamePlayController.OnLeaderboardFormSubmitted -= GoToMainMenu;
    }
}
