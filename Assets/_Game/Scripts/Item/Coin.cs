using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagConstans.Player))
        {
            GameManager.Instance.countCoin +=10;
            AudioManager.Instance.PlayOneShot("collectcoin");
            gameObject.SetActive(false);
            //var coinTxt = MyPooler.ObjectPooler.Instance.GetFromPool("coinNum", transform.position, new Quaternion(0,0,0,0));
            //coinTxt.transform.localScale = Vector3.one;
        }
    }
}
