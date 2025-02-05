using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivorousFlower : MonoBehaviour
{
    [SerializeField]
    Sprite flowerChomp, flowerNormal;
    FlowerSpriteChanger spriteChanger;
    Nectar nectar;
    [SerializeField]
    private float chanceOfCarnivorousFlower = 0.3f;

    public bool flowerIsCarnivorous = false;
    public bool flowerIsChomping = false;

    private float flowerChompTimer = 0f;
    [SerializeField]
    private float flowerChompRate = 3f;

    private void Awake()
    {
        spriteChanger = gameObject.GetComponent<FlowerSpriteChanger>();
        nectar = gameObject.GetComponent<Nectar>();
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
       // Debug.Log("carnivorousFlower: CHOMP");
        spriteChanger.UpdateFlowerSprite(FlowerSpriteChanger.FlowerSprites.CarnivorChomp);
        flowerIsChomping = true;

        StartCoroutine(UnChomp(1f));
    }
    IEnumerator UnChomp(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //Debug.Log("unchomp");
        if (nectar.FlowerHasNectar)
        {
            spriteChanger.UpdateFlowerSprite(FlowerSpriteChanger.FlowerSprites.NormalWithNectar);
        }
        else
        {
            spriteChanger.UpdateFlowerSprite(FlowerSpriteChanger.FlowerSprites.NormalNoNectar);
        }
        
        flowerIsChomping = false;
        //flowerChompTimer = 0;
    }
}
