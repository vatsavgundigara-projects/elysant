using UnityEngine;

public class UIAutoLayout : MonoBehaviour
{
    public RectTransform target;          // The UI you want to move
    public RectTransform portraitSource;  // Values copied when in portrait
    public RectTransform landscapeSource; // Values copied when in landscape

    private bool lastPortrait;

    void Start()
    {
        lastPortrait = Screen.height >= Screen.width;
        ApplyLayout(lastPortrait);
    }

    void Update()
    {
        bool isPortrait = Screen.height >= Screen.width;

        if (isPortrait != lastPortrait)
        {
            lastPortrait = isPortrait;
            ApplyLayout(isPortrait);
        }
    }

    void ApplyLayout(bool isPortrait)
    {
        RectTransform source = isPortrait ? portraitSource : landscapeSource;

        if (source == null || target == null)
            return;

        // Copy all transform values
        target.anchorMin = source.anchorMin;
        target.anchorMax = source.anchorMax;
        target.pivot = source.pivot;
        target.anchoredPosition = source.anchoredPosition;
        target.sizeDelta = source.sizeDelta;
        target.localScale = source.localScale;
        target.localRotation = source.localRotation;
    }
}
