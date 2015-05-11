using UnityEngine;
using System.Collections;

public class FinalSceneConfig : MonoBehaviour {
	FadeIn fade;
	VideoPlayer player;
	// Use this for initialization
	void Start () {
		fade = GameObject.Find ("Transitions").GetComponent<FadeIn>();
		fade.BeginFade(-1);

		player = GameObject.Find ("Video").GetComponent<VideoPlayer>();
	}
	
	// Update is called once per frame
	void Update () {

		Invoke("playvid", 1.0f);
	}

	void playvid(){
		player.Play ();

	}
}
