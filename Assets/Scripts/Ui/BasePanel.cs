using UnityEngine;
using DG.Tweening;

public abstract class BasePanel : MonoBehaviour
{
    [Header("Base Panel Settings")]
    [SerializeField] protected float animationDuration = 0.5f;
    [SerializeField] protected Ease openEase = Ease.OutBack;
    [SerializeField] protected Ease closeEase = Ease.InBack;

    protected bool isOpen = false;

    protected virtual void Awake()
    {
        transform.localScale = Vector3.zero;
        gameObject.SetActive(false);
    }

    public virtual void OpenPanel()
    {
        gameObject.SetActive(true);
        transform.DOScale(1, animationDuration).SetEase(openEase);
        isOpen = true;
    }

    public virtual void ClosePanel()
    {
        transform.DOScale(0, animationDuration)
            .SetEase(closeEase)
            .OnComplete(() => gameObject.SetActive(false));
        isOpen = false;
    }
}
