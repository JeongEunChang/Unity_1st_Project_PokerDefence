using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CardDrowScript: MonoBehaviour
{
    public static bool CanCardDrow = true; // 스테이지 완료하면 true로 바꿀 것, 스테이지 끝나면 Drowed 도 전부 true로 바꿀 것
    public bool Drowed = true; // ccd가 true로 바뀌면 drowed 도 true로 바뀌고, 

    public Transform[] TradeCard;
    public Transform Card;
    public int[] dumpcard = new int[5] {50, 50, 50, 50, 50}; // 왜 배열 초기화 해줘도, 인스펙터 정보는 갱신되지 않음? 지정해준 값 넘게 넣을 수도 있던데...?
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanCardDrow == true)
            {
                Ray MouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(MouseRay, out hit, 1000.0f, 1 << LayerMask.NameToLayer("Card")))
                {
                    Card = hit.collider.transform;

                    if (Drowed == true)
                    {
                        int randomnumber = Random.Range(0, 36); // 업데이트 함수 내에서 for문쓰면 한번에 발생함,,,?


                        if (randomnumber == dumpcard[0] || randomnumber == dumpcard[1] || randomnumber == dumpcard[2] || randomnumber == dumpcard[3] || randomnumber == dumpcard[4])
                        {
                            while (randomnumber == dumpcard[0] || randomnumber == dumpcard[1] || randomnumber == dumpcard[2] || randomnumber == dumpcard[3] || randomnumber == dumpcard[4])
                            {
                                randomnumber = Random.Range(0, 36);
                            }
                        }

                        dumpcard[i] = randomnumber;
                        i++;
                        if(i == 5)
                            i = 0;

                        Transform Drow = Instantiate(TradeCard[randomnumber]);
                        Drow.position = new Vector3(Card.transform.position.x, 2.5f , Card.transform.position.z); // 포지션 값 받아와서 그 값에 더해줄 수 있는 방법은 없을라나?
                        Drow.rotation = new Quaternion(Card.transform.rotation.x, Card.transform.rotation.y, 180, 0);
                        Destroy(Card.gameObject);
                        //Drowed = false;
                    }
                }

            }
        }
    }



}


//if (Input.GetMouseButtonDown(0))
//{
//    Ray MoouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
//    RaycastHit hit;
//    if (Physics.Raycast(MoouseRay, out hit, 1000.0f, 1 << LayerMask.NameToLayer("Building")))
//    {
//        Building = hit.collider.transform.GetComponent<Barrack>();
//        print("선택됐어");
//    }
//}