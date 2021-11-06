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
    [SerializeField] ColorData_SO myColor;
    [SerializeField] SpriteRenderer renderer;
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

    public void ChangeColor(InputAction.CallbackContext ctx)
    {
        if(ctx.ReadValue<float>() != 0)
        myColor.colorData.ChangeColor((int)myColor.colorData.currentSpec + ((ctx.ReadValue<float>() > 0) ? 1 : -1));
        renderer.color = myColor.colorData.GetColor(myColor.colorData.currentSpec);
    }

    //private void Update()
    //{
    //    Mouse mouse = Mouse.current;
    //    if(mouse.)
    //}
}
