using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LoadingHandle : MonoBehaviour
{

    void Start()
    {
        //��ת�ĽǶȣ�ʱ�������룬������360�㣬������ת��ʽ��������ת��ѭ����ʽ-1����ѭ�����Ҵ�ͷ��ʼ
        //transform.DORotate(new Vector3(0, 0, -360), 2, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        transform.DORotate(new Vector3(0, 0, -360), 2, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

