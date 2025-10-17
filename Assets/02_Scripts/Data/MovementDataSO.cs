using UnityEngine;

namespace _02_Scripts.Data
{
    [CreateAssetMenu(fileName = "MovementDataSO", menuName = "SO/MovementDataSO")]
    public class MovementDataSO : ScriptableObject
    {
        [Range(0, 30)] 
        public float maxSpeed = 15f;
    
        [Range(0.1f, 100)]
        public float acceleration = 50, deacceleration = 50;
    }
}
