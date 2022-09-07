using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartView : HomeSceneViewBase
{
   public void StartGame()
   {
        HomeSceneViewManager.instance.SwitchView(HomeSceneViewIndex.LoadingView , ()=> {
            nextView = HomeSceneViewIndex.HomeView;
        });
   }
}
