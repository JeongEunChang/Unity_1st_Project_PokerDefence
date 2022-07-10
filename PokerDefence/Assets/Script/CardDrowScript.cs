using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CardDrowScript: MonoBehaviour
{
    public UnityEngine.UI.Text CardText;
    public GameObject CardPrint;

    public static bool CanCardDrow = true; // �������� �Ϸ��ϸ� true�� �ٲ� ��, �������� ������ Drowed �� ���� true�� �ٲ� ��
    public bool Drowed = true; // ccd�� true�� �ٲ�� drowed �� true�� �ٲ��, 

    public Transform[] TradeCard;
    public Transform Card;
    public Transform[] EndCrad;
    public Transform[] NoDrowedCrad;
    private int[] dumpcard = new int[5] {50, 50, 50 ,50 , 50}; // �� �迭 �ʱ�ȭ ���൵, �ν����� ������ ���ŵ��� ����? �������� �� �Ѱ� ���� ���� �ִ���...?
    int i = 0;
    int EndCardCount = 0;
    // staic ���� �迭 ����, private �� �����ϸ� �ʱ�ȭ ����, �ٵ� public���� �����ϸ� �ҽ��ڵ� ������ �ʱ�ȭ �Ұ���
    // Start is called before the first frame update
    void Start()
    {
        CardText = CardPrint.gameObject.transform.Find("CardCombResult").GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Regen.StageComplate == true)
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
                            int randomnumber = Random.Range(0, 36);

                            if (randomnumber == dumpcard[0] || randomnumber == dumpcard[1] || randomnumber == dumpcard[2] || randomnumber == dumpcard[3] || randomnumber == dumpcard[4])
                            {
                                while (randomnumber == dumpcard[0] || randomnumber == dumpcard[1] || randomnumber == dumpcard[2] || randomnumber == dumpcard[3] || randomnumber == dumpcard[4])
                                {
                                    randomnumber = Random.Range(0, 36);
                                }
                            }
                            dumpcard[i] = randomnumber;
                            i++;

                            Transform Drow = Instantiate(TradeCard[randomnumber]);
                            Drow.position = new Vector3(Card.transform.position.x, 2.5f, Card.transform.position.z); // ������ �� �޾ƿͼ� �� ���� ������ �� �ִ� ����� ������?
                            Drow.rotation = new Quaternion(Card.transform.rotation.x, Card.transform.rotation.y, 180, 0);
                            EndCrad[EndCardCount] = Drow;

                            CardComb.PrintCardComb(Drow.gameObject);

                            NoDrowedCrad[EndCardCount] = Card;
                            EndCardCount++;

                            Card.gameObject.SetActive(false);
                            //Destroy(Card.gameObject);

                            if (EndCardCount == 5)
                            {
                                CardPrint.SetActive(true);
                                CardText.text = CardComb.CardResult;
                                i = 0;
                                EndCardCount = 0;
                                CanCardDrow = false;
                            }
                        }
                    }

                }
            }
        }

        else if (Regen.StageComplate == false)
        {
            if (CanCardDrow == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    Destroy(EndCrad[i].gameObject);
                    //EndCrad[i] = null;
                    NoDrowedCrad[i].gameObject.SetActive(true);
                    CanCardDrow = true;
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