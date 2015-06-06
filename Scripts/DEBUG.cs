using UnityEngine;
using System.Collections;
using UnityEditor;

public class DEBUG : MonoBehaviour {

	private static DEBUG instance = null;

	public static DEBUG GetInstance() {
		if (!GameObject.Find("Game")) {
			instance = new DEBUG(); 
		} else {
			instance = GameObject.Find("Game").GetComponent<DEBUG>();
		}
		
		return instance; 
	}
	
	public enum STATES {
		intro, start, options, characterSelect, ship, town, pub, shop, evilCave1, evilCave2, evilCave3, evilCave4, 
		outside, outside2, downstairs, upstairs, kitchen, bedroom, masterbedroom, maize1, maize2, maize3, maize10, maize23, maize30, maizeBoss, 
		graveyard1,
		graveyard2,
		graveyard3,
		graveyard4,
		graveyard5,
		graveyard6,
		battle
	}

	public STATES state; 


	
 
	public string startScene() 
	{
		return state.ToString(); 
	}
}
