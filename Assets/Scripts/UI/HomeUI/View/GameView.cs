using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class GameView : HomeSceneViewBase
{
    public GameObject topPanel, midPanel, botPanel;
    public GameObject heroView;
    public GameObject parent , lsCardSelect;
    public GameObject cardObj;
    public Button playeGameButton;
    public Slider progress;
    [SerializeField] GameObject cardReview;
    int total = 4;
    List<GameObject> lsCard = new List<GameObject>();
    public void PlayGame()
    {
        if (total >= 0)
            return;
        topPanel.transform.DOLocalMoveY(413.15f, 3f);
        botPanel.transform.DOLocalMoveY(-483f, 3f);
        heroView.transform.DOLocalMoveX(-1698f, 3f);
        //enemyView.transform.DOLocalMoveX(1400f, 3f);
        PoolObject.instance.CreateHero(CardManager.instance.idCard);
        CardManager.instance.CreateListCard();
        EnemyManager.instance.StartSpamEnemy();
        SoulManager.instance.StartSpamSoul();
        progress.maxValue = EnemyManager.instance.counter;
        progress.minValue = 0;
    }
    public override void OnSetup()
    {
        playeGameButton.onClick.AddListener(PlayGame);
        for (int i = 0; i <= 9; i++)
        {
            GameObject card = Instantiate(cardObj, parent.transform);
            card.GetComponent<CardDemo>().touchPanel = cardReview;
            card.GetComponent<CardDemo>().OnSetup(DataManager.instance.cardConfig.FindById(i), () =>
            { 
            });
            lsCard.Add(card);
        }
        heroView.transform.DOLocalMoveX(0 , 2.5f).OnComplete(()=> {
            foreach(var e in lsCard)
            {
                e.GetComponent<CardDemo>().AddActionButton(()=> 
                {
                    if (e.gameObject.transform.parent == parent.transform)
                    {
                        if (total < 0) return;
                        CardManager.instance.idCard.Add(e.GetComponent<CardDemo>().id);
                        e.gameObject.transform.SetParent(lsCardSelect.transform);
                        total--;
                        e.GetComponent<CardDemo>().IsSeclect = true;
                    }
                    else if (e.gameObject.transform.parent == lsCardSelect.transform)
                    {
                        total++;
                        e.gameObject.transform.SetParent(parent.transform);
                        CardManager.instance.idCard.Remove(e.GetComponent<CardDemo>().id);
                        e.GetComponent<CardDemo>().IsSeclect = false;
                    }
                });
            }
            CardReviewDialogParam param = new CardReviewDialogParam();
            param.id = 0;
            DialogManager.instance.ShowDialog(DialogIndex.CardReviewDialog , param , ()=> {
                DialogManager.instance.currentDialog.transform.SetParent(cardReview.transform);
                DialogManager.instance.currentDialog.GetComponent<RectTransform>().localPosition = new Vector2(0,0);
            });
        }).SetOptions(true);
        //enemyView.transform.DOLocalMoveX(628.71f , 3f);
        base.OnSetup();
    }
    public void Update()
    {
        progress.value = EnemyManager.instance.totalEnemyReSpam;
    }
    public override void OnShowView()
    {
        base.OnShowView();
    }
    public void Pause()
    {
        DialogManager.instance.ShowDialog(DialogIndex.PauseDialog);
        DialogManager.instance.currentDialog.gameObject.transform.SetParent(
            HomeSceneViewManager.instance.currentView.gameObject.transform.GetChild(0).GetChild(2));
    }
}
