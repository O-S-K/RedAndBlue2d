using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtr : Singleton<CameraCtr>
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public void Init()
    {
        target = PlayerManager.Instance.currentPlayer.transform;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetStateGame() == GameState.Playing)
        {
            Debug.Log("udpate came");
            transform.position = target.position + offset;
        }
    }
}
