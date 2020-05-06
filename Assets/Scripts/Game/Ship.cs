using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private PhotonView photonView;
    private new Collider collider;
    private bool controllable = true;
    public void Start()
    {
        photonView = GetComponent<PhotonView>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (!photonView.IsMine || !controllable)
        {
            return;
        }
    }
}
