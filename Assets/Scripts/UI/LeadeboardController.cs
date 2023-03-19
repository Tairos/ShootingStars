using System.Collections.Generic;
using UnityEngine;

public class LeadeboardController : MonoBehaviour
{
    [SerializeField] ScriptableObjectLeaderboardService _leaderboardService;
    [SerializeField] Transform _content;
    [SerializeField] LeaderboardEntry _leaderboardEntry;

    void OnEnable()
    {
        foreach (var entry in _content)
        {
            Destroy((entry as Transform).gameObject);
        }
        Load(_leaderboardService.Get());
    }

    void Load(List<LeaderboardData> data)
    {
        var dataCount = data.Count;
        for (var i = 0; i < dataCount; i++)
        {
            var row = GeEntry();
            row.SetValues(i+1, data[i].Name, data[i].Seconds);
        }
    }

    LeaderboardEntry GeEntry()
    {
        return Instantiate(_leaderboardEntry, _content);
    }
}
