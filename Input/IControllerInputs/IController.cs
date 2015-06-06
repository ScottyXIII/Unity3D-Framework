using UnityEngine;
using System.Collections;

public class IController : IControllerInput {

	private bool isAxisUpInUse = false;
	private bool isDpadUpInUse = false;

	private bool isDpadLeftInUse = false;
	private bool isDpadRightInUse = false;

	public bool isAxisDownInUse = false;
	private bool isDpadDownInUse = false;

	public override bool up()
	{	
		if (Input.GetAxis("Vertical") >= 0.5)
		{ 
			if(isAxisUpInUse == false)
			{	
				isAxisUpInUse = true;
				return true; 
			}
		} if(Input.GetAxis("VertDpad_360") == 1)
		{
			if(isDpadUpInUse == false)
			{
				isDpadUpInUse = true;
				return true; 
			}
		}
		
		if (Input.GetAxis("VertDpad_360") == 0)
		{
			isDpadUpInUse = false;
		}

		if (Input.GetAxis("Vertical") == 0)
		{
			isAxisUpInUse = false;
		}

		return false;
	}
		


	public override bool down()
	{	
		if( Input.GetAxis("Vertical") <= -0.5)
		{ 
			if(isAxisDownInUse == false)
			{	
				isAxisDownInUse = true;
				return true; 
			}
		} if(Input.GetAxis("VertDpad_360") == -1)
		{
			if(isDpadDownInUse == false)
			{
				isDpadDownInUse = true;
				return true; 
			}
		}

		if (Input.GetAxis("VertDpad_360") == 0)
		{
			isDpadDownInUse = false;
		}
		if( Input.GetAxis("Vertical") == 0)
		{
			isAxisDownInUse = false;
		}  

		return false; 
	}

	public override bool left()
	{	
		if( Input.GetAxis("Horizontal") <= -0.5)
		{ 
			if(isAxisDownInUse == false)
			{	
				isAxisDownInUse = true;
				return true; 
			}
		} if(Input.GetAxis("HorDpad_360") == -1)
		{
			if(isDpadLeftInUse == false)
			{
				isDpadLeftInUse = true;
				return true; 
			}
		}

		if (Input.GetAxis("HorDpad_360") == 0)
		{
			isDpadLeftInUse = false;
		}
		if( Input.GetAxis("Horizontal") == 0)
		{
			isAxisDownInUse = false;
		}  
		
		return false; 
	}

	public override bool right()
	{	
		if(Input.GetAxis("Horizontal") >= 0.5)
		{ 
			if(isAxisDownInUse == false)
			{	
				isAxisDownInUse = true;
				return true; 
			}
		} if(Input.GetAxis("HorDpad_360") == 1)
		{
			if(isDpadRightInUse == false)
			{
				isDpadRightInUse = true;
				return true; 
			}
		}
		
		if (Input.GetAxis("HorDpad_360") == 0)
		{
			isDpadRightInUse = false;
		}

		if(Input.GetAxis("Horizontal") == 0)
		{
			isAxisDownInUse = false;
		}  
		
		return false; 
	}

	public override bool upHeld()
	{	 
		if( Input.GetAxis("VertDpad_360") == 1)
		{
			return true; 
		}
	
		if(Input.GetAxis("Vertical") >= 0.7 && Input.GetAxis("Vertical") != 0)
		{
			return true; 
		}

		return false; 
	}

	public override bool downHeld()
	{	 
		if(Input.GetAxis("VertDpad_360") == -1)
		{
			return true; 
		}

		if(Input.GetAxis("Vertical") <= 0.7 && Input.GetAxis("Vertical") != 0)
		{
			return true; 
		}

		return false; 
	}

	public override bool leftHeld()
	{
		if( Input.GetAxis("HorDpad_360") == -1)
		{
			return true; 
		}
		
		if( Input.GetAxis("Horizontal") <= 0.7 && Input.GetAxis("Horizontal") != 0)
		{
			return true; 
		}
		
		return false; 
	}

	public override bool rightHeld()
	{	 
		if(Input.GetAxis("HorDpad_360") == 1)
		{
			return true; 
		}
		
		if(Input.GetAxis("Horizontal") >= 0.7 && Input.GetAxis("Horizontal") != 0)
		{
			return true; 
		}
		
		return false; 
	}

	public override bool action()
	{	
		return Input.GetButtonDown (button_action); 
	}

	public override bool cancel()
	{	
		return Input.GetButtonDown (button_cancel); 
	}

	public override bool inventory()
	{	
		return Input.GetButtonDown (button_inventory); 
	}
	
	public override bool actionHeld()
	{	
		return Input.GetButton (button_action); 
	}
	
	public override bool cancelHeld()
	{	
		return Input.GetButton (button_cancel); 
	}

	public override bool inventoryHeld()
	{	
		return Input.GetButton (button_inventory); 
	}


}
