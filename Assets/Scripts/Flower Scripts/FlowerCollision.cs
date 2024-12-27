using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCollision : MonoBehaviour
{
    [SerializeField]
    GameObject bee;

    Collider2D beeCollider;
    Collider2D flowerCollider;
    private void Awake()
    {
        beeCollider = bee.GetComponent<Collider2D>();
        flowerCollider = GetComponent<Collider2D>();
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
            Debug.Log("hit!");
        }
    }
}
