using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManger : MonoBehaviour
{
    public static GameManger instance;
    public bool isWin;
    public bool isLost;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080 ,FullScreenMode.ExclusiveFullScreen);
        HomeSceneViewManager.instance.SwitchView(HomeSceneViewIndex.GameView , null);
        isWin = false;
        isLost = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            isLost = true;
        }
    }
    void Update()
    {
       if(isWin || isLost)
       {
            DialogManager.instance.ShowDialog(DialogIndex.ResultDialog);
            DialogManager.instance.currentDialog.gameObject.transform.SetParent(
                HomeSceneViewManager.instance.currentView.gameObject.transform.GetChild(0).GetChild(2));
       }
    }
    public void OnExit()
    {
        SceneManager.LoadScene("HomeScene");
    }
   
}
