using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour
{
    Vector3 originPos;
    bool isSetPos = false;
    private void OnEnable()
    {
        if (!isSetPos)
        {
            originPos = transform.position;
        }
        transform.position = originPos;

    }
    public void ResetPos()
    {
        transform.position = originPos;
        isSetPos = true;
    }
}
