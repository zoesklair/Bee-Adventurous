using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorMovement : MonoBehaviour
{
    [SerializeField]
    private float predatorSpeed = 5f;
    GameObject bee;

    SpriteRenderer sprite;

    float xScaling;

    Vector3 predatorMovement;
    bool givenUp;
    [SerializeField]
    float secondstoChaseBee = 6f;
    float chaseTimer;

    private void Awake()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        bee = GameObject.Find("Bee");
        predatorMovement = Vector3.zero;
        givenUp = false;
        chaseTimer = 0;
        xScaling = transform.localScale.x;
    }

    // Update is called once per frame
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
            predatorMovement = beePos - transform.position;
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
