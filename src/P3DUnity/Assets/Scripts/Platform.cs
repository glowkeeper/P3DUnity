using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private string tag = "Player";
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("in trigger enter", collider);
        if(collider.gameObject.tag == tag) {
            Debug.Log("in tag trigger enter", collider);
            collider.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        Debug.Log("in trigger exit", collider);
        if(collider.gameObject.tag == tag) {
            Debug.Log("in tag trigger exit", collider);
            collider.transform.SetParent(null);
        }
    }
}
