using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField] GameObject _gameplayStage;
    [SerializeField] GameConfig _gameConfig;
    [SerializeField] GameplayTargetsController _gameplayTargetsController;

    public bool IsPlaying => _playing;
    bool _playing = false;


    void Awake()
    {
        Hide();
    }

    public void Play()
    {
        _gameplayStage.SetActive(true);
        _gameplayTargetsController.Instantiate(_gameConfig);
        _playing = true;
    }

    public void Pause()
    {
        _playing = false;
    }

    public void Hide()
    {
        _gameplayStage.SetActive(false);
        _playing = false;
    }
}
