using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achear : MonoBehaviour
{
    [SerializeField] GameObject handPos , arrow;
    bool isActack;
    void Start()
    {
        isActack = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(arrow.activeSelf)
        {
            arrow.transform.position = handPos.transform.position;
        }
        
    }
    public void Attack()
    {
        isActack = true;
        //GameObject cloneArrow = Instantiate(arrow);
        //cloneArrow.SetActive(true);
        //cloneArrow.GetComponent<Rigidbody2D>().AddForce(Vector2.right*2f);
    }
}
