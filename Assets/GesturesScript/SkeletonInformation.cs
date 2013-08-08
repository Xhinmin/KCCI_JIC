using UnityEngine;
using System.Collections;

public class SkeletonInformation : MonoBehaviour
{
    public static SkeletonWrapper skeletonWrapper;
    public Vector3 HandRightPos;
    public Vector3 HandLeftPos;
    public Vector3 AnkleLeftPos; // Ankle - ¸}½ï
    public Vector3 AnkleRightPos;
    public Vector3 ElbowLeftPos; // Elbow - ¤â¨y
    public Vector3 ElbowRightPos;
    public Vector3 FootLeftPos;
    public Vector3 FootRightPos;
    public Vector3 HeadPos;
    public Vector3 HipCenterPos; // Hip - ÆbÃö¸`
    public Vector3 HipLeftPos;
    public Vector3 HipRightPos;
    public Vector3 KneeLeftPos;
    public Vector3 KneeRightPos;
    public Vector3 ShoulderCenterPos;
    public Vector3 ShoulderLeftPos;
    public Vector3 ShoulderRightPos;
    public Vector3 SpinePos; // Spine - ¯á¬W
    public Vector3 WristLeftPos; // Wrist - µÃ
    public Vector3 WristRightPos;

	// Use this for initialization
	void Start () {
        skeletonWrapper = GameObject.Find("Kinect_Prefab").GetComponent<SkeletonWrapper>();
	}
	
	// Update is called once per frame
	void Update () {

        HandRightPos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight];
        HandLeftPos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft];
        AnkleLeftPos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.AnkleLeft];
        AnkleRightPos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.AnkleRight];
        ElbowLeftPos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ElbowLeft];
        ElbowRightPos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ElbowRight];
        FootLeftPos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.FootLeft];
        FootRightPos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.FootRight];
        HeadPos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.Head];
        HipCenterPos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter];
        HipLeftPos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HipLeft];
        HipRightPos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HipRight];
        KneeLeftPos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.KneeLeft];
        KneeRightPos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.KneeRight];
        ShoulderCenterPos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderCenter];
        ShoulderLeftPos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderLeft];
        ShoulderRightPos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight];

        SpinePos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.Spine];
        WristLeftPos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.WristLeft];
        WristRightPos = skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.WristRight];


    }
}
