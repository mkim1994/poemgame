using UnityEngine;
using System.Collections;

public class FinalSceneConfig : MonoBehaviour {
	FadeIn fade;
	// Use this for initialization
	void Start () {
		fade = GameObject.Find ("Transitions").GetComponent<FadeIn>();
		fade.BeginFade(-1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
