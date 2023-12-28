using UnityEngine;
using UnityEngine.UI;
public class IsExit : MonoBehaviour
{
    public Button IsOk;
    public Button IsCancel;
    public GameObject ExitGame;
    void Start()
    {
        IsOk.onClick.AddListener(OnBtnOk);
        IsCancel.onClick.AddListener(() => { ExitGame.SetActive(false);  Time.timeScale = 1; });
    }

    public void OnBtnOk()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    void Update()
    {
        
    }
}
