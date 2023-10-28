using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] private string tag = "Player";

    [SerializeField] private string animatorParam = "IsMoving";

    [SerializeField] private Animator platform;

    void Start()
    {
        if (platform == null) {
     
            Debug.Log("PlatformMover has no Animator");
        } 
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        // Debug.Log("in mover trigger enter", collider);
        if(collider.gameObject.tag == tag) {
            // Debug.Log("in tag mover trigger enter", collider);
            platform.SetBool(animatorParam, true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        // Debug.Log("in mover trigger exit", collider);
        if(collider.gameObject.tag == tag) {
            // Debug.Log("in tag mover trigger exit", collider);  
            platform.SetBool(animatorParam, false);
        }
    }
}
