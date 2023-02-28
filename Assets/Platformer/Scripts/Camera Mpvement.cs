using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMpvement : MonoBehaviour
{

    public Transform target;

    public Vector3 offset;

    private void Update()
    {
        transform.position = target.position + offset;
    }
    /*   private float scroll;
       void Update()
       {
           scroll = Input.GetAxis("Horizontal");
           if (scroll != 0)
           {
               movement();
           }
   
       }
   
       private void movement()
       {
           transform.position += transform.right * scroll * Time.deltaTime;
       }*/
}
