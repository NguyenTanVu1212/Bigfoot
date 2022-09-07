using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSceneConfig 
{
   public static HomeSceneViewIndex[] homeSceneViewIndices = {HomeSceneViewIndex.StartView ,
        HomeSceneViewIndex.HomeView , HomeSceneViewIndex.CategoryView , HomeSceneViewIndex.LevelGameView
        , HomeSceneViewIndex.LoadingView , HomeSceneViewIndex.GameView};
}
public enum HomeSceneViewIndex
{
    StartView = 0,
    HomeView = 1,
    CategoryView = 2,
    LevelGameView = 3,
    LoadingView = 4,
    GameView = 5
}
