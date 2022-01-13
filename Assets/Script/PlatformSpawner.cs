using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;

    Vector3 nextspawnpoint;

    public static PlatformSpawner instance;
    
    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnPlatform();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlatform()
    {
        GameObject temp = Instantiate(platform, nextspawnpoint, Quaternion.identity);
        nextspawnpoint = temp.transform.GetChild(1).transform.position;
    }
}
