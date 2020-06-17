using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AddShipMenu : BaseMenu
{
    public PlayerController playerController;
    public IslandController IslandController;

    public void AddShip(string nameShip)
    {
        playerController.AddShip(nameShip, IslandController.PortObject.transform);
    }
    public virtual void SetPlayerController(PlayerController controller)
    {
        playerController = controller;
    }

    public void AddShip(int indexShip)
    {
        playerController.AddShip(indexShip, IslandController.PortObject.transform);
        OnCloseMenu();
    }

}
