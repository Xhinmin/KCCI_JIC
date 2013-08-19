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
    private float updateValue;

    public float UndetectTime;
    public float addValue;

    public bool isStartRecove;

    // Use this for initialization
    void Awake()
    {
        this.isChangeFinish = true;
        this.isStartRecove = false;
        this.addValue = this.UndetectTime;
    }

    /// <summary>
    /// ITween顏色改變每個Frame變化值
    /// </summary>
    /// <param name="value">變化值</param>
    void ColorChangeUpdate(float value)
    {
        this.SpriteList[this.currentIndex].SetColor(new Color(1, 1, 1, value));
    }

    /// <summary>
    /// ITween顏色改變完成後
    /// </summary>
    void ColorChangeComplete()
    {
        this.isChangeFinish = true;
    }

    /// <summary>
    /// 減少圖片Alpha值
    /// </summary>
    public void DecPictureAlpha()
    {
        if (this.isChangeFinish)
        {
            if (this.SpriteList[this.currentIndex].color.a <= 0)
            {
                this.currentIndex++;
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
                        "onupdateparams", this.updateValue,
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
                    "onupdateparams", this.updateValue,
                    "oncomplete", "ColorChangeComplete"
                    ));
            }
        }
    }

    /// <summary>
    /// 增加圖片Alpha值
    /// </summary>
    public void AddPictureAlpha()
    {
        if (this.isChangeFinish)
        {
            if (this.SpriteList[this.currentIndex].color.a >= 1)
            {
                this.currentIndex--;
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
                        "onupdateparams", this.updateValue,
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
                    "onupdateparams", this.updateValue,
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
            DecPictureAlpha();
        }

        //Alpha增加
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            AddPictureAlpha();
        }

        if (!this.isStartRecove)
        {
            this.addValue -= Time.deltaTime;
            if (this.addValue <= 0)
            {
                this.addValue = this.UndetectTime;
                this.isStartRecove = true;
            }
        }
        else
        {
            this.AddPictureAlpha();
        }

        //print("Current Picture Name：" + this.SpriteList[this.currentIndex].name + " ,Current Alpha = " + this.SpriteList[this.currentIndex].color.a);
    }
}
