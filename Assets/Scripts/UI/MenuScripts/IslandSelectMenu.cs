using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class IslandSelectMenu : MonoBehaviour
{
    public GameObject PanelWildIsland;
    public GameObject PanelHomeIsland;
    public GameObject PanelEnemyIsland;

    protected PlayerController playerController;
    protected ShipController shipController;
    protected IslandController islandController;
    protected bool isEnable = false;

    public void SetIslandToPanel(GameObject islandTop, ShipController controller)
    {
        shipController = controller;
        islandController = islandTop.GetComponent<IslandController>();
        OnSetEnablePanel();
    }
    public void SetPlayerController(PlayerController controller)
    {
        playerController = controller;
    }

    public void FoundCity()
    {
        islandController.IslandType = BentIslandType.Mine;
        playerController.PlayerIslands.Add(islandController.gameObject);
        islandController.PanelIsland = playerController.panelIsland.gameObject;
    }

    public void OnSelectWildIsland()
    {
       shipController.SetTargetIsland(islandController.PortObject);
       OnSetDisablePanel();      //last added row
    }
    public void OnSelectHomeIsland()
    { 
        shipController.SetHomeIsland(islandController.PortObject);
        OnSetDisablePanel();//last added row
    }

    public void OnSetEnablePanel()
    {
        isEnable = true;
        ActivatePanel();
    }

    public void OnSetDisablePanel()
    {
        isEnable = false;
        ActivatePanel();
    }

    private void ActivatePanel()
    {
        if (islandController.IslandType == BentIslandType.Wild)
        {
            PanelWildIsland.SetActive(isEnable);
            gameObject.SetActive(isEnable);
        }
        else if (islandController.IslandType == BentIslandType.Mine)
        {
            PanelHomeIsland.SetActive(isEnable);
            gameObject.SetActive(isEnable);
        }
        else if (islandController.IslandType == BentIslandType.Enemy)
        {
            PanelEnemyIsland.SetActive(isEnable);
            gameObject.SetActive(isEnable);
        }
    }
    
    public void OnCloseMenu()
    {
        PanelWildIsland.SetActive(false);
        PanelHomeIsland.SetActive(false);
        PanelEnemyIsland.SetActive(false);
        gameObject.SetActive(false);
    }
}
