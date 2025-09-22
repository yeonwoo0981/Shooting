using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    private float _desireAngle;
    
    // 무기는 마우스 방향으로 회전함.
    public void AimWeapon(Vector2 pointerPos)
    {
        Vector2 dir = pointerPos - (Vector2)transform.position;
        _desireAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, _desireAngle);
    }
}
