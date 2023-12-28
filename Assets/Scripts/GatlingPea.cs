using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GatlingPea : Plant
{
    //间隔时间
    public float interval;
    //计时器
    private float timer;
    //拿到游戏物体
    public GameObject bullet;
    //豌豆生成位置
    public Transform bulletPos;

    public Transform bulletPos2;
    public Transform bulletPos3;

    public IsFire Fire;
    public JiqiangQK Judge;


    public float CreatTime = 0.2f;
    public int BulletNum;

    private Coroutine generator;

    protected override void Start()
    {
        base.Start();
    }
    private void Update()
    {

        if (!start)
        {
            return;
        }
        Debug.Log(Judge.IsKQ);

        if (Judge.IsKQ == false)
        {

            interval = 2;
            BulletNum = Random.Range(2, 10);

            timer += Time.deltaTime;
            if (timer > interval && Fire.isFire == true)
            {
                generator = StartCoroutine(GenerateObjects());
                timer = 0;
            }
        }
       else
        {
            timer += Time.deltaTime;
            interval = 0.1f;
            if (timer > interval)
            {
                BulletNum = 1;
                generator = StartCoroutine(GenerateObjects2());
                timer = 0;
            }
            
            
           
        }
    }
    IEnumerator GenerateObjects()
    {
        for (int i = 0; i < BulletNum; i++)
        {
            yield return new WaitForSeconds(CreatTime);
            SoundManager.instance.PlaySound(Globals.S_Shoot);
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
    }
    IEnumerator GenerateObjects2()
    {
        for (int i = 0; i < BulletNum; i++)
        {
            yield return new WaitForSeconds(CreatTime);
            SoundManager.instance.PlaySound(Globals.S_Shoot);
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
            Instantiate(bullet, bulletPos2.position, Quaternion.identity);
            Instantiate(bullet, bulletPos3.position, Quaternion.identity);
        }
    }
}
