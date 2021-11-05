using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    GameObject player;
    public GameObject weapon;

    public float turnRate = 2f * Mathf.PI;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        weapon.transform.right = player.transform.position - transform.position;

        //Debug.Log(Vector3.Dot(weapon.transform.forward, player.transform.forward));

        //if(Vector3.Dot(weapon.transform.forward, player.transform.forward) >= 0.9f)
        //{

        //}

   

    }

    IEnumerator Aim()
    {


        yield return null;
    }


}
