using UnityEngine;
using UnityEngine.Video;

public class VideoController : EntryPoint
{
    [SerializeField] private VideoPlayer videoPlayer;
    
    void Start()
    {
        if (videoPlayer == null) {
     
            Debug.Log("VideoController has no Game Video Player");
        }

        if (gameController == null) {
     
            Debug.Log("VideoController has no Game Controller");
        } 

        if (place == EntryPoints.Place.NONE) {
     
            Debug.Log("VideoController has no Entry Point");
        } 
    }

    private void OnTriggerEnter(Collider collider) {

        //Debug.LogWarning("VIDEOCONTROLLER: in trigger enter");
        if (collider.gameObject.tag == tag) {  
            //Debug.LogWarning("VIDEOCONTROLLER: in trigger player enter"); 
            videoPlayer.Play();
            gameController.HasEntered(place);
        }
    }

    private void OnTriggerExit(Collider collider) {

        //Debug.LogWarning("VIDEOCONTROLLER: in trigger exit");
        if (collider.gameObject.tag == tag) {    
            //Debug.LogWarning("VIDEOCONTROLLER: in trigger player exit");        
            videoPlayer.Stop();
        }
    }
}
