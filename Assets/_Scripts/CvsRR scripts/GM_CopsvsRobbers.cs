using UnityEngine;
using System.Collections;
using EasyEditor;

public enum CopsVsRobbers {Cop, Robber};

public class GM_CopsvsRobbers : MonoBehaviour {

	// This script handles the Cops vs robbers missions


	// this is set at the begining of the game, before the AI start, 2 buttons appear so the player can set his TEAM.
	public CopsVsRobbers playerTeam;		

	[SerializeField]
	private Camera gameStartCam;

	public bool gameStarted = false;

	[SerializeField]
	private Transform copStartPos;
	[SerializeField]
	private Transform robberStartPos;

	[SerializeField]
	private Camera CopCameraStart;
	[SerializeField]
	private Camera RobberCameraStart;


	[SerializeField]
	private CameraFader camFader_ref;
	[SerializeField]
	private DataComps dataComps;

	[SerializeField]
	private GameObject[] CopsVsRobbersInitialCanvas;


	void Start()
	{
		if (dataComps == null)
		dataComps = GameObject.FindGameObjectWithTag ("DataBase").GetComponent<DataComps>();

		ControlGameUI (false);
	}


	// initialize the game.
	public void CopsVsRobbersGameStart(int cop1rob2)
	{
		if (cop1rob2 == 1) 
		{
			playerTeam = CopsVsRobbers.Cop;
			copStartPos.GetChild (0).gameObject.SetActive (true);
			dataComps.fpsPlayer_ref.gameObject.transform.position = copStartPos.position;

			print ("Came Started as Cop");
		}
		if (cop1rob2 == 2) 
		{
			playerTeam = CopsVsRobbers.Robber;
			robberStartPos.GetChild (0).gameObject.SetActive (true);
			dataComps.fpsPlayer_ref.gameObject.transform.position = robberStartPos.position;
			print ("Came Started as Robber");
		}


		HideCanvasPack (1);
	}



	// Call the camera sequence for the team.


	// 

	public void StartGame()
	{



		ControlGameUI (true);
		print ("Game Started");

		if( playerTeam == CopsVsRobbers.Cop)
		dataComps.fpsPlayer_ref.gameObject.transform.position = copStartPos.position;
		
		if( playerTeam == CopsVsRobbers.Robber)
		dataComps.fpsPlayer_ref.gameObject.transform.position = robberStartPos.position;


		gameStarted = true;

		// turn off starting camera and Fly thru Cameras
		gameStartCam.gameObject.SetActive(false);
		CopCameraStart.gameObject.SetActive (false);
		RobberCameraStart.gameObject.SetActive (false);

	}


	// shows or hides the Game UI with the input bool
	void ControlGameUI( bool show)
	{
		for(int i=0; i< dataComps.uiImages.Length; i++)
		{
			dataComps.uiImages [i].SetActive (show);
		}

	


	}




	void OnValidate()
	{
		if (dataComps == null)
			dataComps = GameObject.FindGameObjectWithTag ("DataBase").GetComponent<DataComps>();
		
		camFader_ref = GameObject.Find ("CameraFader").GetComponent<CameraFader>();

	}



	void HideCanvasPack (int pack)
	{
		switch (pack)

		{
			case 1:
				
			gameStartCam.enabled = false;
			for(int i =0; i<  CopsVsRobbersInitialCanvas.Length; i++)
			{
				CopsVsRobbersInitialCanvas [i].SetActive (false);
			}

			break;

		}
		
	}

	[Inspector]
	public void ShowUIButtons()
	{
		ControlGameUI (true);
	}
	[Inspector]
	public void HideUIButtons()
	{
		ControlGameUI (false);
	}


}
