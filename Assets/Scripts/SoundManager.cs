using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //创建一个单例
    public static SoundManager instance;
    //用于播放音乐
    private AudioSource audioSource;

    private Dictionary<string, AudioClip> diactAudio;

    private void Awake()
    {
        //初始化
        instance = this;
        audioSource = GetComponent<AudioSource>();
        diactAudio = new Dictionary<string, AudioClip>();
    }
    void Start()
    {

    }


    void Update()
    {

    }
    //辅助函数：加载音频，要确保音频文件的路径在Resources文件夹下
    public AudioClip LoadAudio(string path)
    {
        return (AudioClip)Resources.Load(path);
    }
    //辅助函数:获取音频，并且将其缓存在dictAudio中，避免重复加载
    private AudioClip GetAudio(string path)
    {
        if (!diactAudio.ContainsKey(path))
        {
            diactAudio[path] = LoadAudio(path);
        }
        return diactAudio[path];
    }
    //播放音乐
    public void PlayBGM(string name, float volume = 1.0f)
    {
        audioSource.Stop();
        audioSource.loop = true;
        audioSource.clip = GetAudio(name);
        audioSource.Play();
    }
    //停止音乐
    public void StopBGM()
    {
        audioSource.Stop();
    }

    //播放音效
    public void PlaySound(string path, float volume = 1.0f)
    {

        audioSource.PlayOneShot(LoadAudio(path), volume);

    }
    public void PlaySound(AudioSource audioSource, string path, float volume = 1.0f)
    {
        audioSource.PlayOneShot(LoadAudio(path), volume);

    }
}
