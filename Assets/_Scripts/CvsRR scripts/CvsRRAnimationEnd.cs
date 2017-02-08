using UnityEngine;
using System.Collections;

public class CvsRRAnimationEnd : MonoBehaviour {



	public GM_CopsvsRobbers CvsRgameManagerRef;

	void OnEnable()
	{
		SetAnimationEnd ();
	}

	public void SetAnimationEnd()
	{
		CvsRgameManagerRef.StartGame ();
	}
}
