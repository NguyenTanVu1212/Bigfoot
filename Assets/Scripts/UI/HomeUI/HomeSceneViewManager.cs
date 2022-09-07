using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HomeSceneViewManager : MonoBehaviour
{
    public static HomeSceneViewManager instance;
    
    private void Awake()
    {
        if (instance == null) instance = this;
        Screen.SetResolution(1920,1080, FullScreenMode.FullScreenWindow , 60);
        foreach (HomeSceneViewIndex e in HomeSceneConfig.homeSceneViewIndices)
        {
            string s = e.ToString();
            GameObject viewObject = Instantiate(Resources.Load("UI/HomeScene/" + s, typeof(GameObject))) as GameObject;
            viewObject.transform.SetParent(transform, false);
            RectTransform rect = viewObject.GetComponent<RectTransform>();
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            HomeSceneViewBase view = viewObject.GetComponent<HomeSceneViewBase>();
            dicView.Add(view.viewIndex, view);
            viewObject.SetActive(false);
        }
        
        //DontDestroyOnLoad(currentIndex);
    }
    [SerializeField] Dictionary<HomeSceneViewIndex, HomeSceneViewBase> dicView = new Dictionary<HomeSceneViewIndex, HomeSceneViewBase>();
    public HomeSceneViewBase currentView  ;
    public HomeSceneViewIndex currentIndex ;

    private void Start()
    {
       
    }

    public void SwitchView(HomeSceneViewIndex index , Action callback )
    {
        DialogManager.instance.HideAllDialog();
        if(currentView!= null)
        {
            currentView.HideView(()=>{
                currentView.gameObject.SetActive(false);
                ShowNewView(index , callback);
            });
        }
        else
        {          
            ShowNewView(index , callback);
        }
        //DontDestroyOnLoad(currentView);
    }

    void ShowNewView(HomeSceneViewIndex index, Action callback )
    {
        currentIndex = index;
        currentView = dicView[index];
        currentView.gameObject.SetActive(true);
        currentView.ShowView(callback);
        callback?.Invoke();
    }
}