using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBucket : MonoBehaviour
{
    private float deg = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Float());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Float()
    {
        while (true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(deg * Mathf.Deg2Rad) * 0.00075f);
            if (deg >= 360)
            {
                deg = 0;
            }
            else
            {
                deg += 0.5f;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
