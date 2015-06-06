using UnityEngine;
using System.Collections;

[System.Serializable]
public class InputManager : MonoBehaviour {

	[SerializeField]
	public ControllerConfig config = new ControllerConfig(); 
	
	// Use this for initialization
	void Start () {
		config.detectController (); 
	}

	public bool up()
	{ 
		return config.input.up ();
	}
	
	public bool down()
	{
		return config.input.down ();
	}

	public bool left()
	{ 
		return config.input.left ();
	}
	
	public bool right()
	{
		return config.input.right ();
	}
	
	public bool upHeld()
	{ 
		return config.input.upHeld ();
	}
	
	public bool downHeld()
	{
		return config.input.downHeld ();
	}
	
	public bool leftHeld()
	{ 
		return config.input.leftHeld ();
	}
	
	public bool rightHeld()
	{
		return config.input.rightHeld ();
	}
	
	public bool actionKey()
	{
		return config.input.action ();
	}

	public bool cancelKey()
	{
		return config.input.cancel ();
	}

	public bool inventoryKey()
	{
		return config.input.inventory ();
	}

}
