using UnityEngine;
using System.Collections;

public class TransitionEffectFadeIn : IStateTransition {
 
	public void Init() 
	{
		Fade.StartAlphaFade (Color.black, true, 5f);
	}

	
	public bool Run()
	{
		if (GameObject.Find ("Fade").GetComponent<Fade> ().finsihed) {
			return true; 
		}
		return false; 
	}
}
