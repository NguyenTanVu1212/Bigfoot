using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelGameView : HomeSceneViewBase
{
    [SerializeField] List<Button> lsBtn = new List<Button>();
    public override void OnSetup()
    {
        foreach(var e in lsBtn)
        {
            e.onClick.AddListener(()=> {
                DialogManager.instance.HideAllDialog();
                //MissionConfigData data = DataManager.instance.missionConfig.FindDataById(lsBtn.IndexOf(e));
                MissionDialogParam dataParam = new MissionDialogParam();
                dataParam.id = lsBtn.IndexOf(e);
                //DialogManager.instance.ShowDialog(DialogIndex.MissionDialog, dataParam, () =>
                //{

                //    DialogManager.instance.currentDialog.transform.SetParent(transform);
                //});
                LoadSceneManager.instance.LoadAsynScene("GameScene", () => {
                    MissionManager.instance.ChoseLevel(dataParam.id);
                });
            });
        }
        base.OnSetup();
    }
    public void Leval_01()
    {
        
        
        //LoadSceneManager.instance.LoadAsynScene("GameScene", ()=> {
        //    DataManager.instance.ChoseLevel(0);
        //});
    }
    public void Leval_02()
    {
        //DataManager.instance.ChoseLevel(1);

        //LoadSceneManager.instance.LoadAsynScene("GameScene", () => {
        //    DataManager.instance.ChoseLevel(1);
        //});
    }
    public void BackToHome()
    {
        HomeSceneViewManager.instance.SwitchView(HomeSceneViewIndex.HomeView, () =>
        {

        });
    }

}
