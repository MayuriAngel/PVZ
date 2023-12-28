
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNormal : MonoBehaviour
{
    public Vector3 direction = new Vector3(-1, 0, 0);
    public float speed = 1;
    protected bool isWalk;
    protected Animator animator;

    public float damage;
    public float damageInterval = 0.5f;
    protected float damageTimer;

    public float health = 100;
    public float lostHeadHealth = 15;
    protected float currentHealth;
    protected GameObject head;
    protected bool lostHead;
    public bool isDie;
    
    protected virtual void  Start()
    {
        isWalk = true;
        animator = GetComponent<Animator>();
        damageTimer = 0;

        currentHealth = health;
        head = transform.Find("Head").gameObject;
        isDie = false;
        lostHead = false;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (isDie)
            return;
        Move();
    }

    protected void Move()
    {
        if (isWalk)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    // ��ײ��ʼ
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDie)
            return;
        if (other.tag == "Plant")
        {
            // ����ֲ�ֹͣ�ƶ�
            isWalk = false;
            animator.SetBool("Walk", false);
            SoundManager.instance.PlaySound(Globals.S_ZombieEat);
            
        }
    }

    // ��ײ������
    private void OnTriggerStay2D(Collider2D other)
    {
        if (isDie)
            return;
        if (other.tag == "Plant")
        {
            
            // �����Ӵ�ֲ�����˺�
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                damageTimer = 0;
                // ������ֲ������˺�
                Plant plant = other.GetComponent<Plant>();
                float newHealth = plant.ChangeHealth(-damage);
                if (newHealth <= 0)
                {
                    isWalk = true;
                    animator.SetBool("Walk", true);
                }
            }
        }
    }

    // ��ײ�˳�
    private void OnTriggerExit2D(Collider2D other)
    {
        if (isDie)
            return;
        if (other.tag == "Plant")
        {
            // �뿪ֲ�����ֲ�ﱻ�����ˣ������ƶ�
            isWalk = true;
            animator.SetBool("Walk", true);
            
        }
    }




public virtual void ChangeHealth(float num)
    {
        currentHealth = Mathf.Clamp(currentHealth + num, 0, health);
        // Ѫ�ߵ���lostHeadHealthʱ������LostHead״̬
        if (currentHealth < lostHeadHealth && !lostHead)
        {
            lostHead = true;
            animator.SetBool("LostHead", true);
            head.SetActive(true);
        }
        if (currentHealth <= 0)
        {
            animator.SetTrigger("Die");
            
            isDie = true;
        }
    }

    public void DieAniOver()
    {
        
        animator.enabled = false;
        
        GameManager.instance.ZombieDied(gameObject);
        Destroy(gameObject);

    }

}

