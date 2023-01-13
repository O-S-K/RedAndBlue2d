using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
using TMPro;
using DG.Tweening;
using System;

public class SkinUI : MonoBehaviour
{
    [SerializeField] SkeletonGraphic previewRed;
    [SerializeField] SkeletonGraphic previewBlue;

    [SerializeField] TextMeshProUGUI _txtCoin;
    [SerializeField] Button btnSlect;
    [SerializeField] Button btnBuy;
    [SerializeField] TextMeshProUGUI txtBuy;
    [SerializeField] Button btnBack;
    [SerializeField] InfoCharacterSO infoCharacterSO;
    [SerializeField] GameObject Content;
    [SerializeField] ItemShop itemShopPrefab;
    [SerializeField] int idcurrent;

    [SerializeField] List<ItemShop> itemShops;
    ItemShop itemShopSelect;
    InfoChacracter infoChacracterSelect;
    [SerializeField] List<int> listInt;
    private void Awake()
    {
        listInt = PlayerPrefsExtra.GetList<int>("listSkinUnlock", new List<int>() { 0 });
        btnBuy.onClick.AddListener(() =>
            OnClickUnlock(itemShopSelect, infoChacracterSelect));
        btnBack.onClick.AddListener(() =>
        {
            UI_Manager.Instance.BackToMenu();
            gameObject.SetActive(false);

        });
        InitItemShop();

    }
    private void OnEnable()
    {
        _txtCoin.text = GameRes.Coin.ToString();
        var idcurrent = GameRes.IDSkin;
        var infoChacracters = infoCharacterSO.infoChacracters;
        foreach (var item in itemShops)
        {
           item.OnHide();
        }
        foreach (var item in itemShops)
        {
            if (idcurrent == item.id)
            {
                previewRed.Skeleton.SetSkin(infoChacracters[idcurrent].GetNameSkinRed());
                previewRed.Skeleton.SetSlotsToSetupPose();
                previewRed.AnimationState.Apply(previewRed.Skeleton);

                previewBlue.Skeleton.SetSkin(infoChacracters[idcurrent].GetNameSkinBlue());
                previewBlue.Skeleton.SetSlotsToSetupPose();
                previewBlue.AnimationState.Apply(previewBlue.Skeleton);

                item.OnSelect();
            }
        }
    }

    void Start()
    {
        //  GameRes.listSkinUnlock = new List<int>(){1,2,3,4,5};

    }
    void InitItemShop()
    {

        var idcurrent = GameRes.IDSkin;
        foreach (var item in infoCharacterSO.infoChacracters)
        {
            var itemShop = Instantiate(itemShopPrefab, Content.transform);
            itemShop.id = item.id;
            itemShop.price = item.price;
            CheckUnlockItemShop(itemShop, item);
            itemShop.OnClickEvent += (id) =>
            {
                itemShopSelect = itemShop;
                infoChacracterSelect = item;
                if (itemShop.isUnlock)
                {
                    Debug.Log("unlock");
                    btnSlect.gameObject.SetActive(true);
                    btnBuy.gameObject.SetActive(false);
                    OnClickSelect(id, itemShop, item);
                }
                else
                {
                    foreach (var itemshop in itemShops)
                    {
                        itemshop.OnHide();
                    }
                    itemShop.OnSelect();
                    Debug.Log("onhide");
                    btnSlect.gameObject.SetActive(false);
                    btnBuy.gameObject.SetActive(true);
                    txtBuy.text = "BUY " + item.price.ToString();
                    previewRed.Skeleton.SetSkin(item.GetNameSkinRed());
                    previewRed.Skeleton.SetSlotsToSetupPose();
                    previewRed.AnimationState.Apply(previewRed.Skeleton);

                    previewBlue.Skeleton.SetSkin(item.GetNameSkinBlue());
                    previewBlue.Skeleton.SetSlotsToSetupPose();
                    previewBlue.AnimationState.Apply(previewBlue.Skeleton);
                    //OnClickUnlock(id, itemShop, item);
                }
                // idcurrent = id;
                // foreach (var item in itemShops)
                // {
                //     item.OnHide();
                // }
                // itemShop.OnSelect();
                // previewRed.Skeleton.SetSkin(item.GetNameSkinRed());
                // previewRed.Skeleton.SetSlotsToSetupPose();
                // previewRed.AnimationState.Apply(previewRed.Skeleton);

                // previewBlue.Skeleton.SetSkin(item.GetNameSkinBlue());
                // previewBlue.Skeleton.SetSlotsToSetupPose();
                // previewBlue.AnimationState.Apply(previewBlue.Skeleton);
            };

            itemShops.Add(itemShop);
            if (itemShop.id == idcurrent)
            {
                previewRed.Skeleton.SetSkin(item.GetNameSkinRed());
                previewRed.Skeleton.SetSlotsToSetupPose();
                previewRed.AnimationState.Apply(previewRed.Skeleton);

                previewBlue.Skeleton.SetSkin(item.GetNameSkinBlue());
                previewBlue.Skeleton.SetSlotsToSetupPose();
                previewBlue.AnimationState.Apply(previewBlue.Skeleton);

                itemShop.OnSelect();
            }
        }

    }
    void OnClickUnlock(ItemShop itemShop, InfoChacracter item)
    {
        Debug.Log("unlock");
        if (GameRes.Coin >= itemShop.price)
        {
            Debug.Log("unlock success");
            GameRes.listSkinUnlock.Add(itemShop.id);
            List<int> skin = PlayerPrefsExtra.GetList<int>("listSkinUnlock", new List<int>() { 0 });
            skin.Add(itemShop.id);
            PlayerPrefsExtra.SetList<int>("listSkinUnlock", skin);
            GameRes.Coin -= itemShop.price;
            OnClickSelect(itemShop.id, itemShop, item);
            itemShop.OnUnlock();
            btnSlect.gameObject.SetActive(true);
            btnBuy.gameObject.SetActive(false);
            DOVirtual.Int(Int32.Parse(_txtCoin.text), GameRes.Coin, 1, (x) => _txtCoin.text = x.ToString());
        }
    }
    public void OnClickSelect(int id, ItemShop itemShop, InfoChacracter item)
    {
        idcurrent = id;
        foreach (var itemshop in itemShops)
        {
            itemshop.OnHide();
        }
        itemShop.OnSelect();
        previewRed.Skeleton.SetSkin(item.GetNameSkinRed());
        previewRed.Skeleton.SetSlotsToSetupPose();
        previewRed.AnimationState.Apply(previewRed.Skeleton);

        previewBlue.Skeleton.SetSkin(item.GetNameSkinBlue());
        previewBlue.Skeleton.SetSlotsToSetupPose();
        previewBlue.AnimationState.Apply(previewBlue.Skeleton);
        GameRes.IDSkin = itemShop.id;
    }


    void CheckUnlockItemShop(ItemShop itemShop, InfoChacracter item)
    {
        var ListSkinUnlock = GameRes.listSkinUnlock;
        Debug.Log("cOUNT " + ListSkinUnlock.Count);
        foreach (var c in ListSkinUnlock)
        {
            Debug.Log("item " + c);
        }

        if (ListSkinUnlock.Contains(itemShop.id))
        {
            itemShop.Init(true, item.iconLock, item.icon);
            itemShop.icon.sprite = item.icon;

        }
        else
        {
            itemShop.Init(false, item.iconLock, item.icon);
            itemShop.icon.sprite = item.iconLock;

        }
    }

}
