using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SoundLibrary", menuName = "GameAssets/Sound Library", order = 1)]
public class SoundLibrary : ScriptableObject
{
    [System.Serializable]
    public class SoundItem
    {
        public string soundName;
        public AudioClip clip;
    }

    [Header("All Sound Clips")]
    public List<SoundItem> soundItems = new List<SoundItem>();

    /// <summary>
    /// Get sound clip by name (safe lookup)
    /// </summary>
    public AudioClip GetClipByName(string name)
    {
        SoundItem item = soundItems.Find(s => s.soundName == name);
        return item != null ? item.clip : null;
    }
}
