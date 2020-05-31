using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Island
{
    public class ResourcesCount
    {
        public Resource Wood = new Resource(ResourceType.Wood);
        public Resource Stone = new Resource(ResourceType.Stone);
        public Resource Iron = new Resource(ResourceType.Iron);
        public Resource Gold = new Resource(ResourceType.Gold);
        public Resource Steel = new Resource(ResourceType.Steel);
        public Resource Board = new Resource(ResourceType.Board);
    }
}
