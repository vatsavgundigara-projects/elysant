using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI matchesText;
    [SerializeField] private TextMeshProUGUI turnsText;



    public void UpdateMatches(int count)
    {
        matchesText.text = $"Matches: {count}";
    }

    public void UpdateTurns(int count)
    {
        turnsText.text = $"Turns: {count}";
    }
}