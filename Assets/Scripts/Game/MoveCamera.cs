using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    protected bool isMove = false;
    public GameObject buttonStartMovingCamera;
    public GameObject buttonStopMovingCamera;

    public void SetIsMoveTrue()
    {
        isMove = true;
        buttonStartMovingCamera.SetActive(false);
        buttonStopMovingCamera.SetActive(true);
    }
    public void SetIsMoveFalse()
    {
        isMove = false;
        buttonStartMovingCamera.SetActive(true);
        buttonStopMovingCamera.SetActive(false);
    }

    public bool GetIsMove()
    {
        return isMove;
    }
}
