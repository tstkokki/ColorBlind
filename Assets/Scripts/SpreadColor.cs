using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadColor : MonoBehaviour
{
    private SpriteRenderer rend;
    private MaterialPropertyBlock block;
    private float transition = 0;
    // Start is called before the first frame update
    void Start()
    {
        block = new MaterialPropertyBlock();
        rend = GetComponent<SpriteRenderer>();
        transition = 0;
        StartCoroutine("Fade", Color.yellow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fade(Color color)
    {
        while (true)
        {
            block.SetColor("PaintColor", color);
            transition = Time.deltaTime;
            while (transition < 1)
            {
                block.SetFloat("Threshold", transition);
                rend.SetPropertyBlock(block);
                transition = Mathf.Sqrt(transition);
                if (transition > 0.99999f)
                {
                    transition = 1;
                }
                else
                {
                    yield return new WaitForSeconds(Time.deltaTime * 20);
                }
            }
            Debug.Log("agane" + transition);
            yield return new WaitForSeconds(1);
        }
        
    }
}
