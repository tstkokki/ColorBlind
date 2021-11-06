using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    GameObject player;
    public GameObject weapon;
    public GameObject projectile;
    public GameObject projectileSpawn;

    bool shootOnCD = false;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        weapon.transform.right = player.transform.position - transform.position;


        if (Vector2.Distance(player.transform.position, transform.position) < 5 && !shootOnCD)
        {
            GameObject bullet = Instantiate(projectile, projectileSpawn.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = weapon.transform.right * 3f;
            shootOnCD = true;
            StartCoroutine(ShootCD());
        }



    }

    IEnumerator Aim()
    {


        yield return null;
    }

    IEnumerator ShootCD()
    {
        yield return new WaitForSeconds(5f);
        shootOnCD = false;
    }

}