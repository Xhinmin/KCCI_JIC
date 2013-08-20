using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// last modify：2013-08-18 
/// 圖片控制器
/// </summary>
public class PictureColorController : MonoBehaviour
{
    public List<SmoothMoves.Sprite> SpriteList = new List<SmoothMoves.Sprite>();    //Sprite清單
    public float ChangeDeltaScale;  //每次變動的幅度(0~1)
    public float CountDownTime;     //每次變動的冷卻時間(秒)

    private bool isChangeFinish;
    private int currentIndex = 0;   //目前圖片的index

    [HideInInspector]
    public bool isStartRecover;     //開始進行回復圖案
    public float UndetectTime;      //沒有手的動作多久後開始回復(秒)
    [HideInInspector]
    public float addValue;

    // Use this for initialization
    void Start()
    {
        this.isChangeFinish = true;
        this.isStartRecover = false;
        this.addValue = this.UndetectTime;
    }

    /// <summary>
    /// ITween顏色改變每個Frame變化值
    /// </summary>
    /// <param name="value">變化值</param>
    void ColorChangeUpdate(float value)
    {
        //當前圖片進行Alpha修正，他的下一張Alpha值則為補數
        for (int i = 0; i < this.SpriteList.Count; i++)
        {
            if (i == this.currentIndex)
                this.SpriteList[i].SetColor(new Color(1, 1, 1, value));

            else if (i == this.currentIndex + 1)
                this.SpriteList[i].SetColor(new Color(1, 1, 1, 1 - value));

            else
                this.SpriteList[i].SetColor(new Color(1, 1, 1, 0));
        }
    }

    /// <summary>
    /// ITween顏色改變完成後
    /// </summary>
    void ColorChangeComplete()
    {
        //修改狀態
        this.isChangeFinish = true;
    }

    /// <summary>
    /// 減少圖片Alpha值
    /// </summary>
    public void DecreasePictureAlpha()
    {
        if (this.isChangeFinish)
        {
            //當前Alpha小於0，則開始切換下一張圖
            if (this.SpriteList[this.currentIndex].color.a <= 0)
            {
                this.currentIndex++;
                //如果已經是最下面的圖，則不進行圖片修正
                if (this.currentIndex >= this.SpriteList.Count - 1)
                {
                    this.currentIndex = this.SpriteList.Count - 2;
                    this.SpriteList[this.currentIndex].color.a = 0;
                }
                else
                {
                    this.isChangeFinish = false;
                    iTween.ValueTo(this.gameObject, iTween.Hash(
                        "name", "ColorChange",
                        "from", this.SpriteList[this.currentIndex].color.a,
                        "to", this.SpriteList[this.currentIndex].color.a - this.ChangeDeltaScale,
                        "time", this.CountDownTime,
                        "onupdate", "ColorChangeUpdate",
                        "oncomplete", "ColorChangeComplete"
                        ));
                }
            }
            else
            {
                this.isChangeFinish = false;
                iTween.ValueTo(this.gameObject, iTween.Hash(
                    "name", "ColorChange",
                    "from", this.SpriteList[this.currentIndex].color.a,
                    "to", this.SpriteList[this.currentIndex].color.a - this.ChangeDeltaScale,
                    "time", this.CountDownTime,
                    "onupdate", "ColorChangeUpdate",
                    "oncomplete", "ColorChangeComplete"
                    ));
            }
        }
    }

    /// <summary>
    /// 增加圖片Alpha值
    /// </summary>
    public void IncreasePictureAlpha()
    {
        if (this.isChangeFinish)
        {
            //當前Alpha大於1，則開始切換下一張圖
            if (this.SpriteList[this.currentIndex].color.a >= 1)
            {
                this.currentIndex--;
                //如果已經是最上面的圖，則不進行圖片修正
                if (this.currentIndex < 0)
                {
                    this.currentIndex = 0;
                    this.SpriteList[this.currentIndex].color.a = 1;
                }
                else
                {
                    this.isChangeFinish = false;
                    iTween.ValueTo(this.gameObject, iTween.Hash(
                        "name", "ColorChange",
                        "from", this.SpriteList[this.currentIndex].color.a,
                        "to", this.SpriteList[this.currentIndex].color.a + this.ChangeDeltaScale,
                        "time", this.CountDownTime,
                        "onupdate", "ColorChangeUpdate",
                        "oncomplete", "ColorChangeComplete"
                        ));
                }
            }
            else
            {
                this.isChangeFinish = false;
                iTween.ValueTo(this.gameObject, iTween.Hash(
                    "name", "ColorChange",
                    "from", this.SpriteList[this.currentIndex].color.a,
                    "to", this.SpriteList[this.currentIndex].color.a + this.ChangeDeltaScale,
                    "time", this.CountDownTime,
                    "onupdate", "ColorChangeUpdate",
                    "oncomplete", "ColorChangeComplete"
                    ));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Alpha減少
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            DecreasePictureAlpha();
        }

        //Alpha增加
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            IncreasePictureAlpha();
        }

        if (!this.isStartRecover)
        {
            this.addValue -= Time.deltaTime;
            if (this.addValue <= 0)
            {
                this.addValue = this.UndetectTime;
                this.isStartRecover = true;
            }
        }
        else
        {
            this.IncreasePictureAlpha();
        }

        print("Current Picture Name：" + this.SpriteList[this.currentIndex].name + " ,Current Alpha = " + this.SpriteList[this.currentIndex].color.a);
    }
}
