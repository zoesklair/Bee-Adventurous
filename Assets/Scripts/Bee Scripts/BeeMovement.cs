using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour
{
    [SerializeField]
    private float beeSpeed = 5f;

    [SerializeField]
    private float hoverH = 0.1f;
    [SerializeField]
    private float hoverF = 1f;

    [SerializeField]
    private GameObject mainCamera;


    public float screenWidth;
    public Vector2 screenBounds;

    private SpriteRenderer beeSprite;
    private bool beeFacingRight;

    private void Awake()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        screenWidth = screenBounds.x * 2;

        beeSprite = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        beeFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        HoverBee();
        MoveBee();
    }
    void HoverBee()
    {
        Vector3 hover = new Vector3(0, hoverH * Mathf.Sin(hoverF * Time.time), 0);
        transform.position += beeSpeed * Time.deltaTime * hover;
    }

    void MoveBee()
    {
        Vector3 userMovement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += beeSpeed * Time.deltaTime * userMovement;

        //make bee face direction of movement
        CheckBeeSpriteDirection(userMovement.x);

        //clamp position
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, screenBounds.x - screenWidth, screenBounds.x);
        clampedPos.y = Mathf.Clamp(clampedPos.y, screenBounds.y * -1, screenBounds.y);
        transform.position = clampedPos;

        //set boundary where screen should start scrolling 3/4 across screen
        float scrollBoundaryPos = screenBounds.x - (0.25f * screenWidth);
        if (userMovement.x > 0 && transform.position.x >= scrollBoundaryPos)
        {
            //Debug.Log("move camera");
            Vector3 cameraMove = new Vector3(userMovement.x, 0, 0) * beeSpeed * Time.deltaTime; 
            mainCamera.transform.position += cameraMove;
            //update screenbounds
            screenBounds.x += cameraMove.x;
        }
    }

    void CheckBeeSpriteDirection(float horizontalMovement)
    {
        if (horizontalMovement > 0)
        {
            beeSprite.flipX = false;
        }
        else if (horizontalMovement < 0)
        {
            beeSprite.flipX = true;
            //Debug.Log("face left");
        }
    }
}
