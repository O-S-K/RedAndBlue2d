using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Platform_Lever : MonoBehaviour
{
    [SerializeField] Transform btnLever;
    [SerializeField] Transform moveablePlatform;
    [SerializeField] float angle;
    [SerializeField] float speed;
    [SerializeField] Transform targetTop;
    [SerializeField] Transform targetBottom;
    public bool isRight = true;
    float offsetY;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagConstans.Player))
        {
            if (!isRight)
            {
                isRight = true;
                btnLever.DORotate(new Vector3(0, 0, angle), speed).SetEase(Ease.InOutSine);
                moveablePlatform.DOMoveY(targetTop.position.y, speed).SetEase(Ease.InOutSine);
            }
            else
            {
                isRight = false;

                btnLever.DORotate(new Vector3(0, 0, -angle), speed).SetEase(Ease.InOutSine);
                moveablePlatform.DOMoveY(targetBottom.position.y, speed).SetEase(Ease.InOutSine);
            }
        }
    }

}
