using UnityEngine;
using System.Collections;

public class TextActivity : MonoBehaviour {

	public Sprite one;
	public Sprite two;

	public int line;

	//private Animator birdanim;
	//private Animator fishanim;
	public GameObject A;
	public GameObject B;

	private Color32 color1 = new Color32(129,210,255,5);
	private Color32 color2 = new Color32(25,78,109,5);
	//public Camera cam;

	GameMaster gm;

	private SpriteRenderer spriteRenderer;

	void Start(){
		gm = GameObject.Find("GM").GetComponent<GameMaster>();
		//cam = GetComponent<Camera>();
		Camera.main.clearFlags = CameraClearFlags.SolidColor;

		spriteRenderer = GetComponent<SpriteRenderer>();
		if(spriteRenderer.sprite == null)
			spriteRenderer.sprite = one;


		//birdanim = bird.GetComponent<Animator>();
		//fishanim = fish.GetComponent<Animator>();



	}

	void OnMouseOver()
	{
		/*transform.localScale = new Vector3(Mathf.PingPong(Time.time,0.4f)+1f,
		                                   Mathf.PingPong(Time.time, 0.4f)+1f
		                                   ,0);
		           */                        
		//transform.localScale+=new Vector3(0.1f,0.1f,0);

		if(Input.GetMouseButtonDown (0)){

			if(spriteRenderer.sprite == one){
				spriteRenderer.sprite = two;
				A.SetActive (false);
				B.SetActive (true);
				if(line == 1){
					gm.birdyes = false;
				}
				else if(line == 2){
					gm.skyyes = false;
					Camera.main.backgroundColor = color2;

				}
			}
			else if(spriteRenderer.sprite == two){
				spriteRenderer.sprite = one;
				B.SetActive (false);
				A.SetActive (true);
				if(line == 1){
					gm.birdyes = true;

				}
				else if(line == 2)
					gm.skyyes = true;
					Camera.main.backgroundColor = color1;

			}
		}

	}

	/*void OnMouseExit()
	{
		transform.localScale = new Vector3(1f,1f,0);
	}*/
	void Update(){

		//transform.localScale = new Vector3(1f,1f,0);



	}

}


/*
public Color color1 = Color.red;
public Color color2 = Color.blue;
public float duration = 3.0F;

Camera camera;

void Start() {
	camera = GetComponent<Camera>();
	camera.clearFlags = CameraClearFlags.SolidColor;
}

void Update() {
	float t = Mathf.PingPong(Time.time, duration) / duration;
	camera.backgroundColor = Color.Lerp(color1, color2, t);
}*/