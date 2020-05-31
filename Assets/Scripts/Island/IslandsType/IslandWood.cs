using Assets.Scripts.Island;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandWood : BaseIsland
{
    public IslandWood() : base(ResourceType.Wood)
    {
        increaseValue = 1f;
        timeRespavn = 1.5f;
    }
}
