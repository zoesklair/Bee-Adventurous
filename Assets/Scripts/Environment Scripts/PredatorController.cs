using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorController : MonoBehaviour
{
    //[SerializeField]
    //private float chanceOfPredatorPerBlock = 0.5f;
    [SerializeField]
    GameObject predatorPrefab;
    GameObject predatorInstance;
    private GameObject groundBlock;
    private ScoreController scoreController;

    private float ChanceOfPredator
    {
        get
        {
            int score = scoreController.Score;
            if(score < 75)
            {
                return 0f;
            }
            else if(score < 200)
            {
                return 0.2f;
            }
            return 0.3f;
        }
    }

    private void Awake()
    {
        groundBlock = transform.gameObject;
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(Random.value < ChanceOfPredator)
        {
            SpawnPredator();
        }
    }

    void SpawnPredator()
    {
        //get random vertical pos between 9 and -1
        //float verticalPos = (Random.value * 10) - 1;
        float verticalPos = Random.Range(-1, 9);
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
