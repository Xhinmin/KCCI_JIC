using UnityEngine;
using System.Collections;

public class HandShowDistinct : MonoBehaviour
{
    public int X_Max;
    public int X_Min;
    public int Y_Max;
    public int Y_Min;

    public SkeletonInformation skeletonInformation;
    public int ratio; //影響倍率值

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
                Mathf.Clamp(KinectDetectOutput.RightHandPosition.x * ratio, X_Min, X_Max),
                Mathf.Clamp(KinectDetectOutput.RightHandPosition.y * ratio, Y_Min, Y_Max),
                0);
        }
        else
        {
            this.transform.localPosition = this.OrginalLocalPosition + new Vector3(
                Mathf.Clamp(KinectDetectOutput.LeftHandPosition.x * ratio, X_Min, X_Max),
                Mathf.Clamp(KinectDetectOutput.LeftHandPosition.y * ratio, Y_Min, Y_Max),
                0);
        }

        //Raycast hit
        if (Physics.Raycast(transform.position, new Vector3(0, 0, 1), out hit, 10, this.TargetLayer) == true)
        {
            //if (KinectDetectOutput.isRocking)
            //{
            PictureColorController script = this.hit.collider.transform.parent.GetComponent<PictureColorController>();
            script.DecPictureAlpha();
            script.isStartRecove = false;
            script.addValue = script.UndetectTime;
            //}
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
