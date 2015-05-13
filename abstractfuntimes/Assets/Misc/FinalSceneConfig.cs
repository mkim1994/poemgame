using UnityEngine;
using System.Collections;

public class FinalSceneConfig : MonoBehaviour {
	FadeIn fade;
	VideoPlayer player;
	// Use this for initialization
	void Start () {
		fade = GameObject.Find ("Transitions").GetComponent<FadeIn>();
		fade.fadeSpeed = 0.4f;
		fade.BeginFade(-1);

		player = GameObject.Find ("Video").GetComponent<VideoPlayer>();
	}
	
	// Update is called once per frame
	void Update () {

		Invoke("playvid", 0.4f);
	}

	void playvid(){
		player.Play ();
		fade.fadeSpeed = 0.8f;

	}
}
