using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    [SerializeField]
    GameObject backdropPrefab;
    GameObject currentBackdrop;
    BeeMovement bm;
    private Vector3 ScreenBounds => bm.screenBounds;
    private float BackgroundEdgePos => currentBackdrop.transform.position.x + backdropWidth/2;
    private float backdropWidth;
    void Awake()
    {
        bm = GameObject.Find("Bee").GetComponent<BeeMovement>();
        currentBackdrop = GameObject.Find("Backdrop");
        backdropWidth = 35.54f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((ScreenBounds.x + 2) > BackgroundEdgePos) //create new backdrop when current screen bound is nearing edge
        {
            currentBackdrop = RepeatBackdrop();
        }
    }

    GameObject RepeatBackdrop()
    {
        GameObject newBackdrop = Instantiate(backdropPrefab, transform);
        newBackdrop.transform.position = new Vector3(BackgroundEdgePos + backdropWidth/2, transform.position.y, transform.position.z);
        return newBackdrop;
    }
}
