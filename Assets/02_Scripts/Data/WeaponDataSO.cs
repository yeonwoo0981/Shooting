using UnityEngine;

namespace _02_Scripts.Data
{
    [CreateAssetMenu(fileName = "WeaponDataSO", menuName = "SO/WeaponDataSO")]
    public class WeaponDataSO : ScriptableObject
    {
        [field:SerializeField] public BulletDataSO BulletData { get; private set; }
        
        [field:SerializeField] [field: Range(0, 100)] public int AmmoCapacity { get; set; } = 100; // 탄창용량 (탄용)
        [field:SerializeField] [field: Range(0.1f, 3f)] public float CoolTime { get; set; } = 0.3f; // 발사 쿨 (발쿨)
        [field:SerializeField] public bool AutomaticFire { get; set; } // 자발 (자동 발사)
        [field:SerializeField] public bool MultiBulletShoot { get; set; } // 여발 (여러발 발사)
        [field: SerializeField] [field: Range(0, 10)] public int BulletCount { get; private set; } = 0; // 여러 발을 쏠 때, 한번에 발사되는 총알 개수 
        [field:SerializeField] [field: Range(0f, 10f)] public float SpreadAngle { get; set; } = 5f; // 퍼지는 정도 (퍼정)
        // 추가: field는 쓰면 다른 거에도 field를 붙여야 함
        
        public int GetBulletCountSpawn()
        {
            if (MultiBulletShoot)
                return BulletCount;
            return 1;
        } 
    }
}