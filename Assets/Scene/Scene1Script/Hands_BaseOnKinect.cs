using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hands_BaseOnKinect : MonoBehaviour
{
    public HandType handType;
    public SkeletonInformation skeletonInformation;
    private float t;
    public int ratio;

    [System.Serializable]
    public class HandSettingValue
    {
        public string name;         //手臂種類 前或後
        public int ratio;           //Kinect轉動比率
        public float RotateAngle;   //轉動角度幅度
    }


    public List<HandSettingValue> HandSettingValueList;
    HandSettingValue 前手臂;
    HandSettingValue 後手臂;
    // Use this for initialization
    void Start()
    {
        前手臂 = HandSettingValueList.Find((HandSettingValue data) => { return data.name == "前手臂"; });
        後手臂 = HandSettingValueList.Find((HandSettingValue data) => { return data.name == "後手臂"; });

    }

    // Update is called once per frame
    void Update()
    {
        switch (handType)
        {
            case HandType.左後手臂:
                t = Mathf.Max(Mathf.Min((skeletonInformation.ElbowLeftPos.y - skeletonInformation.ShoulderLeftPos.y) * 後手臂.ratio, 1), -1);
                t = (t + 1) / 2;
                this.transform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(後手臂.RotateAngle, -後手臂.RotateAngle, t));
                break;

            case HandType.右後手臂:
                t = Mathf.Max(Mathf.Min((skeletonInformation.ElbowRightPos.y - skeletonInformation.ShoulderRightPos.y) * 後手臂.ratio, 1), -1);
                t = (t + 1) / 2;
                this.transform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(-後手臂.RotateAngle, 後手臂.RotateAngle, t));
                break;

            case HandType.左前手臂:
                t = Mathf.Max(Mathf.Min((skeletonInformation.HandLeftPos.y - skeletonInformation.ElbowLeftPos.y) * 前手臂.ratio, 1), -1);
                t = (t + 1) / 2;
                this.transform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(前手臂.RotateAngle, -前手臂.RotateAngle, t));
                break;

            case HandType.右前手臂:
                t = Mathf.Max(Mathf.Min((skeletonInformation.HandRightPos.y - skeletonInformation.ElbowRightPos.y) * 前手臂.ratio, 1), -1);
                t = (t + 1) / 2;
                this.transform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(-前手臂.RotateAngle, 前手臂.RotateAngle, t));
                break;
        }
    }


    public enum HandType
    {
        左後手臂 = 0, 右後手臂 = 1, 左前手臂 = 2, 右前手臂 = 3
    }

}
