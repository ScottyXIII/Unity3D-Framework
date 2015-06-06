using UnityEngine;
using System.Collections;

public class CollisionImageChange : MonoBehaviour {

	public Sprite open, closed;  

	public SpriteRenderer door; 

	public bool is_open, is_locked = false; 

	public Collider2D collision; 

	public void Update() 
	{
		if (is_open && !is_locked) {
			door.sprite = open; 
		} else {
			door.sprite = closed; 
		}
	}

	public void OnTriggerStay2D(Collider2D collision) 
	{ 
		is_open = true; 
	}

	public  void OnTriggerExit2D(Collider2D other)
	{
		is_open = false; 
	}
}
