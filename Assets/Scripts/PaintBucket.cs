using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBucket : MonoBehaviour
{
    [SerializeField] PaintAmount_SO paint;
    public int paintAmount;
    public float floatSpeed;
    public float floatAmount;
    Vector3 startPos;
    [SerializeField] Sounds_SO sounds;

    void Start()
    {
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(startPos.x, startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatAmount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            paint.ChangeAmount(paintAmount);
            sounds.PlayFromList(2);
            Destroy(gameObject);
        }
    }
}
