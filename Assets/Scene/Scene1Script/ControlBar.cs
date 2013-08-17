using UnityEngine;
using System.Collections;

public class ControlBar : MonoBehaviour {
    public GameObject RotateBridge01, RotateBridge02;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("q"))
        {

            RotateBridge01.transform.eulerAngles = new Vector3 (0, 0, -33);            
        }
        if (Input.GetKey("a"))
        {
            RotateBridge01.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey("z"))
        {

            RotateBridge01.transform.eulerAngles = new Vector3(0, 0, 33);  
            
        }
        if (Input.GetKey("w"))
        {

            RotateBridge02.transform.eulerAngles = new Vector3(0, 0, 33);  
            
        }
        if (Input.GetKey("s"))
        {

            RotateBridge02.transform.eulerAngles = new Vector3(0, 0, 0);  
            
        }
        if (Input.GetKey("x"))
        {

            RotateBridge02.transform.eulerAngles = new Vector3(0, 0, -33);  
            
        }
	}
}
