using UnityEngine;
using System.Collections;

public class SaveData : MonoBehaviour {


	public bool isFirstTime;
	public int lastCompletedLevel;

	public bool wepSlot3;	// true if rewarded by AD
	public bool wepSlot4;



	// Use this for initialization
	void Awake () {
	

		isFirstTime = SaveSystem.GetFirstTime();
		lastCompletedLevel = SaveSystem.GetLastCompletedLevel();


	}
	

}
