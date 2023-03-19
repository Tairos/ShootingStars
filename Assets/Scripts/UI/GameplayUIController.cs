using UnityEngine;

public class GameplayUIController : MonoBehaviour
{
    [SerializeField] CountdownAnimation _countdownAnimation;

    public void Show()
    {
        _countdownAnimation.StartCountdown();
    }
}
