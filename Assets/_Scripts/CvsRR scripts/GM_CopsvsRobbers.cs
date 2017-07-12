using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
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

	[Header("UI to toggle on and OFF")]
	[SerializeField]
	private GameObject gameplayCanvas;
	[SerializeField]
	private GameObject skipButton;

	[SerializeField]
	private GameObject[] CopsVsRobbersInitialCanvas;


	[SerializeField]
	private CameraFader camFader_ref;

	[Header("Datacomps")]
	[SerializeField]
	private DataComps dataComps;


	[Header("The containers for the npcs"),SerializeField]
	[Space(20)]
	private Transform copsNpcs;
	[SerializeField]
	private int robbersToKill;
	[SerializeField]
	private Transform robbersNpcs;
	[SerializeField]
	private int copsToKill;




	void Start()
	{
		if (dataComps == null)
		dataComps = GameObject.FindGameObjectWithTag ("DataBase").GetComponent<DataComps>();

		skipButton.SetActive (false);
		gameplayCanvas.SetActive (false);
		ControlGameUI (false);
	}


	// initialize the game.
	public void CopsVsRobbersGameStart(int cop1rob2)
	{
		if (cop1rob2 == 1) 
		{
			playerTeam = CopsVsRobbers.Cop;
			copStartPos.GetChild (0).gameObject.SetActive (true);
			//dataComps.fpsPlayer_ref.gameObject.transform.position = copStartPos.position;
			// turn off the other game
			robbersNpcs.parent.gameObject.SetActive (false);
			// initialize enemies to kill
			dataComps.gameObject.GetComponent<KillAllEnemiesMission>().EnemyCounter = robbersToKill;

			print ("Came Started as Cop");
		}
		if (cop1rob2 == 2) 
		{
			playerTeam = CopsVsRobbers.Robber;
			robberStartPos.GetChild (0).gameObject.SetActive (true);
			//dataComps.fpsPlayer_ref.gameObject.transform.position = robberStartPos.position;
			// turn off the otehr game
			copsNpcs.parent.gameObject.SetActive (false);
			// initialize enemies to kill
			dataComps.gameObject.GetComponent<KillAllEnemiesMission>().EnemyCounter = copsToKill;
			print ("Came Started as Robber");
		}

		skipButton.SetActive (true);

        if (GetComponent<TeamSkin>())
        {
            GetComponent<TeamSkin>().SetTeamSkin(cop1rob2);
        }
		HideCanvasPack (1);
	}



	// Call the camera sequence for the team.


	// 

	public void StartGame()
	{
		ControlGameUI (true);
		// turn ON gameplayCanvas
		gameplayCanvas.SetActive (true);
		skipButton.SetActive (false);

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





	/// <summary>
	/// Counts the cops and robbers.


	[Inspector]
	[Comment("Turns ON the npcs so they can be counted for the team the player chooses")]
	public void CountCopsAndRobbers()
	{
		robbersToKill = 0;
		copsToKill = 0;
		
		for (int i = 0; i < copsNpcs.childCount; i++) 
		{
			copsNpcs.GetChild (i).gameObject.SetActive (true);

			if (copsNpcs.GetChild (i).gameObject.GetComponent<CopsVsRobbersUnit> ().unitType == CopsVsRobbers.Robber)
				robbersToKill++;


		}

		for (int i = 0; i < robbersNpcs.childCount; i++) 
		{

			robbersNpcs.GetChild (i).gameObject.SetActive (true);

			if (robbersNpcs.GetChild (i).gameObject.GetComponent<CopsVsRobbersUnit> ().unitType == CopsVsRobbers.Cop)
				copsToKill++;



		}

		#if UNITY_EDITOR
		EditorUtility.SetDirty (gameObject.GetComponent<GM_CopsvsRobbers> ());
		#endif
	}




}
