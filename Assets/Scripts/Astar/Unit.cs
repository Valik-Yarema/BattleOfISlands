using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Transform target;
    public float speed = 5;
    Vector3[] path;
    int targetIndex;
    private static PathRequestManager pathManager;

    public bool restart=false;
    void Start()
    {
        pathManager = GetComponentInChildren<PathRequestManager>();
        pathManager.RequestPath(transform.position, target.position, OnPathFound);
    }

    private void Update()
    {
        if (restart)
        {
            print("restart path");
            restart = false;
            pathManager.RequestPath(transform.position, target.position, OnPathFound);
        }
    }

    public void StartNow()
    {
        pathManager.RequestPath(transform.position, target.position, OnPathFound);
    }

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
        Vector3 currentWaypoint = path[0];
        while (true)
        {
            if (transform.position == currentWaypoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    print("have reached the goal");
                    yield break;
                }
                currentWaypoint = path[targetIndex];
                print("path[targetIndex]: "+ targetIndex);
            }
            print(transform.position);
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

}
