using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public LineRenderer line;
    public Transform headerBow, taliBow , handPos , EndPos;
    public Transform aimPos;
            
    // Start is called before the first frame update
    void Start()
    {
        line.SetPosition(0, headerBow.position);
        line.SetPosition(2 , taliBow.position);
        //line.SetPosition(1, aimPos.position) ;
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(1, handPos.position);
    }
}
