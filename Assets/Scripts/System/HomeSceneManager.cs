using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSceneManager : MonoBehaviour
{
    private void Start()
    {
        HomeSceneViewManager.instance.SwitchView(HomeSceneViewIndex.HomeView , null);
    }
}
