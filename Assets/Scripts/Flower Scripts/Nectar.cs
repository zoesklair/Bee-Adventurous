using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nectar : MonoBehaviour
{
    [SerializeField]
    GameObject bee;
    Energy beeEnergy;
    [SerializeField]
    GameObject nectarObjectPrefab;
    GameObject nectarObjectInstance;

    private float energyFromNectar = 20;

    private bool flowerHasNectar;
    public bool FlowerHasNectar => flowerHasNectar;

    private void Awake()
    {
        beeEnergy = bee.GetComponent<Energy>();
    }
    // Start is called before the first frame update
    void Start()
    {
        flowerHasNectar = true;
        nectarObjectInstance = Instantiate(nectarObjectPrefab, transform);
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
        Destroy(nectarObjectInstance);
    }
}
