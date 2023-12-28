using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallNut : Plant
{
    protected override void Start()
    {
        base.Start();
       
    }
    private void Update()
    {
        
    }
    public override float ChangeHealth(float num)
    {
        float currentHealth = base.ChangeHealth(num);
        //修改动画参数
        animator.SetFloat("BloodPercent", (float)currentHealth/health);
        
        return currentHealth;
    }

}
