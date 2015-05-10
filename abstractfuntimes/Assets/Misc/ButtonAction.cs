using UnityEngine;
using System.Collections;

public class ButtonAction : MonoBehaviour {

	FadeIn fade;

	// Use this for initialization
	void Start () {
		fade = GameObject.Find ("Transitions").GetComponent<FadeIn>();
	}
	
	// Update is called once per frame
	void Update () {
	}


	public void TitleClick(){
		fade.BeginFade(1);
		Invoke("loadbase", 1.0f);


	}


	void loadbase(){
		Application.LoadLevel ("Base");
	}
}
