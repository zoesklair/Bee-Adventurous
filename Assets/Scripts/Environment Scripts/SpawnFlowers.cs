using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlowers : MonoBehaviour
{
    [SerializeField]
    private GameObject flowerPrefab;

    private List<GameObject> containedObjects; //store flowers to destroy when ground block is off-screen
    private ScoreController scoreController;

    private float ChanceOfFlowerSpawning //increase difficulty as score gets higher
    {
        get
        {
            int score = scoreController.Score;
            if (score < 100)
            {
                return 1.0f;
            }
            else if (score < 300)
            {
                return 0.85f;
            }
            else if (score < 500)
            {
                return 0.75f;
            }
            else if (score < 1000)
            {
                return 0.7f;
            }
            else return 0.6f;
        }
    }

    private void Awake()
    {
        containedObjects = new List<GameObject>();
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
    }

    //flower spawning code for uniform ground
    /*GameObject SpawnFlowersOnBlock()
    {
        
        float blockSectionWidth = transform.localScale.x;
        float blockSectionStart = transform.position.x - blockSectionWidth/2;

        float flowerPosX = Random.Range(blockSectionStart, blockSectionStart + blockSectionWidth);
        Vector3 flowerPos = new Vector3(flowerPosX, -3.75f, 0);
        Quaternion flowerRot = Quaternion.identity;
        GameObject spawnedFlower = Instantiate(flowerPrefab, flowerPos, flowerRot);
        return spawnedFlower; 
    }*/
    void SpawnFlowersOnSpawnPoints()
    {
        List<GameObject> spawnPoints = GetSpawnPoints();
        if(spawnPoints.Count > 0)
        {
            //check if flower should spawn
            float randomFloat = Random.value;
            if(randomFloat < ChanceOfFlowerSpawning)
            {
                Debug.Log("flower is spawning: " + randomFloat + " out of " + ChanceOfFlowerSpawning);
                //choose spawn point
                int index = Random.Range(0, spawnPoints.Count);
                Transform spTransform = spawnPoints[index].transform;
                Vector3 flowerPos = new Vector3(spTransform.position.x, spTransform.position.y, 0);
                Quaternion flowerRot = Quaternion.identity;
                GameObject spawnedFlower = Instantiate(flowerPrefab, flowerPos, flowerRot);
                containedObjects.Add(spawnedFlower);
            }
        }

    }
    private List<GameObject> GetSpawnPoints()
    {
        List<GameObject> spawnPoints = new List<GameObject>();
        foreach (Transform child in gameObject.transform)
        {
            if (child.name == "SpawnPoint")
            {
                spawnPoints.Add(child.gameObject);
            }
        }
        return spawnPoints;
    }
    void Start()
    {
        SpawnFlowersOnSpawnPoints();
    }

    private void OnDestroy()
    {
        foreach(GameObject go in containedObjects)
        {
            Destroy(go);
        }    
    }
}
