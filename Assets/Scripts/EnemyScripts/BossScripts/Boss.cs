using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Boss : MonoBehaviour, IHasCoolDown
{
    private Vector3 startPos;
    private Vector3 finalPos;
    private Vector3 crashDirection;

    private readonly float speed = 2f;

    private bool ready;
    private bool dead;

    private int attack;
    public int maxHp = 150;
    public int hp;

    private Transform weaponParent;
    private Transform laser;
    private Transform missle;
    private Transform beam;

    [SerializeField] private CooldownSystem cooldownSystem;
    private GameObject player;
    private PlayerController playerscript;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] TextMeshProUGUI congrats;
    [SerializeField] Image healthBar;

    public int Id { get; private set; }
    public float CooldownDuration { get; private set; }


    // Start is called before the first frame update
    private void Start()
    {
        startPos = new Vector3(25, 0, 0);
        finalPos = new Vector3(13, 0, 0);
        crashDirection = new Vector3(10, -14, 0);
        transform.position = startPos;
        hp = maxHp;
        weaponParent = transform.GetChild(2);
        GetWeapons();
        ready = false;
        player = GameObject.Find("Player");
        attack = 1;
        InvokeRepeating("RandomAttack", 5, 2.2f);
        dead = false;
        healthBar.gameObject.SetActive(true);
        playerscript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (!ready)
        {
            Movement();
        }
        if (playerscript.m_death)
        {
            CancelInvoke("RandomAttack");
        }
        if (dead)
        {
            CancelInvoke("RandomAttack");
            Crash();
        }
    }

    private void Movement()
    {
        if (transform.position != finalPos)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, finalPos, step);
            ready = false;
        }
        else
        {
            ready = true;
        }
    }

    private void Crash()
    {
        if(transform.GetChild(2).gameObject.activeSelf)
        {
            transform.GetChild(2).gameObject.SetActive(false);
        }
        if(transform.position != crashDirection)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, crashDirection, step);
        }
        else
        {
            playerscript.score += 90;
            congrats.gameObject.SetActive(true);
            if (playerscript.score == 200)
            {
                congrats.text = "You got the best possible score! Congratulations!";
            }
            else
            {
                congrats.text = "Final Score: " + playerscript.score;
            }
            healthBar.gameObject.SetActive(false);
            CancelInvoke(nameof(SpawnRandomExplosions));
            gameObject.SetActive(false);
        }
    }

    private void SpawnRandomExplosions()
    {
        Vector3 randomSpawn = transform.position + new Vector3(Random.Range(-5f, 0f), Random.Range(-2f, 2f), -1);
        Instantiate(explosion,randomSpawn,explosion.transform.rotation);
    }

    public void TakeDamage()
    {
        DamageFlash damageFlash = FindObjectOfType<DamageFlash>();
        if (hp > 0)
        {
            hp--;
            damageFlash.StartCoroutine(damageFlash.Flash());
        }
        if (hp <= 0 && !dead)
        {
            hp = 0;
            dead = true;
            InvokeRepeating(nameof(SpawnRandomExplosions), 0, 1);
        }
    }

    private void RandomAttack()
    {
        if (ready && player)
        {
            if (hp < (maxHp * 0.5f))
            {
                attack = Random.Range(1, 5);
                Attack();
                attack = Random.Range(1, 4);
                Attack();
                //yield return new WaitForSeconds(2);
            }
            else if (hp > (maxHp * 0.5f))
            {
                attack = Random.Range(1, 4);
                Attack();
                //yield return new WaitForSeconds(2);
            }
        }
        //yield return new WaitForSeconds(1);
    }

    void Attack()
    {
        switch (attack)
        {
            case 1:
                //do attack 1
                Attack1();
                break;
            case 2:
                //do attack 2
                Attack2();
                break;
            case 3:
                //do attack 3
                Attack3();
                break;
            case 4:
                Attack1();
                Attack2();
                Attack3();
                break;
            default:
                //do attack 1
                Attack1();
                break;
        }
    }

    private void GetWeapons()
    {
        laser = weaponParent.GetChild(0).GetChild(0);
        missle = weaponParent.GetChild(1);
        beam = weaponParent.GetChild(2).GetChild(0);
    }
    public void Attack1()
    {
        Id = 1;
        CooldownDuration = 4f;
        //public int Id => attack1Id;
        //public float cooldownDuration => 6f;
        //if (cooldownSystem.IsOnCooldown(attack1Id))
        if (!cooldownSystem.IsOnCooldown(Id))
        {
            laser.gameObject.SetActive(true);
            cooldownSystem.PutOnCooldown(this);
        }
    }
    void Attack2()
    {
        Id = 2;
        CooldownDuration = 3f;
        if (!cooldownSystem.IsOnCooldown(Id))
        {
            int randomIndex = Random.Range(0, 2);
            if (!missle.GetChild(randomIndex).gameObject.activeSelf)
            {
                missle.GetChild(randomIndex).gameObject.SetActive(true);
                cooldownSystem.PutOnCooldown(this);
            }
        }
    }
    void Attack3()
    {
        Id = 3;
        CooldownDuration = 5.5f;
        if (!cooldownSystem.IsOnCooldown(Id))
        {
            beam.gameObject.SetActive(true);
            cooldownSystem.PutOnCooldown(this);
        }
    }
}

