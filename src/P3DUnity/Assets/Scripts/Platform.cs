using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EntryPoints;

public class Platform : EntryPoint
{
    void Start()
    {
        if (gameController == null) {
     
            Debug.Log("Platform has no Game Controller");
        } 

        if (place == EntryPoints.Place.NONE) {
     
            Debug.Log("Platform has no Entry Point");
        } 
    }

    private void OnTriggerEnter(Collider collider)
    {
        // Debug.Log("in trigger enter", collider);
        if(collider.gameObject.tag == tag) {
            // Debug.Log("in platform tag trigger enter", collider);
            gameController.HasEntered(place);
            collider.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        // Debug.Log("in trigger exit", collider);
        if(collider.gameObject.tag == tag) {
            // Debug.Log("in tag trigger exit", collider);
            collider.transform.SetParent(null);
        }
    }
}
