using UnityEngine;
using System.Collections;

public class SaveData : MonoBehaviour {


	public bool isFirstTime;
	public int lastCompletedLevel;


	public string weaponString;




	// Use this for initialization
	void Awake () {
	

		isFirstTime = SaveSystem.GetFirstTime();
		lastCompletedLevel = SaveSystem.GetLastCompletedLevel();

		weaponString = SaveSystem.GetWeaponsGained();


	}
	

}
