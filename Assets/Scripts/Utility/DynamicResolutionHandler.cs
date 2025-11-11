using UnityEngine;

[RequireComponent(typeof(Camera))]
public class DynamicResolutionHandler : MonoBehaviour
{
    public RectTransform targetRect; // assign your white panel or root container
    public float referenceAspect = 1080f / 1920f; // 9:16 reference (portrait)
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        UpdateResolution();
    }

    void Update()
    {
        // Optional: handle runtime orientation changes
        if (Screen.width != lastWidth || Screen.height != lastHeight)
        {
            UpdateResolution();
        }
    }

    private int lastWidth, lastHeight;

    void UpdateResolution()
    {
        lastWidth = Screen.width;
        lastHeight = Screen.height;

        float screenAspect = (float)Screen.width / Screen.height;

        // Adjust camera size based on aspect ratio difference
        if (screenAspect >= referenceAspect)
        {
            // Wider than reference (landscape)
            cam.orthographicSize = 5f; // base size
        }
        else
        {
            // Taller than reference (portrait)
            float scaleFactor = referenceAspect / screenAspect;
            cam.orthographicSize = 5f * scaleFactor;
        }

        // Ensure targetRect remains centered
        if (targetRect != null)
        {
            targetRect.anchorMin = new Vector2(0.5f, 0.5f);
            targetRect.anchorMax = new Vector2(0.5f, 0.5f);
            targetRect.pivot = new Vector2(0.5f, 0.5f);
            targetRect.anchoredPosition = Vector2.zero;
        }
    }
}
