using System;
using _02_Scripts.Agent;
using _02_Scripts.Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
   public InputReader _agentInput;
   public AgentMovement _agentMovement { get; private set; }

   public UnityEvent<Vector2> OnPointerChanged;
   
   private void Awake()
   {
      _agentMovement = GetComponent<AgentMovement>();
   }

   private void Update()
   {
      OnPointerChanged?.Invoke(_agentInput.MousePos);
      _agentMovement.SetMove(_agentInput.Movement);
   }
}
