using UnityEngine;
using System.Collections.Generic;
using EasyEditor;
using System.Collections;

public class BattleRoyaleGM : MonoBehaviour {

    [SerializeField]
    private bool testMode;  // do nothing
    [SerializeField]
    private GameObject fpsPlayerObj;
    [SerializeField]
    private GameObject GamePad_UI_obj;
    [SerializeField]
    private GameObject Gameplay_UI_obj;

    [SerializeField]
    private GameObject[] buttons;

    [Header("Allies pool"),SerializeField]
    private GameObject[] allies;

    [SerializeField]
    private float distanceFromGround;
    private RaycastHit hit;

    [Header("Distance Range from which the allies will spawn from the player"),Range(5,20), SerializeField]
    private float minAllySpawnRange;
    [Range(5,20), SerializeField]
    private float maxAllySpawnRange;

    // cache vars
    private AI cacheAIref;
    private NavMeshAgent cacheNavMeshA; 

    // use this class for spawning the random location for the player
    [System.Serializable]
    public class BattleRoyaleSpawn
    {
        public Transform spawnPoint;
    };

    public BattleRoyaleSpawn[] battleRoyaleSpawn;

    [Tooltip("Game type, defined by the player selecting Solo, Duo or Squad")]  // 1 , 2  and 3 respectively
    public int gameType;

    private int randomSpawnPoint;

    private List<GameObject> allyRef = new List<GameObject>();

    private WaitForSeconds oneSec;

    #region Monobehaviour
    void Start ()
    {
        if (testMode)
        {
            return;
        }
        GamePad_UI_obj.SetActive(false);
        Gameplay_UI_obj.SetActive(false);

        oneSec = new WaitForSeconds(1.0f);
    }
    #endregion

    #region Methods

    // Select a random spawn point, then move it to the ground to player spawn level, if allies are to be included the ref points are created before sending the player to the ground, to avoid collision issues with allies
    [Inspector]
    public void PlaceSpawnPointsOverGround()
    {
        if (testMode)
        {
            return;
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }

        randomSpawnPoint = Random.Range(0,battleRoyaleSpawn.Length);

        if (Physics.Raycast(battleRoyaleSpawn[randomSpawnPoint].spawnPoint.position, Vector3.down, out hit))
        {
            switch (gameType)
            {
                case 2:
                    GameObject g = new GameObject();
                    g.transform.position = new Vector3(battleRoyaleSpawn[randomSpawnPoint].spawnPoint.position.x + (Random.Range(minAllySpawnRange, maxAllySpawnRange) * GetRandomSign()),
                                                       battleRoyaleSpawn[randomSpawnPoint].spawnPoint.position.y,
                                                       battleRoyaleSpawn[randomSpawnPoint].spawnPoint.position.z + (Random.Range(minAllySpawnRange, maxAllySpawnRange) * GetRandomSign()));
                    allyRef.Add(g);
                break;

                case 3:
                    GameObject g1 = new GameObject();
                    g1.transform.position = new Vector3(battleRoyaleSpawn[randomSpawnPoint].spawnPoint.position.x + (Random.Range(minAllySpawnRange, maxAllySpawnRange) * GetRandomSign()),
                                                       battleRoyaleSpawn[randomSpawnPoint].spawnPoint.position.y,
                                                       battleRoyaleSpawn[randomSpawnPoint].spawnPoint.position.z + (Random.Range(minAllySpawnRange, maxAllySpawnRange)) * GetRandomSign());
                    GameObject g2 = new GameObject();
                    g2.transform.position = new Vector3(battleRoyaleSpawn[randomSpawnPoint].spawnPoint.position.x + (Random.Range(minAllySpawnRange, maxAllySpawnRange) * GetRandomSign()),
                                                       battleRoyaleSpawn[randomSpawnPoint].spawnPoint.position.y,
                                                       battleRoyaleSpawn[randomSpawnPoint].spawnPoint.position.z + (Random.Range(minAllySpawnRange, maxAllySpawnRange)) * GetRandomSign());
                    GameObject g3 = new GameObject();
                    g3.transform.position = new Vector3(battleRoyaleSpawn[randomSpawnPoint].spawnPoint.position.x + (Random.Range(minAllySpawnRange, maxAllySpawnRange) * GetRandomSign()),
                                                       battleRoyaleSpawn[randomSpawnPoint].spawnPoint.position.y,
                                                       battleRoyaleSpawn[randomSpawnPoint].spawnPoint.position.z + (Random.Range(minAllySpawnRange, maxAllySpawnRange)) * GetRandomSign());

                    allyRef.Add(g1);
                    allyRef.Add(g2);
                    allyRef.Add(g3);
                    break;
            }

            // move the player spawn point to the ground
            battleRoyaleSpawn[randomSpawnPoint].spawnPoint.position = new Vector3(battleRoyaleSpawn[randomSpawnPoint].spawnPoint.position.x,
                                                                    hit.point.y + distanceFromGround,
                                                                    battleRoyaleSpawn[randomSpawnPoint].spawnPoint.position.z);
            // move the allies spawn points to the ground
            for (int i=0; i< allyRef.Count; i++)
            {
                if (Physics.Raycast(allyRef[i].transform.position, Vector3.down, out hit))
                {
                    allyRef[i].transform.position = new Vector3(allyRef[i].transform.position.x, hit.point.y , allyRef[i].transform.position.z);
                }
            }


            // now activate and move the player to the point
            if(fpsPlayerObj == null)
            {
                fpsPlayerObj = ServiceLocator.dataComps.fpsPlayer_ref.gameObject;
            }
            else
            {
                fpsPlayerObj.transform.position = battleRoyaleSpawn[randomSpawnPoint].spawnPoint.position;
            }
            
            // now spawn the allies to their position
            for (int i = 0; i < allyRef.Count; i++)
            {
                if(allies.Length == 0)
                {
                    return;
                }

                int index = Random.Range(0, allies.Length);
                StartCoroutine(SetupAllyCo(allies[index], allyRef[i].transform));
            }

        }

        StartCoroutine(TurnOnUICo());
    }

    IEnumerator TurnOnUICo()
    {
        yield return new WaitForSeconds(1.0f);
        GamePad_UI_obj.SetActive(true);
        Gameplay_UI_obj.SetActive(true);
    }


    IEnumerator SetupAllyCo(GameObject g, Transform p)
    {
        GameObject f;
        yield return oneSec;
        f = Instantiate(g, p) as GameObject;
        f.transform.position = f.transform.parent.position;
        cacheAIref = f.GetComponent<AI>();
        cacheNavMeshA = f.GetComponent<NavMeshAgent>();
        cacheAIref.factionNum = 1;
        cacheAIref.followPlayer = true;
        cacheNavMeshA.stoppingDistance = 6f;
        f.SetActive(false);
        yield return oneSec;
        f.SetActive(true);
    }

    // use this from the buttons
    public void StartGame(int type)
    {
        testMode = false;
        gameType = type;
        PlaceSpawnPointsOverGround();
    }



    private float GetRandomSign()
    {
        if(Random.Range(-1,1) > 0)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
    #endregion
}
