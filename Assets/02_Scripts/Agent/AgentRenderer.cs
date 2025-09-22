using UnityEngine;
using UnityEngine.InputSystem;

public class AgentRenderer : MonoBehaviour
{
    public void FaceDirection(Vector2 pointerPos)
    {
        if (transform.position.x < pointerPos.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (transform.position.x > pointerPos.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
