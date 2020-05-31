using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Island
{
    public class Resource 
    {
        float ResourceStoc=0;

        private ResourceType currentResourceType;
        public ResourceType GetResourceType
        {
            get
            {
                return currentResourceType;
            }
        }

        public Resource(ResourceType setResourceType)
        {
            currentResourceType = setResourceType;
        }

        public void AddRecourceStoc(float value)
        {
            ResourceStoc +=value;
        } 
        public float GetResourceInStoc()
        {
            return ResourceStoc;
        }
    }
}