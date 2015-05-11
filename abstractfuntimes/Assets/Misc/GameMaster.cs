using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public GameObject fps;
	public GameObject thirdpcam;
	public GameObject bird;
	public GameObject fish;
	public GameObject skylight;
	public GameObject oceanlight;


	public bool birdyes;
	public bool skyyes;
	public bool orderyes;
	public bool flowyes;

	public GameObject skywater;
	public GameObject oceanwater;

	int combocount = 16; //2^4 = 16
	bool[] combos;

	Camera cam;
	Camera charcam;
	bool zoomyes;
	//bool canclick;

	private Color32 color1 = new Color32(129,210,255,5);
	private Color32 color2 = new Color32(21,37,58,5);

	int zoom = 2;
	int normal = 50;
	
	public GameObject text;
	public Sprite[] linechanges;
	SpriteRenderer line1,line2,line3,line4;

	FadeIn fade;

	void Start () {
		fade = GameObject.Find ("Transitions").GetComponent<FadeIn>();

		fps.SetActive (false);
		thirdpcam.SetActive (true);
		birdyes = true;
		skyyes = true;
		orderyes = true;
		flowyes = true;
		zoomyes = false;
	
		skywater.SetActive(false);
		oceanwater.SetActive(false);
		skylight.SetActive(true);
		oceanlight.SetActive(false);
		text.SetActive(true);

		cam = thirdpcam.GetComponent<Camera>();
		charcam = fps.transform.FindChild ("FirstPersonCharacter").gameObject.GetComponent<Camera>();


		combos = new bool[combocount];
		for(int i = 0; i<combocount; i++){
			combos[i] = false;
		}
		Transform text1 = text.transform.FindChild("text1");
		Transform text2 = text.transform.FindChild("text2");
		Transform text3 = text.transform.FindChild("text3");
		Transform text4 = text.transform.FindChild("text4");

		line1 = text1.FindChild("l1").gameObject.GetComponent<SpriteRenderer>();
		line2 = text2.FindChild("l2").gameObject.GetComponent<SpriteRenderer>();
		line3 = text3.FindChild("l3").gameObject.GetComponent<SpriteRenderer>();
		line4 = text4.FindChild("l4").gameObject.GetComponent<SpriteRenderer>();
	}

	void Update (){

		//keep track of combos
		int count = 0;
		for(int i = 0; i < combocount; i++){
			if(combos[i]){
				count++;
			}
		}
		Debug.Log(count);
		if(count == combocount){
			fade.BeginFade(1);
			Invoke("loadfinal", 1.0f);
		}

		checkCombos();


		//actual game
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

			RenderSettings.fogColor = color1;

			skylight.SetActive(true);
			oceanlight.SetActive(false);
		}
		else if(!skyyes){
			cam.clearFlags = CameraClearFlags.SolidColor;
			charcam.clearFlags = CameraClearFlags.SolidColor;
			cam.backgroundColor = color2;
			charcam.backgroundColor = color2;

			RenderSettings.fogColor = color2;

			skylight.SetActive(false);
			oceanlight.SetActive(true);
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

			skywater.SetActive(false);
			oceanwater.SetActive(false);

		}
	}
	void enterfp(){
		if(skyyes){
			skywater.SetActive(true);
		}
		else{
			oceanwater.SetActive(true);
		}

		thirdpcam.SetActive (false);
		fps.SetActive (true);
		bird.SetActive (false);
		fish.SetActive (false);
		text.SetActive (false);

	}

	void loadfinal(){
		Application.LoadLevel ("Final");
	}

	void checkCombos(){
		if(line1.sprite == linechanges[0]){ //if equal to writer
			if(line2.sprite == linechanges[2]){ //if equal to spontaneous
				if(line3.sprite == linechanges[4]){ //if equal to order
					if(line4.sprite == linechanges[6]){ //if equal to flowing
						combos[0] = true;
					}
					else{
						combos[1] = true;
					}
				}
				else{
					if(line4.sprite == linechanges[6]){ //if equal to flowing
						combos[2] = true;
					}
					else{
						combos[3] = true;
					}
				}
			}
			else{
				if(line3.sprite == linechanges[4]){ //if equal to order
					if(line4.sprite == linechanges[6]){ //if equal to flowing
						combos[4] = true;
					}
					else{
						combos[5] = true;
					}
				}
				else{
					if(line4.sprite == linechanges[6]){ //if equal to flowing
						combos[6] = true;
					}
					else{
						combos[7] = true;
					}
				}
			}
		}
		else{
			if(line2.sprite == linechanges[2]){ //if equal to spontaneous
				if(line3.sprite == linechanges[4]){ //if equal to order
					if(line4.sprite == linechanges[6]){ //if equal to flowing
						combos[8] = true;
					}
					else{
						combos[9] = true;
					}
				}
				else{
					if(line4.sprite == linechanges[6]){ //if equal to flowing
						combos[10] = true;
					}
					else{
						combos[11] = true;
					}
				}
			}
			else{
				if(line3.sprite == linechanges[4]){ //if equal to order
					if(line4.sprite == linechanges[6]){ //if equal to flowing
						combos[12] = true;
					}
					else{
						combos[13] = true;
					}
				}
				else{
					if(line4.sprite == linechanges[6]){ //if equal to flowing
						combos[14] = true;
					}
					else{
						combos[15] = true;
					}
				}
			}
		}
	}
}
