using UnityEngine;

namespace _02_Scripts.Data
{
    [CreateAssetMenu(fileName = "BulletDataSO", menuName = "SO/BulletDataSO")]
    public class BulletDataSO : ScriptableObject
    {
        [field:SerializeField] public GameObject BulletPrefab { get; set; }
        [field: SerializeField] public float Damage { get; set; }
    }
}