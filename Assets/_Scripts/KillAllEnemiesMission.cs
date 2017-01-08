using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KillAllEnemiesMission : MonoBehaviour {


	public int enemiesLeft;

	public Text enemiesLeftText;

	public int enemyCounter;

	public int EnemyCounter
	{
		get
		{
			return enemyCounter;	
		}

		set
		{
			enemyCounter = value;

			enemiesLeft = enemyCounter;
			enemiesLeftText.text = "" + enemiesLeft;

			if (enemyCounter == 0) 
			{
				// Start level completed Event...
			}
				
		}


	}












}
