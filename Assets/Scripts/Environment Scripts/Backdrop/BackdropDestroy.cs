using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackdropDestroy : MonoBehaviour
{
    BeeMovement bm;
    private Vector3 ScreenBounds => bm.screenBounds;

    private void Awake()
    {
        bm = GameObject.Find("Bee").GetComponent<BeeMovement>();
    }
    void Update()
    {
        if (transform.position.x < (ScreenBounds.x - 2*bm.screenWidth) - 2) //if off screen
        {
            Destroy(gameObject);
        }
    }
}
