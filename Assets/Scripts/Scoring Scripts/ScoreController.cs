using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    //used to get screen bounds from bee movement component
    [SerializeField]
    private GameObject bee;
    private BeeMovement bm;

    [SerializeField]
    private TMP_Text scoreDisplay;
    private Vector2 ScreenBounds => bm.screenBounds;

    private float initialScreenXPos;

    public int Score
    {
        get
        {
            return scoreFromDistance;
        }
    }

    private int scoreFromDistance;

    private void Awake()
    {
        scoreFromDistance = 0;
        bm = bee.GetComponent<BeeMovement>();
        initialScreenXPos = bm.screenBounds.x;
    }
    void Update()
    {
        scoreFromDistance = (int)(ScreenBounds.x - initialScreenXPos);
        scoreDisplay.text = "Score: " + scoreFromDistance;
    }
}
