using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject car;
    public Transform[] carsPosition = new Transform[3];
    // Start is called before the first frame update
    void Start()
    {
        SpawningCar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawningCar()
    {
        int spawnPos = Random.Range(0, carsPosition.Length);
        GameObject carSpawned = Instantiate(car, carsPosition[spawnPos].transform.position, Quaternion.identity);
        
    }
}
