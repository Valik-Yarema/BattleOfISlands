using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandMenu : BaseMenu
{
    public PlayerController playerController;

    protected IslandController islandController;
    protected ShipController shipController;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    public virtual void SetIslandController(IslandController controller)
    {
        islandController = controller;
        gameObject.SetActive(true);
    }

    public virtual void SetShipController(ShipController controller)
    {
        shipController = controller;
    }
    public virtual void SetHomeIsland()
    {
        shipController.HomeIsland = islandController.gameObject;
    }
}
