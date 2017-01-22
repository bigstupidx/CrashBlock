using UnityEngine;
using System.Collections;

public class SaveData : MonoBehaviour {


	public bool isFirstTime;
	public int lastCompletedLevel;

	public bool wepSlot3;	// true if rewarded by AD
	public bool wepSlot4;
	public bool wepSlot5;

	public bool[] levelsCompleted;

	// Use this for initialization
	void Awake () {
	

		isFirstTime = SaveSystem.GetFirstTime();
		lastCompletedLevel = SaveSystem.GetLastCompletedLevel();

		if (SaveSystem.GetLevelTut () == 0) {
			levelsCompleted [0] = false;
		} else 
		{
			levelsCompleted [0] = true;
		}
		if (SaveSystem.GetLevelTut () == 0) {
			levelsCompleted [1] = false;
		} else 
		{
			levelsCompleted [1] = true;
		}
		if (SaveSystem.GetLevelTut () == 0) {
			levelsCompleted [2] = false;
		} else 
		{
			levelsCompleted [2] = true;
		}
		if (SaveSystem.GetLevelTut () == 0) {
			levelsCompleted [3] = false;
		} else 
		{
			levelsCompleted [3] = true;
		}
		if (SaveSystem.GetLevelTut () == 0) {
			levelsCompleted [4] = false;
		} else 
		{
			levelsCompleted [4] = true;
		}
		if (SaveSystem.GetLevelTut () == 0) {
			levelsCompleted [5] = false;
		} else 
		{
			levelsCompleted [5] = true;
		}



	}
	

}
