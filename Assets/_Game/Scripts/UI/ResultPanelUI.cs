using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ResultPanelUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _txtCoin;
    [SerializeField] TextMeshProUGUI _txtHeart;
    [SerializeField] GameObject root;
    [SerializeField] TextMeshProUGUI txtLevel;
    [SerializeField] TextMeshProUGUI txtLevelFinish;

    [SerializeField] int idCharacter;
    [SerializeField] InfoCharacterSO infoCharacterSO;

    [SerializeField] SkeletonGraphic red;
    [SerializeField] SkeletonGraphic blue;

    [Header("Button")]
    [SerializeField] Button _home;
    [SerializeField] Button _startButton;
    [SerializeField] Button _skin;
    [SerializeField] Button _shop;
    [SerializeField] Button _sprinBoard;
    private void Reset()
    {
        root = transform.GetChild(0).gameObject;
        red = transform.GetChild(2).Find("HeroRed").GetComponent<SkeletonGraphic>();
        blue = transform.GetChild(2).Find("HeroBlue").GetComponent<SkeletonGraphic>();
        _startButton = transform.GetChild(2).Find("Play").GetComponent<Button>();
        _skin = transform.GetChild(2).Find("SkinShop").GetComponent<Button>();
        _shop = transform.GetChild(2).Find("sHOP").GetComponent<Button>();
        _sprinBoard = transform.GetChild(2).Find("Spin").GetComponent<Button>();
    }
    private void OnEnable()
    {
        _txtCoin.text = GameRes.Coin.ToString();
        _txtHeart.text = GameRes.Heart.ToString();
        idCharacter = GameRes.IDSkin;
        Debug.Log("OnEnable = " + idCharacter);
        int lv ;
        if(GameManager.Instance.isSelectLV)
        {
            lv = GameRes.LevelSelectMode;
        }
        else
        {
            lv = GameRes.Level;
        }
         int lvPre = lv - 1;
        txtLevel.text = "LEVEL " + lv.ToString();
        txtLevelFinish.text = "LEVEL " + lvPre.ToString();
        SetSkinCharacter(red, idCharacter, true);
        SetSkinCharacter(blue, idCharacter, false);
    }
    private void Awake()
    {
        _home.onClick.AddListener(OnHome);
        _startButton.onClick.AddListener(OnStartButton);
        _skin.onClick.AddListener(OnSkin);
        _shop.onClick.AddListener(OnShop);
        _sprinBoard.onClick.AddListener(OnSprinBoard);
    }

    private void OnHome()
    {
        root.SetActive(false);
        GameManager.Instance.isSelectLV = false;
         UI_Manager.Instance.menuUI.gameObject.SetActive(true);
        UI_Manager.Instance.menuUI.ShowMenu();

    }

    private void OnSprinBoard()
    {
        root.SetActive(false);
        UI_Manager.Instance.menuUI.OnSprinBoard();

    }
    private void OnShop()
    {
        root.SetActive(false);
        UI_Manager.Instance.menuUI.OnShop();

    }

    private void OnSkin()
    {
        root.SetActive(false);
        UI_Manager.Instance.menuUI.OnSkin();

    }

    private void OnStartButton()
    {
        gameObject.SetActive(false);
        // root.SetActive(false);
        UI_Manager.Instance.menuUI.HideMenu();

        UI_Manager.Instance.popupUI.ShowGameUI();
        GameManager.Instance.StartGame();
        UI_Manager.Instance.popupUI.GetGameUI().gameObject.SetActive(true);
    }

    void Start()
    {

    }
    void SetSkinCharacter(SkeletonGraphic skeleton, int idCharacter, bool isRed)
    {
        string nameSkin = isRed == true ? infoCharacterSO.infoChacracters[idCharacter].GetNameSkinRed() : infoCharacterSO.infoChacracters[idCharacter].GetNameSkinBlue();
        skeleton.Skeleton.SetSkin(nameSkin);
        skeleton.Skeleton.SetSlotsToSetupPose();
        skeleton.AnimationState.Apply(skeleton.Skeleton);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
