using UnityEngine;
using System.Collections;

public enum ConversationType {
	NONE, RANDOM, ONQUEST, STARTQUEST, ENDQUEST
}

public class Conversation : ScriptableObject {

	public ConversationType type; 
	public Quests aboutQuest; 
	public ConversationEntry[] ConversationLines; 

}
