using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListResources : MonoBehaviour
{

    public List<Text> TextObjects;
    protected PlayerController playerController;
 
    public void SetPlayerController(PlayerController controller)
    {
        playerController = controller;
    }
}
