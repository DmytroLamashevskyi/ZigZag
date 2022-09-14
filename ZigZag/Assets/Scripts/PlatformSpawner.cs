using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public float createDuration;
    public GameObject prefub;
    public Transform lastPlatform;
    Vector3 lastPostion;
    Vector3 newPosition;
    bool isStop;

    // Start is called before the first frame update
    void Start()
    {
        lastPostion = lastPlatform.position;
        StartCoroutine(SpawnPlatforms());
    }

    // Update is called once per frame
    IEnumerator SpawnPlatforms()
    {
        while(!isStop)
        {
            GeneratePosition(); 
            Instantiate(prefub, newPosition, Quaternion.identity);
            lastPostion = newPosition;

            yield return new WaitForSeconds(createDuration);
        }

    } 

    void GeneratePosition()
    {
        newPosition = lastPostion;

        if(Random.Range(0,2)==0)
        {
            newPosition.x += 2;
        }
        else
        {
            newPosition.z += 2;
        }  
    }


}
