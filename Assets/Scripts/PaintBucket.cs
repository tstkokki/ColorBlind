using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBucket : MonoBehaviour
{
    [SerializeField] PaintAmount_SO paint;
    public int paintAmount;
    public float floatSpeed;
    public float floatAmount;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.time * floatSpeed) * floatAmount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            paint.ChangeAmount(paintAmount);
            Destroy(gameObject);
        }
    }
}
