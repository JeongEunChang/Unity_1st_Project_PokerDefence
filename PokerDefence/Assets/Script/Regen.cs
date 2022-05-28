using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regen : MonoBehaviour
{
    public GameObject[] Monster;
    public GameObject[] Stage;
    public StageInspector StageSet;
    public int StageCount = 0;
    public int MonsterCount = 0;
    public int index = 0;
    public static int DiedMonster = 0;
    public static bool StageComplate = true;

    // Start is called before the first frame update
    void Start()
    {
        StageSet = Stage[StageCount].GetComponent<StageInspector>();
        StageCount++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonNextStage()
    {
        if (CardDrowScript.CanCardDrow == false)
        {
            GameObject.Find("Main Camera").transform.position = new Vector3(5.08f, 41.3f, 10.5f);
            StageComplate = false;
            InvokeRepeating("ClickNextStage", 1.5f, StageSet.RegenTime);
            InvokeRepeating("CheckEndStage", 0, 0.001f);
        }

        else if (CardDrowScript.CanCardDrow == true)
            print("카드를 모두 뽑아주세요");
    }

    public void CheckEndStage()
    {
        if (StageSet.MaxRegen == DiedMonster)
        {
            Debug.Log(DiedMonster);
            GameObject.Find("Main Camera").transform.position = new Vector3(-83.29f, 8.8f, -35.07f);
            CancelInvoke("CheckEndStage");
            CancelInvoke("ClickNextStage");
            print("스테이지 종료");
            DiedMonster = 0;
            StageSet = Stage[StageCount].GetComponent<StageInspector>();
            StageCount++;
            MonsterCount = 0;
            StageComplate = true;
        }
    }

    public void ClickNextStage()
    {
        if (MonsterCount < StageSet.MaxRegen)
        {
            GameObject tmp = Instantiate(Monster[StageSet.RegenMonster[index]]);
            tmp.transform.position = GameObject.Find("Start").transform.position;
            MonsterCount++;
            index++;

        }

        if (index > StageSet.RegenMonster.Length - 1)
        {
            index = 0;
        }
    }
}
