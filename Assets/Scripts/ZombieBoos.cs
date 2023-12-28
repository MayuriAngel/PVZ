using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieBoos : MonoBehaviour
{
    public Transform Pos;
    public GameObject Bullet;
    //���ʱ��
    public float interval;
    //��ʱ��
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
