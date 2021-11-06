using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Paint Collection", menuName = "Custom/Paint Collection")]
public class PaintCollection : ScriptableObject
{
    public List<PaintAmount_SO> paints = new List<PaintAmount_SO>();
    public int currentIndex;
    /// <summary>
    /// Get the amount of paint of color by index
    /// <para>0 = White, 1 = Red, 2 = Green, 3 = Blue</para>
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public int Get(int i)
    {
        if (i < paints.Count && i >= 0)
        {
            return paints[i].GetAmount;
        }
        return 0;
    }

    public void SetIndex(int i)
    {
        if (i < paints.Count && i >= 0)
        {
            currentIndex = i;
        }

    }

    /// <summary>
    /// Increment paint amount
    ///<para>index i: 0 = White, 1 = Red, 2 = Green, 3 = Blue</para>
    /// </summary>
    /// <param name="i"></param>
    /// <param name="_amount"></param>
    public void Increment(int i, int _amount = -1)
    {
        if (i < paints.Count && i >= 0)
        {
            paints[i].ChangeAmount(_amount);
        }
    }

    public int White
    {
        get => Get(0);
        set => paints[0].Amount = value;
    }
    public int Red
    {
        get => Get(1);
        set => paints[1].Amount = value;
    }
    public int Green
    {
        get => Get(2);
        set => paints[2].Amount = value;
    }
    public int Blue
    {
        get => Get(3);
        set => paints[3].Amount = value;
    }
}
