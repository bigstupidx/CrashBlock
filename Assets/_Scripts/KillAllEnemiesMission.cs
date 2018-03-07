using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using EasyEditor;
using UnityEngine.Analytics;

public class KillAllEnemiesMission : MonoBehaviour {

	[SerializeField]
	private GameObject resultsCanvas;
	[Header("Gameobjects to activate with timer."),SerializeField]
	private GameObject[] resultsCanvasObj;

	[Header("Current level number, for SavingLevelComplete")]
	public int levelNum;

	// Communicating Scripts
	[SerializeField]
	private DataComps dataComps;


	public int enemiesLeft;

	public Text enemiesLeftText;

	public int enemyCounter;

	public int EnemyCounter
	{
		get
		{
			return enemyCounter;	
		}

		set
		{
			enemyCounter = value;

			enemiesLeft = enemyCounter;
			if (enemiesLeftText != null) {
				enemiesLeftText.text = "" + enemiesLeft;
			}

			if (enemyCounter <= 0) 
			{
				// Start level completed Event...
				StartCoroutine (LevelCompletedCo());
			}
				
		}


	}


	void Awake()
	{
		if(resultsCanvas.activeSelf == true)
		resultsCanvas.SetActive (false);

		if (!dataComps) 
		{
            dataComps = ServiceLocator.dataComps;
		}

	}


	IEnumerator LevelCompletedCo()
	{
		resultsCanvas.SetActive (true);
		dataComps.pauseMan_ref.DeactivateUI ();
		// Start time to complete display
		// Start accuracy %
		// Shots fired
		// Grenades used if more than 0
		// Healthpacks used if more than 0

		// save level completed
		SaveLevelCompleted ();
        LevelCompletedAnalitics();

        yield return new WaitForSeconds (2.0f);

		resultsCanvasObj [0].SetActive (true);
		resultsCanvasObj [1].SetActive (true);



	}


    private void LevelCompletedAnalitics()
    {
        Analytics.CustomEvent("Level" + levelNum + "Completed");
    }



	void SaveLevelCompleted()
	{

		switch(levelNum)
		{

			case 0:
				SaveSystem.SetLevelTut (1);
				break;

			case 1:
				SaveSystem.SetLevel1 (1);
				break;
			case 2:
				SaveSystem.SetLevel2 (1);
				break;
			case 3:
				SaveSystem.SetLevel3 (1);
				break;
			case 4:
				SaveSystem.SetLevel4 (1);
				break;
			case 5:
				SaveSystem.SetLevel5 (1);
				break;




		}

	}








}
