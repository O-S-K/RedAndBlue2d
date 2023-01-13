using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class GameUI : MonoBehaviour
{
    [SerializeField] Color colorBlue;
    [SerializeField] Color colorRed;
    [SerializeField] Sprite sprBlue;
    [SerializeField] Sprite sprRed;

    [SerializeField] Image imgbtnSwith;
    [SerializeField] List<Image> btnUI;
    [SerializeField] Button btnPause;
    [SerializeField] TextMeshProUGUI txtHeart;
    [SerializeField] TextMeshProUGUI txtLevel;
    [SerializeField] GameObject keyBlue;
    [SerializeField] GameObject keyRed;
    [SerializeField] EventTrigger btnLeft;
    [SerializeField] EventTrigger btnRight;
    [SerializeField] EventTrigger btnJump;
    [SerializeField] EventTrigger btnZoom;
    [SerializeField] EventTrigger btnSwith;
    [SerializeField] KeyAnimate keyAnimate;
    public Transform startPosHeart;
    public Transform endPosHeart;
    public GameObject heartPrefab;
    private void Awake()
    {
        btnPause.onClick.AddListener(OnPause);
    }
    private void OnDisable()
    {
        keyBlue.SetActive(false);
        keyRed.SetActive(false);
    }
    private void OnEnable()
    {
        if (GameRes.IsSelectLV == 1)
        {
            txtLevel.text = "Level " + GameRes.LevelSelectMode.ToString();

        }
        else
        {
            txtLevel.text = "Level " + GameRes.Level.ToString();
        }

    }
    public void SetHeart()
    {
        txtHeart.text = GameRes.Heart.ToString();
    }
    public void HideKey()
    {
        keyBlue.SetActive(false);
        keyRed.SetActive(false);
    }
    public void SetTextLv(int lv)
    {
        txtLevel.text = "Level " + lv.ToString();
    }
    private void OnPause()
    {
        GameManager.Instance.ChangeStateGame(GameState.GamePause);
        UI_Manager.Instance.popupUI.ShowPausePanel();
    }


    void Start()
    {

        txtHeart.text = GameRes.Heart.ToString();
    }

    public void SetColorUI(bool isBlue)
    {
        // if (isBlue)
        // {
        //     for (int i = 0; i < btnUI.Count; i++)
        //     {
        //         btnUI[i].color = colorBlue;
        //     }
        //     imgbtnSwith.sprite = sprBlue;
        // }
        // else
        // {
        //     for (int i = 0; i < btnUI.Count; i++)
        //     {
        //         btnUI[i].color = colorRed;
        //     }
        //     imgbtnSwith.sprite = sprRed;
        // }
    }
    public void SetHeart(int heart)
    {
        GameRes.Heart += heart;
        txtHeart.text = GameRes.Heart.ToString();
    }
    public (EventTrigger, EventTrigger, EventTrigger, EventTrigger, EventTrigger) GetEventTrigger()
    {
        return (btnLeft, btnRight, btnJump, btnZoom, btnSwith);
    }

    public void PlayAnimateKey(bool isKeyBlue, Transform pos)
    {
        keyAnimate.playAnimate(isKeyBlue, pos);
    }



}
