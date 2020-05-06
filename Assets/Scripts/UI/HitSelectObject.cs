using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSelectObject : MonoBehaviour
{
    private bool select;
    protected PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }
    void Update()
    {

        if ((Input.GetMouseButtonDown(0))) { select = true; }
        if (select)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject != null) 
                {
                    var selectTarget = hit.collider.gameObject.GetComponent<ObjectProperty>();
                    if (selectTarget != null)
                    {
                        selectTarget.SetIsSelected(true);
                    }
                }
            }
            select = false;
        }

    }
}
