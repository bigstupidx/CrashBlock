using UnityEngine;
using System.Collections;

public class SaveData : MonoBehaviour {


	public bool isFirstTime;
	public int lastCompletedLevel;

	public bool wepSlot4;	// true if awarded by AD
	public bool wepSlot5;

	public bool[] levelsCompleted;

	private DataComps dataComps;

	// Use this for initialization
	void Awake () {
	

		isFirstTime = SaveSystem.GetFirstTime();
		lastCompletedLevel = SaveSystem.GetLastCompletedLevel();

		if (dataComps == null)
			dataComps = gameObject.GetComponent<DataComps> ();


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


		if (SaveSystem.GetWepSlot4 () == 1) 
		{
			wepSlot4 = true;

			// enable slot 4
			dataComps.WeaponSlotsObj[3].SetActive(true);
			// disable Slot 4 Reward backpack icon
			dataComps.WeaponSlotsObj[5].SetActive(false);

			// enable Slot 5 Rewards backpack icon
			dataComps.WeaponSlotsObj[6].SetActive(true);


		}



	}




	// this fucntion awards the weapon slot 4 persistently after watching the AD when calling int 4
	// this function activates slot 5 on the level when watched AD but not persistently
	public void AwardSlot(int slotNum)
	{

		switch(slotNum)
		{
			case 4:
				// save the slot
				SaveSystem.SetWepSlot4 (1);

				// turn on the slot
				dataComps.WeaponSlotsObj[3].SetActive(true);
				// enable Slot 5 Rewards backpack icon
				dataComps.WeaponSlotsObj[6].SetActive(true);


			break;

			case 5:
				// turn on slot 5 this game only
				dataComps.WeaponSlotsObj[4].SetActive(true);
				// disable earn slot 5 Reward Backpack
				dataComps.WeaponSlotsObj[6].SetActive(false);			

			break;
		}



	}







}
