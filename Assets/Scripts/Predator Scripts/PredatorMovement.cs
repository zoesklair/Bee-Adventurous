using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorMovement : MonoBehaviour
{
    [SerializeField]
    private float predatorSpeed = 5f;
    [SerializeField]
    private float distanceToLockOn = 1f;
    GameObject bee;
    Vector3 predatorMovement;
    bool givenUp;

    private void Awake()
    {
        bee = GameObject.Find("Bee");
        predatorMovement = Vector3.zero;
        givenUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovePredator();
    }

    void MovePredator()
    {
        //get bee transform
        //make vector from predator to bee pos
        // move in that direction


        float dist = Vector3.Distance(bee.transform.position, transform.position);
        if(dist > distanceToLockOn && !givenUp)
        {
            Vector3 beePos = bee.transform.position;
            predatorMovement = beePos - transform.position;
            predatorMovement.Normalize();
        }
        givenUp = true;
        transform.position += predatorMovement * predatorSpeed * Time.deltaTime;


        /*if(predatorMovement == Vector3.zero)
        {
            Vector3 beePos = bee.transform.position;
            predatorMovement = beePos - transform.position;
            predatorMovement.Normalize();
        }*/
        //Vector3 beePos = bee.transform.position;
        //Vector3 predDirection = (beePos - transform.position);
        //predDirection.Normalize();

        transform.position += predatorMovement * predatorSpeed * Time.deltaTime;

    }
}
