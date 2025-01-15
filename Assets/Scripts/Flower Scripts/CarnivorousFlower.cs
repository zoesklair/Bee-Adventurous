using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivorousFlower : MonoBehaviour
{
    [SerializeField]
    Sprite flowerChomp, flowerNormal;
    SpriteRenderer spriteRenderer;
    [SerializeField]
    private float chanceOfCarnivorousFlower = 0.3f;

    private bool flowerIsCarnivorous = false;

    private float flowerChompTimer = 0f;
    [SerializeField]
    private float flowerChompRate = 3f;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(Random.value < chanceOfCarnivorousFlower)
        {
            flowerIsCarnivorous = true;
            Debug.Log("carnivorouosFlower: flower is carnivorous");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (flowerIsCarnivorous)
        {
            UpdateChompTimer();
        }
    }

    void UpdateChompTimer()
    {
        flowerChompTimer += Time.deltaTime;
        if(flowerChompTimer >= flowerChompRate)
        {
            Chomp();
            flowerChompTimer = 0;
        }
    }
    void Chomp()
    {
        Debug.Log("carnivorousFlower: CHOMP");
        spriteRenderer.sprite = flowerChomp;
    }
}
