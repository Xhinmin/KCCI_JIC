using UnityEngine;
using System.Collections;

public class WordMove : MonoBehaviour
{
    public int wordStatus;              //目前字版跑到哪個道路的狀態值
    public int WordExitStatus;          //當字版撞到出口後，是否是正確的出口的確認值

    public GameObject ControlBridge;
    private ControlBar controlbar01;

    public GameObject WordCreat002;
    private WordTest WTest002;

    public testWordObj testWordChild;
    // Use this for initialization
    void Start()
    {
        wordStatus = 1;

        WordCreat002 = GameObject.Find("WordCreat");
        WTest002 = WordCreat002.GetComponent<WordTest>();

        ControlBridge = GameObject.Find("控制橋");
        controlbar01 = ControlBridge.GetComponent<ControlBar>();

        testWordChild = this.gameObject.GetComponentInChildren<testWordObj>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Exit00") {
            WordExitStatus = 2;
        }
        if (other.gameObject.name == "Exit01" || other.gameObject.name == "Exit02" || other.gameObject.name == "Exit03")
        {
            if (testWordChild.wordHeadNum == other.GetComponent<ExitNumber>().ExitNum)
            {
                if (testWordChild.wordHeadNum == WTest002.WordOne)
                    WTest002.EWordOneC++;
                if (testWordChild.wordHeadNum == WTest002.WordTwo)
                    WTest002.EWordTwoC++;
                if (testWordChild.wordHeadNum == WTest002.WordThree)
                    WTest002.EWordThreeC++;
                WordExitStatus = 1;
                WTest002.CorrectCount++;
            }
            else {
                WordExitStatus = 2;
                WTest002.WrongCount++;
            }
        }


        if (other.gameObject.name == "BlueTriggerRight" && wordStatus == 2)
        {
            wordStatus = 3;
            this.gameObject.transform.parent = GameObject.Find("B_RightBridge").transform;
            this.gameObject.transform.localPosition = new Vector3(3.2f, 6, 0);
          
        }
        else if (other.gameObject.name == "BlueTriggerLeft" && wordStatus == 1)
        {
            wordStatus = 2;
            this.gameObject.transform.parent = GameObject.Find("B_LeftBridge").transform;
            this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.position.x, 6, 0);
           
        }
        else if ( other.gameObject.name == "RedTriggerTop" && wordStatus == 3
            || other.gameObject.name == "RedTriggerMid" && wordStatus == 3
            || other.gameObject.name == "RedTriggerBot" && wordStatus == 3)
        {
            this.gameObject.transform.parent = null;
            wordStatus = 1;
            if (other.gameObject.name == "RedTriggerTop")
                this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.position.x, 19, -49);
            else if (other.gameObject.name == "RedTriggerMid")
                this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.position.x, 6, -49);
            else if (other.gameObject.name == "RedTriggerBot")
                this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.position.x, -7, -49);
        }
        if (other.gameObject.name == "DeadLine")
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "BlueTriggerRight" && wordStatus == 3)
        {
            wordStatus = 3;
        }
        else if (other.gameObject.name == "BlueTriggerLeft" && wordStatus == 2)
        {
            wordStatus = 2;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "GreenTrigger" && wordStatus == 1 )
        {
            wordStatus = 4;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (KinectDetectOutput.SkeletonIsEnable == true)
        {
            if (wordStatus == 1)
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                this.gameObject.transform.Translate(20 * Time.deltaTime, 0, 0);
            }
            else if (wordStatus == 2)
            {
                if (ControlBridge.GetComponent<ControlBar>().LBridgeStatus == 1)
                {
                    this.gameObject.transform.eulerAngles = new Vector3(0, 0, -30);
                }
                if (ControlBridge.GetComponent<ControlBar>().LBridgeStatus == 2)
                {
                    this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                if (ControlBridge.GetComponent<ControlBar>().LBridgeStatus == 3)
                {
                    this.gameObject.transform.eulerAngles = new Vector3(0, 0, 30);
                }
                this.gameObject.transform.Translate(20 * Time.deltaTime, 0, 0);
            }
            else if (wordStatus == 3)
            {
                if (ControlBridge.GetComponent<ControlBar>().RBridgeStatus == 1)
                {
                    this.gameObject.transform.eulerAngles = new Vector3(0, 0, 30);
                }
                if (ControlBridge.GetComponent<ControlBar>().RBridgeStatus == 2)
                {
                    this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                if (ControlBridge.GetComponent<ControlBar>().RBridgeStatus == 3)
                {
                    this.gameObject.transform.eulerAngles = new Vector3(0, 0, -30);
                }
                this.gameObject.transform.Translate(20 * Time.deltaTime, 0, 0);

            }
            else if (wordStatus == 4)
            {
                this.gameObject.transform.Translate(20 * Time.deltaTime, 0, 150 * Time.deltaTime);
                this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x - 0.8f * Time.deltaTime,
                    this.gameObject.transform.localScale.y - 0.8f * Time.deltaTime, this.gameObject.transform.localScale.z - 0.8f * Time.deltaTime);
            }
        }

    }
}


