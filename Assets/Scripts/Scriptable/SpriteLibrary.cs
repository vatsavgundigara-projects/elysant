using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SpriteLibrary", menuName = "GameAssets/Sprite Library", order = 2)]
public class SpriteLibrary : ScriptableObject
{
    [System.Serializable]
    public class SpriteItem
    {
        public string spriteName;
        public Sprite sprite;
    }

    [Header("All Sprites")]
    public List<SpriteItem> spriteItems = new List<SpriteItem>();

    /// <summary>
    /// Get sprite by name (safe lookup)
    /// </summary>
    public Sprite GetSpriteByName(string name)
    {
        SpriteItem item = spriteItems.Find(s => s.spriteName == name);
        return item != null ? item.sprite : null;
    }

    /// <summary>
    /// Get a random sprite (for random card generation)
    /// </summary>
    public Sprite GetRandomSprite()
    {
        if (spriteItems.Count == 0) return null;
        return spriteItems[Random.Range(0, spriteItems.Count)].sprite;
    }
}
