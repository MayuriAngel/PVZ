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
        // Ѫ�ߵ���lostHeadHealthʱ������LostHead״̬
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
        // ��ԭ�ش�����ͨ��ʬ  
        Instantiate(normalZombiePrefab, transform.position, transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Plant")
        {
            // ����ֲ�ֹͣ�ƶ�
            isWalk = false;
            animator.SetBool("IsPlant", true);
        }
    }
    // ��ײ�˳�
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Plant")
        {
            // �뿪ֲ�����ֲ�ﱻ�����ˣ������ƶ�
            isWalk = true;
            animator.SetBool("IsPlant", false);
        }
    }
}
