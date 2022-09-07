using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IDebuff 
{
    void Debuff(Action callBack);
    void EndDebuff();
}
