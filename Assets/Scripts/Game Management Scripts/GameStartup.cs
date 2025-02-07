using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartup : MonoBehaviour
{
    [SerializeField]
    GameObject bee;
    [SerializeField]
    GameObject camera;

    BeeMovement beeMovement;

    Vector3 beeStartPos = Vector3.zero;
    Vector3 camStartPos = new Vector3(0, 0, -10);

    public Vector2 originalScreenBounds;

    public void Awake()
    {
        beeMovement = bee.GetComponent<BeeMovement>();
        originalScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    public void SetUpGame()
    {
        bee.transform.position = beeStartPos;
        beeMovement.screenBounds = originalScreenBounds;
        camera.transform.position = camStartPos;
    }
}
