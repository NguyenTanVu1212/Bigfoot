using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class LoadSceneManager : MonoBehaviour
{
    public static LoadSceneManager instance;

    Action callBackLoadScene;
    int curentIndex;
    string curenttName;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void LoadScene(string sceneName , Action callback)
    {
        curenttName = sceneName;
        callBackLoadScene = callback;
        SceneManager.LoadScene(curenttName , LoadSceneMode.Single);
        SceneManager.sceneLoaded += OnLoadScene;
    }
    public void LoadScene(int sceneIndex, Action callback)
    {
        curentIndex = sceneIndex;
        callBackLoadScene = callback;
        SceneManager.LoadScene(curentIndex, LoadSceneMode.Single);
        SceneManager.sceneLoaded += OnLoadScene;
    }

    void OnLoadScene(Scene scene  , LoadSceneMode mode)
    {
        if (scene.name == curenttName)
        {
            callBackLoadScene?.Invoke();
        }else if (scene.buildIndex== curentIndex)
        {
            callBackLoadScene?.Invoke();
        }
    }
    public void LoadAsynScene(int sceneIndex , Action callback)
    {
        DialogManager.instance.HideAllDialog();
        HomeSceneViewManager.instance.SwitchView(HomeSceneViewIndex.LoadingView , null);
        StartCoroutine(LoadAsynLoop(sceneIndex , callback));
    }
    public void LoadAsynScene(string sceneName, Action callback)
    {
        DialogManager.instance.HideAllDialog();
        HomeSceneViewManager.instance.SwitchView(HomeSceneViewIndex.LoadingView, ()=> {
        });
        
        StartCoroutine(LoadAsynLoop(sceneName, callback));

        
    }

    public IEnumerator LoadAsynLoop(int sceneIndex, Action callback)
    {
        yield return new WaitForSeconds(1);
        LoadingView view = (LoadingView)HomeSceneViewManager.instance.currentView;
        yield return new WaitForSeconds(0.4f);
        AsyncOperation asynLoad = SceneManager.LoadSceneAsync(sceneIndex);
        callback?.Invoke();
        
        while (!asynLoad.isDone)
        {
            view.SettingProgress(asynLoad.progress);
            //if(asynLoad.progress > 0.5f)
            //{
            //    
            //}
            yield return null;
        }
        
    }
    public IEnumerator LoadAsynLoop(string sceneName, Action callback)
    {
        
        yield return new WaitForSeconds(1f);
        LoadingView view = (LoadingView)HomeSceneViewManager.instance.currentView;
        yield return new WaitForSeconds(0.4f);      
        AsyncOperation asynLoad = SceneManager.LoadSceneAsync(sceneName);
        callback?.Invoke();
        while (!asynLoad.isDone)
        {
            if(asynLoad.progress > 0.5)
            {
                view.SettingProgress(asynLoad.progress);
            }
             yield return null ;
        }
        

    }
}
