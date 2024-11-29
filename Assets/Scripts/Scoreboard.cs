using UnityEngine;
using TMPro;
public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreboardText;
    int score = 0;

    public void IncreaseScore(int ammount)
    {
        score += ammount;
        scoreboardText.text = score.ToString();
    }
}
