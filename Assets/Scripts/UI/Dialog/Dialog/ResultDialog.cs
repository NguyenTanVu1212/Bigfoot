using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResultDialog : BaseDialog
{
    [SerializeField] GameObject winResult , lostResult ;
    [SerializeField] TextMesh gold, exp;

    public override void OnSetup(DialogParam param = null)
    {
        //Time.timeScale = 0;
        if(GameManger.instance.isWin)
        {
            lostResult.SetActive(false);
            winResult.SetActive(true);
        }
        if (GameManger.instance.isLost)
        {
            lostResult.SetActive(true);
            winResult.SetActive(false);
        }
        base.OnSetup(param);
    }
    public override void OnHideDialog()
    {
        Time.timeScale = 1;
        base.OnHideDialog();
    }
    public void Claim()
    {
        this.transform.SetParent(null);
        Time.timeScale = 1;
        DialogManager.instance.HideDialog(this);
        LoadSceneManager.instance.LoadAsynScene("HomeScene" , ()=> {
            
        });
    }
}
