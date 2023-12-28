using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScaredyShroom : Plant
{
    //间隔时间
    public float interval;
    //计时器
    private float timer;
    //拿到游戏物体
    public GameObject bullet;
    //子弹生成位置
    public Transform bulletPos;
    //是否发射子弹
    public IsBullet IsBullet;
    //是否害怕
    public ScareCli Scare;
    //碎觉
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
