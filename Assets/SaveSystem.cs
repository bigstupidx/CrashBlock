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



	//-----------------------------------------------------  Weapon list as a string, when loaded and saved needs to be comnverted to a bool list

	public static void SetWeaponsGained(string _value)
	{
		PlayerPrefs.SetString ("WeaponsGained", _value);
	}


	public static string GetWeaponsGained()
	{
		return PlayerPrefs.GetString ("WeaponsGained");
	}


}
