using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGroundBlock : MonoBehaviour
{
    //get screen bounds
    private GameObject bee;
    private BeeMovement bm;
    private Vector2 ScreenBounds => bm.screenBounds;

    private void Awake()
    {
        bee = GameObject.Find("Bee");
        bm = bee.GetComponent<BeeMovement>();
    }

    void Update()
    {
        if(transform.position.x < (ScreenBounds.x - bm.screenWidth) - 10) //when ground goes past left screen edge
        {
            Destroy(gameObject);
        }
    }
}
