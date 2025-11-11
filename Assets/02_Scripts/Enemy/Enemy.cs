using System;
using _02_Scripts.Agent;
using _02_Scripts.Data;
using UnityEngine;
using UnityEngine.Events;

namespace _02_Scripts
{
    public class Enemy : MonoBehaviour, IHittable
    {
        [SerializeField] private int health;
        public int Health
        {
            get => health;
            set => health = Mathf.Clamp(value, 0, EnemyData.MaxHealth);
        }
        
        [field: SerializeField] public EnemyDataSO EnemyData;
        
        [field:SerializeField] public UnityEvent OnGetHit { get; set; }
        
        private void OnEnable()
        {
            Health = EnemyData.MaxHealth;
        }

        public void GetDamage(int damage, GameObject dealer)
        {
            Health -= damage;
            OnGetHit?.Invoke();

            if (Health <= 0)
            {
                Destroy(gameObject);
                Application.Quit();
            }
        }
    }
}