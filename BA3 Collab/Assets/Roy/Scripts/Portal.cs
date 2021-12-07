using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform target;
    public float portalRadious=.2f;
   
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            /*
            float distance = Vector3.Distance(other.transform.position , this.transform.position);
            if (distance > portalRadious) 
            {
                other.transform.position = target.position;
                other.transform.rotation = target.rotation;
            }*/
            //other.transform.position =new Vector3( target.position.x,target.position.y,target.position.z);
            other.transform.position = target.position;
            other.transform.rotation = target.rotation;
        }
        Debug.Log("Something entered "+other.tag);
    }
}
