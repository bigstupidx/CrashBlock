//InstantDeathCollider.cs by Azuline Studios© All Rights Reserved
//script for instant death collider which kills player or destroys/deactivates game objects on contact.
using UnityEngine;
using System.Collections;

public class InstantDeathCollider : MonoBehaviour {

    public AdManager admanager;


    private void Start()
    {
        admanager = ServiceLocator.adManager;
    }


    void OnTriggerEnter ( Collider col  ){
        if (col.gameObject.tag == "Player") {
            FPSPlayer player = col.GetComponent<FPSPlayer>();
            if (player.invulnerable)
            {
                player.invulnerable = false;
            }
            admanager.resetPositionInDeath = true;

            player.ApplyDamage(player.maximumHitPoints + 1.0f);
            
                
		}else if (col.GetComponent<Rigidbody>()) {	
			col.gameObject.SetActive(false);
		}
	}
	
	void Reset (){
		if (GetComponent<Collider>() == null){
			gameObject.AddComponent<BoxCollider>();
			GetComponent<Collider>().isTrigger = true;
		}
	}
}