using System;
using System.Threading.Tasks;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField] GameObject _gameplayStage;
    [SerializeField] GameConfig _gameConfig;
    [SerializeField] GameplayTargetsController _gameplayTargetsController;
    [SerializeField] GameplayUIController _gameplayUIController;
    [SerializeField] Transform _targetsParent;
    [SerializeField] Transform _bulletsParent;

    public bool IsPlaying => _playing;
    bool _playing = false;
    float _gameTime;

    public event Action OnLeaderboardFormSubmitted;

    void Awake()
    {
        Hide();
        _gameplayUIController.OnLeaderboardFormSubmitted += LeadeboardSubmitted;
    }

    void Update()
    {
        _gameTime += Time.deltaTime;
        if (IsPlaying && _targetsParent.childCount == 0)
        {
            Hide();
            _gameplayUIController.GameFinished(_gameTime);
            foreach (var bulletTransform in _bulletsParent)
            {
                Destroy((bulletTransform as Transform).gameObject);
            }
        }
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
        _gameTime = 0;
    }

    void LeadeboardSubmitted()
    {
        OnLeaderboardFormSubmitted.Invoke();
    }

    void OnDestroy()
    {
        _gameplayUIController.OnLeaderboardFormSubmitted -= LeadeboardSubmitted;
    }
}
