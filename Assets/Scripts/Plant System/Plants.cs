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
    Wilted,
    Weedy,
    Dry,
    Dead,
    Wet,
    Buggy,
    None
};

[CreateAssetMenu(menuName = "GhostGarden/Plant")]
public class Plants : ScriptableObject
{
    public string Name;
    public string Description;
    public PlantStates currentState;
    public PlantStatus currentStatus;
}
