using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class AgentAnimation : MonoBehaviour
{
    public Animator Animator {get; private set;}
    private readonly int walkHash = Animator.StringToHash("Walk");

    private void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
        if(Animator == null)
            Debug.LogError("No Animator attached to AgentAnimation");
    }

    public void SetWalkAnimation(bool value)
    {
        Animator.SetBool(walkHash, value);
    }


    public void AnimatePlayer(float velocity)
    {
        SetWalkAnimation(velocity > 0);
    }
}
