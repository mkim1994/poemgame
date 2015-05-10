using UnityEngine;
using System.Collections;

public class CharCamera : MonoBehaviour {

	// Use this for initialization
	Camera cam;
	GameMaster gm;


	private Color32 color1 = new Color32(129,210,255,5); //light blue
	private Color32 color2 = new Color32(25,78,109,5); //dark blue

	void Start () {
		cam = GetComponent<Camera>();
		cam.clearFlags = CameraClearFlags.SolidColor;
		gm = GameObject.Find("GM").GetComponent<GameMaster>();
	}
	
	// Update is called once per frame
	void Update () {

		if(gm.skyyes){
			cam.clearFlags = CameraClearFlags.SolidColor;
			cam.backgroundColor = color1;
		}
		else if(!gm.skyyes){
			cam.clearFlags = CameraClearFlags.SolidColor;
			cam.backgroundColor = color2;
		}

		
	}
}
