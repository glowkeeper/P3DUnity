
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using EntryPoints;

public class GameController : MonoBehaviour
{
    [SerializeField] private string tag = "Player";
    [SerializeField] private SpawnController spawnController;
    [SerializeField] private UI ui;  

    [SerializeField] private int maxFalls = 3;
    [SerializeField] private int maxPlaces = 5;

      
    private GameObject player;

    private Vector3 startPosition;

    private int numFalls = 0;
    private int numPlaces = 0;

    private bool doSpawn = true;

    private EntryPoints.Place[] places;

    void Start()
    {      
        player = GameObject.FindWithTag(tag);
        if (player != null) {

            if ( spawnController != null)
            {
                if ( ui != null)
                {
                    startPosition = player.transform.position; 
                    places = new EntryPoints.Place[maxPlaces];
                    ui.UpdateLives(maxFalls);
                    ui.UpdatePlaces(maxPlaces);
                    
                } else {
                     Debug.Log("No UI");
                }
            } else {
                Debug.Log("No spawn controller");
            }
            // Debug.Log("player start position " + startPosition.ToString());
        } else {
            Debug.Log("No player tagged");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( doSpawn ) 
        {       
            if ( spawnController.CanSpawn )     
            {
                doSpawn = spawnController.Spawn();    
                // Debug.Log("Spawned? " + doSpawn.ToString());
            } else {
                Debug.Log("Can't Spawn");
            }
        }    
    }

    public void HasFallen() 
    {
        numFalls++;        
        if ( numFalls < maxFalls )
        {
            // Debug.Log("fall " + numFalls.ToString());
            ui.UpdateLives(maxFalls - numFalls);
            player.transform.position = startPosition;

        } else {

            // Debug.Log("Quitting as no lives left!");
            ui.UpdateLives(0);
            ui.HasFinished(false);

            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }

    public void HasEntered(EntryPoints.Place place)
    {
        // Debug.Log("Game Controller Entry place " + place.ToString());
        if (!places.Contains(place)) 
        {
            // Debug.Log("New Entry place " + place.ToString());

            places[numPlaces] = place;

            numPlaces++;           
            if(numPlaces == maxPlaces) {
                
                // Debug.Log("Game complete!");
                ui.UpdatePlaces(0);
                ui.HasFinished(true);

            } else {

                ui.UpdatePlaces(maxPlaces - numPlaces); 
            }
        }
    }
}
