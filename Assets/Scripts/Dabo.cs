using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dabo : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public GameObject Two;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.IsTwo == true)
        {
            //Two.SetActive(true);
            canvasGroup.DOFade(0, 4);
        }
    }
}
