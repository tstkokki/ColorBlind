using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAimShoot : MonoBehaviour
{
    [SerializeField] Transform arm;
    [SerializeField] Transform barrel;
    Vector3 aim;
    [SerializeField] GameObject projectile;
    public void Aim(InputAction.CallbackContext ctx)
    {
        float angle = Mathf.Atan2 (ctx.ReadValue<Vector2>().y, ctx.ReadValue<Vector2>().x)*Mathf.Rad2Deg;
        aim.z = angle;
        arm.rotation = Quaternion.Euler(aim);
    }

    public void Shoot(InputAction.CallbackContext ctx)
    {
        if(ctx.ReadValue<float>() > 0)
        {
            //Debug.Log( Vector3.RotateTowards(arm.transform.position, barrel.transform.position, 6.2f, 1));
            //Debug.Log( Quaternion.FromToRotation(arm.transform.position, barrel.transform.position));
            Instantiate(projectile, barrel.position, arm.rotation);
        }
    }
}
