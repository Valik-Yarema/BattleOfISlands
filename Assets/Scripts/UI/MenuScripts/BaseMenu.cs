using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMenu : MonoBehaviour
{
    public GameObject panel;

    public bool GetActive()
    {
        return panel.active;
    }

    public void SetActive(bool value)
    {
        panel.SetActive(value);
    }

    public virtual void OnCloseMenu() { }
    
}
