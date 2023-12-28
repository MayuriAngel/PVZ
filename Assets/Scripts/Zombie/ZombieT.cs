using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieT : ZombieNormal
{
    public GameObject normalZombiePrefab;


    public override void ChangeHealth(float num)
    {
        SoundManager.instance.PlaySound(Globals.S_Shieldhit);
        currentHealth = Mathf.Clamp(currentHealth + num, 0, health);
        // 血线低于lostHeadHealth时，进入LostHead状态
        if (currentHealth < lostHeadHealth && !lostHead)
        {
            Destroy(gameObject);
        }

    }
    public void OnDestroy()
    {
        CreateNormalZombie();
        GameManager.instance.ZombieDied(gameObject);
    }
    private void CreateNormalZombie()
    {
        // 在原地创建普通僵尸  
        Instantiate(normalZombiePrefab, transform.position, transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Plant")
        {
            // 碰到植物，停止移动
            isWalk = false;
            animator.SetBool("IsPlant", true);
        }
    }
    // 碰撞退出
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Plant")
        {
            // 离开植物，或者植物被消灭了，继续移动
            isWalk = true;
            animator.SetBool("IsPlant", false);
        }
    }
}
