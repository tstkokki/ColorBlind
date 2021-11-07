using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGoal : MonoBehaviour
{
    [SerializeField] GameEvent finalEvent;
    private void OnTriggerEnter(Collider other)
    {
        finalEvent.Raise();

    }
}
