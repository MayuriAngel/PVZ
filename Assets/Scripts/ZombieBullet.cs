using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBullet : MonoBehaviour
{

    public Vector3 direction;
    public float speed;
    public float damage = 15;

    
    protected virtual void Start()
    {
        Destroy(gameObject, 10);
    }
    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {

            //植物受到攻击
            Plant plant = collision.GetComponent<Plant>();
            plant.ChangeHealth(-damage);
            DestroyBullet();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
    //销毁子弹
    public virtual void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
