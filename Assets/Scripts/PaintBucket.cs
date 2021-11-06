using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBucket : MonoBehaviour
{
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
        float deg = 0;
        while (true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(deg * Mathf.Deg2Rad));
            if (deg >= 360)
            {
                deg = 0;
            }
            else
            {
                deg++;
            } 
        }
    }
}
