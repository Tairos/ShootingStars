using System.Threading.Tasks;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField] GameObject _gameplayStage;
    [SerializeField] GameConfig _gameConfig;
    [SerializeField] GameplayTargetsController _gameplayTargetsController;
    [SerializeField] GameplayUIController _gameplayUIController;  

    public bool IsPlaying => _playing;
    bool _playing = false;


    void Awake()
    {
        Hide();
    }

    public void Play()
    {
        _gameplayUIController.Show();
        _gameplayStage.SetActive(true);
        _gameplayTargetsController.Instantiate(_gameConfig);
        StartPlaying();
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

    async void StartPlaying()
    {
        await Task.Delay(1000 * _gameConfig.Countdown);
        _playing = true;
    }
}
