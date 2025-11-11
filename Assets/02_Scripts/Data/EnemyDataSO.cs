using UnityEngine;

namespace _02_Scripts.Data
{
    [CreateAssetMenu(fileName = "EnemyDataSO", menuName = "SO/EnemyDataSO")]
    public class EnemyDataSO : ScriptableObject
    {
        [field:SerializeField] public float AttackRange { get; set; }
        [field:SerializeField] public float ChaseRange { get; set; }
        
        [field:SerializeField] public int MaxHealth { get; set; }
        [field:SerializeField] public int Damage { get; set; }
        [field:SerializeField] public float AtkCoolTime { get; set; }
    }
}
