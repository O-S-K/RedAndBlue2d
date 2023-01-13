using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class KeyAnimate : MonoBehaviour
{
    public Camera cam;

    


    [SerializeField] Transform posPlayer;
    [SerializeField] Transform posKeyRed;
    [SerializeField] Transform posKeyBlue;


    [SerializeField] Image imageKey;
    [SerializeField] Sprite keyBlue;
    [SerializeField] Sprite keyRed;

   public RectTransform rt;
    Transform curentKey;
    private void Awake()
    {

    }
    private void Start()
    {
       // playAnimate(false);

    }
    // Start is called before the first frame update
    public  void playAnimate(bool isKeyBlue,Transform pos)
    {
        posPlayer = pos;
        imageKey.gameObject.SetActive(true);
        if (isKeyBlue)
        {
            imageKey.sprite = keyBlue;
            curentKey = posKeyBlue;
        }
        else
        {
            imageKey.sprite = keyRed;
            curentKey = posKeyRed;


        }
        rt.anchoredPosition = cam.ViewportToWorldPoint(new Vector3(posPlayer.position.x, posPlayer.position.y, 0));

        rt.DOMove(curentKey.position, 0.4f).SetEase(Ease.Linear)
        .OnComplete(() =>
        {
            imageKey.gameObject.SetActive(false);
            curentKey.gameObject.SetActive(true);
           
        });
      
    }

    // Update is called once per frame
    void Update()
    {
    }
}
