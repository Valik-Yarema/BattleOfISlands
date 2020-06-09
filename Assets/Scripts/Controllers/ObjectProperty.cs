using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectProperty : MonoBehaviour
{
    public bool IsSelected = false;
    public GameObject selectObject;
    public virtual void SetIsSelected(bool value)
    {
        IsSelected = value;
        selectObject.SetActive(true);
    }
}
