using TMPro;
using UnityEngine;

public class LeaderboardEntry : MonoBehaviour
{
    [SerializeField] TMP_Text _position;
    [SerializeField] TMP_Text _name;
    [SerializeField] TMP_Text _seconds;

    public void SetValues(int position, string name, int seconds)
    {
        _position.text = position.ToString();
        _name.text = name;
        _seconds.text = $"{seconds / 60:00}:{seconds % 60:00}";
    }
}
