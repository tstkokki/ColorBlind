using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentToBlock : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            if (other.transform != transform.parent.parent)
            {
                transform.parent.parent = other.transform;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            if (other.transform == transform.parent.parent)
            {
                transform.parent.parent = null;
            }
        }
    }
}
