using System;
using System.Collections;
using _02_Scripts.Data;
using UnityEngine;

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

        public void Reload(int ammo)
        {
            Ammo += ammo;
        }

        private void Update()
        {
            if (_canFire && !_shootCoolTime)
            {
                if (Ammo > 0)
                {
                    Ammo--;
                    Shoot();
                }
                else
                {
                    _canFire = false;
                    return;
                }
                FinishShooting();
            }
        }

        private void FinishShooting()
        {
            StartCoroutine(CoolTimeCoroutine());
            if (!_weaponData.AutomaticFire)
                _canFire = false;
        }

        private void Shoot()
        {
            Instantiate(_weaponData.BulletData.BulletPrefab, _firePos.position, transform.rotation);
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
