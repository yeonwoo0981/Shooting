using System;
using UnityEngine;

public class Mission2 : MonoBehaviour
{
   private void Update()
   {
      if (Input.GetKey(KeyCode.LeftArrow))
      {
         transform.Rotate(0, -5, 0, Space.Self);
      }
      else if (Input.GetKey(KeyCode.RightArrow))
      {
         transform.Rotate(0, 5, 0, Space.Self);
      }
   }
}
