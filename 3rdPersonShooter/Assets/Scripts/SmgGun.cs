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

    public AudioClip shootingSound;
    public AudioClip relodingSound;
    
    public AudioSource audioSource;


    public GameObject enemyHitImpact;
    public static SmgGun instance;
    public MovementStateManager playerMovement;

    private void Start()
    {
        instance = this;
    }

    private void Awake()
    {
        bulletsInMag = maxBullets;
        AmmoCount.Instance.UpdateAmmoMax(bulletsInMag);
    }
    void Update()
    {
        if (reloded)
        {
            return;
        }

        if (bulletsInMag<=0) 
        {
            StartReloding();
            
        }
        
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextFire)
        {
            
            nextFire = Time.time + 1f/fireRate;
            Shoot();
           
        }
       
    }

    void Shoot()
    {
        if (mag == 0)
        {
            return;
        }
        bulletsInMag--;
        if (bulletsInMag == 0)
        {
            mag--;
            
        }

        AmmoCount.Instance.UpdateAmmoCurrent(bulletsInMag);
        AmmoCount.Instance.UpdateMag(mag);
        
        muzzleEffect.Play();
        audioSource.PlayOneShot(shootingSound);
       
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit , shootingRange))
        {
            // Debug.Log(hit.transform.name + "Left mouse pressed");
            //impact = Instantiate(bulletImpact, hit.point, Quaternion.LookRotation(hit.normal));
            Damage objectDamage = hit.transform.GetComponent<Damage>();
            EnemyMovement enemy = hit.transform.GetComponent<EnemyMovement>();
            EnemyDrone droneEnemy = hit.transform.GetComponent<EnemyDrone>();
            KeyFunction key = hit.transform.GetComponent<KeyFunction>();
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
            else if (hit.collider.tag == "key")
            {
                Debug.Log("Key has detected raycast ");
                KeyFunction.Instance.DetachFromParent();

            }
        }
    }

    IEnumerator Relod()
    {
       /* playerMovement.walkSpeed = 0f;
        playerMovement.runSpeed = 0f;*/
        reloded = true;
        animator.SetBool("Relod", true );
        
        audioSource.PlayOneShot(relodingSound);
        yield return new WaitForSeconds(relodingTime);
        animator.SetBool("Relod", false);
        animator.SetBool("Idle", true);
        bulletsInMag = maxBullets;
        AmmoCount.Instance.UpdateAmmoCurrent(bulletsInMag);
        reloded = false;
    }

    public void StartReloding()
    {

       StartCoroutine(Relod());
       Debug.Log("Gun Reloded");
    } 


}

