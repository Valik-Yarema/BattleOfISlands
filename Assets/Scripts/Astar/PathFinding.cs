using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System;

public class PathFinding : MonoBehaviour
{

    PathRequestManager requestManager;
    Grid grid;

    private void Awake()
    {
        requestManager = GetComponent<PathRequestManager>();
        grid = GetComponent<Grid>();
    }

    public void StartFindPath(Vector3 startPos, Vector3 turgetPos)
    {
        StartCoroutine(FindePath(startPos, turgetPos));
    }
    IEnumerator FindePath(Vector3 startPosition,Vector3 targetPosition)
    {
        Vector3[] waypoints = new Vector3[0];
        bool pathSuccess = false;

        Node startNode = grid.GetNodeFromGrid(startPosition);
        Node targetNode = grid.GetNodeFromGrid(targetPosition);

        if (startNode.walkable /*&& targetNode.walkable*/)
        {
            Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
            HashSet<Node> closedSet = new HashSet<Node>();
            openSet.Add(startNode);
            while (openSet.Count > 0)
            {
                Node currentNode = openSet.RemoveFirst();
                closedSet.Add(currentNode);

                if (currentNode == targetNode)
                {
                    pathSuccess = true;
                    break;
                }

                foreach (Node neighbour in grid.GetNeighbours(currentNode))
                {
                    if (!neighbour.walkable || closedSet.Contains(neighbour))
                    {
                        continue;
                    }

                    int newMovementCostToNeighbour = currentNode.gCost + GetDistanse(currentNode, neighbour);
                    if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        neighbour.gCost = newMovementCostToNeighbour;
                        neighbour.hCost = GetDistanse(neighbour, targetNode);
                        neighbour.parent = currentNode;
                        if (!openSet.Contains(neighbour))
                        {
                            openSet.Add(neighbour);
                        }
                    }
                }
            }
        }
        yield return null;
        if (pathSuccess)
        {
            waypoints = RetracePath(startNode, targetNode);
        }
        requestManager.FinishProcessingPath(waypoints, pathSuccess);

    }
    Vector3[] RetracePath(Node startNode,Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;
        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        Vector3[] waytpoints = SimplifyPath(path);
        Array.Reverse(waytpoints);
        return waytpoints;
        
    }

    Vector3[] SimplifyPath(List<Node> path)
    {
        List<Vector3> waytpoints = new List<Vector3>();
        Vector2 directionOld = Vector2.zero;
        for (int i = 1; i < path.Count; i++)
        {
            Vector2 directionNew = new Vector2(path[i - 1].gridX - path[i].gridX, path[i - 1].gridY - path[i].gridY);
            if (directionNew != directionOld)
            {
                waytpoints.Add(path[i].worldPosition);
            }
        }
        return waytpoints.ToArray();
    }

    int GetDistanse(Node nodeA, Node nodeB)
    {
        int distanseX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int distanseY = Mathf.Abs(nodeA.gridY - nodeB.gridY);
        if (distanseX > distanseY)
        {
            return 14 * distanseY + 10 * (distanseX - distanseY);
        }
        return 14 * distanseX + 10 * (distanseY - distanseX);
    }
}

