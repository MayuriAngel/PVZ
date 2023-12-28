using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //����һ������
    public static SoundManager instance;
    //���ڲ�������
    private AudioSource audioSource;

    private Dictionary<string, AudioClip> diactAudio;

    private void Awake()
    {
        //��ʼ��
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
    //����������������Ƶ��Ҫȷ����Ƶ�ļ���·����Resources�ļ�����
    public AudioClip LoadAudio(string path)
    {
        return (AudioClip)Resources.Load(path);
    }
    //��������:��ȡ��Ƶ�����ҽ��仺����dictAudio�У������ظ�����
    private AudioClip GetAudio(string path)
    {
        if (!diactAudio.ContainsKey(path))
        {
            diactAudio[path] = LoadAudio(path);
        }
        return diactAudio[path];
    }
    //��������
    public void PlayBGM(string name, float volume = 1.0f)
    {
        audioSource.Stop();
        audioSource.loop = true;
        audioSource.clip = GetAudio(name);
        audioSource.Play();
    }
    //ֹͣ����
    public void StopBGM()
    {
        audioSource.Stop();
    }

    //������Ч
    public void PlaySound(string path, float volume = 1.0f)
    {

        audioSource.PlayOneShot(LoadAudio(path), volume);

    }
    public void PlaySound(AudioSource audioSource, string path, float volume = 1.0f)
    {
        audioSource.PlayOneShot(LoadAudio(path), volume);

    }
}
