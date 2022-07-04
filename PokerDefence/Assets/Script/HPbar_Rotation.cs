using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar_Rotation : MonoBehaviour
{
    public Transform MainCamera;
    public Image asd;
    public HPScript HPt;
    float FullHP;
    float NowHP;
    float persant;
    // Start is called before the first frame update
    void Start()
    {
        asd = GetComponent<Image>();
        HPt = gameObject.GetComponentInParent<HPScript>();
        FullHP = (float)HPt.HP;
        MainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        NowHP = HPt.HP;
        persant = NowHP / FullHP;
        asd.fillAmount = persant;
        this.transform.forward = MainCamera.forward;
    }
}
