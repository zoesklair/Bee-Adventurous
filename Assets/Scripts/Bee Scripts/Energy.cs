using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Energy : MonoBehaviour
{
    [SerializeField]
    TMP_Text energyDisplay;
    public float EnergyLevel => energyLevel;

    private float energyLevel;
    private float energyLevelReductionRate = 1;
    

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
        energyDisplay.text = "Energy Level: " + (int)EnergyLevel;
    }

    public void UpdateEnergy(float energyChange)
    {
        energyLevel += energyChange;
    }
}
