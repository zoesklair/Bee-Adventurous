using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorCollision : MonoBehaviour
{
    GameOverController gameOverController;

    GameObject bee;

    Collider2D beeCollider;
    Collider2D predatorCollider;

    private void Awake()
    {
        bee = GameObject.Find("Bee");
        beeCollider = bee.GetComponent<Collider2D>();
        gameOverController = GameObject.Find("GameOverController").GetComponent<GameOverController>();
        predatorCollider = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (beeCollider.bounds.Intersects(predatorCollider.bounds) && Time.timeScale == 1f)
        {
            Debug.Log("PredatorCollision: Eaten!");
            gameOverController.SetGameOver();
        }
    }
}
