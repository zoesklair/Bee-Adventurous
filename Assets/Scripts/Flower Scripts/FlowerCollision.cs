using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCollision : MonoBehaviour
{
    GameObject bee;

    Collider2D beeCollider;
    Collider2D flowerCollider;
    Nectar flowerNectar;
    private void Awake()
    {
        bee = GameObject.Find("Bee");
        beeCollider = bee.GetComponent<Collider2D>();
        flowerCollider = GetComponent<Collider2D>();
        flowerNectar = GetComponent<Nectar>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (beeCollider.bounds.Intersects(flowerCollider.bounds))
        {
            //Debug.Log("hit!");
            if(Input.GetKeyDown(KeyCode.Space) && flowerNectar.FlowerHasNectar)
            {
                flowerNectar.CollectNectar();
            }
        }
    }
}
