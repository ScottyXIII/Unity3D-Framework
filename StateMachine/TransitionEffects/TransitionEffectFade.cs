using UnityEngine;
using System.Collections;

public class TransitionEffectFade : IStateTransition {
	
	public void Init() 
	{
		Fade.StartAlphaFade (Color.black, false, 5f);
	}
	
	public bool Run()
	{
		if (GameObject.Find ("Fade").GetComponent<Fade> ().finsihed) {
			return true; 
		}
		return false; 
	}
}
