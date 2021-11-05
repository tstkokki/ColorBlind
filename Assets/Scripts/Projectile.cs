using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float force = 100;
    // Start is called before the first frame update
    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right*force, ForceMode.Impulse);

        Destroy(gameObject, 5f);
    }

}
