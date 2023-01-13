using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    [SerializeField] PlayerType keyType;
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var player = other.GetComponent<Player>();
            if (keyType == player.GetTypePlayer())
            {
                AudioManager.Instance.PlayOneShot("key");
                UI_Manager.Instance.popupUI.GetGameUI().PlayAnimateKey(keyType == PlayerType.Blue,transform);
                player.TakeKey();
                gameObject.SetActive(false);
            }

        }
    }
}
