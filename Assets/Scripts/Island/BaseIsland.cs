using Assets.Scripts.Island;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseIsland : MonoBehaviour
{
    public Resource Resource;
    public float timeRespavn = 2.0f;
    public float waitTime = 1.0f;
    protected float increaseValue = 1;
    public ResourceType GetResourceType
    {
        get
        {
            return Resource.GetResourceType;
        }
    }

    public BaseIsland(ResourceType islandType)
    {
        Resource = new Resource(islandType);
    }
        
    void Start()
    {
        StartCoroutine("Countdown", timeRespavn);
    }


    public virtual void IncreaseResource()
    {
        Resource.AddRecourceStoc(increaseValue);
    }

    protected virtual IEnumerator Countdown(float time)
    {
        while (true)
        {
            if (time > 0) {
                Debug.Log(time--);
                yield return new WaitForSeconds(waitTime);
            }
            else
            {
                time = timeRespavn;
                IncreaseResource();
                yield return new WaitForSeconds(waitTime);
            } 
        }
    }

    public virtual void SetIncreaseValue(float newIncreaseValue)
    {
        increaseValue = newIncreaseValue;
    }
    public virtual float GetResourceInStoc()
    {
        return Resource.GetResourceInStoc();
    }

}
