using UnityEngine;
using System.Collections;

public class DestructibleMechPart : MonoBehaviour {


    #region Variables
    [SerializeField]
    private float hp;

    private float startingHP;

    [Header("Destruction details"),SerializeField]
    private GameObject destruction_p;
    [SerializeField]
    private GameObject destroyedObjLeft;
    [SerializeField]
    private bool isParentedToOriginalParent;

    [SerializeField]
    private bool destroysOriginalMesh;
    private bool isDestroyed;

    private MeshRenderer mesh_r;
    [SerializeField]
    private float animTime;

    [SerializeField]
    private Color32 flashyColour = Color.red;
    [SerializeField]
    private Color32 startingColour = Color.white;
    private Color32 lerpedColor; //-- used for caching
    private WaitForSeconds smallTimer;

    bool isCriticallyFlashingRunning;


    [Header("SFX")]
    [SerializeField]
    private AudioClip metalHit1_sfx;
    [SerializeField]
    private AudioClip metalHit2_sfx;

    private AudioSource playerSpeaker;


    [SerializeField]
    private bool previewColor;

    private DataComps dataComps;

    #endregion

    void Start()
    {
        startingHP = hp;

        if (!mesh_r)
        {
            mesh_r = GetComponent<MeshRenderer>();
        }

        dataComps = ServiceLocator.dataComps;

        playerSpeaker = dataComps.playerSpeaker_ref.GetComponent<AudioSource>();

        smallTimer = new WaitForSeconds(0.1f);
    }



    public void DamagePart(float damage)   //-- received from fps weapons
    {


        if (Random.Range(0, 1) == 0)
        {
            playerSpeaker.PlayOneShot(metalHit1_sfx);
        }
        else
        {
            playerSpeaker.PlayOneShot(metalHit2_sfx);
        }


        CheckForDamageParts(damage);


        if (hp - damage <= 0)
        {
            isDestroyed = true;
            if (!isCriticallyFlashingRunning)
            {
                isCriticallyFlashingRunning = true;
                StartCoroutine (CriticallyDamagedPartCo());
            }
            DestroyPart();
            return;
        }
        else
        {
            hp -= damage;

            if(hp <= startingHP * 0.25f)
            {
                if (!isCriticallyFlashingRunning)
                {
                    isCriticallyFlashingRunning = true;
                    CriticallyDamagedPartCo();
                }
              
            }
            
            StartCoroutine(FlashDamage());
        }
    }


    void DestroyPart()
    {
        if(destruction_p)
        Instantiate(destruction_p, transform.position, Quaternion.identity);

        if (isParentedToOriginalParent && destroyedObjLeft)
        {
            GameObject g;
            g = Instantiate(destroyedObjLeft, transform.position, Quaternion.identity) as GameObject;
            g.transform.parent = transform.parent;
        }

        if(destroysOriginalMesh)
        Destroy(gameObject);

        GetComponent<Collider>().enabled = false;
    }

    IEnumerator FlashDamage()
    {
        float timer = 0;
        while (timer < animTime)
        {
            timer += Time.deltaTime;

            lerpedColor = Color32.Lerp(startingColour, flashyColour, (timer / animTime));
            mesh_r.material.SetColor("_Color", lerpedColor);

            yield return null;

        }

        yield return smallTimer;

        timer = 0;

        while (timer < animTime)
        {
            timer += Time.deltaTime;

            lerpedColor = Color32.Lerp(flashyColour, startingColour, (timer / animTime));
            mesh_r.material.SetColor("_Color", lerpedColor);


            yield return null;



        }
    }

    IEnumerator CriticallyDamagedPartCo()
    {
        float timer = 0;
        while (timer < animTime/2)
        {
            timer += Time.deltaTime;

            lerpedColor = Color32.Lerp(startingColour, flashyColour, (timer / animTime));
            mesh_r.material.SetColor("_Color", lerpedColor);

            yield return null;

        }

        //yield return new WaitForSeconds (0.1f);

        timer = 0;

        while (timer < animTime/2)
        {
            timer += Time.deltaTime;

            lerpedColor = Color32.Lerp(startingColour, flashyColour, (timer / animTime));
            mesh_r.material.SetColor("_Color", lerpedColor);


            yield return null;



        }
        if(gameObject && gameObject.activeSelf && isCriticallyFlashingRunning)
        StartCoroutine(CriticallyDamagedPartCo());
    }

  void OnValidate()
  {
      if (!mesh_r)
      {
          mesh_r = GetComponent<MeshRenderer>();
      }

      if (previewColor)
      {
          mesh_r.sharedMaterial.SetColor("_Color", flashyColour);
      }
      else
      {
          mesh_r.sharedMaterial.SetColor("_Color", startingColour);
      }
      
  }


    void CheckForDamageParts(float damAmmount)
    {
        if (GetComponent<TankFatLadyDamagePart>())
        {
            GetComponent<TankFatLadyDamagePart>().ReceiveDamage(damAmmount);
        }
    }


}
