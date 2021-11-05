using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAimShoot : MonoBehaviour
{
    [SerializeField] Transform arm;
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
        Instantiate(projectile, arm.position + arm.forward, arm.rotation);
    }
}
