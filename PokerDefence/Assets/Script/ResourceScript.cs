using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScript : MonoBehaviour
{
    public static int Money = 100;
    UnityEngine.UI.Text MoneyText;

    public static int GetMoney()
    {
        return Money;
    }

    public static void PlusMoney(int Value)
    {
        Money += Value;
    }

    public static bool MinusMoney(int Value)
    {
        if (Money >= Value)
        {
            Money -= Value;
            return true;
        }
        
        return false;
    }

    void Start()
    {
        MoneyText = GetComponent<UnityEngine.UI.Text>(); // 만약 Text가 여러 개면 어떤 거 넣음....?
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = "Money : " + Money.ToString();
    }
}
