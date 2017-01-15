using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using EasyEditor;

public class KillAllEnemiesMission : MonoBehaviour {

	[SerializeField]
	private GameObject resultsCanvas;
	[Header("Gameobjects to activate with timer."),SerializeField]
	private GameObject[] resultsCanvasObj;


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

			if (enemyCounter == 0) 
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
			dataComps = GameObject.FindGameObjectWithTag ("DataBase").GetComponent<DataComps> ();
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

		yield return new WaitForSeconds (2.0f);

		resultsCanvasObj [0].SetActive (true);
		resultsCanvasObj [1].SetActive (true);



	}











}
