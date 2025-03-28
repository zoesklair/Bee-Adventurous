using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nectar : MonoBehaviour
{
    GameObject bee;
    Energy beeEnergy;
    FlowerSpriteChanger spriteChanger;

    private float energyFromNectar = 20;

    private bool flowerHasNectar;
    public bool FlowerHasNectar => flowerHasNectar;

    private void Awake()
    {
        spriteChanger = gameObject.GetComponent<FlowerSpriteChanger>();
        bee = GameObject.Find("Bee");
        beeEnergy = bee.GetComponent<Energy>();
    }
    void Start()
    {
        //flower begins with nectar
        spriteChanger.UpdateFlowerSprite(FlowerSpriteChanger.FlowerSprites.NormalWithNectar);
        flowerHasNectar = true;
    }

    public void CollectNectar()
    {
        //energy goes up
        beeEnergy.UpdateEnergy(energyFromNectar);
        flowerHasNectar = false;
        spriteChanger.UpdateFlowerSprite(FlowerSpriteChanger.FlowerSprites.NormalNoNectar);
    }
}
