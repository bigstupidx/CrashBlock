using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour {






	[System.Serializable]
	public class LoadLevelButtons
	{
		public string sceneName;

	};

	public LoadLevelButtons[] loadLevelButtons;



	public void LoadlLevel(int index)		// use this function to load the level
	{

		print ("Loading Level = "+loadLevelButtons [index].sceneName);

		SceneManager.LoadScene ("" + loadLevelButtons [index].sceneName, LoadSceneMode.Single);



	}


	public void TestBut ()
	{
		print ("button works!");

	}







}
