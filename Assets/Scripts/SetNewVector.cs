using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNewVector : MonoBehaviour
{
    [SerializeField] VectorThree_SO vec;
    // Start is called before the first frame update
    void Start()
    {
        vec.Set(transform.position);
    }
}
