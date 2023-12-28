using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
   public GameObject Exit;
    void Start()
    {
      
        
    }

    private void Update()
    {
        
    }
   public void  OnBtnExit()
    {
       
        Time.timeScale = 0;
        Exit.SetActive(true);
        SoundManager.instance.PlaySound(Globals.S_Pause);

    }
    public void OnBtnReturn()
    {
        Debug.Log("·µ»Ø");
        SceneManager.LoadScene("Menu");
       
    }
    public void OnBtnContinue()
    {
        Time.timeScale = 1;
        Exit.SetActive(false);
    }
    public void OnBtnRetry()
    {
        
        SceneManager.LoadScene("Game");
       
    }
}
