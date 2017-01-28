using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class LevelSelectManager : MonoBehaviour {






	[System.Serializable]
	public class LoadLevelButtons
	{
		public string sceneName;

	};

	public LoadLevelButtons[] loadLevelButtons;



	public void LoadlLevel(int index)		// use this function to load the level
	{


		switch (index)
		{

			case 0:

				print ("Loading Level = "+loadLevelButtons [index].sceneName);
				Analytics.CustomEvent ("Level1Started");
				SceneManager.LoadScene ("" + loadLevelButtons [index].sceneName, LoadSceneMode.Single);
			break;
			case 1:

				print ("Loading Level = "+loadLevelButtons [index].sceneName);
				Analytics.CustomEvent ("Level2Started");
				SceneManager.LoadScene ("" + loadLevelButtons [index].sceneName, LoadSceneMode.Single);
				break;
			case 2:

				print ("Loading Level = "+loadLevelButtons [index].sceneName);
				Analytics.CustomEvent ("Level3Started");
				SceneManager.LoadScene ("" + loadLevelButtons [index].sceneName, LoadSceneMode.Single);
				break;

			case 3:

				if (SaveSystem.GetLevel1 () == 1 || SaveSystem.GetLevel2 () == 1) 
				{
					print ("Loading Level = "+loadLevelButtons [index].sceneName);
					Analytics.CustomEvent ("Level4Started");
					SceneManager.LoadScene ("" + loadLevelButtons [index].sceneName, LoadSceneMode.Single);
				}
				
			break;

			case 4:
				if (SaveSystem.GetLevel3 () == 1) 
				{
				print ("Loading Level = "+loadLevelButtons [index].sceneName);
				Analytics.CustomEvent ("Level5Started");
				SceneManager.LoadScene ("" + loadLevelButtons [index].sceneName, LoadSceneMode.Single);
				}

			break;

		}



	}


	public void TestBut ()
	{
		print ("button works!");

	}







}
