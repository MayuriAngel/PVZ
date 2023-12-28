using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PeaShooter : Plant
{
    //间隔时间
    public float interval;
    //计时器
    private float timer;
    //拿到游戏物体
    public GameObject bullet;
    //豌豆生成位置
    public Transform bulletPos;
    public IsFire Fire;

    protected override void Start()
    {
        base.Start();
       
    }
    void Update()
    {

        if (!start) { return; }
        timer += Time.deltaTime;
        if (timer > interval&&Fire.isFire==true)
        {
            SoundManager.instance.PlaySound(Globals.S_Shoot);
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
            timer = 0;

        }


    }


}
