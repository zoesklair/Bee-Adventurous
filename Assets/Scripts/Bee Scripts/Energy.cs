using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    [SerializeField]
    TMP_Text energyDisplay;
    [SerializeField]
    GameObject energyBar;
    Slider energyBarSlider;
    [SerializeField]
    GameObject gameOverPanel;
    GameOverScreen gameOverScreen;

    public float EnergyLevel => energyLevel;

    private float energyLevel;
    [SerializeField]
    private float energyLevelReductionRate = 1;

    private void Awake()
    {
        energyBarSlider = energyBar.GetComponent<Slider>();
        gameOverScreen = gameOverPanel.GetComponent<GameOverScreen>();
    }
    // Start is called before the first frame update
    void Start()
    {
        energyLevel = 100;
    }

    // Update is called once per frame
    void Update()
    {
        ReduceEnergy();
        DisplayEnergy();
        CheckNoEnergyAndGameOver();
    }

    void ReduceEnergy()
    {
        UpdateEnergy(-(energyLevelReductionRate * Time.deltaTime));
    }
    void DisplayEnergy()
    {
        //debug
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
            gameOverScreen.SetGameOver();
        }
    }
}
