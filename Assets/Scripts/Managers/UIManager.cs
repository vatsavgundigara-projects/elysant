using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI matchesText;
    [SerializeField] private TextMeshProUGUI turnsText;
    [SerializeField] private TextMeshProUGUI levelText;
     public  BasePanel levelCompletePanel ;
    public GameObject touchProtector;
    public void UpdateLevel(string count)
    {
        levelText.text = "Level : "+count;
    }
    public void UpdateMatches(int count)
    {
        matchesText.text = $" {count}";
    }

    public void UpdateTurns(int count)
    {
        turnsText.text = $" {count}";
    }

    
}