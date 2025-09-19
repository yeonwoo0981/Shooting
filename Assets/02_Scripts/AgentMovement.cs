using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]

public class AgentMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _currentVelocity;

    private Vector2 _moveDir;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetMove(Vector2 moveDir)
    {
        _moveDir = moveDir;
        // 가속, 감속 계산 및 방향 세팅
        CalculateSpeed(_moveDir);
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
        if (dir != Vector2.zero)
        {
            _currentVelocity++;
        }
        else if (dir == Vector2.zero)
        {
            _currentVelocity--;
        }

        return dir.magnitude;
    }
}
