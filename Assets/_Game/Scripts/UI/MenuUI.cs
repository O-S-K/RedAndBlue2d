using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Spine.Unity;
public class MenuUI : MonoBehaviour
{
    [SerializeField] int idCharacter;
    [SerializeField] InfoCharacterSO infoCharacterSO;
    [SerializeField] SkeletonGraphic red;
    [SerializeField] SkeletonGraphic blue;
    [SerializeField] Button arrowLeft;
    [SerializeField] Button arrowRight;



    [SerializeField] GameObject home;
    [SerializeField] PopupUI popupUI;
    [SerializeField] MenuUI menuUI;


    [Header("Button")]
    [SerializeField] Button _startButton;
    [SerializeField] Button _selectLevel;
    [SerializeField] Button _skin;
    [SerializeField] Button _shop;
    [SerializeField] Button _sprinBoard;



    [Header("other")]
    [SerializeField] TextMeshProUGUI _textCoin;
    [SerializeField] TextMeshProUGUI _textHeart;
    [SerializeField] TextMeshProUGUI _textLevel;


    private void OnEnable()
    {
        AudioManager.Instance.PlayMusic("game5");
        _textCoin.text = GameRes.Coin.ToString();
        _textHeart.text = GameRes.Heart.ToString();
        _textLevel.text = "LEVEL "+ GameRes.Level.ToString();
        Reset();
    }
    private void Reset()
    {
        home = transform.GetChild(0).gameObject;
        _startButton = transform.GetChild(0).Find("Play").GetComponent<Button>();
        _selectLevel = transform.GetChild(0).Find("Select Level").GetComponent<Button>();
        _skin = transform.GetChild(0).Find("SkinShop").GetComponent<Button>();
        _shop = transform.GetChild(0).Find("sHOP").GetComponent<Button>();
        _sprinBoard = transform.GetChild(0).Find("Spin").GetComponent<Button>();
    }
    private void Awake()
    {

        _startButton.onClick.AddListener(OnStartButton);
        _selectLevel.onClick.AddListener(OnSelectLevel);
        _skin.onClick.AddListener(OnSkin);
        _shop.onClick.AddListener(OnShop);
        _sprinBoard.onClick.AddListener(OnSprinBoard);

        _textCoin.text = GameRes.Coin.ToString();
        _textHeart.text = GameRes.Heart.ToString();

        arrowLeft.onClick.AddListener(OnArrowLeft);
        arrowRight.onClick.AddListener(OnArrowRight);


    }
    void Start()
    {
        Initialized();
    }

    // Update is called once per frame

    public void HideMenu()
    {
        home.SetActive(false);
    }

    public void ShowMenu()
    {
        home.SetActive(true);
        idCharacter = GameRes.IDSkin;
        Debug.Log("OnEnable = " + idCharacter);

        SetSkinCharacter(red, idCharacter, true);
        SetSkinCharacter(blue, idCharacter, false);
    }
    private void OnArrowRight()
    {
        idCharacter = GameRes.IDSkin;
        int tempID = idCharacter + 1;


        if (tempID <= infoCharacterSO.infoChacracters.Count - 1)
        {
            idCharacter = tempID;
            GameRes.IDSkin = idCharacter;
            arrowLeft.gameObject.SetActive(true);

            SetSkinCharacter(red, idCharacter, true);
            SetSkinCharacter(blue, idCharacter, false);
        }
        else if (tempID <= infoCharacterSO.infoChacracters.Count)
        {
            arrowRight.gameObject.SetActive(false);
        }
    }

    private void OnArrowLeft()
    {
        idCharacter = GameRes.IDSkin;
        int tempID = idCharacter - 1;
        if (tempID == 0)
        {
            arrowLeft.gameObject.SetActive(false);
            idCharacter = tempID;
            GameRes.IDSkin = idCharacter;
            SetSkinCharacter(red, idCharacter, true);
            SetSkinCharacter(blue, idCharacter, false);
        }
        else
        {
            arrowRight.gameObject.SetActive(true);
            idCharacter = tempID;
            GameRes.IDSkin = idCharacter;
            SetSkinCharacter(red, idCharacter, true);
            SetSkinCharacter(blue, idCharacter, false);
        }
    }



    private void Initialized()
    {
        //skeletonAnimation.Skeleton.SetSkin(nameSkin);
        //skeletonAnimation.Skeleton.SetSlotsToSetupPose();
        //skeletonAnimation.AnimationState.Apply(skeletonAnimation.Skeleton);
        // GameRes.IDSkin = 2;
        idCharacter = GameRes.IDSkin;
        SetSkinCharacter(red, idCharacter, true);
        SetSkinCharacter(blue, idCharacter, false);
        idCharacter = GameRes.IDSkin;
        bool checkArrowL = idCharacter + 1 >= infoCharacterSO.infoChacracters.Count ? true : false;
        if (checkArrowL)
        {
            arrowRight.gameObject.SetActive(false);
        }
        bool checkArrowR = idCharacter - 1 <= 0 ? true : false;

        if (checkArrowR)
        {
            arrowLeft.gameObject.SetActive(false);
        }

    }
    public void BackToMenu()
    {
        home.SetActive(true);
    }
    void SetSkinCharacter(SkeletonGraphic skeleton, int idCharacter, bool isRed)
    {
        string nameSkin = isRed == true ? infoCharacterSO.infoChacracters[idCharacter].GetNameSkinRed() : infoCharacterSO.infoChacracters[idCharacter].GetNameSkinBlue();
        skeleton.Skeleton.SetSkin(nameSkin);
        skeleton.Skeleton.SetSlotsToSetupPose();
        skeleton.AnimationState.Apply(skeleton.Skeleton);
    }
    public void OnSprinBoard()
    {
        gameObject.SetActive(false);
        home.SetActive(false);
        popupUI.ShowSprinBoard();
    }

    public void OnShop()
    {
        gameObject.SetActive(false);

        home.SetActive(false);
        popupUI.ShowShop();
    }

    public void OnSkin()
    {
        gameObject.SetActive(false);

        home.SetActive(false);
        popupUI.ShowSkin();
    }

    public void OnSelectLevel()
    {
        home.SetActive(false);
        popupUI.ShowLevelSelect();
    }

    public void OnStartButton()
    {
        gameObject.SetActive(false);

        home.SetActive(false);
        popupUI.ShowGameUI();
        GameManager.Instance.StartGame();
    }


}
