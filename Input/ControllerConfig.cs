using UnityEngine;
using System.Collections;

public enum controllerProfile {
	Keys, Controller 
};

[System.Serializable]
public class ControllerConfig  {

	public controllerProfile profile; 

	[SerializeField]
	public IControllerInput input; 
	public IControllerInput prv_input; 

	public bool controller_conected = false; 

	public string controller1 = "";
	public string controller2 = "";
	
 	public void detectController()
	{
		try {
			if (Input.GetJoystickNames()[0] != null) {

				this.input = new IController ();

				profile = controllerProfile.Controller; 

				controller_conected = true; 

				setControllerDefalts();

				setControllers(); 
 
			}
		} catch {
			 
				this.input = new IKeyboard(); 

				profile = controllerProfile.Keys; 

				controller_conected = false; 

				setKeyDefaults();
			}
	 
	}

	public bool detectInputChange() 
	{	
		if (this.input.GetType () == typeof(IController)) {
			try {
				if (Input.GetJoystickNames()[0] == null) {
					detectController();
				}
			}
			catch {return false;}
		} else if (this.input.GetType () == typeof(IKeyboard)) {
			try {
				if (Input.GetJoystickNames()[0] != null) {

					detectController();
				}
			}
			catch {return false;}
		}
		return false; 
	}
	public void setControllers() 
	{
		this.controller1 = Input.GetJoystickNames () [0]; 
		 
		try {
			this.controller2 = Input.GetJoystickNames () [1]; 
		} catch {
			return; 
		}
	}

	public void setKeyDefaults() 
	{ 
		if (!controller_conected) {
		
			((IKeyboard) input).Keys_up = KeyCode.UpArrow;
			((IKeyboard) input).Keys_down = KeyCode.DownArrow;
			((IKeyboard) input).Keys_left = KeyCode.LeftArrow;
			((IKeyboard) input).Keys_right = KeyCode.RightArrow;
			((IKeyboard) input).Keys_cancel = KeyCode.A;
			((IKeyboard) input).Keys_action = KeyCode.B;
			((IKeyboard) input).Keys_inventory = KeyCode.Tab;
		}

	}

	public void setControllerDefalts() 
	{
		if (controller_conected) {
			
			((IController)input).button_action = "A_360";
			((IController)input).button_cancel = "B_360";
			((IController)input).button_inventory = "Y_360";

		}

	}

	public void switchControl(controllerProfile newProfile)
	{
		this.profile = newProfile; 
	}
}
