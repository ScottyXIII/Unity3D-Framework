using UnityEngine;
using System.Collections;

[System.Serializable]
public class IControllerInput {

	[SerializeField]
	public KeyCode Keys_up, Keys_down, Keys_left, Keys_right, Keys_action, Keys_cancel, Keys_esc, Keys_pause, Keys_start, Keys_inventory;

	public string button_up, button_down, button_left, button_right, button_action, button_cancel, button_inventory, button_y, button_esc, button_pause, button_start;

	public virtual bool up(){return false;}
	public virtual bool down(){return false;}
	public virtual bool left(){return false;}
	public virtual bool right(){return false;}

	public virtual bool upHeld(){return false;}
	public virtual bool downHeld(){return false;}
	public virtual bool leftHeld(){return false;}
	public virtual bool rightHeld(){return false;}

	// Left anolog stick
	public virtual float getHorAxis(){return 0f;}
	public virtual float getVirtAxis(){return 0f;}
	
	// Right anolog stick
	public virtual float getRightHorAxis(){return 0f;}
	public virtual float getRightVirtAxis(){return 0f;}
	
	// Right anolog stick
	public virtual float getDparHor(){return 0f;}
	public virtual float getDpadVert(){return 0f;}
	
	public virtual bool action(){return false;}
	public virtual bool cancel(){return false;}
	public virtual bool inventory(){return false;}
	public virtual bool actionHeld(){return false;}
	public virtual bool cancelHeld(){return false;}
	public virtual bool inventoryHeld(){return false;}

	public virtual bool leftTrigger(){return false;}
	public virtual bool rightTrigger(){return false;}
	public virtual bool leftBumper(){return false;}
	public virtual bool rightBumper(){return false;}
	public virtual bool leftTriggerHeld(){return false;}
	public virtual bool rightTriggerHeld(){return false;}
	public virtual bool leftBumperHeld(){return false;}
	public virtual bool rightBumperHeld(){return false;}

	public virtual bool start(){return false;}
	public virtual bool select(){return false;}
	public virtual bool startHeld(){return false;}
	public virtual bool selectHeld(){return false;}

}
