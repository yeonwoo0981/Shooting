using System;
using UnityEngine;

public class Player : MonoBehaviour
{
   public AgentInput _agentInput { get; private set; }
   public AgentMovement _agentMovement { get; private set; }

   private void Awake()
   {
      _agentInput = GetComponent<AgentInput>();
      _agentMovement = GetComponent<AgentMovement>();
   }

   private void Update()
   {
      _agentMovement.SetMove(_agentInput._moveDir);
   }
}
