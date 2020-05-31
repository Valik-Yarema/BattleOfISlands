using Assets.Scripts.Island;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandIron : BaseIsland
{
    public IslandIron() : base(ResourceType.Iron)
    {
        increaseValue = 1f;
        timeRespavn = 2.5f;
    }
 }
