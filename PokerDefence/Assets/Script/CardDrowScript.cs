using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CardDrowScript: MonoBehaviour
{
    public static bool CanCardDrow = true; // �������� �Ϸ��ϸ� true�� �ٲ� ��, �������� ������ Drowed �� ���� true�� �ٲ� ��
    public bool Drowed = true; // ccd�� true�� �ٲ�� drowed �� true�� �ٲ��, 

    public Transform[] TradeCard;
    public Transform Card;
    public int[] dumpcard = new int[5] {50, 50, 50, 50, 50}; // �� �迭 �ʱ�ȭ ���൵, �ν����� ������ ���ŵ��� ����? �������� �� �Ѱ� ���� ���� �ִ���...?
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
                        int randomnumber = Random.Range(0, 36); // ������Ʈ �Լ� ������ for������ �ѹ��� �߻���,,,?


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
                        Drow.position = new Vector3(Card.transform.position.x, 2.5f , Card.transform.position.z); // ������ �� �޾ƿͼ� �� ���� ������ �� �ִ� ����� ������?
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
//        print("���õƾ�");
//    }
//}