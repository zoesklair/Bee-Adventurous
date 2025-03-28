using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorMovement : MonoBehaviour
{
    [SerializeField]
    private float predatorSpeed = 5f;
    GameObject bee;

    float xScaling; //for flipping sprite & collider based on direction of movement

    Vector3 predatorMovement;
    Vector3 PredatorHeadPos => transform.position + new Vector3(-0.86f, 0.52f, 0f);
    bool givenUp;
    [SerializeField]
    float secondstoChaseBee = 6f;
    float chaseTimer;

    private void Awake()
    {
        bee = GameObject.Find("Bee");
        predatorMovement = Vector3.zero;
        givenUp = false;
        chaseTimer = 0;
        xScaling = transform.localScale.x;
    }

    void Update()
    {
        MovePredator();
        CheckIfOffScreen();
    }

    void MovePredator()
    {
        //make predator follow bee
        if(!givenUp)
        {
            Vector3 beePos = bee.transform.position;
            predatorMovement = beePos - PredatorHeadPos;
            predatorMovement.Normalize();
            
            chaseTimer += Time.deltaTime;
            if(chaseTimer >= secondstoChaseBee)
            {
                givenUp = true;
                //move off screen upwards
                predatorMovement.y = 1;
                
            }
        }

        if(predatorMovement.x > 0)
        {
            gameObject.transform.localScale = new Vector3(-xScaling, transform.localScale.y, transform.localScale.z);
        }
        else if(predatorMovement.x < 0)
        {
            gameObject.transform.localScale = new Vector3(xScaling, transform.localScale.y, transform.localScale.z);
        }
        transform.position += predatorMovement * predatorSpeed * Time.deltaTime;
    }

    void CheckIfOffScreen()
    {
        if(givenUp && transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }
}
