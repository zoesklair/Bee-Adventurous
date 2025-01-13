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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < (ScreenBounds.x - bm.screenWidth) - 10)
        {
            //Debug.Log("destroy block");
            Destroy(gameObject);
        }
    }
}
