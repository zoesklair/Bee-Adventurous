using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorController : MonoBehaviour
{
    [SerializeField]
    private float chanceOfPredatorPerBlock = 0.5f;
    [SerializeField]
    GameObject predatorPrefab;
    GameObject predatorInstance;

    private GameObject groundBlock;

    private void Awake()
    {
        groundBlock = transform.gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(Random.value < chanceOfPredatorPerBlock)
        {
            SpawnPredator();
        }
    }

    void SpawnPredator()
    {
        Vector3 predPos = new Vector3(groundBlock.transform.position.x, 5, 0);
        Quaternion predRot = Quaternion.identity;
        Debug.Log("predatorcontroller: spawn predator");
        predatorInstance = Instantiate(predatorPrefab, predPos, predRot);
    }
}
