using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSplatGenerator : MonoBehaviour
{
    [SerializeField] SpreadColor paint;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        GenerateSplat(Color.green, new Vector3(2, 1) * 2);
    }

    // Update is called once per frame
    void Update()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void GenerateSplat (Color col, Vector3 collision)
    {
        Vector3 directionV = collision - transform.position;
        Quaternion dir = Quaternion.Euler(new Vector3(0, 0, Mathf.Round((Mathf.Atan2(directionV.y, directionV.x) * Mathf.Rad2Deg - 90) / 90) * 90));

        SpreadColor obj = Instantiate(paint, new Vector3(0.5f, 0.5f), dir, transform);

        obj.StartSplat(col);
    }
}
