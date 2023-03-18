using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class LeadeboardController : MonoBehaviour
{
    [SerializeField] ScriptableObjectLeaderboardService _leaderboardService;
    [SerializeField] Transform _content;
    [SerializeField] LeaderboardEntry _leaderboardEntry;

    void OnEnable()
    {
        Load(_leaderboardService.Get());
    }

    void Load(List<LeaderboardData> data)
    {
        var dataCount = data.Count;
        for (var i = 0; i < dataCount; i++)
        {
            var row = GeEntry(i);
            row.SetValues(i, data[i].Name, data[i].Seconds);
        }
    }

    LeaderboardEntry GeEntry(int i)
    {
        if (_content.childCount < i)
        {
            return _content.GetChild(i).GetComponent<LeaderboardEntry>();
        }

        return Instantiate(_leaderboardEntry, _content);
    }
}
