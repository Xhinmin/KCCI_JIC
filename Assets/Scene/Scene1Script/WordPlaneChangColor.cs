using UnityEngine;
using System.Collections;

public class WordPlaneChangColor : MonoBehaviour {
    public WordMove WordMoveColorChild;
    public Color CorrectColor = Color.green;
    public Color WrongColor = Color.red;
	// Use this for initialization
	void Start () {
        WordMoveColorChild = this.gameObject.transform.parent.GetComponent<WordMove>();
	}
	
	// Update is called once per frame
	void Update () {
        if (WordMoveColorChild.WordExitStatus == 1) {
            print("Correct");
            this.renderer.material.color = CorrectColor;
        }
        else if (WordMoveColorChild.WordExitStatus == 2)
        {
            this.renderer.material.color = WrongColor;
        }
	}
}
