using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float duration;
    private float timer;
    //����̫�������λ��
    public Vector3 targetPos;
    
    private void Start()
    {
        timer = 0;
        
    }
    public void SetTargetPos(Vector3 pos)
    {
        targetPos = pos;
    }
    private void Update()
    {
        //���ƶ������
        if (targetPos != Vector3.zero && Vector3.Distance(targetPos, transform.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.2f);
            return;

        }
        //���ӳ�����
        timer += Time.deltaTime;
        if (timer > duration)
        {       
            Destroy(gameObject);
        }
    }
    private void OnMouseDown()
    {
        SoundManager.instance.PlaySound(Globals.S_SunCollect);
           Destroy(gameObject);
            GameManager.instance.ChangeSunNum(50);
        
       
    }
}
