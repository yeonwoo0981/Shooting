using System;
using _02_Scripts.Data;
using UnityEngine;

namespace _02_Scripts.Weapon
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D _rb;
        [SerializeField] private float _speed = 15.57f;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.linearVelocity = transform.right * _speed;
        }
    }
}