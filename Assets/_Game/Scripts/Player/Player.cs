using Spine;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerType playerType;
    //Animation

    [SerializeField] AnimationHandle animationHandle;
    [SerializeField] CharacterController2D characterController;
    [SerializeField] CharacterSkin characterSkin;

    [SpineEvent] public string eventHit;
   public bool hasKey = false;
    public int checkDie = 0;

    private void Awake()
    {

    }
    public PlayerType GetPlayerType()
    {
        return playerType;
    }
    void Start()
    {
    }
    public void Initialized()
    {
        checkDie = 0;
        animationHandle.Initialize();
        characterSkin.Initialize();
        characterController.isOpenDoor = false;
        characterController.Init(animationHandle);
        if (playerType == PlayerType.Red)
        {
            characterSkin.SetSkin(GameRes.IDSkin + "_2");

        }
        else
        {
            characterSkin.SetSkin(GameRes.IDSkin + "_1");

        }
        animationHandle.skeletonAnimation.AnimationState.Event += OnEvent;
        characterController.rb.bodyType = RigidbodyType2D.Dynamic;
    }
    public void SetIdleRestart()
    {
        characterController.isOpenDoor = false;
        animationHandle.PlayAnimation("idle1", 0.1f, 0, true);
    }
    public void OnSpring(float forceHieght)
    {
        characterController.Jump(forceHieght);
    }
    public void OnOpenDoor()
    {
        characterController.isOpenDoor = true;
    }
    public void OnCloseDoor()
    {
        characterController.isOpenDoor = false;
    }
    public void Victory(int randID)
    {
        animationHandle.PlayAnimation("win" + randID.ToString(), 0.1f, 0, true, true);
    }
    public void LockX()
    {
        characterController.rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }
    public void UnLockX()
    {
        characterController.rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
    }
    public void Resfesh()
    {
        checkDie = 0;

        characterController.isUpdate = true;
    }
    public void TakeKey()
    {
        hasKey = true;
    }
    public bool OpenDoor()
    {
        return hasKey;
    }
    public void ResetPlayer()
    {
        checkDie = 0;

        characterController.Idle();
        this.Wait(0.3f, () =>
        {
                characterController.isOpenDoor = false;
        });
    

    }
    public void SetKinematic(bool isKinematic)
    {
        characterController.rb.bodyType = isKinematic ? RigidbodyType2D.Kinematic : RigidbodyType2D.Dynamic;
        if (!isKinematic)
        {
            characterController.rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        }
     
    }
    public void PlayerUpdateState()
    {
        characterController.SetMain();
    }
    public PlayerType GetTypePlayer()
    {
        return playerType;
    }

    public void SetDir(Vector2 dir)
    {
        characterController.dir = dir;
    }
    public void JumpPlayer()
    {
        characterController.Jump();
    }
    public void PlayerDead()
    {
        //  if (!isDead)
        //  {

        //  }
        // GameRes.Heart--;
        if (GameRes.Heart > 0)
        {
            GameRes.Heart--;
        }

        AudioManager.Instance.PlayOneShot("die", 1);
        characterController.Dead();

        UI_Manager.Instance.popupUI.ShowFailPanel();
        UI_Manager.Instance.popupUI.GetGameUI().SetHeart();



    }
    private void OnEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name.Equals(eventHit))
        {

        }
        else
        {

        }

    }

    public void Reset()
    {
        if (transform.name.Contains("Red"))
        {
            playerType = PlayerType.Red;
        }
        else
        {
            playerType = PlayerType.Blue;
        }
        animationHandle = transform.Find("Agent").GetComponent<AnimationHandle>();
        characterSkin = transform.Find("Agent").GetComponent<CharacterSkin>();
        characterController = GetComponent<CharacterController2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.transform.CompareTag(TagConstans.Heart))
        {
            other.gameObject.SetActive(false);
            UI_Manager.Instance.popupUI.SetHeart(3);
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag(TagConstans.Saw))
        {
            if (checkDie == 0)
            {
                Debug.Log("Dead =" + transform.name);
                PlayerDead();
                checkDie++;
            }


        }
        if (other.transform.CompareTag(TagConstans.Movealong))
        {
            transform.SetParent(other.transform);
        }
        if (other.transform.CompareTag(TagConstans.WaterRed))
        {
            if (playerType == PlayerType.Blue)
            {
                PlayerDead();
            }
        }
        if (other.transform.CompareTag(TagConstans.Water))
        {
            PlayerDead();
        }

        if (other.transform.CompareTag(TagConstans.WaterBlue))
        {
            if (playerType == PlayerType.Red)
            {
                PlayerDead();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag(TagConstans.Movealong))
        {
            transform.SetParent(PlayerManager.Instance.transform);
        }
    }
}
