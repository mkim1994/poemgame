using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public GameObject fps;
	public GameObject thirdpcam;
	public GameObject bird;
	public GameObject fish;

	public GameObject text;

	public bool birdyes;
	public bool skyyes;
	public bool orderyes;
	public bool flowyes;

	public int combocount; //2^4 = 16

	Camera cam;
	Camera charcam;
	bool zoomyes;
	//bool canclick;

	private Color32 color1 = new Color32(129,210,255,5);
	private Color32 color2 = new Color32(21,37,58,5);

	int zoom = 2;
	int normal = 50;
//	float smooth = 0.5f;

	void Start () {
		fps.SetActive (false);
		thirdpcam.SetActive (true);
		birdyes = true;
		skyyes = true;
		orderyes = true;
		flowyes = true;
		zoomyes = false;

		cam = thirdpcam.GetComponent<Camera>();
		charcam = fps.transform.FindChild ("FirstPersonCharacter").gameObject.GetComponent<Camera>();
	}

	void Update () {
		if(zoomyes){
			if(cam.orthographicSize > zoom){
				cam.orthographicSize-=2;
			}
			else{
				enterfp();
			}
		}
		else if(!zoomyes){
			if(cam.orthographicSize < normal){
				cam.orthographicSize+=2;
			}
		}

		if(skyyes){
			cam.clearFlags = CameraClearFlags.SolidColor;
			charcam.clearFlags = CameraClearFlags.SolidColor;
			cam.backgroundColor = color1;
			charcam.backgroundColor = color1;
		}
		else if(!skyyes){
			cam.clearFlags = CameraClearFlags.SolidColor;
			charcam.clearFlags = CameraClearFlags.SolidColor;
			cam.backgroundColor = color2;
			charcam.backgroundColor = color2;
		}

		if(Input.GetMouseButtonDown (1)){
			zoomyes = true;
		}
		if(Input.GetMouseButtonDown (0)){
			zoomyes = false;
			thirdpcam.SetActive (true);
			fps.SetActive (false);
			text.SetActive (true);
			if(birdyes) bird.SetActive (true);
			else fish.SetActive (true);
		}
	}
	void enterfp(){
		thirdpcam.SetActive (false);
		fps.SetActive (true);
		bird.SetActive (false);
		fish.SetActive (false);
		text.SetActive (false);
	}
}
