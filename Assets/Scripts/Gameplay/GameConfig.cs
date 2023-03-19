using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "ShootingStars/GameConfig")]

public class GameConfig : ScriptableObject
{
    public int CubesAmountMin;
    public int CubesAmountMax;

    public float TargetScaleMin;
    public float TargetScaleMax;

    public int Duration;

    public Color[] Colors;


#if UNITY_EDITOR
    void OnValidate()
    {
        ValidateRange(CubesAmountMin, CubesAmountMax, "CubesAmount");
        ValidateRange(TargetScaleMin, TargetScaleMax, "TargetScale");
        if (Colors.Length == 0)
        {
            throw new System.Exception("There are no colors configured at GameConfig");
        }
    }
    void ValidateRange(int min, int max, string name)
    {
        if (max < min)
        {
            throw new System.Exception($"GameConfig {name} range is wrongly configured at GameConfig");
        }
    }

    void ValidateRange(float min, float max, string name)
    {
        if (max < min)
        {
            throw new System.Exception($"GameConfig {name} range is wrongly configured at GameConfig");
        }
    }
#endif
}
