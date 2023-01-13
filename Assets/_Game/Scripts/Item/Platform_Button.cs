using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

enum PlayerHold
{
    None,
    Red,
    Blue
}
public class Platform_Button : MonoBehaviour
{
    [SerializeField] PlayerHold playerHold = PlayerHold.None;
    [SerializeField] Platform_Button platform_Button;
    [SerializeField] Transform btnYellow;
    [SerializeField] Transform moveablePlatform;
    [SerializeField] float offsetBtn;
    [SerializeField] float speed;
    [SerializeField] Transform targetTop;
    [SerializeField] Transform targetBottom;
    public bool isHold = false;
    [SerializeField]
    float offsetY;

    void OnEnable()
    {
        isHold = false;
        offsetY = btnYellow.transform.position.y;

        btnYellow.transform.position = new Vector3(btnYellow.transform.position.x, offsetY, btnYellow.transform.position.z);
        moveablePlatform.transform.position = new Vector3(moveablePlatform.transform.position.x, targetBottom.position.y, moveablePlatform.transform.position.z);
    }
    void Start()
    {
    }
    void TurnOn()
    {
        btnYellow.DOMoveY(btnYellow.transform.position.y - offsetBtn, speed).SetEase(Ease.InOutSine);
        moveablePlatform.DOMoveY(targetTop.position.y, speed).SetEase(Ease.InOutSine);
    }
    void TurnOff()
    {
        btnYellow.DOMoveY(offsetY, speed).SetEase(Ease.InOutSine);
        moveablePlatform.DOMoveY(targetBottom.position.y, speed).SetEase(Ease.InOutSine);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( (other.CompareTag(TagConstans.Player) || other.CompareTag(TagConstans.Box)) &&  platform_Button == null)
        {
            if (platform_Button != null && platform_Button.isHold)
            {

            }
            else if (platform_Button != null && !platform_Button.isHold && playerHold == PlayerHold.None)
            {
                if (other.GetComponent<Player>().GetTypePlayer() == PlayerType.Red)
                {
                    playerHold = PlayerHold.Red;
                }
                else if (other.GetComponent<Player>().GetTypePlayer() == PlayerType.Blue)
                {
                    playerHold = PlayerHold.Blue;
                }
                isHold = true;
                Debug.Log("Platform_Button 12 != NULL");
                TurnOn();
            }
            else if (platform_Button == null)
            {
                isHold = true;
                Debug.Log("Platform_Button NULL");
                TurnOn();
            }

        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.CompareTag(TagConstans.Player) || other.CompareTag(TagConstans.Box)) &&  platform_Button != null)
        {
            if (platform_Button != null && platform_Button.isHold)
            {

            }
            else if (platform_Button != null && !platform_Button.isHold && playerHold == PlayerHold.None)
            {
                if (other.GetComponent<Player>().GetTypePlayer() == PlayerType.Red)
                {
                    playerHold = PlayerHold.Red;
                }
                else if (other.GetComponent<Player>().GetTypePlayer() == PlayerType.Blue)
                {
                    playerHold = PlayerHold.Blue;
                }
                isHold = true;
                Debug.Log("Platform_Button 12 != NULL");
                TurnOn();
            }
            else if (platform_Button == null)
            {
                isHold = true;
                Debug.Log("Platform_Button NULL");
                TurnOn();
            }

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(TagConstans.Player))
        {


            if (platform_Button != null && platform_Button.isHold)
            {

            }
            else if (platform_Button != null && !platform_Button.isHold)
            {
                if (other.GetComponent<Player>().GetTypePlayer() == PlayerType.Blue && playerHold == PlayerHold.Blue)
                {
                    isHold = false;
                    playerHold = PlayerHold.None;
                    TurnOff();

                }
                else if (other.GetComponent<Player>().GetTypePlayer() == PlayerType.Red && playerHold == PlayerHold.Red)
                {
                    isHold = false;
                    playerHold = PlayerHold.None;
                    TurnOff();

                }
                Debug.Log("Platform_Button OnTriggerExit2D");
            }
            else if (platform_Button == null)
            {
                isHold = false;
                Debug.Log("Platform_Button OnTriggerExit2D");
                TurnOff();
            }

        }
        if (other.CompareTag(TagConstans.Box))
        {
            if (platform_Button != null && platform_Button.isHold)
            {

            }
            else if (platform_Button != null && !platform_Button.isHold)
            {

                isHold = false;
                playerHold = PlayerHold.None;
                Debug.Log("Platform_Button OnTriggerExit2D");
                TurnOff();
            }
            else if (platform_Button == null)
            {
                isHold = false;
                Debug.Log("Platform_Button OnTriggerExit2D");
                TurnOff();
            }
        }
    }

}
