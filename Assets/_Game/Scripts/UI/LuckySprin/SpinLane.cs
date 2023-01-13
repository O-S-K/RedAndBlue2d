using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public enum SpinLaneType
{
    Coin,
    Heart,
}
public class SpinLane : MonoBehaviour
{
    [SerializeField] SpinLaneType _type;
    [SerializeField] int _value;
    [SerializeField] Image _icon;
    [SerializeField] Sprite _iconCoin;
    [SerializeField] Sprite _iconHeart;

    [SerializeField] TextMeshProUGUI _textValue;
    private void Reset()
    {
        _icon = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        _textValue = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();


    }
    void Start()
    {
        if (_type == SpinLaneType.Coin)
        {
            _icon.sprite = _iconCoin;
        }
        else if (_type == SpinLaneType.Heart)
        {
            _icon.sprite = _iconHeart;
        }
        _textValue.text = "+" + _value.ToString();
    }

   
    public (SpinLaneType,int) GetInfo()
    {
        return (_type, _value);
    }
}
