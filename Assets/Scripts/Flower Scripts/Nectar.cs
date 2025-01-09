using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nectar : MonoBehaviour
{
    GameObject bee;
    Energy beeEnergy;

    GameObject nectarObject;

    private float energyFromNectar = 20;

    private bool flowerHasNectar;
    public bool FlowerHasNectar => flowerHasNectar;

    private void Awake()
    {
        bee = GameObject.Find("Bee");
        beeEnergy = bee.GetComponent<Energy>();
        nectarObject = gameObject.transform.GetChild(0).gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        //flower begins with nectar
        flowerHasNectar = true;
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    public void CollectNectar()
    {
        //energy go up
        beeEnergy.UpdateEnergy(energyFromNectar);
        flowerHasNectar = false;
        Destroy(nectarObject);
    }
}
