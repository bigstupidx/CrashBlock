using UnityEngine;
using System.Collections;

public class SimplePause : MonoBehaviour {

	// What I do :  This script pauses the game with the UI buttons while navigating into them.

    // how to use: Assign this script functions to pause and unpase the game.
    // for example The inventory button, set the pause function, and the cross to close the inventory, set it to unpause the game.
	
	// Delegate and Events
	public delegate void PauseEnemiesDelegate();
	public static event PauseEnemiesDelegate pauseEnemiesEvent; 

	private bool pauseBool = false;


	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
				
			if (!pauseBool) {
				PauseGame ();
			} else 
				{
				UnPauseGame ();
				}
			pauseBool = !pauseBool;


		}
	}



    public void PauseGame(){

        Time.timeScale = 0.0f;

    }

    
    public void UnPauseGame(){
        
        Time.timeScale = 1.0f;
        
    }


	public void PauseEnemies()		// pauses level enemies now, need to pause the daynight cycle and the night enemies as well.
	{

		pauseEnemiesEvent();

	}







}
