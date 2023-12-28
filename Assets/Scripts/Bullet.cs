using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public float damage = 15;

    //�ж��㶹�Ƿ��ɻ����׮����
    public bool TorchwoodCreate;
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
        if (collision.tag == "Zombie")
        {
            SoundManager.instance.PlaySound(Globals.S_PeaHit);
            //��˿�ܵ�����
            collision.GetComponent<ZombieNormal>().ChangeHealth(-damage);
            DestroyBullet();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "EnemyBullet")
        {
            Destroy(gameObject);
        }
    }
    //�����ӵ�
    public virtual void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
