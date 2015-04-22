using UnityEngine;
using System.Collections;

public class TextActivity : MonoBehaviour {

	public Sprite writer;
	public Sprite philosopher;

	private SpriteRenderer spriteRenderer;

	void Start(){
		spriteRenderer = GetComponent<SpriteRenderer>();
		if(spriteRenderer.sprite == null)
			spriteRenderer.sprite = writer;
	}

	void OnMouseOver()
	{
		transform.localScale = new Vector3(Mathf.PingPong(Time.time,0.4f)+1f,
		                                   Mathf.PingPong(Time.time, 0.4f)+1f
		                                   ,0);
		                                   
		//transform.localScale+=new Vector3(0.1f,0.1f,0);

		if(Input.GetMouseButtonDown (0)){
			spriteRenderer.sprite = philosopher;
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
