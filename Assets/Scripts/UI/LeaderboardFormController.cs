using System;
using TMPro;
using UnityEngine;

public class LeaderboardFormController : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreText;
    [SerializeField] TMP_InputField _inputField;
    [SerializeField] ScriptableObjectLeaderboardService _leaderboarService;

    TouchScreenKeyboard keyboard;
    float _time;

    public event Action OnSubmit;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Show(float time)
    {
        _time = time;
        gameObject.SetActive(true);
        _scoreText.text = $"{_time / 60:00}:{_time % 60:00}";
    }

    public void Submit()
    {
        gameObject.SetActive(false);

        var entry = new LeaderboardData {
            Name = _inputField.text,
            Seconds = _time
        };

        _leaderboarService.Save(entry);
        OnSubmit?.Invoke();
    }

    public void ShowKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open("Real User", TouchScreenKeyboardType.Default);
    }
}
