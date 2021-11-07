using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    // reference to next level prefab
    [SerializeField] GameObject nextLevel;
    [SerializeField] GameEvent movePlayer;
    [SerializeField] GameEvent levelTransition;
    //reference to next safe point
    [SerializeField] ParticleSystem bigSmoke;
    Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collider.enabled = false;
            nextLevel.SetActive(true);

            Instantiate(bigSmoke, transform.position, bigSmoke.transform.rotation);
            //movePlayer.Raise();
            levelTransition.Raise();
        }
    }
}
