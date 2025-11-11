using System;
using TMPro;
using UnityEngine;

namespace _02_Scripts
{
    public class EnemyHealthText : MonoBehaviour
    {
        private TextMeshPro  _text;
        private Enemy _enemy;

        private void Awake()
        {
            _text = GetComponent<TextMeshPro>();
            _enemy = GetComponentInParent<Enemy>();
        }

        private void Start()
        {
           UpdateHealthText();
        }
        
        public void UpdateHealthText()
        {
            _text.text = $"{_enemy.Health}";
        }
    }
}