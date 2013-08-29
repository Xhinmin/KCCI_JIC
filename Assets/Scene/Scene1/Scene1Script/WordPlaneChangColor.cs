using UnityEngine;
using System.Collections;

public class WordPlaneChangColor : MonoBehaviour {
    public WordMove WordMoveColorChild;
    public Color CorrectColor = Color.green;
    public Color WrongColor = Color.red;
    public AudioSource CorrectAudio, WrongAudio;

    bool AudioIsPlay;
	// Use this for initialization
	void Start () {
        AudioIsPlay = false;
        WordMoveColorChild = this.gameObject.transform.parent.GetComponent<WordMove>();
	}
	
	// Update is called once per frame
	void Update () {
        if (WordMoveColorChild.WordExitStatus == 1) {
            if (AudioIsPlay == false)
            {
                CorrectAudio.Play();
                AudioIsPlay = true;
            }
            this.renderer.material.color = CorrectColor;
        }
        else if (WordMoveColorChild.WordExitStatus == 2)
        {
            if (AudioIsPlay == false)
            {
                WrongAudio.Play();
                AudioIsPlay = true;
            }
            this.renderer.material.color = WrongColor;
        }
	}
}
