using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using EasyEditor;
using Heyzap;

public class PauseManager : MonoBehaviour {

	// this scripts manages the pause menu and animations.

	// menu options are: Restart LEvel,  Go TO level select,  Resume

	// Need to promote here our other games later....

	public GameObject pauseCanvasObj;
	public GameObject deathCanvasObj;
	public GameObject ammoCanvasObj;
	public GameObject gameplayCanvas;

	public Animator anim;

	public FPSPlayer fpsPlayer_ref;

	public DataComps dataComps_ref;

	[Header("Level Select scene name")]
	public string levelSelectSceneName = "LevelSelect";

	[Header("Next Level Name")]
	public string nextSceneName;


	// ------------------- Activate and Deactivate the Pause Canvas

	// <-Called by DataComps

	public void ActivatePauseCanvas () 
	{

		pauseCanvasObj.SetActive (true);
		print ("Activate PauseMenu");
		// activate the animator trigger...

		for (int i = 0; i < dataComps_ref.uiImages.Length; i++)   // Hide UI Gameplay
		{
			dataComps_ref.uiImages [i].gameObject.SetActive (false);

		}


	}

	public void DeactivatePauseCanvas ()
	{
		pauseCanvasObj.SetActive (false);
		print ("Deactivate PauseMenu");

		for (int i = 0; i < dataComps_ref.uiImages.Length; i++)   // Display UI Gameplay
		{
			dataComps_ref.uiImages [i].gameObject.SetActive (true);

		}

	}


	// ------------------- Activate and Deactivate the Death Canvas

	// <-Called by DataComps
	public void ActivateDeathCanvas () 
	{

		deathCanvasObj.SetActive (true);
		// activate the animator trigger...
		Time.timeScale = 0;
		for (int i = 0; i < dataComps_ref.uiImages.Length; i++)   // Hide UI Gameplay
		{
			dataComps_ref.uiImages [i].gameObject.SetActive(false);

		}


	}

	public void DeactivateDeathCanvas ()
	{
		deathCanvasObj.SetActive (false);
		Time.timeScale = 1;
		for (int i = 0; i < dataComps_ref.uiImages.Length; i++)   // Display UI Gameplay
		{
			dataComps_ref.uiImages [i].gameObject.SetActive (true);

		}

	}

	// ------------------- Activate and Deactivate the Ammo Canvas

	// <-Called by DataComps
	public void ActivateAmmoCanvas () 
	{

		ammoCanvasObj.SetActive (true);
		// activate the animator trigger...
		//Time.timeScale = 1;
		//for (int i = 0; i < dataComps_ref.uiImages.Length; i++)   // Hide UI Gameplay
		//{
		//	dataComps_ref.uiImages [i].gameObject.SetActive(false);
		//
		//}


	}
	[Inspector]
	public void DeactivateAmmoCanvas ()
	{
		ammoCanvasObj.SetActive (false);
		//Time.timeScale = 1;
		//for (int i = 0; i < dataComps_ref.uiImages.Length; i++)   // Display UI Gameplay
		//{
		//	dataComps_ref.uiImages [i].gameObject.SetActive (true);
		//
		//}

	}
	[Inspector]
	public void DeactivateAmmoCanvasNOAD ()
	{
		PlayerWeapons.WatchedAdAmmo = true;
		ammoCanvasObj.SetActive (false);
		//Time.timeScale = 1;
		//for (int i = 0; i < dataComps_ref.uiImages.Length; i++)   // Display UI Gameplay
		//{
		//	dataComps_ref.uiImages [i].gameObject.SetActive (true);
		//
		//}

	}



	public void RestartButton()
	{
		Time.timeScale = 1.0f;
		fpsPlayer_ref.RestartMap ();
	}

	public void LevelSelectButton ()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene ("" +levelSelectSceneName, LoadSceneMode.Single);

	}

	public void NextLEvelButton ()
	{
		SceneManager.LoadScene ("" + nextSceneName, LoadSceneMode.Single);
	}

	[Inspector]
	public void DeactivateUI()
	{
		for (int i = 0; i < dataComps_ref.uiImages.Length; i++)   // Display UI Gameplay
		{
			dataComps_ref.uiImages [i].gameObject.SetActive (false);

		}
	}
	[Inspector]
	public void ActivateUI()
	{
		for (int i = 0; i < dataComps_ref.uiImages.Length; i++)   // Display UI Gameplay
		{
			dataComps_ref.uiImages [i].gameObject.SetActive (true);

		}
	}




	void Awake ()
	{

		if(!dataComps_ref)
			dataComps_ref = gameObject.GetComponent<DataComps>();

		if (!fpsPlayer_ref)
			fpsPlayer_ref = dataComps_ref.fpsPlayer_ref;

		if (pauseCanvasObj.activeSelf)
			pauseCanvasObj.SetActive (false);


	}




}
