using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SaveSystem {



	public static void SetFirstTime(int _val)		// First time gives info
	{
		PlayerPrefs.SetInt("FirstTimePlaying", _val);
	}

	public static bool GetFirstTime()				// Fetches the info   In GET function  ,1 will beFfirs default value.
	{
		return PlayerPrefs.GetInt("FirstTimePlaying", 1) == 1;
	}


	//-----------------------------------------------------  Last completed level


	public static void SetLastCompletedLevel(int _value)
	{
		PlayerPrefs.SetInt ("LastCompletedLevel", _value);
	}
	public static int GetLastCompletedLevel()
	{
		return PlayerPrefs.GetInt ("LastCompletedLevel");
	}



	//-----------------------------------------------------  Weapon slots 3 and 4

	public static void SetWepSlot3(int _value)
	{
		PlayerPrefs.SetInt ("WeaponSlot3", _value);
	}


	public static int GetWepSlot3()
	{
		return PlayerPrefs.GetInt ("WeaponSlot3");
	}

	public static void SetWepSlot4(int _value)
	{
		PlayerPrefs.SetInt ("WeaponSlot4", _value);
	}


	public static int GetWepSlot4()
	{
		return PlayerPrefs.GetInt ("WeaponSlot4");
	}

}
