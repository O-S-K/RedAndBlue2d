using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TextCoinAnimation : MonoBehaviour
{
    RectTransform rt;
    void Start()
    {

    }
    private void OnEnable()
    {
        rt = GetComponent<RectTransform>();
        PlayAnimationCoin();

    }

    public void PlayAnimationCoin()
    {
        rt.DOAnchorPosY(rt.anchoredPosition.y + rt.up.y, 0.7f).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
        //transform.DOScale(0, 1f).SetEase(Ease.InOutSine);

    }
}
