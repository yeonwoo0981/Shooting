using System;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    private float _desireAngle;
    private WeaponRenderer _weaponRenderer;

    private void Awake()
    {
        _weaponRenderer = GetComponentInChildren<WeaponRenderer>();
    }

    // 무기는 마우스 방향으로 회전함.
    public void AimWeapon(Vector2 pointerPos)
    {
        Vector2 dir = pointerPos - (Vector2)transform.position;
        _desireAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        AdjustRendering();
        transform.rotation = Quaternion.Euler(0, 0, _desireAngle);
    }

    private void AdjustRendering()
    {
        _weaponRenderer.WeaponSprite(_desireAngle > 90 || _desireAngle < -90, _desireAngle > 90 && _desireAngle < 270);
    }
}
