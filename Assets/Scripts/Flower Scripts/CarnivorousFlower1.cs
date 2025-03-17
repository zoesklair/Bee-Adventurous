using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivorousFlower1 : MonoBehaviour
{
    [SerializeField]
    GameObject dangerNotionsPrefab;
    GameObject dangerNotions;

    AudioSource audioSource;
    FlowerSpriteChanger spriteChanger;
    Nectar nectar;
    private bool isWarning;
    private float timeInRange;

    private ScoreController scoreController;

    [SerializeField]
    private float chanceOfCarnivorousFlower = 0.3f;

    //colliders
    Collider2D beeCollider;
    Collider2D flowerCollider;

    public bool flowerIsCarnivorous = false;
    public bool flowerIsChomping = false;

    private float timeUntilWarn = 0.5f;
    //private float timeUntilChomp = 0.4f;
    private float TimeUntilChomp
    {
        get
        {
            int score = scoreController.Score;
            if (score < 100)
            {
                return 0.7f;
            }
            else if (score < 500)
            {
                return 0.65f;
            }
            else
            {
                return 0.5f;
            }
        }
    }

    private void Awake()
    {
        isWarning = false;
        timeInRange = 0;
        spriteChanger = gameObject.GetComponent<FlowerSpriteChanger>();
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
        audioSource = gameObject.GetComponent<AudioSource>();
        nectar = gameObject.GetComponent<Nectar>();
        beeCollider = GameObject.Find("Bee").GetComponent<Collider2D>();
        flowerCollider = gameObject.GetComponent<Collider2D>();

    }
    void Start()
    {
        if (Random.value < chanceOfCarnivorousFlower)
        {
            flowerIsCarnivorous = true;
            Debug.Log("carnivorouosFlower1: flower is carnivorous");
        }
    }

    void Update()
    {
        if (flowerIsCarnivorous)
        {
            if (!flowerIsChomping && beeCollider.bounds.Intersects(flowerCollider.bounds) && Time.timeScale == 1f)
            {
                timeInRange += Time.deltaTime;
                if (!isWarning && timeInRange > timeUntilWarn)
                {
                    isWarning = true;
                    AddWarning();
                    Debug.Log("carnivourous flower: Warning");
                }
                if (isWarning && timeInRange > (timeUntilWarn + TimeUntilChomp))
                {
                    isWarning = false;
                    RemoveWarning();
                    Chomp();

                }

            }
            else
            {
                isWarning = false;
                RemoveWarning();
                timeInRange = 0;
            }
        }
    }
    void Chomp()
    {
        Debug.Log("carnivorousFlower: CHOMP");
        spriteChanger.UpdateFlowerSprite(FlowerSpriteChanger.FlowerSprites.CarnivorChomp);
        flowerIsChomping = true;

        StartCoroutine(UnChomp(1f));
    }
    IEnumerator UnChomp(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (nectar.FlowerHasNectar)
        {
            spriteChanger.UpdateFlowerSprite(FlowerSpriteChanger.FlowerSprites.NormalWithNectar);
        }
        else
        {
            spriteChanger.UpdateFlowerSprite(FlowerSpriteChanger.FlowerSprites.NormalNoNectar);
        }

        flowerIsChomping = false;
    }

    void AddWarning()
    {
        dangerNotions = Instantiate(dangerNotionsPrefab, transform);
        audioSource.Play();
    }
    void RemoveWarning()
    {
        Destroy(dangerNotions);
    }

    //check if bee is in range
    //if yes set bee in range = true
    //if bee leaves, bee in range = false
    //timer for bee in range
    //if timer > timeUntilWarn
    // change colour
    //after time to warn, chomp

}
