using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinningArea : MonoBehaviour
{
    public string nameOfLevelToLoad = "";

    public GameObject player;

    public enum gameStates { Playing, Death, GameOver, BeatLevel };
    public gameStates gameState = gameStates.Playing;

    private bool endEntered = false;

    public GameObject mainCanvas;
    public GameObject beatLevelCanvas;

    // Start is called before the first frame update
    void Start()
    {
        beatLevelCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if (endEntered)
       {
                    
           // hide the player so game doesn't continue playing
           player.SetActive(false);
           // switch which GUI is showing			
           mainCanvas.SetActive(false);
           beatLevelCanvas.SetActive(true);
       }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Horiz") { 
        endEntered = true;
            // SceneManager.LoadScene(nameOfLevelToLoad);
        }
        Debug.Log("entered");
        
    }

}
