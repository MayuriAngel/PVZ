using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareCli : MonoBehaviour
{
    public bool IsScare = false;
    public Animator ani;
    public ScaredyShroom scaredyShroom;

    void Start()
    {
        ani = scaredyShroom.GetComponent<Animator>();
       
    }

    
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �����봥�����Ķ����Ƿ��ǽ�ʬ  
        if (collision.CompareTag("Zombie"))
        {
            Debug.Log("����");
            IsScare=true;
          

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        // �����봥�����Ķ����Ƿ��ǽ�ʬ  
        if (collision.CompareTag("Zombie"))
        {
            Debug.Log("����");
            IsScare = true;


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // �����봥�����Ķ����Ƿ��ǽ�ʬ  
        if (collision.CompareTag("Zombie"))
        {
            IsScare = false;
           
        }
    }
}
