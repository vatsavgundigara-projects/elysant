using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform gridParent;
    [SerializeField] private List<Sprite> cardImages;

    private List<Card> cards = new List<Card>();

    void Start()
    {
        GenerateCards();
    }

    private void GenerateCards()
    {
        List<int> cardIds = new List<int>();
        for (int i = 0; i < cardImages.Count; i++)
        {
            cardIds.Add(i);
            cardIds.Add(i);
        }
        Shuffle(cardIds);

        for (int i = 0; i < cardIds.Count; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, gridParent);
            Card card = newCard.GetComponent<Card>();
            card.CardId = cardIds[i];
            card.FrontSprite = cardImages[cardIds[i]];
            cards.Add(card);
        }
    }
    private void Shuffle(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(0, list.Count);
            (list[i], list[randomIndex]) = (list[randomIndex], list[i]);
        }
    }
}