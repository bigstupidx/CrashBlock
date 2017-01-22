using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataComps : MonoBehaviour {


	public Image hpBar;


	public PauseManager pauseMan_ref;

	public FPSPlayer fpsPlayer_ref;
	public PlayerWeapons playerWeps_ref;
	public PlayerSpeaker playerSpeaker_ref;

	[Header("GamePLay buttons images to hide During Pause")]
	public GameObject[] uiImages;

	//[Header("WeaponImages")]
	// Weapons  Database to fill in the slots image, text
	[System.Serializable]
	public class WeaponSlot
	{
		public string weaponName;
		public bool hasGun;			// a gun is currently equipped
		public int wepNumber;		// weapon number
		public Sprite wepImage;		// sprite reference ref
		public WeaponBehavior wepBehaviour_ref;
	};

	public WeaponSlot[] weaponSlot;

	// update 
	public GameObject[] WeaponSlotsObj;	// weapon slots  Game Objects
	public int[] weaponSlotEquippedGun;	// weapon index on slot
	public Image[] weaponImage;			// image for the slot
	public Text[] weaponAmmoTxt;		// ammo text ref from weapon slots
	public bool [] weaponSlotStatus;    // true is equipping, false is empty

	public int nextSlotToEquip=0;			// checks the next slot available to equip


	// called from weapon pickup
	public  void EquipPickedUpWeapon(int index)
	{
		// check next slot to equip
		for (int i = 0; i < weaponSlotStatus.Length; i++) 
		{
				if (weaponSlotStatus [i] == false) {
					nextSlotToEquip = i;
					break;
				}
		}



		// set the numbers and image on WeaponSlot[]
		weaponSlotStatus [nextSlotToEquip] = true;
		weaponSlotEquippedGun [nextSlotToEquip] = index;
		// weapon set
		weaponSlot[index-1].hasGun = true;
		weaponImage [nextSlotToEquip].sprite = weaponSlot [index-1].wepImage;

		// Equip the new weapon for the player to use
		SelectWeapon(index);
	
		
	}

	// eqippes a player for the player, Called from weapon slots tap on slot event
	public void SelectWeapon(int wepindex)
	{
		playerWeps_ref.EquipWeapon (wepindex);
	}	



	public void WepSlotEquipWeapon(int slotNumber)
	{
		SelectWeapon(weaponSlotEquippedGun[slotNumber-1]);
	}






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