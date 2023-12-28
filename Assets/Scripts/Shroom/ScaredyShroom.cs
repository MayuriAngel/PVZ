using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScaredyShroom : Plant
{
    //���ʱ��
    public float interval;
    //��ʱ��
    private float timer;
    //�õ���Ϸ����
    public GameObject bullet;
    //�ӵ�����λ��
    public Transform bulletPos;
    //�Ƿ����ӵ�
    public IsBullet IsBullet;
    //�Ƿ���
    public ScareCli Scare;
    //���
    public float sleepTime;
    
    protected override void Start()
    {

        base.Start();
        animator.SetBool("IsAttack", false);
    }
    void Update()
    {
        
        if (!start) { return; }
        sleepTime += Time.deltaTime;
        if (sleepTime < 10 && sleepTime > 3&&IsBullet.isAttack == false)
        {
            animator.SetBool("GetUp", false);
        }
        else if (sleepTime > 10)
        {

            sleepTime = 0;
        }
        else
        {
            animator.SetBool("GetUp", true);
        }

        timer += Time.deltaTime;
        
        if (Scare.IsScare == true)
        {
            animator.SetBool("IsScare", true);
        }
        else
        {
            animator.SetBool("IsScare", false);
            if (timer > interval && IsBullet.isAttack == true)
            {

                timer = 0;
                Instantiate(bullet, bulletPos.position, Quaternion.identity);
            }
        }
    }
}
