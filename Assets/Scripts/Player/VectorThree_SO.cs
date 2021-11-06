using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Vector3 SO", menuName ="Custom/Vector3")]
public class VectorThree_SO : ScriptableObject
{
    public Vector3 _vector3 = Vector3.zero;

    public void Set(Vector3 _pos)
    {
        _vector3 = _pos;
    }

    public void Set(float x, float y, float z)
    {
        _vector3.x = x;
        _vector3.y = y;
        _vector3.z = z;
    }

    public Vector3 Get()
    {
        return _vector3;
    }
}
