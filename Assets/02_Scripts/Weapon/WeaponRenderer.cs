using System;
using UnityEngine;

public class WeaponRenderer : MonoBehaviour
{
    private SpriteRenderer _sR;

    private void Awake() => _sR = GetComponent<SpriteRenderer>();

    public void WeaponSprite(bool flipValue, bool orderValue)
    {
        transform.localEulerAngles = flipValue ? new Vector3(180f, 0, 0) : Vector3.zero;
        _sR.sortingOrder = orderValue ? 1 : 100;
    }
}
