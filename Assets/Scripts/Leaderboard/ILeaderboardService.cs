using System;
using System.Collections.Generic;

public interface ILeaderboardService
{
    void Save(LeaderboardData data);
    List<LeaderboardData> Get();
}

[Serializable]
public struct LeaderboardData {
    public string Name;
    public float Seconds;
}