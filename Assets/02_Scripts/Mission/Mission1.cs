using UnityEngine;

namespace _02_Scripts.Mission
{
    public class Mission1 : MonoBehaviour
    {
        private void Update()
        {
            transform.Rotate(new Vector3(0f, 5f, 0f));
        }
    }
}
