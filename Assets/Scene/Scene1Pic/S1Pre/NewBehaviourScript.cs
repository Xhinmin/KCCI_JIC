using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
    public GameObject ppp;
    float iii;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        iii += Time.deltaTime;
        if (iii > 1)
        {
            Instantiate(ppp, new Vector3(this.gameObject.transform.position.x + iii, this.gameObject.transform.position.y, this.gameObject.transform.position.z), ppp.transform.rotation);
            iii = 0;
        }
	}
}
