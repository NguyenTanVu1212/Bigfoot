using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryView : HomeSceneViewBase
{
    public void BackToHome()
    {
        HomeSceneViewManager.instance.SwitchView(HomeSceneViewIndex.HomeView, null);
    }
    public void ChoeseChapter()
    {
        HomeSceneViewManager.instance.SwitchView(HomeSceneViewIndex.LevelGameView, null);
    }
         
}
