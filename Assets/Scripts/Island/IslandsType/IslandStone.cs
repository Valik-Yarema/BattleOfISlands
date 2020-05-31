using Assets.Scripts.Island;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandStone : BaseIsland
{
    public IslandStone():base(ResourceType.Stone)
    {
        increaseValue = 1f;
        timeRespavn = 2.0f;
    }
}
