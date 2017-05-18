using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum FatLadyState {Dormant, Intro, Attacking, Death, Outro};

public class TankFatLady : MonoBehaviour {

    #region Variables
    [Header("Boss State"),SerializeField]
    private FatLadyState fatLadystate;

    private FatLadyState FatLadystate
    {
        get
        {

            return fatLadystate;
        }
        set
        {
            fatLadystate = value;

            switch (fatLadystate)
            {
                case FatLadyState.Dormant:
                break;
                case FatLadyState.Intro:
                    if (!hasCalledIntro)
                    {
                        hasCalledIntro = true;
                        StartCoroutine(IntroCutScene());
                    }
                    
                break;
                case FatLadyState.Attacking:

                    if(!isTraversing)
                    StartCoroutine(TraversingWaypointsCo());

                break;

                case FatLadyState.Death:
                    ObjsToToggleInCutscenes(false);
                    FatLadystate = FatLadyState.Outro;
                    
                
                break;


                case FatLadyState.Outro:

                    if (!hasCalledOutro)
                    {
                        hasCalledOutro = true;

                        OutroCamera.SetActive(true);        //--- turn on cameras
                        outroCamStartPoint.gameObject.SetActive(true);

                        OutroCamera.transform.position = outroCamStartPoint.position;

                        StartCoroutine(DefeatedCutScene());
                        StartCoroutine(LoadNextLevelCo());
                    }
                    
                break;

            }



        }
    }       //-- state property

    [SerializeField]
    private float hp;
    private float startingHp;

    [SerializeField]
    private Image bossHpSlider;

    [Header("Animators and effects"), SerializeField]
    private Animator fatLadyAnim;
    [SerializeField]
    private string[] fatAnimTriggers;
    [SerializeField]
    private AudioClip greeting_sfx;
    [SerializeField]
    private AudioClip[] damage_sfx;
    [SerializeField]
    private AudioClip defeated_sfx;
    [SerializeField]
    private AudioClip explodingTank_sfx;



    [Header("Shooting")]
    [SerializeField]
    private float atkSpeedmin;
    [SerializeField]
    private float atkSpeedmax;
    private int atkSpeedCache;
    private WaitForSeconds minAtkSpeed;
    private WaitForSeconds maxAtkSpeed;

    private bool isAttacking;       //- permision to let know the update function the boss is attacking

    [SerializeField]
    private GameObject missile;
    //private GameObject g;
    [SerializeField]
    private GameObject missileShoot_p;      //-- the particles when a missile is being shot, just toggle them

    [SerializeField]
    private Transform shootingPoint;        //-- Instance point of the cannon missile

    [SerializeField]
    private Transform rotatingPoint;        //-- For rotating the tank cannon


    

    [Header("Navmesh Agent"), SerializeField]
    private NavMeshAgent navAgent;

    private bool isTraversing;

    [SerializeField]
    private float waypointChangingSpeed;
    private WaitForSeconds waypointChangingSpeedTimer;

    private int currentWaypoint;
    [SerializeField]
    private Transform[] waypoints;


    //--- components
    private DataComps dataComps;
    private Transform player_T;
    private AudioSource audioS;

    //--- cutscenes Variables
    [Header("Cut Scenes Area"), SerializeField]
    private GameObject introCamera;
    private bool hasCalledIntro;
    [SerializeField]
    private GameObject[] objsTotoggle;
 
    [SerializeField]
    private GameObject OutroCamera;
    [SerializeField]
    private  Transform outroCamStartPoint;
    [SerializeField]
    private float outroCamSpeed;
    private bool hasCalledOutro;
    
    #endregion








    #region Mechanics Functions
    // Use this for initialization
    void Start()
    {
        LoadRefs();
        InitializeScript();

        FatLadystate = FatLadyState.Intro;
        
    }

    IEnumerator IntroCo()
    {
        yield return new WaitForSeconds(1.0f);

        fatLadystate = FatLadyState.Intro;
    }

    // Update is called once per frame
    void Update()
    {
        switch (fatLadystate)
        {
            case FatLadyState.Dormant:

            break;


            case FatLadyState.Attacking:

                if (!isAttacking)
                {
                    isAttacking = true;
                    StartCoroutine(AtkCo());
                }

                if (hp <= 0)
                {

                    FatLadystate = FatLadyState.Death;
                }


            break;

                
            case FatLadyState.Outro:

                // animate OutroCamera until enxt level loads
                if(OutroCamera.activeSelf && outroCamStartPoint.gameObject.activeSelf)
                {
                    OutroCamera.transform.LookAt(gameObject.transform);
                    OutroCamera.transform.RotateAround(gameObject.transform.position, Vector3.up, outroCamSpeed * Time.deltaTime);
                }    




            break;

        }



    }
   

    

