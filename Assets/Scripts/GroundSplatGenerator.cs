using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundSplatGenerator : MonoBehaviour
{
    [SerializeField] SpreadColor paint;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    //void Start()
    //{
    //    GenerateSplat(Color.green, new Vector3(2, 1) * 2);
    //}

    // Update is called once per frame
    void Update()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void GenerateSplat (Vector3 collision)
    {
        Vector3 directionV = collision - transform.position;
        Quaternion dir = Quaternion.Euler(new Vector3(0, 0, Mathf.Round((Mathf.Atan2(directionV.y, directionV.x) * Mathf.Rad2Deg - 90) / 90) * 90));

        SpreadColor obj = Instantiate(paint, transform.position, dir, transform);

        obj.StartSplat(sr.color, sr.sprite.texture, sr.sprite, transform.rotation.eulerAngles.z - dir.eulerAngles.z);
    }
}
