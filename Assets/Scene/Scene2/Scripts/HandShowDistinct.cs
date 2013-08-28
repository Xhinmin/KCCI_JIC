using UnityEngine;
using System.Collections;

/// <summary>
/// 0820：藉由Kinect右手及左手的點　給予新對應的手位置
/// 0824：
/// </summary>
public class HandShowDistinct : MonoBehaviour
{
    public int X_Max;
    public int X_Min;
    public int Y_Max;
    public int Y_Min;

    public SkeletonInformation skeletonInformation;
    public int handRatio; //影響倍率值
    public int hipRatio; //影響倍率值
    public HandType handType;

    public LayerMask TargetLayer;

    private RaycastHit hit;
    private Vector3 OrginalLocalPosition;

    // Use this for initialization
    void Start()
    {
        this.OrginalLocalPosition = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (handType == HandType.Right)
        {
            this.transform.localPosition = this.OrginalLocalPosition + new Vector3(
                Mathf.Clamp(KinectDetectOutput.RightHandPosition.x * handRatio + skeletonInformation.HipCenterPos.x * hipRatio, X_Min, X_Max),
                Mathf.Clamp(KinectDetectOutput.RightHandPosition.y * handRatio + skeletonInformation.HipCenterPos.x * hipRatio, Y_Min, Y_Max),
                0);
        }
        else
        {
            this.transform.localPosition = this.OrginalLocalPosition + new Vector3(
                Mathf.Clamp(KinectDetectOutput.LeftHandPosition.x * handRatio + skeletonInformation.HipCenterPos.x * hipRatio, X_Min, X_Max),
                Mathf.Clamp(KinectDetectOutput.LeftHandPosition.y * handRatio + skeletonInformation.HipCenterPos.x * hipRatio, Y_Min, Y_Max),
                0);
        }

        //Raycast hit
        if (Physics.Raycast(transform.position, new Vector3(0, 0, 1), out hit, 10, this.TargetLayer) == true)
        {
            if (KinectDetectOutput.isRocking)
            {
                //修正被觸摸到的圖形
                PictureColorController script = this.hit.collider.transform.parent.GetComponent<PictureColorController>();
                script.DecreasePictureAlpha();
                script.isStartRecover = false;
                script.addValue = script.UndetectTime;
            }
        }


        //偵測到骨架時 將手的圖顯示出來

        if (KinectDetectOutput.SkeletonIsEnable)
        {
            this.transform.GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            this.transform.GetChild(1).gameObject.SetActive(false);
            this.transform.GetChild(0).gameObject.SetActive(false);
        }


    }



    void OnDrawGizmos()
    {
        //畫出偵測線
        Gizmos.DrawRay(this.transform.position, new Vector3(0, 0, 1) * 10);
    }

    public enum HandType
    {
        Right = 0, Left = 1
    }
}
