using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooterNew : MonoBehaviour
{
    public GameObject bulletPrefab; // �㶹Ԥ����
    //public Transform firePoint; // �����
    //public Transform firePoint; // �����
    public Transform bulletPos;

    public float bulletSpeed = 10f; // �㶹�ٶ�
    public float fireRate = 1f; // ����Ƶ��
    public float range = 50f; // ���

    private float fireCountdown = 0f; // ���䵹��ʱ

    void Update()
    {
        // ����Ƿ��н�ʬ�������
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Zombie"))
            {
                // ���㷽������
                Vector3 direction = hitCollider.transform.position - transform.position;

                // �������߼���Ƿ��ܹ�������ʬ
                RaycastHit hit;
                if (Physics.Raycast(bulletPos.position, direction, out hit, range))
                {
                    if (hit.collider.CompareTag("Zombie"))
                    {
                        // �����㶹
                        Fire();
                        break;
                    }
                }
            }
        }

        // ���·��䵹��ʱ
        if (fireCountdown > 0f)
        {
            fireCountdown -= Time.deltaTime;
        }
    }

    // �����㶹
    void Fire()
    {
        if (fireCountdown <= 0f)
        {
         Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation);
            
        }
    }
}
