using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSystem : MonoBehaviour
{
    public Plants plantInfo;
    public SpriteRenderer spriteRenderer;
    private int growthRate;

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
        
    }

    public void WaterPlant()
    {

    }

    public void GrowPlant()
    {

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
