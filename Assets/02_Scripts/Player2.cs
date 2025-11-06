using System;
using _02_Scripts.Agent;
using _02_Scripts.Data;
using UnityEngine;
using UnityEngine.Events;

namespace _02_Scripts
{
    public class Player2 : MonoBehaviour
    {
        public InputReader2 InputReader2;
        
        public AgentMovement AgentMovement { get; private set; }

        public UnityEvent<Vector2> OnPointerChanged;

        public Action OnAttack;
        public Action OnAttackStop;

        private void Awake()
        {
            AgentMovement = GetComponent<AgentMovement>();
        }

        private void Start()
        {
            InputReader2.OnMousePressed += () => OnAttack?.Invoke();
            InputReader2.OnMouseReleased += () => OnAttackStop?.Invoke();
        }

        private void Update()
        {
            OnPointerChanged?.Invoke(InputReader2.MousePos);
            AgentMovement.SetMove(InputReader2.Movement);
        }
    }
}