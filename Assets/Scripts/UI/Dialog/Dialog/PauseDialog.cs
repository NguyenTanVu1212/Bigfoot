using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PauseDialog : BaseDialog
{
    [SerializeField] Slider musicSlier, soundEffectSlider;
    [SerializeField] TMP_InputField musicText, soundEffectText;
    [SerializeField] GameObject mute, unmute, sf, unsf;

    
   
    //public bool UnMute 
    //{
    //    get { return UnMute; }
    //    set 
    //    {
    //        if(value)
    //        {
    //            unmute.SetActive(true) ;
    //            mute.SetActive(false);
    //        }else
    //        {
    //            unmute.SetActive(false);
    //            mute.SetActive(true);
    //        }
    //        UnMute = value;
    //    }
    //}

    //public bool SFX
    //{
    //    get { return SFX; }
    //    set
    //    {
    //        if (value)
    //        {
    //            sf.SetActive(true);
    //            unsf.SetActive(false);
    //        }
    //        else
    //        {
    //            sf.SetActive(false);
    //            unsf.SetActive(true);
    //        }
    //        SFX = value;
    //    }
    //}
    

    public override void OnSetup(DialogParam param = null)
    {
        Time.timeScale = 0;
        base.OnShow();
    }
    public void Start()
    {
        //UnMute = true;
        //SFX = true;
        musicSlier.maxValue = 100;
        musicSlier.minValue = 0;
        musicSlier.value  = 50;
        musicText.text = musicSlier.value.ToString();
        soundEffectSlider.maxValue = 100;
        soundEffectSlider.minValue = 0;
        soundEffectSlider.value  = 50;
        soundEffectText.text = musicSlier.value.ToString();
        
    }

    public override void OnHideDialog()
    {
        Time.timeScale = 1;
        base.OnHideDialog();
    }
    private void Update()
    {
        
    }
    public void OnChangeValuesMusicText()
    {
        musicSlier.value = int.Parse(musicText.text);
    }
    public void OnChangeValuesSoundEffectText()
    {
        soundEffectSlider.value = int.Parse(soundEffectText.text);
    }
    public void Btn_Cancel()
    {
        DialogManager.instance.HideDialog(this);
    }

    public void Btn_Home()
    {
        Time.timeScale = 1;
        LoadSceneManager.instance.LoadAsynScene("HomeScene", () => {
        });
    }
    //Load home scene

    public void Btn_Restart()
    {
        Time.timeScale = 1;
        LoadSceneManager.instance.LoadAsynScene("GameScene" , ()=> { });
    }
    //public void Btn_SoundEffect()
    //{
    //    SFX = !SFX;
    //}
    //public void Btn_Music()
    //{
    //    UnMute = !UnMute;
    //}

    public void OnchangeValueSound()
    {
        soundEffectText.text = ((int)soundEffectSlider.value).ToString();     
    }
    public void OnchangeValueMusic()
    {
        musicText.text = ((int)musicSlier.value).ToString();
    }
}
