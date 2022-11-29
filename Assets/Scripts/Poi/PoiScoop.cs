using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoiScoop : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //Animator‚Ìæ“¾
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //Player‚ªCollider‚Ì”ÍˆÍ“à‚É“ü‚Á‚½‚ç
        if(other.tag == "Player")
        {
            //character_nearby‚ğtrue‚É‚µ‚Ä‚·‚­‚¤
            animator.SetBool("ScoopTrigger",true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Player‚ªCollider‚Ì”ÍˆÍ‚©‚ço‚½‚ç
        if (other.tag == "Player")
        {
            //character_nearby‚ğfalse‚É‚µ‚Ä‚·‚­‚¤‚Ì‚ğ‚â‚ß‚é
            animator.SetBool("ScoopTrigger", false);
        }
    }

}
