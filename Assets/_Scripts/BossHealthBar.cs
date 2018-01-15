using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour {

    public Image bossBar;
    public CharacterDamage bossEnemy;
    float maxHealthOfBoss;

    private void Start()
    {
        maxHealthOfBoss = bossEnemy.hitPoints;
    }

    void Update()
    {
        bossBar.fillAmount = Mathf.InverseLerp(0, maxHealthOfBoss, bossEnemy.hitPoints);
    }
}
