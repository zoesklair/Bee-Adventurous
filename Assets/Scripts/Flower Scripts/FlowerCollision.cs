using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCollision : MonoBehaviour
{
    GameOverController gameOverController;

    GameObject bee;

    Collider2D beeCollider;
    Collider2D flowerCollider;
    Nectar flowerNectar;
    CarnivorousFlower1 carnivorFlower;
    private void Awake()
    {
        bee = GameObject.Find("Bee");
        beeCollider = bee.GetComponent<Collider2D>();
        gameOverController = GameObject.Find("GameOverController").GetComponent<GameOverController>();
        flowerCollider = GetComponent<Collider2D>();
        flowerNectar = GetComponent<Nectar>();
        carnivorFlower = GetComponent<CarnivorousFlower1>();
    }

    void Update()
    {
        if (beeCollider.bounds.Intersects(flowerCollider.bounds) && Time.timeScale == 1f) //check intersection when game is running
        {
            if (carnivorFlower.flowerIsCarnivorous && carnivorFlower.flowerIsChomping) //chomped by carnivorous flower
            {
                Debug.Log("FlowerCollision: eaten by flower - game over");
                gameOverController.SetGameOver();
            }
            if(Input.GetKeyDown(KeyCode.Space) && flowerNectar.FlowerHasNectar) //collect nectar
            {
                flowerNectar.CollectNectar();
            }
        }
    }
}
