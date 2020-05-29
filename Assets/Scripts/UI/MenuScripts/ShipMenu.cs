using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMenu : BaseMenu
{
    public ShipController shipController;

    public GameObject StartButton;
    public GameObject StopButton;
    public bool selectHome = false;
    public bool selectTarget = false;
    public bool startStop = false;
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

    public void OnStartButton()
    {
        shipController.SetMoving(true);
        StartButton.SetActive(false);
        StopButton.SetActive(true);
    }
    public void OnStopButton()
    {
        shipController.SetMoving(false);
        StartButton.SetActive(true);
        StopButton.SetActive(false);
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
