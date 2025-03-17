using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpriteChanger : MonoBehaviour
{
    [SerializeField]
    private Sprite[] flowerSpriteArray;
    private SpriteRenderer spriteRenderer;

    public enum FlowerSprites
    {
        NormalNoNectar = 0,
        NormalWithNectar = 1,
        CarnivorChomp = 2,
        DangerNoNectar = 3,
        DangerWithNectar = 4
    }
    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    public void UpdateFlowerSprite(FlowerSprites flowerState)
    {
        /*switch (flowerState)
        {
            case FlowerSprites.NormalNoNectar:
                spriteRenderer.sprite = flowerSpriteArray[0];
                break;
            case FlowerSprites.NormalWithNectar:
                spriteRenderer.sprite = flowerSpriteArray[1];
                break;
            case FlowerSprites.CarnivorChomp:
                spriteRenderer.sprite = flowerSpriteArray[2];
                break;
        }*/
        spriteRenderer.sprite = flowerSpriteArray[(int)flowerState];
    }
    public void ChangeColour(Color newColour)
    {
        spriteRenderer.color = newColour;
    }
}
