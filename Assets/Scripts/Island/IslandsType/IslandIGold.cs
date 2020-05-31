using Assets.Scripts.Island;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandGold : BaseIsland
{
    public IslandGold():base(ResourceType.Gold)
    {
        increaseValue = 1f;
        timeRespavn = 4.0f;
    }
}
