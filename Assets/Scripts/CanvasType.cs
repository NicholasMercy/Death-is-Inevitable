using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasType : MonoBehaviour
{
    public GameStates gameStates;   

    public void SetParentObjectFalse()
    {
        gameObject.GetComponentInParent<GameObject>().SetActive(false);
    }
}
