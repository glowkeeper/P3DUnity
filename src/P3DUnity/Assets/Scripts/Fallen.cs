using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallen : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameController gameController;

     void Start()
    {
        if (gameController == null) {
     
            Debug.Log("Fallen has no Game Controller");
        } 
    }

    private void OnTriggerEnter(Collider collider) {
        gameController.HasFallen();
    }
}
