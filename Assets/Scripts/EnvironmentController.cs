using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] //for testing make available to change
    private float screenBorder =  -2; //space between screen edge and edge that comes into contact with next block section

    private float blockSectionStart;
    private float blockSectionWidth;

    [SerializeField]
    private GameObject groundBlockPrefab;

    //next block section
    //when screen edge with border enters block section, create block, move section + 10

    //used to get screen bounds from bee movement component
    [SerializeField]
    private GameObject bee;
    private BeeMovement bm;
    private Vector2 ScreenBounds => bm.screenBounds;

    private void Awake()
    {
        bm = bee.GetComponent<BeeMovement>();
        blockSectionStart = 15;
        blockSectionWidth = 10;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(ScreenBounds.x);
        if((ScreenBounds.x + screenBorder) > blockSectionStart)
        {
            MakeBlock();
            blockSectionStart += blockSectionWidth;
        }
    }

    void MakeBlock()
    {
        //Debug.Log("make block");
        GameObject groundBlock = Instantiate(groundBlockPrefab);
        Vector3 blockPos = new(blockSectionStart + (blockSectionWidth / 2), -4.5f, 0);
        groundBlock.transform.position = blockPos;

    }
}
