using System;
using _02_Scripts.Data;
using UnityEngine;

namespace _02_Scripts.Weapon
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D _rb;
        [SerializeField] private float speed = 15.57f;
        private Enemy _enemy;
        
        private void Awake()
        {
            _enemy = GameObject.Find("Enemy1").GetComponent<Enemy>();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.linearVelocity = transform.right * speed;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                _enemy.GetDamage(1, this.gameObject);
        }
    }
}