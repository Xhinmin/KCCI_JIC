using UnityEngine;
using System.Collections;

public class ControlBar : MonoBehaviour {
    public GameObject RotateBridge01, RotateBridge02;
    public int RBridgeStatus, LBridgeStatus;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("q") || KinectDetectOutput.LeftHandGestureType == KinectDetectOutput.GestureType.Up)
        {
            LBridgeStatus = 1;
            RotateBridge01.transform.eulerAngles = new Vector3 (0, 0, -30);            
        }
        if (Input.GetKey("a") || KinectDetectOutput.LeftHandGestureType == KinectDetectOutput.GestureType.Mid)
        {
            LBridgeStatus = 2;
            RotateBridge01.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey("z") || KinectDetectOutput.LeftHandGestureType == KinectDetectOutput.GestureType.Dowm)
        {
            LBridgeStatus = 3;
            RotateBridge01.transform.eulerAngles = new Vector3(0, 0, 30);  
            
        }
        if (Input.GetKey("w") || KinectDetectOutput.RightHandGestureType == KinectDetectOutput.GestureType.Up)
        {
            RBridgeStatus = 1;
            RotateBridge02.transform.eulerAngles = new Vector3(0, 0, 30);  
            
        }
        if (Input.GetKey("s") || KinectDetectOutput.RightHandGestureType == KinectDetectOutput.GestureType.Mid)
        {
            RBridgeStatus = 2;
            RotateBridge02.transform.eulerAngles = new Vector3(0, 0, 0);  
            
        }
        if (Input.GetKey("x") || KinectDetectOutput.RightHandGestureType == KinectDetectOutput.GestureType.Dowm)
        {
            RBridgeStatus = 3;
            RotateBridge02.transform.eulerAngles = new Vector3(0, 0, -30);  
            
        }
	}
}
