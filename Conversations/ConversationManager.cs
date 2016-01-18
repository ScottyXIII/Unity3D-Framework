using UnityEngine;
using System.Collections;

public class ConversationManager : Singleton<ConversationManager> {

	public bool isTalking = false; 

	public Textbox textbox;  
	private int lineIndex; 
	private string text;
	private ConversationEntry currentLine; 

	public bool autoScroll = false; 

	public void StartConversation(Conversation text)
	{
		StartConversation(text, "TextBox");
	}

	public void StartConversation(Conversation text, string textBoxObjPath)
	{
		if (!isTalking) {
			lineIndex = 0; 
			StartCoroutine(DisplayConversation(text));
			TextBoxManager.Instance.CreateTextbox(textBoxObjPath);
			textbox = TextBoxManager.Instance.textbox; 
			textbox.speakerName.text = currentLine.speakersName;
			textbox.image.sprite = currentLine.image; 
		}
	}

	public IEnumerator DisplayConversation(Conversation conversation)
	{
		isTalking = true;
		lineIndex = 0; 
		currentLine = conversation.ConversationLines[lineIndex]; 
		text = ""; 

		while (lineIndex < conversation.ConversationLines.Length) {
 			
			yield return null; 

			if (!autoScroll) {
				if (InputManager.Instance.actionKey()) {
					if (lineIndex == (conversation.ConversationLines.Length-1)) {
						lineIndex = conversation.ConversationLines.Length+1;
						yield return null; 
					} else {
						text = ""; 
						lineIndex++;
						if (lineIndex != conversation.ConversationLines.Length) {
							currentLine = conversation.ConversationLines[lineIndex]; 
						}
					}

				}
			} else {
				text = ""; 
				lineIndex++;
				currentLine = conversation.ConversationLines[lineIndex]; 
				yield return new WaitForSeconds(3f);
			}

			if (text != currentLine.text) {
				foreach (var letter in currentLine.text.ToString()) {
					text += letter;
					yield return new WaitForSeconds(0.03f);
				}
			}
			yield return null; 
		
		}

		KillConversation (); 
	}

	public void KillConversation() 
	{
		lineIndex = 0; 
		TextBoxManager.Instance.DeleteBox ();
		isTalking = false; 
		StopAllCoroutines (); 
	}

	public void Update() 
	{
		if (isTalking) {
			textbox.text.text = text;
			//textbox.speakerName.text = currentLine.speakersName;
			//textbox.image.sprite = currentLine.image; 
		}

	}
}
