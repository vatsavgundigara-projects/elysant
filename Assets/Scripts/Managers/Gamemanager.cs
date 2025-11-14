using UnityEngine;
using System.Collections;
using System;
using System.Linq;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    //public bool isTestModeOn = false;  uncomment this code for test purpose
    private Card firstCard, secondCard;
    private int matches, turns;
    private int currentLevel;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private CardManager cardManager;

    public LevelDatabase levelDatabase;    
    // Global event for showing all cards
    public event Action OnShowAllCards;

    // Global event for hiding all cards
    public event Action OnHideAllCards;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        StartCoroutine("ShowCardOnStart");
    }
    private IEnumerator ShowCardOnStart()
    {
        yield return new WaitForSeconds(0.5f);
        FlipAllShow();

        yield return new WaitForSeconds(2f);
        FlipAllHide();

        yield return new WaitForSeconds(0.5f);
        uiManager.touchProtector.SetActive(false);
    }

    private void Start()
    {
        // Load last saved level or default to level 0
        currentLevel = PlayerPrefsHandler.GetCurrentLevel();
        LevelData levelData = levelDatabase.GetLevel(currentLevel);
        GenerateLevel(levelData.totalCards , levelData.rows , levelData.columns);
        uiManager.UpdateLevel(levelData.levelNo);
    }


    public void FlipAllShow()
    {
        OnShowAllCards?.Invoke();
    }

    public void FlipAllHide()
    {
        OnHideAllCards?.Invoke();
    }

    private void GenerateLevel(int totalCards, int rows, int columns)
    {
        cardManager.GenerateCards( totalCards , rows , columns);
    }

    public void SelectCard(Card card)
    {
        if (card.isAnimating) return;

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

            int activeCards = GetActiveChildCount(cardManager.gridParent);
            Debug.Log("Active child count: " + activeCards);
            if (activeCards < 1) {

                Invoke("OnLevelCompleted", 1f);
            }
        }
        else
        {
            firstCard.Flip();
            secondCard.Flip();
        }

        firstCard = null;
        secondCard = null;
    }

    int GetActiveChildCount(Transform parent)
    {
        int count = 0;
        foreach (Transform child in parent)
        {
            if (child.gameObject.activeInHierarchy)
                count++;
        }
        return count;
    }
    public void OnLevelCompleted()
    {
        // Increase and save current level
        if(currentLevel < levelDatabase.levels.Count-1)
            currentLevel++;

        PlayerPrefsHandler.SetCurrentLevel(currentLevel);
        Debug.Log($"Level {currentLevel} completed, saving progress...");
        uiManager.levelCompletePanel.OpenPanel();
    }

}
