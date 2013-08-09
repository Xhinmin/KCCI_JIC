using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PictureColorController : MonoBehaviour
{
    public List<SmoothMoves.Sprite> SpriteList = new List<SmoothMoves.Sprite>();    //Sprite清單
    public float ChangeScale;   //每次變動的幅度

    private int currentIndex = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Alpha減少
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            //減少Alpha值
            this.SpriteList[this.currentIndex].SetColor(new Color(1, 1, 1, this.SpriteList[this.currentIndex].color.a - this.ChangeScale));
            if (this.SpriteList[this.currentIndex].color.a <= 0)
            {
                this.currentIndex++;
                if (this.currentIndex >= this.SpriteList.Count)
                    this.currentIndex = this.SpriteList.Count - 1;
            }
        }

        //Alpha增加
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            //增加Alpha值
            this.SpriteList[this.currentIndex].SetColor(new Color(1, 1, 1, this.SpriteList[this.currentIndex].color.a + this.ChangeScale));
            if (this.SpriteList[this.currentIndex].color.a >= 1)
            {
                this.currentIndex--;
                if (this.currentIndex < 0)
                    this.currentIndex = 0;
            }
        }

        print("Current Picture Name：" + this.SpriteList[this.currentIndex].name + " ,Current Alpha = " + this.SpriteList[this.currentIndex].color.a);
    }
}
