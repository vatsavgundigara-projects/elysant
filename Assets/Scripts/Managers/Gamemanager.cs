using UnityEngine;
using System.Collections;
using UnityEditorInternal;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Card firstCard, secondCard;
    private int matches, turns;
    [SerializeField] private LevelDatabase levelDatabase;    
    [SerializeField] private UIManager uiManager;
    [SerializeField] private CardManager cardManager;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);


    }

    private void Start()
    {
        LevelData levelData = levelDatabase.GetLevel(0);
        GenerateLevel(levelData.totalCards , levelData.rows , levelData.columns);
        uiManager.UpdateLevel(levelData.levelNo);
    }

    private void GenerateLevel(int totalCards, int rows, int columns)
    {
        cardManager.GenerateCards( totalCards , rows , columns);
    }

    public void SelectCard(Card card)
    {
        if (firstCard == null)
        {
            firstCard = card;
            card.Flip();
        }
        else if (secondCard == null && card != firstCard)
        {
            secondCard = card;
            card.Flip();
            turns++;
            uiManager.UpdateTurns(turns);
            StartCoroutine(CheckMatch());
        }
    }
    private IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(1f);

        if (firstCard.CheckMatch(secondCard))
        {
            matches++;
            uiManager.UpdateMatches(matches);
            // Optionally disable matched cards
            firstCard.gameObject.SetActive(false);
            secondCard.gameObject.SetActive(false);
        }
        else
        {
            firstCard.Flip();
            secondCard.Flip();
        }

        firstCard = null;
        secondCard = null;
    }
}
