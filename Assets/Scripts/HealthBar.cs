using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image healthBar;
    Boss boss;
    float currentHealth;
    float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        boss = FindObjectOfType<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = boss.hp;
        maxHealth = boss.maxHp;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
