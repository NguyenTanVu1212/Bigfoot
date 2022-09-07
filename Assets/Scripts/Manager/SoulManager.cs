using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoulManager : MonoBehaviour
{
    public static SoulManager instance;
    [SerializeField] Text soulText;
    [SerializeField] Transform poolSoul;
    public int totalSoul;
    float timeSpam;
    // Update is called once per frame
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        timeSpam = 15;
        totalSoul = 500;
        soulText.text = totalSoul.ToString();
    }
    void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
       
    }

    public void StartSpamSoul()
    {
        InvokeRepeating("SpamSoul", 5, timeSpam);
    }
    void SpamSoul()
    {
        float x = Random.Range(-6 , 6);
        float y = UnityEngine.Random.Range(-4, 2);
        Vector2 pos = new Vector2(x , 5);
        Soul goldClone = PoolObject.instance.GetSoulToPool();
        goldClone.GetComponent<Soul>().OnSetup(pos, ()=> {
            totalSoul += 50;
            soulText.text = totalSoul.ToString();
        });
        goldClone.gameObject.SetActive(true);
        goldClone.GetComponent<Soul>().Move(new Vector2 (x, y));
    }

    public IEnumerator ChangeTextColor()
    {
        for(int i = 0; i<=3; i++)
        {
            soulText.color = Color.red;
            yield return new WaitForSeconds(0.3f);
            soulText.color = Color.black;
        }
    }
    public void OnUsedSoul(int cost)
    {
        totalSoul -= cost;
        soulText.text = totalSoul.ToString();
    }
    public void AddSoul()
    {
        totalSoul += 50;
        soulText.text = totalSoul.ToString();
    }
}
