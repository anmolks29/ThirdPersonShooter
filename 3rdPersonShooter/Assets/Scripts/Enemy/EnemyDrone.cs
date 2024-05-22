using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDrone : MonoBehaviour
{
    //public NavMeshAgent enemyAgent;
    public Transform playerBody;
    public LayerMask playerLayer;
    public Transform lookPoint;
    public Camera shootingRayCast;

    public GameObject[] walkPoints;
    int currentEnemyPosition = 0;
    public float enemySpeed;
    float walkingPointRadious = 13;

    public float visionRadius;
    public float shootingRadius;
    public bool playerInVisionRadious;
    public bool playerInShootingRadious;
    public bool chasingPlayer;
    public bool guarding;

    public float timeBtwShoot;
    bool previouslyShoot;

    private float enemyHealth = 120f;
    private float currentHealth;
    public float giveDamage = 5f;
    public HealthBar healthBar;

    public ParticleSystem muzzleSpark;
    public ParticleSystem muzzleFlame;
    public ParticleSystem destroyEffect;
    public Animator animator;

    public AudioClip shootingSound;
    public AudioSource audioSource;

    private void Awake()
    {
        playerBody = GameObject.Find("Player").transform;
       // enemyAgent = GetComponent<NavMeshAgent>();
        currentHealth = enemyHealth;
        healthBar.SetHealthToMax(currentHealth);
    }
    private void Update()
    {
        playerInVisionRadious = Physics.CheckSphere(transform.position, visionRadius, playerLayer);
        playerInShootingRadious = Physics.CheckSphere(transform.position, shootingRadius, playerLayer);

        if (!playerInVisionRadious && !playerInShootingRadious)
        {
            Guard();
        }
        if (playerInVisionRadious && !playerInShootingRadious)
        {
            ChasePlayer();
        }
        if (playerInVisionRadious && playerInShootingRadious)
        {
            ShootPlayer();
        }

    }

    private void Guard()
    {
        if (Vector3.Distance(walkPoints[currentEnemyPosition].transform.position, transform.position) < walkingPointRadious)
        {
            guarding = true;
            currentEnemyPosition = Random.Range(0, walkPoints.Length);
            if (currentEnemyPosition >= walkPoints.Length)
            {
                currentEnemyPosition = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, walkPoints[currentEnemyPosition].transform.position, Time.deltaTime * enemySpeed);
        transform.LookAt(walkPoints[currentEnemyPosition].transform.position);
    }

    private void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerBody.transform.position, Time.deltaTime * enemySpeed);
        chasingPlayer = true;
        //Debug.Log("Chasing Player");
        if (chasingPlayer == true)
        {
            animator.SetBool("Walk", false);
            animator.SetBool("AimRun", true);
            animator.SetBool("Shoot", false);

            animator.SetBool("Die", false);
            visionRadius = 10;
            shootingRadius = 8;
        }
        else
        {
            animator.SetBool("Walk", false);
            animator.SetBool("AimRun", false);
            animator.SetBool("Shoot", false);

            animator.SetBool("Die", true);
        }
        chasingPlayer = false;
    }

    private void ShootPlayer()
    {
       // enemyAgent.SetDestination(transform.position);
        

        transform.LookAt(playerBody);
        if (!previouslyShoot)
        {
            muzzleSpark.Play();
            muzzleFlame.Play();
            audioSource.PlayOneShot(shootingSound);
            RaycastHit hit;
            if (Physics.Raycast(shootingRayCast.transform.position, shootingRayCast.transform.forward, out hit, shootingRadius))
            {
                Debug.Log("Drone Shooting" + hit.transform.name);
                MovementStateManager playerBody = hit.transform.GetComponent<MovementStateManager>();
                if (playerBody != null)
                {
                    playerBody.PlayerHitDamage(giveDamage);
                }
                animator.SetBool("Shoot", true);
                animator.SetBool("Walk", false);
                animator.SetBool("AimRun", false);

                animator.SetBool("Die", false);
                
            }
            previouslyShoot = true;
            Invoke(nameof(ActiveShooting), timeBtwShoot);
        }
    }

    private void ActiveShooting()
    {
        previouslyShoot = false;
    }

    public void enemyHitDamage(float takedamage)
    {
        currentHealth -= takedamage;
        healthBar.SetHealthToCurrent(currentHealth);
        if (currentHealth <= 0)
        {
            animator.SetBool("Walk", false);
            animator.SetBool("AimRun", false);
            animator.SetBool("Shoot", false);

            animator.SetBool("Die", true);
            enemyDie();
        }
    }

    private void enemyDie()
    {
        //enemyAgent.SetDestination(transform.position);
        destroyEffect.Play();
        enemySpeed = 0;
        shootingRadius = 0;
        visionRadius = 0;
        playerInShootingRadious = false;
        playerInVisionRadious = false;
        Object.Destroy(gameObject, 3.0f);
    }
}
