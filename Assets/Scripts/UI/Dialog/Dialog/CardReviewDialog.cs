using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardReviewDialog : BaseDialog
{
    CardReviewDialogParam cardConfig;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI damageText, hpText, rofText, costText , nameText , crit , timeeffect , textExplain;
    public override void OnSetup(DialogParam param = null)
    {
        cardConfig = (CardReviewDialogParam)param;
        HeroConfigData dataHero = DataManager.instance.heroConfig.FindDataById(cardConfig.id);
        CardConfigData cardData =  DataManager.instance.cardConfig.FindById(cardConfig.id);
        string path = "UI/Icon/Hero/Forest " + (cardConfig.id + 1).ToString();
        image.sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
        damageText.text = dataHero.Damage.ToString();
        hpText.text = dataHero.Hp.ToString();
        rofText.text = dataHero.Rof.ToString();
        crit.text = dataHero.Crit.ToString();
        costText.text = cardData.cost.ToString();
        timeeffect.text = dataHero.TimeEffect.ToString();
        nameText.text = dataHero.NameHero.ToString();
        textExplain.text = cardData.explain;
        base.OnSetup(param);
    }
    public void OnClose()
    {
        DialogManager.instance.HideDialog(this);
    }
}
