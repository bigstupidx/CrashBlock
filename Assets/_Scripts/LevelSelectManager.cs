using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour {




	AsyncOperation scene;
	public GameObject loadingPanel;
	public Slider progressSlider;

    private bool LoadOnce;

    private void Awake()
    {
        ServiceLocator.levelSelectManager = this;
    }

    [System.Serializable]
	public class LoadLevelButtons
	{
		public string sceneName;

	};

	public LoadLevelButtons[] loadLevelButtons;

	public void LoadlLevelSelect(){
		SceneManager.LoadScene ("LevelSelect");
	}


	public void LoadlLevel(int index)		// use this function to load the level
	{


		switch (index)
		{

			case 0:
				StartCoroutine ("LoadLevelProgressBar", index);
			break;
			case 1:

				StartCoroutine ("LoadLevelProgressBar", index);
				break;
			case 2:

				StartCoroutine ("LoadLevelProgressBar", index);
				break;

			case 3:

				if (SaveSystem.GetLevel1 () == 1 || SaveSystem.GetLevel2 () == 1) 
				{
					StartCoroutine ("LoadLevelProgressBar", index);
				}
				
			break;

			case 4:
				if (SaveSystem.GetLevel3 () == 1) 
				{
					StartCoroutine ("LoadLevelProgressBar", index);
				}

			break;

            case 5:

                StartCoroutine("LoadLevelProgressBar", index);
                break;

        }



	}

	public IEnumerator LoadLevelProgressBar(int index)
	{
        if (!LoadOnce)
        {
            LoadOnce = true;
        
		    yield return new WaitForSeconds (1);

		    loadingPanel.SetActive (true);

		    print ("Loading Level = "+loadLevelButtons [index].sceneName);
		    if (index == 0) {
			    Analytics.CustomEvent ("Tutorial Started");	
		    } else {
			    Analytics.CustomEvent ("Level" + index + "Started");
		    }
		    scene = SceneManager.LoadSceneAsync (loadLevelButtons [index].sceneName);

		    while (!scene.isDone) 
		    {
			    progressSlider.value = scene.progress;
			    Debug.Log ("scene progress: " + scene.progress);
			    yield return null;
		    }
        }
    }

	public void TestBut ()
	{
		print ("button works!");

	}







}
