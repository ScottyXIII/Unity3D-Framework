using UnityEngine;
using System.Collections;

public class TextBoxManager : Singleton<TextBoxManager> {

	public Textbox textbox; 
	public GameObject obj; 

	public void CreateTextbox()
	{
		TextBoxManager.Instance.obj = Game.loadObject ("textBox", "TextBox");
		TextBoxManager.Instance.textbox = obj.GetComponent<Textbox> (); 
	}

	public void CreateTextbox(string path)
	{
		TextBoxManager.Instance.obj = Game.loadObject ("textBox", path);
		TextBoxManager.Instance.textbox = obj.GetComponent<Textbox> (); 
	}

	public void DeleteBox() 
	{
		Destroy (TextBoxManager.Instance.obj.gameObject);
	}

	public void NewLine(string line)
	{
		TextBoxManager.Instance.textbox.text.text = line; 
	}
}
