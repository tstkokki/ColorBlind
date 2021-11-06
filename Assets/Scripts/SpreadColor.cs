using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadColor : MonoBehaviour
{
    public SpriteRenderer rend;
    private MaterialPropertyBlock block;
    private Texture2D replacement;
    private float transition = 0;

    public void StartSplat(Color col, Texture2D tex, Sprite sprite, float dir)
    {
        block = new MaterialPropertyBlock();
        rend = GetComponent<SpriteRenderer>();
        replacement = new Texture2D(16, 16);
        replacement.SetPixels(tex.GetPixels((int)sprite.rect.x, (int)sprite.rect.y, (int)sprite.rect.width, (int)sprite.rect.height));
        replacement.Apply();
        replacement.filterMode = FilterMode.Point;
        transition = 0.0001f;
        block.SetColor("PaintColor", col);
        block.SetTexture("Tile", replacement);
        block.SetFloat("Rotation", dir);
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
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
