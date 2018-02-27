using UnityEngine;
using System.Collections;
using EasyEditor;

public class BattleRoyaleGM : MonoBehaviour {


    [SerializeField]
    private GameObject GamePad_UI_obj;
    [SerializeField]
    private GameObject Gameplay_UI_obj;

    [SerializeField]
    private float distanceFromGround;
    private RaycastHit hit;

    // use this class for spawning the random location for the player
    [System.Serializable]
    public class BattleRoyaleSpawn
    {
        public Transform spawnPoint;
        public GameObject[] allies;
    };

    public BattleRoyaleSpawn[] battleRoyaleSpawn;



    void Start ()
    {
	
	}

    [Inspector]
    public void PlaceSpawnPointsOverGround()
    {
        for (int i = 0; i < battleRoyaleSpawn.Length; i++)
        {
            if(Physics.Raycast(battleRoyaleSpawn[i].spawnPoint.position, Vector3.down, out hit))
            {
                battleRoyaleSpawn[i].spawnPoint.position = new Vector3(battleRoyaleSpawn[i].spawnPoint.position.x,
                                                                        hit.point.y + distanceFromGround,
                                                                        battleRoyaleSpawn[i].spawnPoint.position.z);
            }
        }
    }



    public void StartGame(int type)
    {
      //  switch ()
      //  {
      //
      //  }

    }



}
