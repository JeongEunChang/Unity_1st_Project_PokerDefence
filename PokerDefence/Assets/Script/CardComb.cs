using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardComb : MonoBehaviour
{
    static int[] CardNumber = new int[5];
    static string[] CardType = new string[5];

    public static int CardCount = 0;

    public static void PrintCardComb(GameObject Card)
    {
        if (CardCount < 5)
        {
            CardNumber[CardCount] = Card.GetComponent<CardInfo>().number;
            CardType[CardCount] = Card.GetComponent<CardInfo>().type;
            CardCount++;
        }

        if (CardCount == 5)
        {
            CardCount = 0;

            if (CheckRoyalStraightFlush() == true)
            {
                print("RoyalStraightFlush!!!");
                return;
            }

            else if (CheckStraightFlush() == true)
            {
                print("StraightFlush!!!");
                return;
            }

            else if (CheckFive() == true)
            {
                print("FiveCard!!!");
                return;
            }

            else if (CheckFour() == true)
            {
                print("FourCard!!!");
                return;
            }

            else if (CheckRoyalStraight() == true)
            {
                print("RoyalStraight!!!");
                return;
            }

            else if (CheckFullHouse() == true)
            {
                print("FullHouse!!!");
                return;
            }

            else if (CheckFlush() == true)
            {
                print("Flush!!!");
                return;
            }

            else if (CheckStraight() == true)
            {
                print("Straight!!!");
                return;
            }

            else if (CheckThree() == true)
            {
                print("ThreeCard!!!");
                return;
            }

            else if (CheckTwoPair() == true)
            {
                print("TwoPair!!!");
                return;
            }

            else if (CheckOnePair() == true)
            {
                print("OnePair!!!");
                return;
            }

            else if (checkTop() == true)
            {
                print("Top!!!");
                return;
            }
        }        
    }

    public static bool CheckRoyalStraightFlush() // 플러쉬, 스트레이트 플러쉬, 로얄 스트레이트 플러쉬, 파이브 카드, 포카드, 쓰리카드 걸러냄
    {
        int SameCount = 0;

        for (int i = 0; i < 5; i++)
        {
            string tmp = CardType[0];

            if (tmp == CardType[i])
            {
                SameCount++;
            }
        }

        if (SameCount == 5)
        {
            if(CheckRoyalStraight() == true)
            return true;
        }
        return false;
    }

    public static bool CheckStraightFlush() // 플러쉬, 스트레이트 플러쉬, 로얄 스트레이트 플러쉬, 파이브 카드, 포카드, 쓰리카드 걸러냄
    {
        int SameCount = 0;

        for (int i = 0; i < 5; i++)
        {
            string tmp = CardType[0];

            if (tmp == CardType[i])
            {
                SameCount++;
            }
        }

        if (SameCount == 5)
        {
            if (CheckRoyalStraight() != true)
            {
                if (CheckStraight() == true)
                    return true;
            }
        }
        return false;
    }


    public static bool CheckFlush() // 플러쉬, 스트레이트 플러쉬, 로얄 스트레이트 플러쉬, 파이브 카드, 포카드, 쓰리카드 걸러냄
    {
        int SameCount = 0;

        for (int i = 0; i < 5; i++)
        {
            string tmp = CardType[0];

            if (tmp == CardType[i])
            {
                SameCount++;
            }
        }

        if (SameCount == 5)
        {
            return true;
        } // 플러쉬 조건 충족

        return false;
    }

    
    public static bool checkTop()
    {
        int SameCount = 0;
        for (int i = 0; i < 5; i++)
        {
            int tmp = CardNumber[0];

            if (tmp == CardNumber[i])
            {
                SameCount++;
            }
        }
        if ((SameCount == 1) && (CheckStraight() == false))
        {
            return true;
        }

        return false;
    }

    public static bool CheckRoyalStraight()
    {
        int LeastNumber = 300;
        bool Check1 = false;
        bool Check2 = false;
        bool Check3 = false;
        bool Check4 = false;

        for (int i = 0; i < 5; i++)
        {
            if (LeastNumber > CardNumber[i])
            {
                LeastNumber = CardNumber[i];
            }
        }

        for (int i = 0; i < 5; i++)
        {            
            if (LeastNumber + 1 == CardNumber[i])
            {
                Check1 = true;
            }

            else if (LeastNumber + 2 == CardNumber[i])
            {
                Check2 = true;
            }

            else if (LeastNumber + 3 == CardNumber[i])
            {
                Check3 = true;
            }

            else if (LeastNumber + 4 == CardNumber[i])
            {
                Check4 = true;
            }
        }

        if ((Check1 == true && Check2 == true && Check3 == true && Check4 == true) && LeastNumber == 10)
        {
            return true;
        }

        return false;
    }

    public static bool CheckStraight()
    {
        int LeastNumber = 300;
        bool Check1 = false;
        bool Check2 = false;
        bool Check3 = false;
        bool Check4 = false;

        for (int i = 0; i < 5; i++)
        {
            if (LeastNumber > CardNumber[i])
            {
                LeastNumber = CardNumber[i];
            }
        }

        for (int i = 0; i < 5; i++)
        {            
            if (LeastNumber + 1 == CardNumber[i])
            {
                Check1 = true;
            }

            else if (LeastNumber + 2 == CardNumber[i])
            {
                Check2 = true;
            }

            else if (LeastNumber + 3 == CardNumber[i])
            {
                Check3 = true;
            }

            else if (LeastNumber + 4 == CardNumber[i])
            {
                Check4 = true;
            }
        }

        if ((Check1 == true && Check2 == true && Check3 == true && Check4 == true) && LeastNumber != 10)
        {
            return true;
        }

        return false;
    }


    public static bool CheckFive()
    {
        int SameCount = 0;

        for (int i = 0; i < 5; i++)
        {
            int tmp = CardNumber[0];

            if (tmp == CardNumber[i])
            {
                SameCount++;
            }
        }

        if (SameCount == 5)
        {
            return true;
        }

        return false;
    }


    public static bool CheckFour() // 카드 종류 경우처리 해줘야 함
    {
        int SameCount = 0;

        for (int i = 0; i < 5; i++)
        {
            int tmp = CardNumber[0];

            if (tmp == CardNumber[i])
            {
                SameCount++;
            }
        }

        if (SameCount == 4)
        {
            return true;
        }

        return false;
    }


    public static bool CheckThree() // 카드 종류 경우처리 해줘야 함
    {
        int SameCount1 = 0;
        int SameCount2 = 0;
        int SameCount3 = 0;
        int[] tmp = new int[3] {100, 100, 100};

        for (int i = 0; i < 5; i++)
        {
            tmp[0] = CardNumber[0];

            if (tmp[0] == CardNumber[i])
            {
                SameCount1++;
            }
            
            else if (tmp[0] != CardNumber[i])
            {
                tmp[1] = CardNumber[i];
            }
        }

        for (int i = 0; i < 5; i++)
        {
            if (tmp[1] == CardNumber[i])
            {
                SameCount2++;
            }

            else if (tmp[1] != CardNumber[i] && tmp[0] != CardNumber[i])
            {
                tmp[2] = CardNumber[i];
            }
        }

        for (int i = 0; i < 5; i++)
        {
            if (tmp[2] == CardNumber[i])
            {
                SameCount3++;
            }
        }


        if ((SameCount1 == 3 || SameCount2 == 3 || SameCount3 == 3) && (SameCount1 != 2 && SameCount2 != 2 && SameCount3 != 2))
        {
            return true;
        }

        return false;
    }

    public static bool CheckFullHouse()
    {
        int SameCount1 = 0;
        int SameCount2 = 0;
        int[] tmp = new int[2] { 100, 100 };

        for (int i = 0; i < 5; i++)
        {
            tmp[0] = CardNumber[0];

            if (tmp[0] == CardNumber[i])
            {
                SameCount1++;
            }

            else if (tmp[0] != CardNumber[i])
            {
                tmp[1] = CardNumber[i];
            }
        }

        for (int i = 0; i < 5; i++)
        {
            if (tmp[1] == CardNumber[i])
            {
                SameCount2++;
            }
        }


        if ((SameCount1 == 3 || SameCount2 == 3) && (SameCount1 == 2 || SameCount2 == 2))
        {
            return true;
        }

        return false;
    }

    public static bool CheckTwoPair() // 카드 종류 경우처리 해줘야 함
    {
        int SameCount1 = 0;
        int SameCount2 = 0;
        int SameCount3 = 0;
        int[] tmp = new int[3] { 100, 100, 100 };

        for (int i = 0; i < 5; i++)
        {
            tmp[0] = CardNumber[0];

            if (tmp[0] == CardNumber[i])
            {
                SameCount1++;
            }

            else if (tmp[0] != CardNumber[i])
            {
                tmp[1] = CardNumber[i];
            }
        }

        for (int i = 0; i < 5; i++)
        {
            if (tmp[1] == CardNumber[i])
            {
                SameCount2++;
            }

            else if (tmp[1] != CardNumber[i] && tmp[0] != CardNumber[i])
            {
                tmp[2] = CardNumber[i];
            }
        }

        for (int i = 0; i < 5; i++)
        {
            if (tmp[2] == CardNumber[i])
            {
                SameCount3++;
            }
        }


        if ((SameCount1 != 3 && SameCount2 != 3 && SameCount3 != 3) && ((SameCount1 == 2 && SameCount2 == 2) || (SameCount1 == 2 && SameCount3 == 2) || (SameCount2 == 2 && SameCount3 == 2)))
        {
            return true;
        }

        return false;
    }

    public static bool CheckOnePair() // 카드 종류 경우처리 해줘야 함fsdads
    {
        int[] samecount= new int[4];
        int[] tmp = new int[4] { 100, 100, 100, 100 };

        for (int i = 0; i < 5; i++)
        {
            tmp[0] = CardNumber[0];

            if (tmp[0] == CardNumber[i])
            {
                samecount[0]++;
            }

            else if (tmp[0] != CardNumber[i])
            {
                tmp[1] = CardNumber[i];
            }
        }

        for (int i = 0; i < 5; i++)
        {
            if (tmp[1] == CardNumber[i])
            {
                samecount[1]++;
            }

            else if (tmp[1] != CardNumber[i] && tmp[0] != CardNumber[i])
            {
                tmp[2] = CardNumber[i];
            }
        }

        for (int i = 0; i < 5; i++)
        {
            if (tmp[2] == CardNumber[i])
            {
                samecount[2]++;
            }

            else if (tmp[2] != CardNumber[i] && tmp[0] != CardNumber[i] && tmp[1] != CardNumber[i])
            {
                tmp[3] = CardNumber[i];
            }
        }

        for (int i = 0; i < 5; i++)
        {
            if (tmp[3] == CardNumber[i])
            {
                samecount[3]++;
            }
        }

        int count2 = 0;
        int count1 = 0;
        for (int i = 0; i < 4; i++)
        {
            if (samecount[i] == 2)
            {
                count2++;
            }

            else if(samecount[i] == 1)
            {
                count1++;
            }
        }
        if (count2 == 1 && count1 == 3)
        {
            return true;
        }

        return false;
    }
}
