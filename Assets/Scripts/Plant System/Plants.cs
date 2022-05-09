using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GrowthRate
{
    Fast,
    Normal,
    Slow
}

public enum PlantType
{
    Soil,
    Hanging,
    Aquatic
}

[CreateAssetMenu(menuName = "GhostGarden/Plant")]
public class Plants : ScriptableObject
{
    [Header("Plant Info")]
    public string Name;
    public string Description;
    public PlantType plantType;
    public GrowthRate growthRate;
    public bool bloomsAtNight;
    public bool bloomsDuringDay;

    [Header("Plant Sprites")]
    public Sprite seed;
    public Sprite seedling;
    public Sprite budding;
    public Sprite bloomingOpen;
    public Sprite bloomingClosed;
}
