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

	//-------------------------------------------------- individual levels completed


	public static void SetLevelTut(int _value)
	{
		PlayerPrefs.SetInt ("LevelTut", _value);
	}
	public static int GetLevelTut()
	{
		return PlayerPrefs.GetInt ("LevelTut");
	}


	public static void SetLevel1(int _value)
	{
		PlayerPrefs.SetInt ("Level01", _value);
	}
	public static int GetLevel1()
	{
		return PlayerPrefs.GetInt ("Level01");
	}


	public static void SetLevel2(int _value)
	{
		PlayerPrefs.SetInt ("Level02", _value);
	}
	public static int GetLevel2()
	{
		return PlayerPrefs.GetInt ("Level02");
	}


	public static void SetLevel3(int _value)
	{
		PlayerPrefs.SetInt ("Level03", _value);
	}
	public static int GetLevel3()
	{
		return PlayerPrefs.GetInt ("Level03");
	}


	public static void SetLevel4(int _value)
	{
		PlayerPrefs.SetInt ("Level04", _value);
	}
	public static int GetLevel4()
	{
		return PlayerPrefs.GetInt ("Level04");
	}


	public static void SetLevel5(int _value)
	{
		PlayerPrefs.SetInt ("Level05", _value);
	}
	public static int GetLevel5()
	{
		return PlayerPrefs.GetInt ("Level05");
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
