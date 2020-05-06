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
        WhenSelected();
    }

    private void Update()
    {

    }


    void WhenSelected()
    {
        if (IsSelected)
        {
            selectObject.SetActive(true);
        }
        else
        {
            selectObject.SetActive(false);
        }
    }

}
