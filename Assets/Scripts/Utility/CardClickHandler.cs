using UnityEngine;
using UnityEngine.EventSystems;

public class CardClickHandler : MonoBehaviour, IPointerClickHandler
{
    private Card _card;

    private void Awake()
    {
        _card = GetComponent<Card>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.SelectCard(_card);
    }
}
