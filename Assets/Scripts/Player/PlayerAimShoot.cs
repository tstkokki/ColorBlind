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
    [SerializeField] Sounds_SO _sounds;

    //false = mouse, true = controller
    bool IsMouseOrController = false;

    Mouse _mouse;

    private void Start()
    {
        _mouse = Mouse.current;
    }
    private void LateUpdate()
    {
        //when mouse is active
        if (!IsMouseOrController)
        {
            Vector3 pos = cam.ScreenToWorldPoint(_mouse.position.ReadValue());
            CalculateAngle(pos.x- transform.position.x, pos.y- transform.position.y);
        }
    }

    public void ToggleMouse(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && IsMouseOrController)
        {
            IsMouseOrController = false;
            _mouse = Mouse.current;
        }
    }
    public void ToggleController(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && !IsMouseOrController)
        {
            IsMouseOrController = true;
        }
    }

    public void Aim(InputAction.CallbackContext ctx)
    {
        CalculateAngle(ctx.ReadValue<Vector2>().x, ctx.ReadValue<Vector2>().y);
    }

    private void CalculateAngle(float x, float y)
    {
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
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
                _sounds.PlayFromList(4);
            }
            else
                _sounds.PlayFromList(3);
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
