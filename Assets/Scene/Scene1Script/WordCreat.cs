using UnityEngine;
using System.Collections;

public class WordCreat : MonoBehaviour {

    public float f_GameTime = 0;
    public GameObject[] G_WordEntrance;
    public GameObject G_WordPlane;
    public Material M_Word;
    public SmoothMoves.TextureAtlas[] Smta_WordTexture;
    public SmoothMoves.Sprite Sms_OutSide;
    public SmoothMoves.Sprite Sms_Word;
    public int i_wordCount=5;

	// Use this for initialization
	void Start () {
	
	}
    void WordCC() {
        print("In invoke");
        Instantiate(G_WordPlane, new Vector3(G_WordEntrance[0].transform.position.x, G_WordEntrance[0].transform.position.y, G_WordEntrance[0].transform.position.z), G_WordEntrance[0].transform.rotation);
        int i = Random.Range(0,10);
        Sms_Word.atlas = Smta_WordTexture[i];
        
        Sms_Word._textureIndex = i_wordCount;
        Sms_Word.UpdateArrays();
        i_wordCount++;
        print(i);
    }
	// Update is called once per frame
	void Update () {
        f_GameTime += Time.deltaTime;
        if (!IsInvoking("WordCC")) {
            Invoke("WordCC", 3);
            
        }
    
	}
}
