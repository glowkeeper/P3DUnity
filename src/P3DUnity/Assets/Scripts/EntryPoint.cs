using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EntryPoints;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] protected string tag = "Player";
    [SerializeField] protected GameController gameController;
    [SerializeField] protected EntryPoints.Place place;

    void Start()
    {
        if (gameController == null) {
     
            Debug.Log("Entry Point has no Game Controller");
        } 

        if (place == EntryPoints.Place.NONE) {
     
            Debug.Log("Entry Point has no Place");
        } 
    }

    private void OnTriggerEnter(Collider collider)
    {
        // Debug.Log("in trigger enter point", collider);
        if(collider.gameObject.tag == tag) {
            // Debug.Log("in entry point tag trigger enter", collider);
            gameController.HasEntered(place);
        }
    }
}
