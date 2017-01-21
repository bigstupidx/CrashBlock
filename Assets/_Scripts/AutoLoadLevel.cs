using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AutoLoadLevel : MonoBehaviour {

	[SerializeField]
	private string nextLevel;
	[SerializeField]
	private float loadingTime = 3.0f;


	void Start () 
	{
		StartCoroutine (LoadNextLevelCo());
	
	}

	//  load next level after 3 seconds.

	IEnumerator LoadNextLevelCo()
	{


		yield return new WaitForSeconds (loadingTime);


		SceneManager.LoadScene ("" + nextLevel, LoadSceneMode.Single);

	}





}
