using UnityEngine;

public class Mission4 : MonoBehaviour
{
    [SerializeField] private Transform center;
    [SerializeField] private float orbitRadius = 1.5f;
    [SerializeField] private float rotationSpeed = 180f;

    private float currentAngle = 0f;

    private void Update()
    {
        if (center == null) return;

        currentAngle += rotationSpeed * Time.deltaTime;

        float rad = currentAngle * Mathf.Deg2Rad;

        Vector2 offset = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * orbitRadius;
        transform.position = (Vector2)center.position + offset;

        Vector2 direction = center.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
    }
}
