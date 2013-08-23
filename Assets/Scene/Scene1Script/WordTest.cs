using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WordTest : MonoBehaviour
{
    public Material[] M_Word;

    public GameObject[] G_WordEntrance;         //字的入口
    public GameObject[] G_WordExit;             //判斷字是否放到正確部首的位置
    public GameObject[] G_WordGoalPic;          //部首顯示位置
    public GameObject G_WordPlane;              //產生字的prefab
    public GameObject[] G_Word;                     //字的部首
    public int WordOne, WordTwo, WordThree;     //選擇三個部首
    public int WordOneC, WordTwoC, WordThreeC;  //計算目前該部首顯示到第幾張圖
    public int EWordOneC, EWordTwoC, EWordThreeC;  //計算目前該部首有幾張圖離開遊戲
    public int CorrectCount;                    //計算答對次數
    public int WrongCount;                      //計算答錯次數


    public List<int> saveList = new List<int>();

    // Use this for initialization
    void Start()
    {
        WrongCount = 0;
        CorrectCount = 0;
        WordOneC = 0;
        WordTwoC = 0;
        WordThreeC = 0;
        do
        {
            WordOne = Random.Range(0, 10);
            WordTwo = Random.Range(0, 10);

        } while (WordOne == WordTwo);

        do
        {
            WordThree = Random.Range(0, 10);

        } while (WordThree == WordOne || WordThree == WordTwo);


        Instantiate(G_Word[WordOne], G_WordGoalPic[0].transform.position, G_Word[WordOne].transform.rotation);
        GameObject.Find("Exit01").GetComponent<ExitNumber>().ExitNum = WordOne;
        Instantiate(G_Word[WordTwo], G_WordGoalPic[1].transform.position, G_Word[WordTwo].transform.rotation);
        GameObject.Find("Exit02").GetComponent<ExitNumber>().ExitNum = WordTwo;
        Instantiate(G_Word[WordThree], G_WordGoalPic[2].transform.position, G_Word[WordThree].transform.rotation);
        GameObject.Find("Exit03").GetComponent<ExitNumber>().ExitNum = WordThree;

        saveList.Add(WordOne);
        saveList.Add(WordTwo);
        saveList.Add(WordThree);

    }



    void WordCC()
    {
        print("Ecount" + EWordOneC + " " + EWordTwoC + " " + EWordThreeC + "\n");
        print(CorrectCount);
        int j = Random.Range(0, 3);

        Instantiate(G_WordPlane, G_WordEntrance[j].transform.position, G_WordPlane.transform.rotation);

    }
    // Update is called once per frame
    void Update()
    {
        if (KinectDetectOutput.SkeletonIsEnable == true)
        {
            if (WordOneC + WordTwoC + WordThreeC >= 30)
            {

            }
            else
            {
                if (GameObject.Find("TimeCount").GetComponent<TimeTest>().f_GameTime > 40)
                {
                    if (!IsInvoking("WordCC"))
                    {
                        Invoke("WordCC", 2.4f);
                    }
                }
                else if (GameObject.Find("TimeCount").GetComponent<TimeTest>().f_GameTime > 20)
                {
                    if (!IsInvoking("WordCC"))
                    {
                        Invoke("WordCC", 1.8f);
                    }
                }
                else if (GameObject.Find("TimeCount").GetComponent<TimeTest>().f_GameTime > 0)
                {
                    if (!IsInvoking("WordCC"))
                    {
                        Invoke("WordCC", 1.2f);
                    }
                }

            }
        }
    }
}
