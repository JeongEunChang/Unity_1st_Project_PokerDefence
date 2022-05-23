using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPScript : MonoBehaviour
{
    public int HP = 100;


    // Start is called before the first frame update
    
    public int GetHP()
    {
        return HP;
    }

    public void DamagedHP(int Damage)
    {
        HP -= Damage;
    }
}
