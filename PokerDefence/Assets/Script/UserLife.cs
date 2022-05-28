using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserLife : MonoBehaviour
{
    public static int Life = 30;
    UnityEngine.UI.Text LifeText;

    // Start is called before the first frame update
    void Start()
    {
        LifeText = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        LifeText.text = "Life : " + Life.ToString();
    }

    public static int GetLife()
    {
        return Life;
    }

    public static void DecreaseLife(int Minus)
    {
        Life -= Minus;
    }

    public static void IncreaseLife(int Plus)
    {
        Life += Plus;
    }
}
