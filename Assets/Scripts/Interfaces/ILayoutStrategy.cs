using System.Collections.Generic;
using UnityEngine;

public interface ILayoutStrategy
{
    void ArrangeLayout(List<GameObject> cards, int rows, int columns, RectTransform parent);
}
