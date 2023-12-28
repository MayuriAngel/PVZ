using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScene2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayBGM(Globals.BGM7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
