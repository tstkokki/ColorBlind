using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Target(), 0.2f);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 20, 0.4f * Time.deltaTime);
    }

    Vector3 Target()
    {
        //Vector3.Lerp(transform.position, Target(), 0.2f);

        if (target.position.y < transform.position.y)
        {
            return Vector3.Lerp(transform.position, target.position + Vector3.back * 10 + Vector3.down, 10*Time.deltaTime);
        }
        else if (target.position.y > transform.position.y && target.position.y < transform.position.y + 2f)
        {
            return Vector3.Lerp(transform.position, target.position + Vector3.back * 10, 5f * Time.deltaTime);
        }

        else return Vector3.Lerp(transform.position, target.position + Vector3.back * 10, 5f*Time.deltaTime);
    }
}
