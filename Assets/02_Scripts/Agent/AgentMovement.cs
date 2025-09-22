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
        if (dir.sqrMagnitude > 0)
        {
            _currentVelocity += MovementDataSO.acceleration * Time.deltaTime;
        }
        else
        {
            _currentVelocity -= MovementDataSO.deacceleration * Time.deltaTime;
        }

        return Mathf.Clamp(_currentVelocity, 0, MovementDataSO.maxSpeed);
    }
}
