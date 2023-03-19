using System;
using UnityEngine;

public class GameplayUIController : MonoBehaviour
{
    [SerializeField] CountdownAnimation _countdownAnimation;
    [SerializeField] LeaderboardFormController _leaderboardForm;

    public event Action OnLeaderboardFormSubmitted;

    void Awake()
    {
        _leaderboardForm.OnSubmit += LeadeboardSubmitted;
    }

    public void Show()
    {
        _countdownAnimation.StartCountdown();
    }

    public void GameFinished(float score)
    {
        _leaderboardForm.Show(score);
    }

    void LeadeboardSubmitted()
    {
        OnLeaderboardFormSubmitted.Invoke();
    }

    void OnDestroy()
    {
        _leaderboardForm.OnSubmit -= LeadeboardSubmitted;
    }
}
