using System;
using UnityEngine;

public class Mission2 : MonoBehaviour
{
   [SerializeField] private float rotationSpeed = 100;
   
   private void Update()
   {
      if (Input.GetKey(KeyCode.LeftArrow))
      {
         transform.Rotate(0, 0, rotationSpeed);
      }
      
      if (Input.GetKey(KeyCode.RightArrow))
      {
         transform.Rotate(0, 0, -rotationSpeed);
      }
   }
}
