using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject coin;
    // GameObject obstacle1;
    //public GameObject obstacle2;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
        SpawnCoin();
        //SpawnObstacle1();
        //SpawnObstacle2();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        PlatformSpawner.instance.SpawnPlatform();
        Destroy(gameObject, 2f);
    }

    public void SpawnObstacle()
    {
        int rand = Random.Range(2, 5);
        Transform spawnpoint = transform.GetChild(rand).transform;
        Instantiate(obstacle, spawnpoint.position, Quaternion.identity, transform);
    }

    public void SpawnCoin()
    {
        int rand = Random.Range(5, 8);
        Transform spawnpoint = transform.GetChild(rand).transform;
        Instantiate(coin, spawnpoint.position, coin.transform.rotation, transform);

        int rand1 = Random.Range(8, 11);
        Transform spawnpoint1 = transform.GetChild(rand1).transform;
        Instantiate(coin, spawnpoint1.position, coin.transform.rotation, transform);
    }

    // public void SpawnObstacle1()
    // {
    //     int rand = Random.Range(2,5);
    //     Transform spawnpoint = transform.GetChild(rand).transform;
    //     Instantiate(obstacle1, spawnpoint.position, Quaternion.identity, transform);
    // }

    // public void SpawnObstacle2()
    // {
    //     int rand = Random.Range(2,5);
    //     Transform spawnpoint = transform.GetChild(rand).transform;
    //     Instantiate(obstacle2, spawnpoint.position, Quaternion.identity, transform);
    // }
}
