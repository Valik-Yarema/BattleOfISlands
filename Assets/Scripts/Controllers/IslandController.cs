using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandController : MonoBehaviour
{
    protected PhotonView photonView;
    public GameObject PortObject;
    public GameObject PanelIsland;

    /*protected*/ public BentIslandType islandType = BentIslandType.Wild;

    public BentIslandType IslandType {
        get 
        {
            return islandType;
        }
        set
        {
            if (islandType == BentIslandType.Wild) //need check photonView.isMine  
            {
                islandType = value;
            }
        } 
    }

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        PortObject = GetComponent<PortPlaseScript>().Port;
    }

    public void SetToPanelIslandController()
    {
        PanelIsland.SetActive(true);
        PanelIsland.GetComponent<IslandMenu>().SetIslandController(this);
    }

   

}
