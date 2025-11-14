using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Card : MonoBehaviour, IFlippable, IMatchable
{
    public int CardId;
    public Sprite FrontSprite;
    public Sprite BackSprite;
    private Image _image;
    private bool _isFlipped;

    [Header("Flip Settings")]
    public float flipDuration = 0.5f;
    public Ease flipEase = Ease.InQuad;

    [HideInInspector]public  bool isAnimating = false;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.sprite = BackSprite;
    }
 
    public void Flip()
    {
        //_isFlipped = !_isFlipped;
        //_image.sprite = _isFlipped ? FrontSprite : BackSprite;

        if (isAnimating) return;
        isAnimating = true;

        
        float halfTime = flipDuration / 2f;

        // Step 1: Shrink in X-axis to 0 (hide current side)
        transform.DOScaleX(0f, halfTime)
            .SetEase(flipEase)
            .OnComplete(() =>
            {
                // Toggle faces
                _isFlipped = !_isFlipped;
                //if (GameManager.Instance.isTestModeOn) // uncomment this code for test purpose
                //    _image.sprite = FrontSprite;
                //else
                _image.sprite = _isFlipped ? FrontSprite : BackSprite;

                SoundManager.Instance.PlayOneShot("Click");
                // Step 2: Expand back to full size
                transform.DOScaleX(1f, halfTime)
                    .SetEase(flipEase)
                    .OnComplete(() =>
                    {
                        isAnimating = false;
                    });
            });
    
    }
   
    public bool CheckMatch(Card otherCard)
    {
        return CardId == otherCard.CardId;
    }

    public bool IsFlipped() => _isFlipped;

    private void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnShowAllCards += ShowCard;
            GameManager.Instance.OnHideAllCards += HideCard;
        }
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnShowAllCards -= ShowCard;
            GameManager.Instance.OnHideAllCards -= HideCard;
        }
    }
    public void ShowCard()
    {
        if (!_isFlipped)
            Flip();
    }

    public void HideCard()
    {
        if (_isFlipped)
            Flip();
    }
}
