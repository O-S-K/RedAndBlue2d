using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] float forceHieght;
    [SerializeField] Animator animator;
    void Start()
    {
        
    }
  
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(TagConstans.Player))
        {
            animator.SetTrigger("Active");
            other.GetComponent<Player>().OnSpring(forceHieght);
        }
    }
}
