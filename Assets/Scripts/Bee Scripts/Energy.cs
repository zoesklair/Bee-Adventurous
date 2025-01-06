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

    public float EnergyLevel => energyLevel;

    private float energyLevel;
    private float energyLevelReductionRate = 1;

    private void Awake()
    {
        energyBarSlider = energyBar.GetComponent<Slider>();
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
}
