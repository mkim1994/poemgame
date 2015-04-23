using UnityEngine;
using System.Collections;

public class TextActivity : MonoBehaviour {

	public Sprite writer;
	public Sprite philosopher;
	//private Animator birdanim;
	//private Animator fishanim;
	public GameObject bird;
	public GameObject fish;

	private SpriteRenderer spriteRenderer;

	void Start(){
		spriteRenderer = GetComponent<SpriteRenderer>();
		if(spriteRenderer.sprite == null)
			spriteRenderer.sprite = writer;


		//birdanim = bird.GetComponent<Animator>();
		//fishanim = fish.GetComponent<Animator>();



	}

	void OnMouseOver()
	{
		transform.localScale = new Vector3(Mathf.PingPong(Time.time,0.4f)+1f,
		                                   Mathf.PingPong(Time.time, 0.4f)+1f
		                                   ,0);
		                                   
		//transform.localScale+=new Vector3(0.1f,0.1f,0);

		if(Input.GetMouseButtonDown (0)){
			if(spriteRenderer.sprite == writer){
				spriteRenderer.sprite = philosopher;
				bird.SetActive (false);
				fish.SetActive (true);
			}
			else if(spriteRenderer.sprite == philosopher){
				spriteRenderer.sprite = writer;
				fish.SetActive (false);
				bird.SetActive (true);
			}
		}

	}

	void OnMouseExit()
	{
		transform.localScale = new Vector3(1f,1f,0);
	}
	void Update(){

		//transform.localScale = new Vector3(1f,1f,0);



	}

}
