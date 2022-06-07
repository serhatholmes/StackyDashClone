using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Dashes"){
            other.gameObject.tag = "Normal";
            PlayerCont.instance.TakeDashes(other.gameObject);
            other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.AddComponent<Stack>();
            Destroy(this);
            
        }
    }
}
