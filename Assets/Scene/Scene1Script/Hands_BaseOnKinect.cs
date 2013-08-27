using UnityEngine;
using System.Collections;

public class Hands_BaseOnKinect : MonoBehaviour
{
    public HandType handType;
    public SkeletonInformation skeletonInformation;
    private float t;
    public int ratio;
    public float RotateAngle;
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        switch (handType)
        {
            case HandType.左手:
                t = Mathf.Max(Mathf.Min((skeletonInformation.HandLeftPos.y - skeletonInformation.ShoulderCenterPos.y) * ratio, 1), -1);
                t = (t+1) / 2;
                this.transform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(RotateAngle, -RotateAngle, t));
                break;

            case HandType.右手:
                t = Mathf.Max(Mathf.Min((skeletonInformation.HandRightPos.y - skeletonInformation.ShoulderCenterPos.y) * ratio, 1), -1);
                t = (t+1) / 2;
                this.transform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(-RotateAngle, RotateAngle, t));
                break;
        }
    }


    public enum HandType
    {
        左手 = 0, 右手 = 1
    }

}
