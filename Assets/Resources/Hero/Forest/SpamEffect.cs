using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamEffect : MonoBehaviour
{
    [SerializeField] GameObject effect;
    [SerializeField] Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        effect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartEffect()
    {
        effect.transform.position = pos.position;
        effect.SetActive(true);
    }
    public void EndEffect()
    {
        effect.SetActive(false);
    }
}
