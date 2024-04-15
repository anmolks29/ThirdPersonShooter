using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemyAgent;
    public Transform playerBody;
    public LayerMask playerLayer;
    public GameObject[] walkPoints;
    public Camera shootingRayCast;
    public Transform lookPoint;

    private GameObject bulletImpact;
    public GameObject playerHitimpact;
    int currentEnemyPos;
    public float enemySpeed;
    float walkPointsRadius = 0.5f;
    public float visionRadius;
    public float shootingRadius;
    public bool playerInVisionRadius;
    public bool playerInShootingRadius;
    public float timeBtwShoot = 3;
    bool shoot;

    // Health
    private float maxHealth = 120f;
    private float currentHealth;
    private float damage = 5f;
    public Animator animator;
    private void Awake()
    {
        playerBody = GameObject.Find("Player").transform;
        enemyAgent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
    }
    private void Update()
    {
        playerInVisionRadius = Physics.CheckSphere(transform.position, visionRadius, playerLayer);
        playerInShootingRadius = Physics.CheckSphere(transform.position, shootingRadius, playerLayer);

        if (!playerInVisionRadius && !playerInShootingRadius)
        {
            Guard();
        }

        if (playerInVisionRadius && !playerInShootingRadius)
        {
            ChasePlayer();
        }

        if (playerInVisionRadius && playerInShootingRadius)
        {
            ShootPlayer();
        }
    }
    void Guard()
    {
        if (Vector3.Distance(walkPoints[currentEnemyPos].transform.position, transform.position) < walkPointsRadius)
        {
            currentEnemyPos = Random.Range(0, walkPoints.Length);
            if (currentEnemyPos >= walkPoints.Length )
            {
                currentEnemyPos = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, walkPoints[currentEnemyPos].transform.position, Time.deltaTime * enemySpeed);
        transform.LookAt(walkPoints[currentEnemyPos].transform.position);
        animator.SetBool("EnemyWalk", true);
    }

    void ChasePlayer()
    {
        if (enemyAgent.SetDestination(playerBody.position))
        {
        
          visionRadius = 5f;
          shootingRadius = 3f;
           
        }
        
    }

    void ShootPlayer()
    {
        enemyAgent.SetDestination(transform.position);
        transform.LookAt(lookPoint);

        if (!shoot)
        {
            RaycastHit hit;
            if (Physics.Raycast(shootingRayCast.transform.position,shootingRayCast.transform.forward, out hit, shootingRadius))
            {
                PlayerMovement player = hit.transform.GetComponent<PlayerMovement>();
                Debug.Log("Shooting" + hit.transform.name);

                if (player != null)
                {
                    player.PlayerHitDamage(damage);
                    bulletImpact = Instantiate(playerHitimpact, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(bulletImpact, 2f);
                }
            }
            shoot = true;
            Invoke(nameof(ActiveShooting), timeBtwShoot);
        }
    }

    void ActiveShooting()
    {
        shoot = false;
    }

    public void enemyDamage(float tookDamage)
    {
        currentHealth -= tookDamage;
        if (currentHealth <= 0)
        {
            EnemyDie();
        }
    }
    private void EnemyDie()
    {
        enemyAgent.SetDestination(transform.position);
        enemySpeed = 0;
        shootingRadius = 0;
        visionRadius = 0;
        playerInVisionRadius = false;
        playerInShootingRadius = false;
        Object.Destroy(gameObject,2.0f);

    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(enemyAgent.transform.position, visionRadius);
    }
}
