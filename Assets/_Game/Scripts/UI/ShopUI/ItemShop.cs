using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemShop : MonoBehaviour
{
    public Action<int> OnClickEvent;
    public int id;
    public Image icon;
    [SerializeField] Sprite _iconLock;
    [SerializeField] Sprite _iconUnLock;
    public int price;
    [SerializeField] Button btnClick;

    [SerializeField] Sprite _spriteSelect;
    [SerializeField] Sprite _spriteLock;
    [SerializeField] Sprite _spriteUnLock;
    [SerializeField] Image _panel;
    public bool isSelect = false;
    public bool isUnlock = false;

    private void Reset()
    {
        btnClick = GetComponent<Button>();
        _panel = transform.GetChild(0).GetComponent<Image>();
        icon = transform.GetChild(1).GetComponent<Image>();
    }
    public void Init(bool isUnlock, Sprite _iconLock, Sprite _iconUnLock)
    {
        this._iconLock = _iconLock;
        this._iconUnLock = _iconUnLock;
        if (isUnlock)
        {
            icon.sprite = _iconUnLock;
            this.isUnlock = true;
            _panel.sprite = _spriteUnLock;
        }
        else
        {
            icon.sprite = _iconLock;
            this.isUnlock = false;
            _panel.sprite = _spriteLock;
        }
        if (id == 0)
        {
            this.isUnlock = true;

        }
    }
    public void OnUnlock()
    {
        isUnlock = true;
        icon.sprite = _iconUnLock;
        _panel.sprite = _spriteSelect;
    }
    void Start()
    {
        btnClick.onClick.AddListener(OnClick);
    }
    public void OnSelect()
    {

        isSelect = true;
        _panel.sprite = _spriteSelect;

    }
    public void OnHide()
    {
        if (isUnlock)
        {
            isSelect = false;
            _panel.sprite = _spriteUnLock;
        }
        else
        {
            isSelect = false;
            _panel.sprite = _spriteLock;
        }

    }

    private void OnClick()
    {

        if (isUnlock)
        {
            GameRes.IDSkin = id;
        }
        OnClickEvent.Invoke(id);
    }
    // Update is called once per frame
    void Update()
    {

    }

}
