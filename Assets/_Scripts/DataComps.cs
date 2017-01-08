using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataComps : MonoBehaviour {


	public Image hpBar;


	public int pause = 0;

	public int Pause
	{
		get
		{
			return pause; 
		}

		set
		{
			pause = value;

			PauseSwitch = !PauseSwitch;

			pause=0;

		}
	}



	public bool PauseSwitch =false;










}