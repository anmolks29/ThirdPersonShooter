using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class SmgGun : MonoBehaviour
{
    public GameObject Camera;
    public float giveDamage = 10.0f;
    public float shootingRange = 100f;
    public ParticleSystem muzzleEffect;
    public GameObject bulletImpact;
    public GameObject DronebulletImpact;
    public GameObject impact;
    private float nextFire = 0f;
    public float fireRate = 15f;
    public Animator animator;

    private int maxBullets = 30;
    private int mag = 15;
    private int bulletsInMag;
    public float relodingTime = 1.3f;
    private bool reloded = false;

    public GameObject enemyHitImpact;
    public static SmgGun instance;
    public PlayerMovement playerMovement;

    private void Start()
    {
        instance = this;
    }

    private void Awake()
    {
        bulletsInMag = maxBullets;
    }
    void Update()
    {
        if (reloded)
        {
            return;
        }
        //StartReloding();
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextFire)
        {
            /*animator.SetBool("IdleAiming", true);
            animator.SetBool("Idle", false);*/
            nextFire = Time.time + 1f/fireRate;
            Shoot();

            //Debug.Log("Left mouse pressed");
        }
       /* else if (Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.Mouse0))
        {
            AimStateManager.instance.currentFov = AimStateManager.instance.adsFov;
        }*/
       /* else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("IdleAiming", false);
            animator.SetBool("FireWalk", true);
            animator.SetBool("Walk", true);
            animator.SetBool("Reloding", false);
        }
        else
        {
            animator.SetBool("Fire", false);
            animator.SetBool("Idle", true);
            animator.SetBool("FireWalk", false);
            animator.SetBool("Reloding", false);
        }*/
    }

    void Shoot()
    {
        if (mag == 0)
        {
            return;
        }
        if (bulletsInMag == 0)
        {
            mag--;
        }
        bulletsInMag--;
        muzzleEffect.Play();
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit , shootingRange))
        {
            // Debug.Log(hit.transform.name + "Left mouse pressed");
            //impact = Instantiate(bulletImpact, hit.point, Quaternion.LookRotation(hit.normal));
            Damage objectDamage = hit.transform.GetComponent<Damage>();
            EnemyMovement enemy = hit.transform.GetComponent<EnemyMovement>();
            EnemyDrone droneEnemy = hit.transform.GetComponent<EnemyDrone>();
            if (objectDamage != null)
            {
                objectDamage.HitDamage(giveDamage);
                impact = Instantiate(bulletImpact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 0.1f);
            }
            else if (enemy != null)
            {
                enemy.enemyHitDamage(giveDamage);
                impact = Instantiate(enemyHitImpact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 0.1f);
            }
            else if (droneEnemy != null)
            {
                droneEnemy.enemyHitDamage(giveDamage);
                impact = Instantiate(DronebulletImpact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 1f);
                Debug.Log("Player Hit Drone");
            }
            
        }
    }

   /* IEnumerator Relod()
    {
        playerMovement.playerSpeed = 0f;
        playerMovement.sprintSpeed = 0f;
        reloded = true;
        animator.SetBool("Reloding", true );
        //animator.SetBool("Idle", false );
        yield return new WaitForSeconds(relodingTime);
        animator.SetBool("Reloding", false);
        //animator.SetBool("Idle", true);
        bulletsInMag = maxBullets;
        playerMovement.playerSpeed = 1.9f;
        playerMovement.sprintSpeed = 3f;
        reloded = false;
    }

    public void StartReloding()
    {
        if (bulletsInMag <= 0)
        {
            StartCoroutine(Relod());
            Debug.Log("Gun Reloded");
        }
    }*/


}

