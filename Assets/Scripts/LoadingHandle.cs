using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LoadingHandle : MonoBehaviour
{

    void Start()
    {
        //旋转的角度，时间是两秒，类型是360°，设置旋转方式是线性旋转，循环方式-1永久循环并且从头开始
        //transform.DORotate(new Vector3(0, 0, -360), 2, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        transform.DORotate(new Vector3(0, 0, -360), 2, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

