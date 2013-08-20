using UnityEngine;
using System.Collections;

public class WordMove : MonoBehaviour
{
    public int wordStatus;

    public GameObject ControlBridge;
    private ControlBar controlbar01;
    // Use this for initialization
    void Start()
    {
        wordStatus = 0;
        ControlBridge = GameObject.Find("控制橋");
        controlbar01 = ControlBridge.GetComponent<ControlBar>();
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.name == "BlueTriggerRight" && wordStatus == 2)
        {
            wordStatus = 3;
            this.gameObject.transform.parent = GameObject.Find("B_RightBridge").transform;
            this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.position.x, 6, 0);
          
        }
        else if (other.gameObject.name == "BlueTriggerLeft" && wordStatus == 1)
        {
            wordStatus = 2;
            this.gameObject.transform.parent = GameObject.Find("B_LeftBridge").transform;
            this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.position.x, 6, 0);
           
        }
        else if (other.gameObject.name == "GreenTrigger" && wordStatus == 0)
        {
            this.gameObject.transform.parent = null;
            wordStatus = 1;
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
            this.gameObject.transform.Translate(20 * Time.deltaTime, 0, 90 * Time.deltaTime);
        }

    }
}


