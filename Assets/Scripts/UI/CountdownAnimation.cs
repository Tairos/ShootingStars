﻿using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;
using System;

public class CountdownAnimation : MonoBehaviour
{
    [SerializeField] PlayableDirector _countdown;
    [SerializeField] TMP_Text _countdownText;
    [SerializeField] GameConfig _gameConfig;

    int _count;

    public event Action CountdownFinished;

    public async void StartCountdown()
    {
        gameObject.SetActive(true);
        _count = _gameConfig.Countdown;
        await CountdownStep();
        if (gameObject != null)
        {
            gameObject.SetActive(false);
        }
    }

    async Task CountdownStep()
    {
        _countdown.time = 0;
        _countdown.Play();
        _countdownText.text = _count.ToString();
        await Task.Delay(1000);
        _count--;
        if (_count > 0)
        {
            await CountdownStep();
        }
    }
}