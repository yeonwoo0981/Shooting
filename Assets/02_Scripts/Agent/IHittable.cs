using System;
using UnityEngine;
using UnityEngine.Events;

namespace _02_Scripts.Agent
{
    public interface IHittable
    {
        public UnityEvent OnGetHit { get; set; }
        
        public void GetDamage(int damage, GameObject dealer);
    }
}