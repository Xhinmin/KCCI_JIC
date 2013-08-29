using UnityEngine;
using System.Collections;

public class ggggg : MonoBehaviour {
    SmoothMoves.BoneAnimation bom;
    float fff;
    int aaa;
	// Use this for initialization
	void Start () {
        bom = this.GetComponent<SmoothMoves.BoneAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
        fff += Time.deltaTime;
        if (fff > 1) {
            bom.Play("方框");
            aaa++;
            if (aaa > 3) aaa = 0;
        }
	}
}
