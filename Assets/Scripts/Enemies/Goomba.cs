using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    public float speed;
    public Rigidbody goombaRB;
    // Start is called before the first frame update
    void Start()
    {
        goombaRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        goombaRB.velocity = new Vector2(speed, goombaRB.velocity.y);
    }
}
