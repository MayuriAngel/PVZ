using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{
    public override void DestroyBullet()
    {
        base.DestroyBullet();
        GameObject FirePrefab = Resources.Load("Prefab/Fire") as GameObject;
        Instantiate(FirePrefab, transform.position, Quaternion.identity);

    }
}
