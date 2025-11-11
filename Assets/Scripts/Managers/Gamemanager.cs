using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Card firstCard, secondCard;
    private int matches, turns;

    [SerializeField] private UIManager uiManager;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
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

        }
    }

}
