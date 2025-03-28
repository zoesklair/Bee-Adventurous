using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    //energy UI elements
    [SerializeField]
    TMP_Text energyDisplay; //for debugging, hidden by default
    [SerializeField]
    GameObject energyBar;
    Slider energyBarSlider;
    [SerializeField]

    GameOverController gameOverController;

    public float EnergyLevel => energyLevel;
    private float energyLevel;
    [SerializeField]
    private float energyLevelReductionRate = 1;

    private void Awake()
    {
        energyBarSlider = energyBar.GetComponent<Slider>();
        gameOverController = GameObject.Find("GameOverController").GetComponent<GameOverController>();
    }
    void Start()
    {
        energyLevel = 100;
    }

    void Update()
    {
        if(Time.timeScale == 1f) //if game is running
        {
            ReduceEnergy();
            DisplayEnergy();
            CheckNoEnergyAndGameOver();
        }
    }

    void ReduceEnergy()
    {
        UpdateEnergy(-(energyLevelReductionRate * Time.deltaTime));
    }
    void DisplayEnergy()
    {
        //for debugging
        energyDisplay.text = "Energy Level: " + (int)EnergyLevel;

        energyBarSlider.value = EnergyLevel / 100f;
    }
    public void UpdateEnergy(float energyChange)
    {
        energyLevel = Mathf.Clamp(energyLevel + energyChange, 0, 100);
    }
    private void CheckNoEnergyAndGameOver()
    {
        if(EnergyLevel < 1)
        {
            Debug.Log("Energy: energy ran out - game over.");
            gameOverController.SetGameOver();
        }
    }
}
