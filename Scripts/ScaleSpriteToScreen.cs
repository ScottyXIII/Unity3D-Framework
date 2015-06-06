using UnityEngine;
using System.Collections;

public class ScaleSpriteToScreen : MonoBehaviour {
	
	/*
	 | This script only work when camera field of view is 53. needs a fix or sort some shit out. Script could be much better but i'm high
	 |
	*/
	
	// Use this for initialization
	void Start () {
		Resize (); 
	}
	
	// Update is called once per frame
	void Update () {
		
		Resize (); //Find on screen resize? Are we expecting people to change screen size during gameplay?
	}
	
	void Resize()
	{
		
		SpriteRenderer sr=GetComponent<SpriteRenderer>();

		if(sr==null) return;
	
		float width=sr.sprite.bounds.size.x;
		float height=sr.sprite.bounds.size.y;
		
		
		float worldScreenHeight=Camera.main.orthographicSize*2f;
		float worldScreenWidth=worldScreenHeight/Screen.height*Screen.width;
		
		Vector3 xWidth = transform.localScale;
		xWidth.x=worldScreenWidth / width;
		transform.localScale=xWidth;
		//transform.localScale.x = worldScreenWidth / width;
		Vector3 yHeight = transform.localScale;
		yHeight.y=worldScreenHeight / height;
		transform.localScale=yHeight;
		//transform.localScale.y = worldScreenHeight / height;
		
		transform.localScale= new Vector3(xWidth.x, yHeight.y, transform.localScale.z);
	}
}
