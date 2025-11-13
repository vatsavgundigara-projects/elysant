using System.Collections.Generic;
using UnityEngine;

public class GridLayoutStrategy : ILayoutStrategy
{
    public void ArrangeLayout(List<GameObject> cards, int rows, int columns, RectTransform parent)
    {
        if (cards == null || cards.Count == 0)
        {
            Debug.LogWarning("No cards to arrange!");
            return;
        }

        float spacing = 20f;
        float cardSize = 125f;

        // Calculate total grid size
        float totalWidth = columns * cardSize + (columns - 1) * spacing;
        float totalHeight = rows * cardSize + (rows - 1) * spacing;

        Vector2 startPos = new Vector2(-totalWidth / 2 + cardSize / 2, totalHeight / 2 - cardSize / 2);

        int index = 0;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                if (index >= cards.Count) return;

                RectTransform rect = cards[index].GetComponent<RectTransform>();
                rect.SetParent(parent);
                rect.anchoredPosition = new Vector2(
                    startPos.x + c * (cardSize + spacing),
                    startPos.y - r * (cardSize + spacing)
                );
                rect.localScale = Vector3.one;
                index++;
            }
        }
    }
}
