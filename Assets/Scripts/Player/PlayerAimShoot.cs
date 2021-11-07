using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAimShoot : MonoBehaviour
{
    [SerializeField] Transform arm;
    [SerializeField] Transform barrel;
    [SerializeField] Camera cam;
    Vector3 aim;
    int cost = 10;
    [SerializeField] PaintCollection paints;
    [SerializeField] GameObject projectile;
    [SerializeField] ColorData_SO myColor;
    [SerializeField] SpriteRenderer renderer;
    public AudioClip shootSound;
    public AudioClip noAmmoSound;

    public void Aim(InputAction.CallbackContext ctx)
    {
        float angle = Mathf.Atan2(ctx.ReadValue<Vector2>().y, ctx.ReadValue<Vector2>().x) * Mathf.Rad2Deg;
        aim.z = angle;
        arm.rotation = Quaternion.Euler(aim);
    }

    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (paints.Get((int)myColor.colorData.currentSpec) > 0)
            {
                Instantiate(projectile, barrel.position, arm.rotation);
                paints.Increment((int)myColor.colorData.currentSpec, -cost);
                GetComponent<AudioSource>().PlayOneShot(shootSound);
            }
            else
                GetComponent<AudioSource>().PlayOneShot(noAmmoSound);
        }
    }

    public void ChangeColor(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() != 0)
        {

            myColor.colorData.ChangeColor((int)myColor.colorData.currentSpec + ((ctx.ReadValue<float>() > 0) ? 1 : -1));
            renderer.color = myColor.colorData.GetColor(myColor.colorData.currentSpec);
            paints.SetIndex((int)myColor.colorData.currentSpec);
        }
    }


}
