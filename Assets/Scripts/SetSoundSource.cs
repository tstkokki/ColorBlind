using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSoundSource : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] Sounds_SO _sounds;
    // Start is called before the first frame update
    void Awake()
    {
        _sounds.SetSource(source);
    }

}
