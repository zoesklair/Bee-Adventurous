using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] //for testing make available to change
    private float screenBorder =  -2f; //space between screen edge and edge that comes into contact with next block section

    private float blockSectionStart;
    private float blockSectionWidth;

    [SerializeField]
    private GameObject groundBlockPrefab;

    //used to get screen bounds from bee movement component
    [SerializeField]
    private GameObject bee;
    private BeeMovement bm;
    private Vector2 ScreenBounds => bm.screenBounds;

    private void Awake()
    {
        bm = bee.GetComponent<BeeMovement>();
        blockSectionStart = 15;
        blockSectionWidth = groundBlockPrefab.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if((ScreenBounds.x + screenBorder) > blockSectionStart)
        {
            MakeBlock();
            blockSectionStart += blockSectionWidth;
        }
    }

    GameObject MakeBlock()
    {
        GameObject groundBlock = Instantiate(groundBlockPrefab);
        Vector3 blockPos = new(blockSectionStart + (blockSectionWidth / 2), -4.5f, 0);
        groundBlock.transform.position = blockPos;

        return groundBlock;
    }

    
}
