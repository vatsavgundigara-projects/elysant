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

        float spacing = 10f;
        float cardSize = 100f;

        // Calculate total grid size
        float totalWidth = columns * cardSize + (columns - 1) * spacing;
        float totalHeight = rows * cardSize + (rows - 1) * spacing;

        Vector2 startPos = new Vector2(-totalWidth / 2 + cardSize / 2, totalHeight / 2 - cardSize / 2);

        
    }
}
