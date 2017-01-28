using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using EasyEditor;

public class LevelSelectBlinker : MonoBehaviour {


	public float effectTimer;

	public Image[] levelImage;

	public Sprite[] discoveredLevelSprite;

	public Sprite[] undiscoveredLevelSprite;

	public bool[] levelAvailable;

	public int lastLevelDeveloped;



	void Start()
	{


		if (levelAvailable [3] == true) 
		{
			levelImage[3].sprite= discoveredLevelSprite [3];
			levelImage [3].gameObject.GetComponent<Outline> ().enabled = false;
			levelImage [3].gameObject.GetComponent<SpriteBounce>().enabled = true;
		}


		if (SaveSystem.GetLevel1 () == 1 && SaveSystem.GetLevel2 () == 1) 
		{

			levelAvailable [3] = true;
			levelImage[3].sprite= discoveredLevelSprite [3];
			levelImage [3].gameObject.GetComponent<Outline> ().enabled = false;
			levelImage [3].gameObject.GetComponent<SpriteBounce>().enabled = true;

		}

		if (SaveSystem.GetLevel3 () == 1) 
		{

			levelAvailable [4] = true;
			levelImage [4].sprite = discoveredLevelSprite [4];
			levelImage [4].gameObject.GetComponent<Outline> ().enabled = false;
			levelImage [4].gameObject.GetComponent<SpriteBounce>().enabled = true;

		}

		if (SaveSystem.GetLevel5 () == 1) 
		{

			levelAvailable [5] = true;
			levelImage [5].sprite = discoveredLevelSprite [5];
			levelImage [5].gameObject.GetComponent<Outline> ().enabled = false;
			levelImage [5].gameObject.GetComponent<SpriteBounce>().enabled = true;

		}








	}




}
