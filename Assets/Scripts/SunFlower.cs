using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : Plant
{
    public GameObject SunPreFab;

    public float readyTime;
    private float timer;

    private int SunNum;
    protected override void Start()
    {
        base.Start();
        timer = 0;
        SunNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!start) { return; }
        timer += Time.deltaTime;
        if (timer > readyTime)
        {
            animator.SetBool("Ready", true);
            timer = 0;
        }

    }
    public void BornSunOver()
    {
        BornSum();
        animator.SetBool("Ready", false);

    }

    //����̫��
    private void BornSum()
    {
        GameObject sunNew = Instantiate(SunPreFab);
        SunNum += 1;
        float randowX;
        //����̫�����������
        if (SunNum % 2 == 1)
        {
            randowX = Random.Range(transform.position.x - 30, transform.position.x - 20);
        }
        else
        {
            //ż��̫�����ұ�����
            randowX = Random.Range(transform.position.x + 20, transform.position.x + 20);
        }
        float randowY = Random.Range(transform.position.y - 20, transform.position.y + 20);
        sunNew.transform.position = new Vector2(randowX, randowY);
    }
}
