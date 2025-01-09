using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlowers : MonoBehaviour
{
    [SerializeField]
    private GameObject flowerPrefab;

    private List<GameObject> containedObject;
    private void Awake()
    {
        containedObject = new List<GameObject>();
    }
    void SpawnFlowersOnBlock()
    {
        
        float blockSectionWidth = transform.localScale.x;
        Debug.Log("block width: " + blockSectionWidth);
        float blockSectionStart = transform.position.x - blockSectionWidth/2;
        Debug.Log("blockSectionStart: " + blockSectionWidth);

        float flowerPosX = Random.Range(blockSectionStart, blockSectionStart + blockSectionWidth);
        Vector3 flowerPos = new Vector3(flowerPosX, -3.75f, 0);
        Quaternion flowerRot = Quaternion.identity;
        GameObject spawnedFlower = Instantiate(flowerPrefab, flowerPos, flowerRot);
        containedObject.Add(spawnedFlower);
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnFlowersOnBlock();
    }

    private void OnDestroy()
    {
        foreach(GameObject go in containedObject)
        {
            Destroy(go);
        }    
    }
}
