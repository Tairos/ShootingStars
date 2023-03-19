using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField] GameObject _gameplayStage;
    [SerializeField] GameConfig _gameConfig;
    [SerializeField] GameplayTargetsController _gameplayTargetsController;

    void Awake()
    {
        Hide();
    }

    public void Play()
    {
        _gameplayStage.SetActive(true);
        _gameplayTargetsController.Instantiate(_gameConfig);
    }

    public void Pause()
    {

    }

    public void Hide()
    {
        _gameplayStage.SetActive(false);
    }
}
