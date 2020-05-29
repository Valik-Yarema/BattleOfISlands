using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    protected PhotonView photonView;
    public GameObject HomeIsland;
    public GameObject Target;
    public float speed = 5;
    public GameObject PanelShip;

    public ObjectProperty customProperty;
    Vector3[] path;
    int targetIndex;
    bool goToHome = false;
    private Vector3 selectPosition;
    bool isFirstTime = true;
    private bool Moving = true;
    private bool CompletedJourney = false;
    private static PathRequestManager pathManager;


    void Start()
    {
        photonView = GetComponent<PhotonView>();
        customProperty = GetComponent<ObjectProperty>();
        pathManager = GetComponentInChildren<PathRequestManager>();
    }
    // Update is called once per frame
    void Update()
    {
     
        if (customProperty.IsSelected)
        {
            if (isFirstTime)
            {
                PanelShip.GetComponent<ShipMenu>().SetShipController(this);
                isFirstTime = false;
            }
        }
        else { 
            isFirstTime = true;
        }
        
        if (CompletedJourney)
        {
            FollowGoal();
            CompletedJourney = false;
        }

       //photonView.RPC("FollowPath", RpcTarget.AllViaServer);
    }

    public void SelectPanel()
    {
        var panel = GetComponent<ShipMenu>();
        panel.SetActive(true);
        panel.shipController = this;
    }

    public bool SelectTargetIsland()
    {
        if (!customProperty.IsSelected)
        {
            return false;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            selectPosition = hit.point;
            selectPosition.y = 0;
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Island"))
            {
                Target = hit.collider.gameObject.GetComponent<PortPlaseScript>().Port;//для вибору точки звідки звозити
                //if (HomeIsland != null) {
                //    FollowGoal();
                //}
                return true;
            }
        }
        return false;
    }
    public bool SelectHomeIsland()
    {
        if (!customProperty.IsSelected)
        {
            return false;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            selectPosition = hit.point;
            selectPosition.y = 0;
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Island"))
            {
                HomeIsland = hit.collider.gameObject.GetComponent<PortPlaseScript>().Port;//для вибору точки куда ресурси возити
                //if (Target != null)
                //{
                //    FollowGoal();
                //}
                return true;
            }

        }
        return false;
    }
    
    public void SetMoving(bool value)
    {
        Moving = value;
        if (value)
        {
            FollowGoal();
        }
    }

    public void FollowGoal()
    {
        try
        {
            if (goToHome)
            {
                pathManager.RequestPath(transform.position, HomeIsland.transform.position, OnPathFound);
            }
            else
            {
                pathManager.RequestPath(transform.position, Target.transform.position, OnPathFound);

            }
        }catch(Exception ex)
        {

        }
    }
    public void FollowGoal(GameObject targetObject)
    {
        pathManager.RequestPath(transform.position, targetObject.transform.position, OnPathFound);
    }

    #region A*
    private void OnPathFound(Vector3[] newPath, bool pathSaccessFull)
    {
        if (pathSaccessFull)
        {
            path = newPath;
            targetIndex = 0;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }
   
    IEnumerator FollowPath()
    {
        if (path == null)
        {
            yield return null;
        }
        Vector3 currentWaypoint = path[0];
        while (true)
        {
            if (!Moving)
            {
                print("Stop");
                yield break;
            }

            if (transform.position == currentWaypoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    print("have reached the goal");
                    goToHome = !goToHome;
                    CompletedJourney = true;
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            Vector3 targetDirection = currentWaypoint - transform.position;

          
            float singleStep = speed * Time.deltaTime;

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            
            Debug.DrawRay(transform.position, newDirection, Color.red);

            transform.rotation = Quaternion.LookRotation(newDirection,new Vector3(0,1,0));
            
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            yield return null;
        }
    }
    public void OnDrawGizmos()
    {
        if (path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }
    #endregion
}
