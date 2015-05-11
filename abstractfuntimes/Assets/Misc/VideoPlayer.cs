
// Original script by wbokunic - http://forum.unity3d.com/threads/52001-Movie-Player-for-Indie-Users
// Modified C# version by Ronan Tumelty
//modified by meeeee

using UnityEngine;
using System.Collections;
using System.IO;

public class VideoPlayer : MonoBehaviour {
	Object[] movie_stills;
	int number_of_stills = 0;
	public bool loop = false;
	public bool playOnStart = false;
	public int fps = 30;
	
	private int stills = 0;
	private bool play = false;
	private bool loaded = false;

	FadeIn fade;

	void Update () {

		if (!loaded) {
			StartCoroutine(ImportVideo());
		}
		
		if(fps > 0){
			if(play == true){
				StartCoroutine(Player());
			}
		} else {
			Debug.LogError("'fps' must be set to a value greater than 0.");
		}  
	}
	
	IEnumerator Player(){
		play = false;
		if(loop){
			Debug.Log("looped. stills: " + stills + ", length: " + movie_stills.Length);
			if(stills >= movie_stills.Length) {

				stills = 0;
				Debug.Log("restarting. stills: " + stills);
			}
		} else {
			if(stills > movie_stills.Length) {
				stills -= 1;
			}
		}
		
		if (stills >= 0 && stills < movie_stills.Length) {
			Texture2D MainTex = movie_stills[stills] as Texture2D;
			GetComponent<Renderer>().material.SetTexture("_MainTex", MainTex);
			stills += 1;
			int fps_fixer = fps*3;
			float wait_time = 1.0f/fps_fixer;
			yield return new WaitForSeconds(wait_time);
			play = true;
		}
		else{
			fade.BeginFade(1);
			Invoke("loadtitle",1.0f);

		}
	}

	void loadtitle(){
		Application.LoadLevel("Title");
	}

	public void Play() { play = true; }
	public void Pause() { play = false; }
	
	void Start ()
	{
		number_of_stills -= 1;

		fade = GameObject.Find ("Transitions").GetComponent<FadeIn>();
	}

	IEnumerator ImportVideo() {
		movie_stills = Resources.LoadAll("");
		loaded = true;
		if (playOnStart)
			play = true;   
		yield return null;
	}
	
	public void UnloadFromMemory() {
		play = false;
		foreach (Object o in movie_stills) Destroy(o);
	}
}
