using UnityEngine;
using System.Collections;

public class CrateDestroyable : MonoBehaviour {

    // this script spawns randomly objects

    [SerializeField, Range(0,100)]
    private float spawnChance;

    [SerializeField]
    private GameObject[] objToSpawn;


    [SerializeField]
    private float hp;


    [SerializeField]
    private Transform spawnPoint_T;
    [SerializeField]
    private GameObject breakParticles;




    public void ApplyDamage(float dmg)
    {
        hp -= dmg;

        if(hp<= 0)
        {
            SpawnObject();

            DetectBroken();
        }
    }



    void SpawnObject()
    {

        if (breakParticles)
        {
            if (GetComponent<Collider>())
            {
                GetComponent<Collider>().enabled = false;
            }
            Instantiate(breakParticles, spawnPoint_T.position, spawnPoint_T.rotation);
        }

        float randomNum = (Random.Range(0, 100));

        if(randomNum<= spawnChance)
        {
            if(objToSpawn.Length == 1 && objToSpawn[0])
            {
                Instantiate(objToSpawn[0], spawnPoint_T.position, spawnPoint_T.rotation); // objToSpawn
            }
            else
            {
                int randomNum2 = Random.Range(0, objToSpawn.Length);

                if(objToSpawn[randomNum2])

                Instantiate(objToSpawn[randomNum2], spawnPoint_T.position, spawnPoint_T.rotation); // objToSpawn
            }
           
        }


    }



    // destroy obj and pooled attached obj are returned to pool manager
    void DetectBroken()
    {
       //remove breakable object if it is broken and particles have faded
             //prevent attached hitmarks from being destroyed with game object
                FadeOutDecals[] decals = gameObject.GetComponentsInChildren<FadeOutDecals>(true);
                foreach (FadeOutDecals dec in decals)
                {
                    dec.parentObjTransform.parent = AzuObjectPool.instance.transform;
                    dec.parentObj.SetActive(false);
                    dec.gameObject.SetActive(false);
                }
                //drop arrows if object is destroyed
                ArrowObject[] arrows = gameObject.GetComponentsInChildren<ArrowObject>(true);
                foreach (ArrowObject arr in arrows)
                {
                    arr.transform.parent = null;
                    arr.myRigidbody.isKinematic = false;
                    arr.myBoxCol.isTrigger = false;
                    arr.gameObject.tag = "Usable";
                    arr.falling = true;
                }

        Destroy(gameObject);
    }

}
