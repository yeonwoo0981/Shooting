using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
   public InputReader _agentInput;
   public AgentMovement _agentMovement { get; private set; }
   
   [field:SerializeField] public UnityEvent<Vector2> OnPointerChanged { get; private set; }
   
   private void Awake()
   {
      _agentMovement = GetComponent<AgentMovement>();
   }

   private void Update()
   {
      _agentMovement.SetMove(_agentInput.Movement);
   }
   
   public void GetPointInput() // 마우스 위치 읽기 메서드
   {
      Vector2 mousePos = Camera.main.ScreenToWorldPoint(_agentInput.MousePos);
      Debug.Log(mousePos);
      OnPointerChanged?.Invoke(mousePos);
      // 이걸 기반으로 총기 시스템 제작
   } 
}
