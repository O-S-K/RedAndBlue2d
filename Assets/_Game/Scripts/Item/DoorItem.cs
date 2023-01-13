using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DoorItem : MonoBehaviour
{
    [SerializeField] PlayerType keyType;
    [SerializeField] Transform door;
    [SerializeField] float top;
    [SerializeField] float down;

    [SerializeField] float offsetY;
    [SerializeField] bool isOpen=false;
    void Start()
    {
       top = door.transform.position.y + (offsetY * 2);
       down = door.transform.position.y;
    }
    public void ResetDoor()
    {
        isOpen = false;
        door.transform.position = new Vector3(door.transform.position.x, down, door.transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var player = other.GetComponent<Player>();
            if (keyType == player.GetTypePlayer() && player.OpenDoor() && !isOpen)
            {
                isOpen = true;
                player.OnOpenDoor();

                PlayerManager.Instance.CountDoor++;
                door.DOMoveY(top, 0.7f).SetEase(Ease.InOutSine);

            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var player = other.GetComponent<Player>();
            if (keyType == player.GetTypePlayer() && player.OpenDoor() && isOpen)
            {
                isOpen = false;
                player.OnCloseDoor();

                PlayerManager.Instance.CountDoor--;

                door.DOMoveY(down, 0.7f).SetEase(Ease.InOutSine);

            }
        }
    }
}