    IEnumerator TraversingWaypointsCo()
    {
        if(!isTraversing)
        isTraversing = true;

        currentWaypoint = Random.Range(0, waypoints.Length);        //-- get a random new waypoint

        if(navAgent)
        navAgent.destination = waypoints[currentWaypoint].position;      // set random waypoint as destination
        

        if(fatLadystate == FatLadyState.Attacking)
        {

          yield return waypointChangingSpeedTimer;
          StartCoroutine (TraversingWaypointsCo());
        }

    }


    IEnumerator AtkCo()
    {
        atkSpeedCache = Random.Range(0,1);
        switch (atkSpeedCache)
        {
            case 0:
                yield return minAtkSpeed;
                break;
            case 1:
                yield return maxAtkSpeed;
                break;

            default:
                break;
        }
        StartCoroutine(AimPlayer());
        StartCoroutine(ShootMissileCo());
    }

    IEnumerator AimPlayer() //-- aim player
    {
        
        float timer = 0.0f;

        while (timer < 1.5f)
        {
            timer += Time.deltaTime;

            var lookPos = player_T.position - rotatingPoint.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            rotatingPoint.rotation = Quaternion.Slerp(rotatingPoint.rotation, rotation, Time.deltaTime * 20
         );
            
            yield return null;
        }
    }

    IEnumerator ShootMissileCo()
    {
        yield return new WaitForSeconds(1.0f);
        // shoot missile
        if (missile)
        {
            GameObject g = null;

            g = Instantiate(missile, shootingPoint.position, Quaternion.identity) as GameObject;
            g.gameObject.GetComponent<ElementalMissile>().StartMissile(player_T.position, shootingPoint, 0);
        }

        if (missileShoot_p && !missileShoot_p.activeSelf)
            missileShoot_p.SetActive(true);

        isAttacking = false;
    }


    public void TakeDamage(float damage, bool isBody)
    {

        if (isBody)
        {
            fatLadyAnim.SetTrigger("DamagedOne");
            audioS.PlayOneShot(damage_sfx[Random.Range(0, damage_sfx.Length-1)], 1.0f);
        }

        if(hp-damage > 0)
        {
            hp -= damage;
            bossHpSlider.fillAmount = ( hp / startingHp);
        }
       
        if(hp -damage <= 0)
        {
            bossHpSlider.fillAmount = 0;
            FatLadystate = FatLadyState.Death;
        }



    }


    #region CutScenes Functions


    IEnumerator IntroCutScene()
    {
        yield return null;

        ObjsToToggleInCutscenes(false);

        introCamera.SetActive(true);

        yield return new WaitForSeconds(7.5f);

        fatLadyAnim.SetTrigger(fatAnimTriggers[0]);

        yield return new WaitForSeconds(2.0f);

        introCamera.SetActive(false);
        
        ObjsToToggleInCutscenes(true);

        yield return new WaitForSeconds(3.0f);

        FatLadystate = FatLadyState.Attacking;

    }


    IEnumerator DefeatedCutScene() //-- call destruction particles and sounds
    {

        yield return null;
    }

    IEnumerator LoadNextLevelCo()
    {

        yield return new WaitForSeconds(8.0f);

        dataComps.GetComponent<PauseManager>().LevelSelectButton();
    }

    #endregion



    void ObjsToToggleInCutscenes(bool toggle)
    {
      for (int i = 0; i < objsTotoggle.Length; i++)
      {
          if (objsTotoggle[i])
          {
              objsTotoggle[i].SetActive(toggle);
          }
      }
    }

    #endregion


    #region Loading references & Initialization 


    void LoadRefs()
    {
        dataComps = GameObject.FindGameObjectWithTag("DataBase").GetComponent<DataComps>();

        player_T = dataComps.fpsPlayer_ref.transform;
    }

    void InitializeScript()
    {
        waypointChangingSpeedTimer = new WaitForSeconds(waypointChangingSpeed);
        minAtkSpeed = new WaitForSeconds(atkSpeedmin);
        maxAtkSpeed = new WaitForSeconds(atkSpeedmax);
        startingHp = hp;
        audioS = GetComponent<AudioSource>();
    }

  // void OnValidate()
  // {
  //    
  //     startingHp = hp;
  //
  //     bossHpSlider.fillAmount = (hp / startingHp);
  // }

    #endregion


}
