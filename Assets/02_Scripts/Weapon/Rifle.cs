using System.Collections;
using _02_Scripts.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

namespace _02_Scripts.Weapon
{
    public class Rifle : MonoBehaviour
    {
        [SerializeField] private WeaponDataSO _weaponData;
        [SerializeField] private Transform _firePos;

        private int _ammo;

        public int Ammo
        {
            get
            {
                return _ammo;
            }
            set
            {
                _ammo = Mathf.Clamp(value, 0, _weaponData.AmmoCapacity);
            }
        }

        private bool _canFire = false;
        private bool _shootCoolTime = false;
        
        private void Start()
        {
            Ammo = _weaponData.AmmoCapacity;
        }

        private void Reload(int ammo)
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                Ammo += ammo;
                Debug.Log($"총알 {ammo}발 재장전");
            }
        }

        private void Update()
        {
            if (_canFire && !_shootCoolTime)
            {
                if (Ammo > 0)
                {
                    for (int i = 0; i < _weaponData.GetBulletCountSpawn(); i++) 
                        Shoot();
                    Ammo -= _weaponData.BulletCount;
                    Debug.Log($"{_weaponData.BulletCount}발 발사.");
                }
                else
                {
                    Debug.Log("재장전 필요, R키 누르세요");
                    _canFire = false;
                    return;
                }
                FinishShooting();
            }
            Reload(100);
        }

        private void FinishShooting()
        {
            StartCoroutine(CoolTimeCoroutine());
            if (!_weaponData.AutomaticFire)
                _canFire = false;
        }

        private void Shoot()
        {
            Instantiate(_weaponData.BulletData.BulletPrefab, _firePos.position, CalculateAngle());
        }

        private Quaternion CalculateAngle()
        {
            float spreadAngle = 0f;
            if (_weaponData.MultiBulletShoot) 
                spreadAngle = Random.Range(-_weaponData.SpreadAngle, _weaponData.SpreadAngle);
            
            Quaternion bulletSpreadAngle = Quaternion.Euler(new Vector3(0, 0, spreadAngle));
            
            return bulletSpreadAngle * transform.rotation;
        }
        
        private IEnumerator CoolTimeCoroutine()
        {
            _shootCoolTime = true;
            yield return new WaitForSeconds(_weaponData.CoolTime);
            _shootCoolTime = false;
        }

        public void TryShooting()
        {
            _canFire = true;
        }

        public void StopShooting()
        {
            _canFire = false;
        }
    }
}
