
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using EntryPoints;

public class GameController : MonoBehaviour
{

    [SerializeField] private SpawnController spawnController;
    [SerializeField] private UI ui;    
    [SerializeField] private GameObject player;

    [SerializeField] private int maxFalls = 3;
    [SerializeField] private int maxPoints = 5;

    private Vector3 startPosition;

    private int numFalls = 0;
    private int numPoints = 0;

    private bool doSpawn = true;

    private EntryPoints.Point[] points;

    void Start()
    {
        // foreach(EntryPoints.Point point in System.Enum.GetValues(typeof(EntryPoints.Point))) {
        //     Debug.Log("Found point" + point.ToString());
        // }
        if (player != null) {

            if ( spawnController != null)
            {
                if ( ui != null)
                {
                    startPosition = player.transform.position; 
                    points = new EntryPoints.Point[maxPoints];
                    ui.UpdateLives(maxFalls);
                    ui.UpdatePlaces(maxPoints);
                } else {
                     Debug.Log("No UI");
                }
            } else {
                Debug.Log("No spawn controller");
            }
            // Debug.Log("player start position " + startPosition.ToString());
        } else {
            Debug.Log("No player found");
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
            Debug.Log("fall " + numFalls.ToString());
            ui.UpdateLives(maxFalls - numFalls);
            player.transform.position = startPosition;
        } else {
            Debug.Log("Quitting!");
            ui.UpdateLives(0);
            ui.HasFinished(false);
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }

    public void HasEntered(EntryPoints.Point point)
    {
        // Debug.Log("Game Controller Entry point " + point.ToString());
        if (!points.Contains(point)) 
        {
            Debug.Log("New Entry point " + point.ToString());
            points[numPoints] = point;
            numPoints++;
            ui.UpdatePlaces(maxPoints - numPoints);
            if(numPoints == maxPoints) {
                ui.UpdatePlaces(0);
                ui.HasFinished(true);
                Debug.Log("Game complete!");
            }
        }
    }
}
