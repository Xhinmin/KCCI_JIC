using UnityEngine;
using System.Collections;

public class testWordObj : MonoBehaviour
{
    public int wordHeadNum;
    public GameObject WordCreat001;
    private WordTest WTest;
    // Use this for initialization
    void Start()
    {
        WordCreat001 = GameObject.Find("WordCreat");
        WTest = WordCreat001.GetComponent<WordTest>();
        int i = Random.Range(0, 3);
        if (i == 0)
        {
            if (WTest.WordOneC < 10)
            {
                wordHeadNum = WTest.WordOne;
                this.renderer.material = WTest.M_Word
                    [WTest.WordOne * 10 + WTest.WordOneC];
                WTest.WordOneC++;
            }
            else if (WTest.WordTwoC < 10)
            {
                wordHeadNum = WTest.WordTwo;
                this.renderer.material = WTest.M_Word
                    [WTest.WordTwo * 10 + WTest.WordTwoC];
                WTest.WordTwoC++;
            }
            else
            {
                wordHeadNum = WTest.WordThree;
                this.renderer.material = WTest.M_Word
                    [WTest.WordThree * 10 + WTest.WordThreeC];
                WTest.WordThreeC++;
            }
        }
        else if (i == 1)
        {
            if (WTest.WordTwoC < 10)
            {
                wordHeadNum = WTest.WordTwo;
                this.renderer.material = WTest.M_Word
                    [WTest.WordTwo * 10 + WTest.WordTwoC];
                WTest.WordTwoC++;
            }
            else if (WTest.WordThreeC < 10)
            {
                wordHeadNum = WTest.WordThree;
                this.renderer.material = WTest.M_Word
                    [WTest.WordThree * 10 + WTest.WordThreeC];
                WTest.WordThreeC++;
            }
            else
            {
                wordHeadNum = WTest.WordOne;
                this.renderer.material = WTest.M_Word
                    [WTest.WordOne * 10 + WTest.WordOneC];
                WTest.WordOneC++;
            }
        }
        else
        {
            if (WTest.WordThreeC < 10)
            {
                wordHeadNum = WTest.WordThree;
                this.renderer.material = WTest.M_Word
                    [WTest.WordThree * 10 + WTest.WordThreeC];
                WTest.WordThreeC++;
            }
            else if (WTest.WordOneC < 10)
            {
                wordHeadNum = WTest.WordOne;
                this.renderer.material = WTest.M_Word
                    [WTest.WordOne * 10 + WTest.WordOneC];
                WTest.WordOneC++;
            }
            else
            {
                wordHeadNum = WTest.WordTwo;
                this.renderer.material = WTest.M_Word
                    [WTest.WordTwo * 10 + WTest.WordTwoC];
                WTest.WordTwoC++;
            }
        }

    }




 
    // Update is called once per frame
    void Update()
    {
      
    }
}
