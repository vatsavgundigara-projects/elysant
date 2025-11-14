using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    public Transform gridParent;
    public  SpriteLibrary spriteLibrary;
    [SerializeField] private List<Sprite> cardImages;

    private List<GameObject> cards = new List<GameObject>();
    [SerializeField] private LayoutManager layoutManager;

    private void Awake()
    {
        for (int i = 0; i < spriteLibrary.spriteItems.Count; i++)
        {
            cardImages.Add(spriteLibrary.GetSpriteByName((i+1).ToString()));
        }
    }
    void Start()
    {
        
    }

    public void GenerateCards(int totalCards, int rows, int columns)
    {
        List<int> cardIds = new List<int>();
        for (int i = 0; i < (totalCards/2); i++)
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
            cards.Add(card.gameObject);
        }

        layoutManager.ArrangeCards(cards, rows, columns);
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