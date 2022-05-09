using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlantStates
{
    Seed,
    Seedling,
    Budding,
    BloomingOpen,
    BloomingClosed
};

public enum PlantStatus
{

    None,
    //Wilted,
    Weedy,
    //Dry,
    //Dead,
    //Wet,
    Buggy
};

public class PlantSystem : MonoBehaviour
{
    public Plants plantInfo;
    public SpriteRenderer spriteRenderer;
    public PlantStates currentState;
    public PlantStatus currentStatus;
    public int growthTick = 0;//increase this variable after each day
    public bool plantWatered = false;
    public bool fullyGrown = false;

    public int currentRate;
    private static int seedGrowth;
    private static int seedlingGrowth;
    private static int buddlingGrowth;

    // Start is called before the first frame update
    void Start()
    {
        SetGrowthRate(plantInfo.growthRate);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case PlantStates.Seed:
                currentRate = seedGrowth;
                break;
            case PlantStates.Seedling:
                currentRate = seedlingGrowth;
                break;
            case PlantStates.Budding:
                currentRate = buddlingGrowth;
                break;
            case PlantStates.BloomingOpen:
                fullyGrown = true;
                break;
            case PlantStates.BloomingClosed:
                fullyGrown = true;
                break;
            default:
                break;
        }
    }

    public void WaterPlant()
    {
        plantWatered = true;
    }

    public void GrowPlant()
    {
        //if (!plantWatered) return;
        growthTick += 1;
        plantWatered = false;
        if(growthTick == currentRate)
        {
            if (fullyGrown) return;
            SwitchState(currentState);
            growthTick = 0;
        }
    }

    public void SwitchState(PlantStates states)
    {
        switch (states)
        {
            case PlantStates.Seed:
                currentState = PlantStates.Seedling;
                break;
            case PlantStates.Seedling:
                currentState = PlantStates.Budding;
                break;
            case PlantStates.Budding:
                currentState = PlantStates.BloomingClosed;
                break;
            case PlantStates.BloomingOpen:
                currentState = PlantStates.BloomingClosed;
                break;
            case PlantStates.BloomingClosed:
                currentState = PlantStates.BloomingOpen;
                break;
            default:
                break;
        }
    }

    public void SetGrowthRate(GrowthRate rate)
    {
        switch (rate)
        {
            case GrowthRate.Fast:
                seedGrowth = 3;
                seedlingGrowth = 2;
                buddlingGrowth = 3;
                break;

            case GrowthRate.Normal:
                seedGrowth = 4;
                seedlingGrowth = 3;
                buddlingGrowth = 4;
                break;

            case GrowthRate.Slow:
                seedGrowth = 5;
                seedlingGrowth = 4;
                buddlingGrowth = 5;
                break;
            default:
                break;
        }
    }
}
