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


		switch (index)
		{

			case 0:

				print ("Loading Level = "+loadLevelButtons [index].sceneName);
				SceneManager.LoadScene ("" + loadLevelButtons [index].sceneName, LoadSceneMode.Single);
			break;
			case 1:

				print ("Loading Level = "+loadLevelButtons [index].sceneName);
				SceneManager.LoadScene ("" + loadLevelButtons [index].sceneName, LoadSceneMode.Single);
				break;
			case 2:

				print ("Loading Level = "+loadLevelButtons [index].sceneName);
				SceneManager.LoadScene ("" + loadLevelButtons [index].sceneName, LoadSceneMode.Single);
				break;

			case 3:

				if (SaveSystem.GetLevel1 () == 1 || SaveSystem.GetLevel2 () == 1) 
				{
					print ("Loading Level = "+loadLevelButtons [index].sceneName);
					SceneManager.LoadScene ("" + loadLevelButtons [index].sceneName, LoadSceneMode.Single);
				}
				
			break;

			case 4:
				if (SaveSystem.GetLevel3 () == 1) 
				{
				print ("Loading Level = "+loadLevelButtons [index].sceneName);
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
