using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataComps : MonoBehaviour {


	public Image hpBar;


	public PauseManager pauseMan_ref;

	public FPSPlayer fpsPlayer_ref;

	[Header("GamePLay buttons images to hide During Pause")]
	public GameObject[] uiImages;



	//public int pause = 0;
	//
	//public int Pause
	//{
	//	get
	//	{
	//		return pause; 
	//	}
	//
	//	set
	//	{
	//		pause = value;
	//
	//		PauseSwitch = !PauseSwitch;
	//
	//		pauseMan_ref.ActivatePauseCanvas (PauseSwitch);
	//
	//		pause=0;
	//
	//	}
	//}



	public bool pauseSwitch = false;

	public bool PauseSwitch
	{
		get{ return pauseSwitch; }
		set
		{
			pauseSwitch = value;

			switch (value) 
			{

			case true:
				pauseMan_ref.ActivatePauseCanvas ();
				break;

			case false:
				pauseMan_ref.DeactivatePauseCanvas ();
				break;

			}

		}
	}
		


	void Awake()
	{
		if(!pauseMan_ref)
		{
			pauseMan_ref = this.gameObject.GetComponent<PauseManager> ();
		}
	}





}