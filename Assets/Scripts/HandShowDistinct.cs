using UnityEngine;
using System.Collections;

public class HandShowDistinct : MonoBehaviour
{
    public int X_Max;
    public int X_Min;
    public int Y_Max;
    public int Y_Min;

    public SkeletonInformation skeletonInformation;

    private Vector3 OrginalLocalPosition;
    public int ratio; //影響倍率值


    public enum HandType { Right, Left };
    public HandType handType;

    RaycastHit hit;
    public GameObject Target;
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
        if (Physics.Raycast(transform.position, new Vector3(0, 0, 1), out hit, 10) == true)
        {
            Target = hit.transform.gameObject;
        }
    }
}
