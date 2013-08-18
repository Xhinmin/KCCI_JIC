using UnityEngine;
using System.Collections;

public class ControlBar : MonoBehaviour {
    public GameObject RotateBridge01, RotateBridge02;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("q") || KinectDetectOutput.LeftHandGestureType == KinectDetectOutput.GestureType.Up)
        {

            RotateBridge01.transform.eulerAngles = new Vector3 (0, 0, -33);            
        }
        if (Input.GetKey("a") || KinectDetectOutput.LeftHandGestureType == KinectDetectOutput.GestureType.Mid)
        {
            RotateBridge01.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey("z") || KinectDetectOutput.LeftHandGestureType == KinectDetectOutput.GestureType.Dowm)
        {

            RotateBridge01.transform.eulerAngles = new Vector3(0, 0, 35);  
            
        }
        if (Input.GetKey("w") || KinectDetectOutput.RightHandGestureType == KinectDetectOutput.GestureType.Up)
        {

            RotateBridge02.transform.eulerAngles = new Vector3(0, 0, 35);  
            
        }
        if (Input.GetKey("s") || KinectDetectOutput.RightHandGestureType == KinectDetectOutput.GestureType.Mid)
        {

            RotateBridge02.transform.eulerAngles = new Vector3(0, 0, 0);  
            
        }
        if (Input.GetKey("x") || KinectDetectOutput.RightHandGestureType == KinectDetectOutput.GestureType.Dowm)
        {

            RotateBridge02.transform.eulerAngles = new Vector3(0, 0, -33);  
            
        }
	}
}
