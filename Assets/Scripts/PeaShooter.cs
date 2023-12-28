using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PeaShooter : Plant
{
    //���ʱ��
    public float interval;
    //��ʱ��
    private float timer;
    //�õ���Ϸ����
    public GameObject bullet;
    //�㶹����λ��
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
