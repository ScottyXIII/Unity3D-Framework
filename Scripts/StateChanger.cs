using UnityEngine;
using System.Collections;

public class StateChanger : MonoBehaviour {

	public string collide_with = ""; 

	public string next_state = ""; 

	public bool new_scene = true;

	public bool reload_shop_items = false; 

	public void OnTriggerEnter2D(Collider2D collision) 
	{
		if (collide_with != "") {
			if (collision.name != collide_with) {
				return; 
			}
		}
		changeState(); 
	}

	protected void changeState() 
	{
		if (reload_shop_items) {
			Game.GetInstance().loadShopItems(); 
		}
		if (new_scene) {

			Game.game_state.ChangeState(next_state, next_state, new TransitionEffectFade(), new TransitionEffectFadeIn());
		
		} else {
			Game.game_state.ChangeState(next_state);
		}
	}
}
