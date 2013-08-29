using UnityEngine;
using System.Collections;

public class KinectDetectOutput : MonoBehaviour
{

    // Speical Requirement : 需要以一個中心點
    public SkeletonInformation skeletonInformation;

    /// <summary>
    /// 所有場景共用
    /// </summary>
    
    //偵測是否有抓到玩家
    public static bool SkeletonIsEnable;

    /// <summary>
    /// 第一個場景使用
    /// </summary>
    public enum GestureType { Up, Mid, Dowm };
    public static GestureType RightHandGestureType;
    public static GestureType LeftHandGestureType;

    // 提供給"兩隻手，分別的高度判斷"
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

    //右肩膀 與 右手掌 的Y差植
    public static float RightHand_RightShouder_Offset;
    //左肩膀 與 左手掌 的Y差植
    public static float LeftHand_LeftShouder_Offset;
    ///////////////////////////////////////////////

    /// <summary>
    /// 第二個場景使用     
    /// </summary>
    
    //右手 與 肩膀中間的 向量誤差值
    public static Vector3 RightHandPosition;
    //左手 與 肩膀中間的 向量誤差值
    public static Vector3 LeftHandPosition;
    //使否手左右晃動
    public static bool isRocking;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //偵測骨架部分 第一個玩家
        if (GameObject.Find("Kinect_Prefab").GetComponent<SkeletonWrapper>().trackedPlayers[0] == -1)
        {
            SkeletonIsEnable = true;
        }
        else
            SkeletonIsEnable = true;


        RightHandPosition = skeletonInformation.HandRightPos - skeletonInformation.ShoulderCenterPos;
        LeftHandPosition = skeletonInformation.HandLeftPos - skeletonInformation.ShoulderCenterPos;

        HandGestureDetect();
        HandisRockingDetect();
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



        LeftHand_LeftShouder_Offset = skeletonInformation.HandLeftPos.y - skeletonInformation.ShoulderLeftPos.y;
        RightHand_RightShouder_Offset = skeletonInformation.HandRightPos.y - skeletonInformation.ShoulderRightPos.y;

        //備用
        if (LeftHandGestureType == GestureType.Dowm && RightHandGestureType == GestureType.Up)
            GestureTypeOne = true;

    }


    /// <summary>
    /// 手掌姿勢偵測【第二場景】
    /// </summary>
    void HandisRockingDetect()
    {
        if (SkeletonInformation.skeletonWrapper.boneVel[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].x > 0.1F ||
            SkeletonInformation.skeletonWrapper.boneVel[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].x > 0.1F)
            isRocking = true;
        else
            isRocking = false;
    }


}
