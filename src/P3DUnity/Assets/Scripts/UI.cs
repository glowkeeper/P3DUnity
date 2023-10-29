using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text timeUI;
    [SerializeField] private TMP_Text livesUI;
    [SerializeField] private TMP_Text placesUI;

    [SerializeField] private string timePreText = "Time: ";
    [SerializeField] private string livesPreText = "Lives: ";
    [SerializeField] private string placesPreText = "Places: ";
    [SerializeField] private string successText = "Success!: ";
    [SerializeField] private string failText = "Fail - Better Luck Next Time!";

    private float gameTime = 0;
    private const string timePostText = " secs";
    private bool isFinished = false;
    
    void Start()
    {
        if (timeUI && livesUI && placesUI) 
        {
            timeUI.text = timePreText + gameTime.ToString();

        } else {

            if (timeUI == null) {
            
                Debug.Log("UI has no time UI"); 
            } 

            if ( livesUI == null )
            {
                Debug.Log("UI has no lives UI"); 
            } 

            if (placesUI == null) {
            
                Debug.Log("UI has no places UI"); 
            } 
        }       
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFinished) {

            gameTime += Time.deltaTime;
            timeUI.text = timePreText + gameTime.ToString("f2") + timePostText;
        }        
    }

    public void UpdateLives(int numLives) {

        livesUI.text = livesPreText + numLives.ToString();
    }

    public void UpdatePlaces(int numPlaces) {

        placesUI.text = placesPreText + numPlaces.ToString();
    }

    public void HasFinished(bool success) 
    {
        isFinished = true;
        if ( success ) {

            gameTime += Time.deltaTime;
            timeUI.text = successText + gameTime.ToString("f2") + timePostText;
        } else {
            timeUI.text = failText;
        }

    }
}
