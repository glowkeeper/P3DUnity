using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkHole : EntryPoint
{
    // Start is called before the first frame update

     void Start()
    {
        if (gameController == null) {
     
            Debug.Log("Sink Hole has no Game Controller");
        } 
    }

    private void OnTriggerEnter(Collider collider) {

        if(collider.gameObject.tag == tag) {
            gameController.HasFallen();
        }
    }
}
