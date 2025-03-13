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
        //get random vertical pos between 5 and -3
        float verticalPos = (Random.value * 12) - 3;
        float horizPos = groundBlock.transform.position.x;
        //if vertical position is high, chance of parrot spawning from above instead of the side
        if(verticalPos > 5.5f)
        {
            float max = groundBlock.transform.position.x - groundBlock.transform.localScale.x/2;
            float min = groundBlock.transform.position.x - groundBlock.transform.localScale.x;
            horizPos = Random.value * (max-min) + min;
        }
        Vector3 predPos = new Vector3(horizPos, verticalPos, 0);
        Quaternion predRot = Quaternion.identity;
        Debug.Log("predatorcontroller: spawn predator");
        predatorInstance = Instantiate(predatorPrefab, predPos, predRot);
    }
}
