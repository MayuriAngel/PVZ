using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torchwood : Plant
{
    private GameObject FireBulletPrefab;
    protected override void Start()
    {
        base.Start();
        FireBulletPrefab = Resources.Load("Prefab/FireBullet") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            if (bullet.TorchwoodCreate)
            {
                return;
            }
            //销毁
            bullet.DestroyBullet();
            //计算触发点的位置
            CreateBullet(collision.bounds.ClosestPoint(transform.position));
        }
    }
    private void CreateBullet(Vector3 borPos)
    {
        GameObject fireBullet = Instantiate(FireBulletPrefab, borPos, Quaternion.identity);
        fireBullet.transform.parent = transform.parent;
        fireBullet.transform.position = borPos;
        fireBullet.GetComponent<Bullet>().TorchwoodCreate = true;
    }
}
