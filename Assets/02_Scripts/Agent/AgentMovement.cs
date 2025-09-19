using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]

public class AgentMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _currentVelocity;
    [field:SerializeField] public MovementDataSO MovementDataSO { get; private set; }

    private Vector2 _moveDir;
    
    public UnityEvent<float> OnVelocityChanged;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetMove(Vector2 moveDir)
    {
        _moveDir = moveDir;
        // 가속, 감속 계산 및 방향 세팅
       _currentVelocity = CalculateSpeed(_moveDir);
       OnVelocityChanged?.Invoke(_currentVelocity);
    }
    
    public void Move()
    {
        _rb.linearVelocity = _moveDir * _currentVelocity;
    }
    
    private void FixedUpdate()
    {
        Move();
    }
    
    private float CalculateSpeed(Vector2 dir)
    {
        if (dir.sqrMagnitude > 0) // 위치 값이 0보다 크면
        {
            _currentVelocity += MovementDataSO.acceleration * Time.deltaTime;
            // but 최대값의 초과값으로는 상승 X
        }
        else // 위치가 값이 0보다 작으면
        {
            _currentVelocity -= MovementDataSO.deacceleration * Time.deltaTime;
            // but 최소값의 미만값으로는 하락 X
        }

        return Mathf.Clamp(_currentVelocity, 0, MovementDataSO.maxSpeed);
        // 을 여기서 해준다
    }
}
