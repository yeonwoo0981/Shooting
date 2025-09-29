using System;
using UnityEngine;

public class WeaponRenderer : MonoBehaviour
{
    public void FlipSprite(bool value)
    {
        if (value)
        {
            transform.localEulerAngles = new Vector3(180f, 0, 0);
        }
        else
        {
            transform.localEulerAngles = Vector3.zero;
        }
    }
}
