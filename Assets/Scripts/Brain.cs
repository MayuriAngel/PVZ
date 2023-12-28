using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Brain : MonoBehaviour
{
    public GameObject Loss;
    private void Start()
    {
        
        
    }
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            Destroy(gameObject, 1.5f);
           
            
        }
       
    }
    private void OnDestroy()
    {
        Loss.SetActive(true);
        
        Time.timeScale = 0;

        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySound(Globals.S_Lost);

    }
    

}
