using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator : MonoBehaviour
{
    [SerializeField]
    private float predatorSpeed = 5f;
    GameObject bee;

    private void Awake()
    {
        bee = GameObject.Find("Bee");
    }

    // Start is called before the first frame update
    void Start()
    {
        
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

        Vector3 beePos = bee.transform.position;
        Vector3 predDirection = (beePos - transform.position);
        predDirection.Normalize();

        transform.position += predDirection * predatorSpeed * Time.deltaTime;

    }
}
