using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadColor : MonoBehaviour
{
    private MaterialPropertyBlock block;
    private float transition = 0;
    // Start is called before the first frame update
    void Start()
    {
        block = new MaterialPropertyBlock();

        StartCoroutine("Fade");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fade(Color color)
    {
        block.SetFloat("Threshold", transition);
        transition += Time.deltaTime;
        yield return null;
    }
}
