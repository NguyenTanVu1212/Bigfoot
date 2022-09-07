using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneManager : MonoBehaviour
{
    public void Btn_Start()
    {
        LoadSceneManager.instance.LoadAsynScene("HomeScene" , ()=> 
        {
           
        });
    }
}
