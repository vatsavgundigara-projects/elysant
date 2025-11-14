using DG.Tweening;
using UnityEngine;

public class StartScreenAnimation : MonoBehaviour
{
    public RectTransform title;
    public RectTransform playButton;
    public RectTransform logo;

    void Start()
    {
        Sequence seq = DOTween.Sequence();

        // Logo drop animation
        logo.localScale = Vector3.zero;
        seq.Append(logo.DOScale(1f, 0.6f).SetEase(Ease.OutBack));

        // Title fade + slide
        title.anchoredPosition += new Vector2(0, 80);
        title.GetComponent<CanvasGroup>().alpha = 0;
        seq.Append(title.DOAnchorPosY(title.anchoredPosition.y - 80, 0.5f).SetEase(Ease.OutQuad));
        seq.Join(title.GetComponent<CanvasGroup>().DOFade(1f, 0.5f));

        // Play Button pop
        playButton.localScale = Vector3.zero;
        seq.Append(playButton.DOScale(1f, 0.5f).SetEase(Ease.OutBack));

        // Looping idle animation for button
        seq.AppendCallback(() =>
        {
            playButton.DOScale(1.05f, 0.8f)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutQuad);
        });
    }
}
