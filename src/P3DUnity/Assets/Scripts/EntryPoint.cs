using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EntryPoints;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private string tag = "Player";

    [SerializeField] private GameController gameController;
    [SerializeField] private EntryPoints.Point point;

    void Start()
    {
        if (gameController == null) {
     
            Debug.Log("Entry Point has no Game Controller");
        } 

        if (point == EntryPoints.Point.NONE) {
     
            Debug.Log("No Entry Point", gameObject);
        } 
    }

    private void OnTriggerEnter(Collider collider)
    {
        // Debug.Log("in trigger enter point", collider);
        if(collider.gameObject.tag == tag) {
            // Debug.Log("in entry point tag trigger enter", collider);
            gameController.HasEntered(point);
        }
    }
}
