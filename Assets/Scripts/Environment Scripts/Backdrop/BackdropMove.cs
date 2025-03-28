using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackdropMove : MonoBehaviour
{
    BeeMovement bm;
    private Vector3 ScreenBounds => bm.screenBounds;
    private float savedScreenEdgePos;
    private float rateOfMove = 0.5f; //fraction of bee's speed
    private void Awake()
    {
        bm = GameObject.Find("Bee").GetComponent<BeeMovement>();
        savedScreenEdgePos = ScreenBounds.x;
    }
    private void Update()
    {
        float screenEdgeChange = ScreenBounds.x - savedScreenEdgePos;
        transform.position += new Vector3(screenEdgeChange * rateOfMove, 0, 0);
        savedScreenEdgePos = ScreenBounds.x;
    }
}
