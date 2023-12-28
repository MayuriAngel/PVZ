using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBullet : MonoBehaviour
{
    //是否攻击
    public bool isAttack;
    public Animator ani;
    public ScaredyShroom scaredyShroom;
   
    // Start is called before the first frame update
    void Start()
    {
        ani = scaredyShroom.GetComponent<Animator>();
        isAttack = false;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 检测进入触发器的对象是否是僵尸  
        if (collision.CompareTag("Zombie"))
        {
            ani.SetBool("IsAttack", true);
        }



    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        // 检测进入触发器的对象是否是僵尸  
        if (collision.CompareTag("Zombie"))
        {
            isAttack = true;
            ani.SetBool("IsAttack", true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Zombie"))
        {
            isAttack = false;
            ani.SetBool("IsAttack", false);
            
           
        }
    }
}
