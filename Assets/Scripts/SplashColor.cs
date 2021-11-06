using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashColor : MonoBehaviour
{
    private ParticleSystem particle;
    [SerializeField] PaintAmount_SO pa;
    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();

        var main = particle.main;

        main.startColor = pa._color;
    }
}
