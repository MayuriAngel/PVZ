using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoadingPanel : MonoBehaviour
{
    public Slider slider;
    public GameObject btnStart;
    //当前进度条的进度
    public float curProgress;
    public float loadingTime = 2;
    public bool really = true;
    AsyncOperation operation;
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);
        btnStart.SetActive(false);
        //点击的监听事件
        btnStart.GetComponent<Button>().onClick.AddListener(OnBtnStart);
        curProgress = 0;
        slider.value = curProgress;
        if (really)
        {
            operation = SceneManager.LoadSceneAsync("Menu");
            operation.allowSceneActivation = false;
        }
    }

    void OnBtnStart()
    {
        if (!really)
        {
            
            SceneManager.LoadScene("Menu");
        }
        else
        {
            operation.allowSceneActivation = true;
        }
        DOTween.Clear();
    }

    void OnSliderValueChange(float value)
    {
        slider.value = value;
        if (value >= 1.0)
        {
            btnStart.SetActive(true);
        }
    }

    void Update()
    {
        if (!really)
        {

            curProgress += Time.deltaTime / loadingTime;
            if (curProgress > 1.0)
            {
                curProgress = 1;
            }
            OnSliderValueChange(curProgress);

        }
        else
        {
            curProgress = Mathf.Clamp01(operation.progress / 0.9f);
            OnSliderValueChange(curProgress);
        }
    }
}
