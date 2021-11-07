using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{

    [SerializeField] VectorThree_SO cameraPoint;
    

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, cameraPoint.Get(), 5 * Time.deltaTime); 
    }
}
