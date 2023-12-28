using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFire : MonoBehaviour
{
    public bool isFire = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie")) {
        isFire = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            isFire = false;
        }
    }
}
