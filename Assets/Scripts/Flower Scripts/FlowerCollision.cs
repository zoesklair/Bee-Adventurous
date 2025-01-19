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
    CarnivorousFlower carnivorFlower;
    private void Awake()
    {
        bee = GameObject.Find("Bee");
        beeCollider = bee.GetComponent<Collider2D>();
        gameOverController = GameObject.Find("GameOverController").GetComponent<GameOverController>();
        flowerCollider = GetComponent<Collider2D>();
        flowerNectar = GetComponent<Nectar>();
        carnivorFlower = GetComponent<CarnivorousFlower>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (beeCollider.bounds.Intersects(flowerCollider.bounds))
        {
            //Debug.Log("hit!");
            if(carnivorFlower.flowerIsCarnivorous && carnivorFlower.flowerIsChomping)
            {
                Debug.Log("Game Over!");
                gameOverController.SetGameOver();
            }
            if(Input.GetKeyDown(KeyCode.Space) && flowerNectar.FlowerHasNectar)
            {
                flowerNectar.CollectNectar();
            }
        }
    }
}
