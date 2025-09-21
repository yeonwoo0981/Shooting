using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class AgentInput : MonoBehaviour
{
    public Vector2 _moveDir { get; private set; }
    [field:SerializeField] public UnityEvent<Vector2> OnPointerChanged { get; private set; } // 벡터2 값 저장하는 이벤트
    
    public void OnMove(InputValue value)
    {
        _moveDir = value.Get<Vector2>(); // 플레이어 이동은 만들 수 있도록 하자.
    }

    private void Update()
    {
        GetPointInput();
    }

    public void GetPointInput() // 마우스 위치 읽기 메서드
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()); // 현재 마우스의 위치를 월드 좌표에서 읽는다.
        OnPointerChanged?.Invoke(mousePos); // 바뀌면 현재 마우스 위치 이벤트 호출
        
        // 이걸 기반으로 총기 시스템 제작
    } 
    
}
