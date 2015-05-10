using UnityEngine;
using System.Collections;

//https://www.youtube.com/watch?v=0HwZQt94uHQ

public class FadeIn : MonoBehaviour {
	
	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.8f;
	private int drawDepth = -1000; //order in the draw hierarchy: lower number = renders on top
	private float alpha = 1.0f; //0 - 1, 1 is completely visible
	private int fadeDir = -1; //direction to fade
	
	void OnGUI(){
		//fade out/in the alpha value using a direction, a speed and Time.deltatime to convert the operation to seconds
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		//force(clamp) the number between 0 and 1 because GUI.color uses alpha values between 0 and 1
		alpha = Mathf.Clamp01 (alpha);
		
		//set color of our GUI (in thsi case our texture). all color values remain the same
		//and the alpha is set to the "alpha" variable
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture ( new Rect(0,0,Screen.width,Screen.height), fadeOutTexture);
	}
	
	//if -1 fade in, if 1 fade out
	public float BeginFade(int direction){
		fadeDir = direction;
		return(fadeSpeed);
	}
	//onlevelwasloaded is called when a level is loaded. it takes loaded level index(int)
	//as a parameter so you can limit the fade in to certain scenes
	
	void OnLevelWasLoaded(){
		BeginFade(-1);
	}
	
	void Update(){
		if(Input.GetKey (KeyCode.Escape)){
			Application.Quit ();
		}

	}

/*	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	}*/
}
