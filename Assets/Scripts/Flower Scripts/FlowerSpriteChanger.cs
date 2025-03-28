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
        CarnivorChomp = 2
    }
    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    public void UpdateFlowerSprite(FlowerSprites flowerState)
    {
        spriteRenderer.sprite = flowerSpriteArray[(int)flowerState];
    }
    public void ChangeColour(Color newColour)
    {
        spriteRenderer.color = newColour;
    }
}
