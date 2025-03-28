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
    private float timeWarning;

    private ScoreController scoreController;

    [SerializeField]
    private float chanceOfCarnivorousFlower = 0.3f;

    //colliders
    Collider2D beeCollider;
    Collider2D flowerCollider;

    public bool flowerIsCarnivorous = false;
    public bool flowerIsChomping = false;

    private float timeUntilWarn = 0.5f;
    private float TimeUntilChomp //based on score for increasing difficulty
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
        timeWarning = 0;
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
            //once flower gives warning, it will chomp regardless of bee colliding
            if (isWarning)
            {
                timeWarning += Time.deltaTime;
            }
            if (timeWarning > TimeUntilChomp)
            {
                isWarning = false;
                timeWarning = 0;
                RemoveWarning();
                Chomp();
            }
            if (!flowerIsChomping && beeCollider.bounds.Intersects(flowerCollider.bounds) && Time.timeScale == 1f)
            {
                timeInRange += Time.deltaTime;
                
                if (!isWarning && timeInRange > timeUntilWarn)
                {
                    isWarning = true;
                    AddWarning();
                }
            }
            else
            {
                timeInRange = 0;
            }
        }
    }
    void Chomp()
    {
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

}
