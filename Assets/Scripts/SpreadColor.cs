using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadColor : MonoBehaviour
{
    public SpriteRenderer rend;
    private MaterialPropertyBlock block;
    private float transition = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartSplat(Color col)
    {
        block = new MaterialPropertyBlock();
        rend = GetComponent<SpriteRenderer>();
        transition = 0.0001f;
        StartCoroutine(Fade(col));
    }

    IEnumerator Fade(Color color)
    {
        block.SetColor("PaintColor", color);
        while (transition < 1.5)
        {
            block.SetFloat("Threshold", transition);
            rend.SetPropertyBlock(block);
            transition = Mathf.Pow(transition, 1f / 4f);
            if (transition > 0.9995f)
            {
                transition = 1.5f;
                block.SetFloat("Threshold", transition);
                rend.SetPropertyBlock(block);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
