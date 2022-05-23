using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAbllity : MonoBehaviour
{
    public int AD;


    public int GetAD()
    {
        return AD;
    }

    public void UpgradeAD(int Value)
    {
        AD += Value;
    }

    public void DowngradeAD(int Value)
    {
        AD -= Value;
    }

}
