using System.Collections.Generic;
using UnityEngine;

public class LayoutManager : MonoBehaviour
{
    private ILayoutStrategy layoutStrategy = new GridLayoutStrategy();

    [SerializeField] private RectTransform layoutParent;

    public void ArrangeCards(List<GameObject> cards, int rows, int columns)
    {
        if (layoutStrategy == null)
            layoutStrategy = new GridLayoutStrategy();

        layoutStrategy.ArrangeLayout(cards, rows, columns, layoutParent);
    }
}
