using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class AgentInput : MonoBehaviour
{
    public Vector2 _moveDir { get; private set; }
    private AgentRenderer _renderer;
    private Vector2 mousePos;
    [field:SerializeField] public UnityEvent<Vector2> OnPointerChanged { get; private set; } // 벡터2 값 저장하는 이벤트

    private void Awake()
    {
        _renderer = GetComponentInChildren<AgentRenderer>();
    }

    public void OnMove(InputValue value)
    {
        _moveDir = value.Get<Vector2>(); // 플레이어 이동은 만들 수 있도록 하자.
    }

    private void Update()
    {
        GetPointInput();
        _renderer.FaceDirection(mousePos);
    }

    public void GetPointInput() // 마우스 위치 읽기 메서드
    {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        OnPointerChanged?.Invoke(mousePos);
        // 이걸 기반으로 총기 시스템 제작
    } 
    
}
