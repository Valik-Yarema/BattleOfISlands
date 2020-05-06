using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMenu : BaseMenu
{
    public ShipController shipController;

    public bool selectHome = false;
    public bool selectTarget = false;
    public void Update()
    {
        if (selectHome)
        { 
            selectHome = !shipController.SelectHomeIsland();
        }
        if (selectTarget)
        {
            selectTarget = !shipController.SelectTargetIsland();
        }
    }

    public virtual void SetShipController(ShipController controller)
    {
        shipController = controller;
        gameObject.SetActive(true);
    }

    public void OnSelectHome()
    {
        if (selectTarget) return; 

        selectHome = true;
    }
    public void OnSelectIsland()
    {
        if (selectHome) return;

        selectTarget = true;
    }

    public void OnCloseMenu()
    {
        shipController.customProperty.SetIsSelected(false);
        gameObject.SetActive(false);
    }

}
