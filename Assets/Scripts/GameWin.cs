using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class GameWin : MonoBehaviour
{
    public Text Ts;
    public CanvasGroup canvasGroup;
    public Button button;
    public GameObject IsShow;
    //��ʱ��
    private float timer;
    //��Ϸ�Ƿ�ʤ��
    private bool IsWin = false;
    void Start()
    {
        button.onClick.AddListener(OnBtnWin);
    }


    void Update()
    {
        if (IsWin == true)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                Time.timeScale = 0;
            }
        }
    }
   public void  OnBtnWin()
    {
        IsWin = true;
        IsShow.SetActive(true);
        Ts.text = "��Ϸʤ�����ݰ�";
        
        canvasGroup.DOFade(0, 5);
        
    }
}
