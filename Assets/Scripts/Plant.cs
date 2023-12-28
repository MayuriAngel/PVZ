using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public float health = 100;
    protected float currentHealth;
    protected bool start;
    protected Animator animator;
    protected BoxCollider2D boxCollider2D;
    public bool IsPlant = true;
    protected virtual void Start()
    {
        currentHealth = health;
        start = false;
        animator = GetComponent<Animator>();
        animator.speed = 0;
        boxCollider2D = GetComponent<BoxCollider2D>();
        if (IsPlant)
        {
            boxCollider2D.enabled = false;
        }
    }


    void Update()
    {

    }
    //��ֲ��ɺ�����ֲ��
    public virtual void SetPlantStart()
    {
        start = true;
        animator.speed = 1.0f;
       
        boxCollider2D.enabled = true;
    }

    //�ı�Ѫ��
    public virtual float ChangeHealth(float num)
    {
        currentHealth = Mathf.Clamp(currentHealth + num, 0, health);
        if (currentHealth <= 0)
        {
            GameObject.Destroy(gameObject);
        }
        return currentHealth;
    }
}
