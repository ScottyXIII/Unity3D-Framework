using UnityEngine;
using System.Collections;

[System.Serializable]
public class IKeyboard : IControllerInput { 

	public override bool up()
	{
		return Input.GetKeyDown (Keys_up); 
	}

	public override bool down()
	{
		return Input.GetKeyDown (Keys_down); 
	}

	public override bool left()
	{
		return Input.GetKeyDown (Keys_left); 
	}

	public override bool right()
	{
		return Input.GetKeyDown (Keys_right); 
	}

	public override bool upHeld()
	{
		return Input.GetKey (Keys_up); 
	}
	
	public override bool downHeld()
	{
		return Input.GetKey (Keys_down); 
	}
	
	public override bool leftHeld()
	{
		return Input.GetKey (Keys_left); 
	}
	
	public override bool rightHeld()
	{
		return Input.GetKey (Keys_right); 
	}
	
	public override bool action()
	{
		return Input.GetKeyDown (Keys_action); 
	}

	public override bool cancel()
	{
		return Input.GetKeyDown (Keys_cancel); 
	}

	public override bool inventory()
	{
		return Input.GetKeyDown (Keys_inventory); 
	}

	public override bool actionHeld()
	{
		return Input.GetKey (Keys_action); 
	}
	
	public override bool cancelHeld()
	{
		return Input.GetKey (Keys_cancel); 
	}
	
	public override bool inventoryHeld()
	{
		return Input.GetKey (Keys_inventory); 
	}
	
 
}
