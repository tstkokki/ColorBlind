
using UnityEngine;

[CreateAssetMenu(fileName = "New Paint Amount", menuName = "Custom/Paint Amount")]
public class PaintAmount_SO : ScriptableObject
{
    public int Amount;
    public int maxAmount;
    public Color _color;
    /// <summary>
    /// Change amount of paint by current amount + _amount, clamped between 0 and max amount
    /// </summary>
    /// <param name="_amount"></param>
    public void ChangeAmount(int _amount)
    {
        Amount = Mathf.Clamp(Amount + _amount, 0, maxAmount);
    }

    public int GetAmount
    {
        get => Amount;
    }

    private void OnEnable()
    {
        Amount = 0;
    }
    private void OnDisable()
    {
        Amount = 0;
    }
}
