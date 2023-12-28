using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieBoos : MonoBehaviour
{
    public Transform Pos;
    public GameObject Bullet;
    //间隔时间
    public float interval;
    //计时器
    private float timer;
   

    
    void Update()
    {

       
        timer += Time.deltaTime;
        if (timer > interval)
        {
            SoundManager.instance.PlaySound(Globals.S_Shoot);
            Instantiate(Bullet, Pos.position, Quaternion.identity);
            timer = 0;

        }


    }

    
}
