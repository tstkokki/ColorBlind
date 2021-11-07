using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sounds Player", menuName = "Custom/Sounds Player")]
public class Sounds_SO : ScriptableObject
{
    public List<AudioClip> sounds = new List<AudioClip>();
    public AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;
    }


    /// <summary>
    /// Plays the supplied audio clip
    /// <para>Optional: volume scale</para>
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="volumeScale"></param>
    public void PlayOneShot(AudioClip clip, float volumeScale = 1)
    {
        if (source != null)
        {
            source.PlayOneShot(clip, volumeScale);

        }
    }

    /// <summary>
    /// Play a sound from the Sounds list
    /// </summary>
    /// <param name="i"></param>
    /// <param name="volumeScale"></param>
    public void PlayFromList(int i, float volumeScale = 1)
    {
        if(source != null && i >=0 && i < sounds.Count)
        {
            source.PlayOneShot(sounds[i], volumeScale);
        }
    }
}
