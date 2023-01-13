using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InputHandle : MonoBehaviour
{
    [SerializeField] KeyBoardType keyBoardType;
    [SerializeField] Vector2 dir;

    [SerializeField] EventTrigger btnLeft;
    [SerializeField] EventTrigger btnRight;
    [SerializeField] EventTrigger btnJump;
    [SerializeField] EventTrigger btnZoom;
    [SerializeField] EventTrigger btnSwith;


    // public CharacterController2D characterController;
    [SerializeField] PlayerManager playerManager;
    private void Reset()
    {
        playerManager = GetComponent<PlayerManager>();

    }
    private void OnSelectionChange()
    {

    }
    void Start()
    {
        // //(btnLeft, btnRight, btnJump, btnZoom, btnSwith);
        btnLeft = UI_Manager.Instance.popupUI.GetGameUI().GetEventTrigger().Item1;
        btnRight = UI_Manager.Instance.popupUI.GetGameUI().GetEventTrigger().Item2;
        btnJump = UI_Manager.Instance.popupUI.GetGameUI().GetEventTrigger().Item3;
        btnZoom = UI_Manager.Instance.popupUI.GetGameUI().GetEventTrigger().Item4;
        btnSwith = UI_Manager.Instance.popupUI.GetGameUI().GetEventTrigger().Item5;



        EventTrigger.Entry btnL_Up = new EventTrigger.Entry();
        btnL_Up.eventID = EventTriggerType.PointerUp;
        btnL_Up.callback.AddListener((data) => { StopMovement((PointerEventData)data); });

        EventTrigger.Entry btnL_Down = new EventTrigger.Entry();
        btnL_Down.eventID = EventTriggerType.PointerDown;
        btnL_Down.callback.AddListener((data) => { MovementLeft((PointerEventData)data); });

        btnLeft.triggers.Add(btnL_Up);
        btnLeft.triggers.Add(btnL_Down);

        EventTrigger.Entry btnR_Up = new EventTrigger.Entry();
        btnR_Up.eventID = EventTriggerType.PointerUp;
        btnR_Up.callback.AddListener((data) => { StopMovement((PointerEventData)data); });

        EventTrigger.Entry btnR_Down = new EventTrigger.Entry();
        btnR_Down.eventID = EventTriggerType.PointerDown;
        btnR_Down.callback.AddListener((data) => { MovementRight((PointerEventData)data); });

        btnRight.triggers.Add(btnR_Up);
        btnRight.triggers.Add(btnR_Down);



        EventTrigger.Entry btnJ = new EventTrigger.Entry();
        btnJ.eventID = EventTriggerType.PointerUp;
        btnJ.callback.AddListener((data) => { Jump((PointerEventData)data); });
        btnJump.triggers.Add(btnJ);


        EventTrigger.Entry btnZ = new EventTrigger.Entry();
        btnZ.eventID = EventTriggerType.PointerUp;
        btnZ.callback.AddListener((data) => { ZoomCamera((PointerEventData)data); });
        btnZoom.triggers.Add(btnZ);

        EventTrigger.Entry btnS = new EventTrigger.Entry();
        btnS.eventID = EventTriggerType.PointerUp;
        btnS.callback.AddListener((data) => { SwithPlayer((PointerEventData)data); });
        btnSwith.triggers.Add(btnS);

    }


    public void Left()
    {
        dir = Vector2.left;
    }
    public void Right()
    {
        dir = Vector2.right;
    }
    public void Stopmove()
    {
        dir = Vector2.zero;
    }
    public void Jump()
    {
        playerManager.currentPlayer.JumpPlayer();
    }
    public void SwithPlayer(PointerEventData data)
    {
        if (GameManager.Instance.GetStateGame() != GameState.Playing)
        {
            return;
        }

        playerManager.SwitchPlayer();
    }

    public void ZoomCamera(PointerEventData data)
    {
    }
    public void StopMovement(PointerEventData data)
    {
        Debug.Log("Stop");
        dir = Vector2.zero;
    }
    public void MovementLeft(PointerEventData data)
    {
        if (GameManager.Instance.GetStateGame() != GameState.Playing)
        {
            return;
        }
        Debug.Log("Left");
        dir = Vector2.left;
    }
    public void MovementRight(PointerEventData data)
    {
        if (GameManager.Instance.GetStateGame() != GameState.Playing)
        {
            return;
        }
        Debug.Log("Right");
        dir = Vector2.right;
    }
    public void Jump(PointerEventData data)
    {
        if (GameManager.Instance.GetStateGame() != GameState.Playing)
        {
            return;
        }
        Debug.Log("Jump");

        playerManager.currentPlayer.JumpPlayer();

    }
    // Update is called once per frame
    void Update()
    {


        if (GameManager.Instance.GetStateGame() != GameState.Playing)
        {
            return;
        }

        if (keyBoardType == KeyBoardType.Editor)
        {
            float x = Input.GetAxis("Horizontal");
            dir = new Vector2(x, 0);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerManager.currentPlayer.JumpPlayer();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                //MyPooler.ObjectPooler.Instance.GetFromPool("coinNum", Vector3.zero, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                playerManager.SwitchPlayer();
            }
        }


        playerManager.currentPlayer.SetDir(dir);

    }

}
