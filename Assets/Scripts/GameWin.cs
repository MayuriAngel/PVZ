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
    //计时器
    private float timer;
    //游戏是否胜利
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
        Ts.text = "游戏胜利，拜拜";
        
        canvasGroup.DOFade(0, 5);
        
    }
}
