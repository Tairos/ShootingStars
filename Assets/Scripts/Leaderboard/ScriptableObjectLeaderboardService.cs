using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Leaderboard", menuName = "My Assets/ScriptableObjectLeaderboardService")]
public class ScriptableObjectLeaderboardService : ScriptableObject, ILeaderboardService
{
    [SerializeField] List<LeaderboardData> _leaderboard = new List<LeaderboardData>();

    public List<LeaderboardData> Get()
    {
        return _leaderboard;
    }

    public void Save(LeaderboardData leaderboardData)
    {
        _leaderboard.Add(leaderboardData);
        _leaderboard.Sort((a,b) => a.Seconds.CompareTo(b.Seconds));
    }
}
