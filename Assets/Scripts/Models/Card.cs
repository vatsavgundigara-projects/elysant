using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour, IFlippable, IMatchable
{
    public int CardId;
    public Sprite FrontSprite;
    public Sprite BackSprite;
    private Image _image;
    private bool _isFlipped;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.sprite = BackSprite;
    }

    public void Flip()
    {
        _isFlipped = !_isFlipped;
        _image.sprite = _isFlipped ? FrontSprite : BackSprite;
    }
    private void OnMouseDown()
    {
        //Flip();
    }
    public bool CheckMatch(Card otherCard)
    {
        return CardId == otherCard.CardId;
    }

    public bool IsFlipped() => _isFlipped;
}
