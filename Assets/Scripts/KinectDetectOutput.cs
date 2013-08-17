using UnityEngine;
using System.Collections;

public class KinectDetectOutput : MonoBehaviour
{

    // Speical Requirement : 需要以一個中心點
    public SkeletonInformation skeletonInformation;

    /// <summary>
    /// 第一個場景使用
    /// </summary>
    public enum GestureType { Up, Mid, Dowm };
    public GestureType RightHandGestureType;
    public GestureType LeftHandGestureType;
    /// 提供給"兩隻手，分別的高度判斷"
    // Type1
    // 左手在上 右手在下
    public bool GestureTypeOne;
    // Type2
    // 左手在中 右手在中
    public bool GestureTypeTwo;
    // Type3
    // 左手在下 右手在上
    public bool GestureTypeThree;
    //手勢距離偏移量
    public float offset;


    ///////////////////////////////////////////////

    /// <summary>
    /// 第二個場景使用     
    /// </summary>
    public static Vector3 RightHandPosition;
    public static Vector3 LeftHandPosition;
    //使否手左右晃動
    public bool isRocking;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RightHandPosition = skeletonInformation.HandRightPos - skeletonInformation.ShoulderCenterPos;
        LeftHandPosition = skeletonInformation.HandLeftPos - skeletonInformation.ShoulderCenterPos;

        HandGestureDetect();
        HandisRockingDetect();
    }

    void GetDatumPoint(float Time)
    {

    }

    /// <summary>
    /// 手掌姿勢偵測【第一場景】
    /// </summary>
    void HandGestureDetect()
    {
        //右手部分判定
        if (skeletonInformation.HandRightPos.x > skeletonInformation.ShoulderCenterPos.x)
        {
            if (skeletonInformation.HandRightPos.y > skeletonInformation.ShoulderCenterPos.y + offset)
                RightHandGestureType = GestureType.Up;
            if (skeletonInformation.HandRightPos.y > skeletonInformation.ShoulderCenterPos.y - offset*2 && skeletonInformation.HandRightPos.y < skeletonInformation.ShoulderCenterPos.y + offset)
                RightHandGestureType = GestureType.Mid;
            if (skeletonInformation.HandRightPos.y < skeletonInformation.ShoulderCenterPos.y - offset*2)
                RightHandGestureType = GestureType.Dowm;
        }


        //左手部分判定
        if (skeletonInformation.HandLeftPos.x < skeletonInformation.ShoulderCenterPos.x)
        {
            if (skeletonInformation.HandLeftPos.y > skeletonInformation.ShoulderCenterPos.y + offset)
                LeftHandGestureType = GestureType.Up;
            if (skeletonInformation.HandLeftPos.y > skeletonInformation.ShoulderCenterPos.y - offset*2 && skeletonInformation.HandLeftPos.y < skeletonInformation.ShoulderCenterPos.y + offset)
                LeftHandGestureType = GestureType.Mid;
            if (skeletonInformation.HandLeftPos.y < skeletonInformation.ShoulderCenterPos.y - offset*2)
                LeftHandGestureType = GestureType.Dowm;
        }

        //備用
        if (LeftHandGestureType == GestureType.Dowm && RightHandGestureType == GestureType.Up)
            GestureTypeOne = true;

    }


    void HandisRockingDetect()
    {
        if (SkeletonInformation.skeletonWrapper.boneVel[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].x > 0.1F ||
            SkeletonInformation.skeletonWrapper.boneVel[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].x > 0.1F)
            isRocking = true;
        else
            isRocking = false;
    }


}
