using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyController : MonoBehaviour
{
    public GameObject keyGameObject;
    public Transform[] keyPostions = new Transform[3];
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnKey();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnKey()
    {
        int spawnPos = Random.Range(0, keyPostions.Length);
        
        GameObject keySpawned = Instantiate(keyGameObject, keyPostions[spawnPos].transform.position, Quaternion.identity, keyPostions[spawnPos].transform);
        Debug.Log("Key Spawned");
    }

}
