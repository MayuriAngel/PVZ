using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooterNew : MonoBehaviour
{
    public GameObject bulletPrefab; // 豌豆预制体
    //public Transform firePoint; // 发射点
    //public Transform firePoint; // 发射点
    public Transform bulletPos;

    public float bulletSpeed = 10f; // 豌豆速度
    public float fireRate = 1f; // 发射频率
    public float range = 50f; // 射程

    private float fireCountdown = 0f; // 发射倒计时

    void Update()
    {
        // 检测是否有僵尸在射程内
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Zombie"))
            {
                // 计算方向向量
                Vector3 direction = hitCollider.transform.position - transform.position;

                // 发射射线检测是否能攻击到僵尸
                RaycastHit hit;
                if (Physics.Raycast(bulletPos.position, direction, out hit, range))
                {
                    if (hit.collider.CompareTag("Zombie"))
                    {
                        // 发射豌豆
                        Fire();
                        break;
                    }
                }
            }
        }

        // 更新发射倒计时
        if (fireCountdown > 0f)
        {
            fireCountdown -= Time.deltaTime;
        }
    }

    // 发射豌豆
    void Fire()
    {
        if (fireCountdown <= 0f)
        {
         Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation);
            
        }
    }
}
