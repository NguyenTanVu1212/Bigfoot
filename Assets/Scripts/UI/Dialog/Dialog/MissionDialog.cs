using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MissionDialog :  BaseDialog 
{
    MissionDialogParam param;
    MissionConfigData data = new MissionConfigData();
    [SerializeField] GameObject listEnemyView;
    [SerializeField] GameObject cardEnemy;
    [SerializeField] Button playButton;
    DifficultGame difficultGame;
    
    List<int> lsIdEnemy =  new List<int>();
   
    public override void OnSetup(DialogParam param = null)
    {
        lsIdEnemy.Clear();    
        this.param = (MissionDialogParam)param;
        //data = DataManager.instance.missionConfig.FindDataById(this.param.id);
        //foreach(var e in data.state_1.Split(','))
        //{
        //    if(!lsIdEnemy.Contains(int.Parse(e)))
        //    {
        //        lsIdEnemy.Add(int.Parse(e));
        //    }
        //}
        //foreach (var e in data.state_2.Split(','))
        //{
        //    if (!lsIdEnemy.Contains(int.Parse(e)))
        //    {
        //        lsIdEnemy.Add(int.Parse(e));
        //    }
        //}
        //foreach (var e in data.state_3.Split(','))
        //{
        //    if (!lsIdEnemy.Contains(int.Parse(e)))
        //    {
        //        lsIdEnemy.Add(int.Parse(e));
        //    }
        //}
        //foreach(var e in lsIdEnemy)
        //{
        //    GameObject card = Instantiate(cardEnemy);
        //    card.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load("UI/Board/" + 1 , typeof(Sprite)) as Sprite;
        //    card.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load("UI/Icon/Enemy/" + e, typeof(Sprite)) as Sprite;
        //    card.transform.SetParent(listEnemyView.transform);
        //}
        base.OnSetup(param);
    }
    public override void OnHideDialog()
    {
        this.transform.SetParent(null);
        if (listEnemyView.transform.childCount != 0)
        {
            for (int i = 0; i < listEnemyView.transform.childCount; i++)
            {
                Destroy(listEnemyView.transform.GetChild(i).gameObject);
            }

        }
        base.OnHideDialog();
    }
    public void Btn_Close()
    {
        DialogManager.instance.HideDialog(this);
    }

    public void Btn_Button()
    {
        //LoadSceneManager.instance.LoadAsynScene("GameScene",  ()=> {
        //    MissionManager.instance.ChoseLevel(this.param.id);
        //});
    }
}
public enum DifficultGame
{
    Normal = 0,
    Medium = 1, 
    Hard =3
}