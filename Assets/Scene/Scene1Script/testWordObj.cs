using UnityEngine;
using System.Collections;

public class testWordObj : MonoBehaviour
{
    public int wordStatus;
    int wordHeadNum;
    // Use this for initialization
    void Start()
    {

        int i = Random.Range(0, 3);
        if (i == 0)
        {
            if (GameObject.Find("WordCreat").GetComponent<WordTest>().WordOneC < 10)
            {
                wordHeadNum = GameObject.Find("WordCreat").GetComponent<WordTest>().WordOne;
                this.renderer.material = GameObject.Find("WordCreat").GetComponent<WordTest>().M_Word
                    [GameObject.Find("WordCreat").GetComponent<WordTest>().WordOne * 10 + GameObject.Find("WordCreat").GetComponent<WordTest>().WordOneC];
                GameObject.Find("WordCreat").GetComponent<WordTest>().WordOneC++;
            }
            else if (GameObject.Find("WordCreat").GetComponent<WordTest>().WordTwoC < 10)
            {
                wordHeadNum = GameObject.Find("WordCreat").GetComponent<WordTest>().WordTwo;
                this.renderer.material = GameObject.Find("WordCreat").GetComponent<WordTest>().M_Word
                    [GameObject.Find("WordCreat").GetComponent<WordTest>().WordTwo * 10 + GameObject.Find("WordCreat").GetComponent<WordTest>().WordTwoC];
                GameObject.Find("WordCreat").GetComponent<WordTest>().WordTwoC++;
            }
            else
            {
                wordHeadNum = GameObject.Find("WordCreat").GetComponent<WordTest>().WordThree;
                this.renderer.material = GameObject.Find("WordCreat").GetComponent<WordTest>().M_Word
                    [GameObject.Find("WordCreat").GetComponent<WordTest>().WordThree * 10 + GameObject.Find("WordCreat").GetComponent<WordTest>().WordThreeC];
                GameObject.Find("WordCreat").GetComponent<WordTest>().WordThreeC++;
            }
        }
        else if (i == 1)
        {
            if (GameObject.Find("WordCreat").GetComponent<WordTest>().WordTwoC < 10)
            {
                wordHeadNum = GameObject.Find("WordCreat").GetComponent<WordTest>().WordTwo;
                this.renderer.material = GameObject.Find("WordCreat").GetComponent<WordTest>().M_Word
                    [GameObject.Find("WordCreat").GetComponent<WordTest>().WordTwo * 10 + GameObject.Find("WordCreat").GetComponent<WordTest>().WordTwoC];
                GameObject.Find("WordCreat").GetComponent<WordTest>().WordTwoC++;
            }
            else if (GameObject.Find("WordCreat").GetComponent<WordTest>().WordThreeC < 10)
            {
                wordHeadNum = GameObject.Find("WordCreat").GetComponent<WordTest>().WordThree;
                this.renderer.material = GameObject.Find("WordCreat").GetComponent<WordTest>().M_Word
                    [GameObject.Find("WordCreat").GetComponent<WordTest>().WordThree * 10 + GameObject.Find("WordCreat").GetComponent<WordTest>().WordThreeC];
                GameObject.Find("WordCreat").GetComponent<WordTest>().WordThreeC++;
            }
            else
            {
                wordHeadNum = GameObject.Find("WordCreat").GetComponent<WordTest>().WordOne;
                this.renderer.material = GameObject.Find("WordCreat").GetComponent<WordTest>().M_Word
                    [GameObject.Find("WordCreat").GetComponent<WordTest>().WordOne * 10 + GameObject.Find("WordCreat").GetComponent<WordTest>().WordOneC];
                GameObject.Find("WordCreat").GetComponent<WordTest>().WordOneC++;
            }
        }
        else
        {
            if (GameObject.Find("WordCreat").GetComponent<WordTest>().WordThreeC < 10)
            {
                wordHeadNum = GameObject.Find("WordCreat").GetComponent<WordTest>().WordThree;
                this.renderer.material = GameObject.Find("WordCreat").GetComponent<WordTest>().M_Word
                    [GameObject.Find("WordCreat").GetComponent<WordTest>().WordThree * 10 + GameObject.Find("WordCreat").GetComponent<WordTest>().WordThreeC];
                GameObject.Find("WordCreat").GetComponent<WordTest>().WordThreeC++;
            }
            else if (GameObject.Find("WordCreat").GetComponent<WordTest>().WordOneC < 10)
            {
                wordHeadNum = GameObject.Find("WordCreat").GetComponent<WordTest>().WordOne;
                this.renderer.material = GameObject.Find("WordCreat").GetComponent<WordTest>().M_Word
                    [GameObject.Find("WordCreat").GetComponent<WordTest>().WordOne * 10 + GameObject.Find("WordCreat").GetComponent<WordTest>().WordOneC];
                GameObject.Find("WordCreat").GetComponent<WordTest>().WordOneC++;
            }
            else
            {
                wordHeadNum = GameObject.Find("WordCreat").GetComponent<WordTest>().WordTwo;
                this.renderer.material = GameObject.Find("WordCreat").GetComponent<WordTest>().M_Word
                    [GameObject.Find("WordCreat").GetComponent<WordTest>().WordTwo * 10 + GameObject.Find("WordCreat").GetComponent<WordTest>().WordTwoC];
                GameObject.Find("WordCreat").GetComponent<WordTest>().WordTwoC++;
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "GreenTrigger")
        {
            wordStatus = 1;
        }
        if (other.gameObject.name == "Exit01" || other.gameObject.name == "Exit02" || other.gameObject.name == "Exit03")
        {
            if (wordHeadNum == other.GetComponent<ExitNumber>().ExitNum)
            {
                if (wordHeadNum == GameObject.Find("WordCreat").GetComponent<WordTest>().WordOne)
                    GameObject.Find("WordCreat").GetComponent<WordTest>().EWordOneC++;
                if (wordHeadNum == GameObject.Find("WordCreat").GetComponent<WordTest>().WordTwo)
                    GameObject.Find("WordCreat").GetComponent<WordTest>().EWordTwoC++;
                if (wordHeadNum == GameObject.Find("WordCreat").GetComponent<WordTest>().WordThree)
                    GameObject.Find("WordCreat").GetComponent<WordTest>().EWordThreeC++;

                GameObject.Find("WordCreat").GetComponent<WordTest>().CorrectCount++;
                Destroy(this.gameObject);
            }
            else
                Destroy(this.gameObject);
        }
        if (other.gameObject.name == "DeadLine")
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "GreenTrigger")
            wordStatus = 0;


    }
    // Update is called once per frame
    void Update()
    {
        if (wordStatus == 1)
            this.transform.Translate(-20 * Time.deltaTime, 0, 0);
        else if (wordStatus == 0)
            this.transform.Translate(-20 * Time.deltaTime, -50 * Time.deltaTime, 30 * Time.deltaTime);
    }
}
