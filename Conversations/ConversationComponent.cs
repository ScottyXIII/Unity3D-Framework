using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class ConversationComponent : MonoBehaviour {

	public string textBoxPath = "TextBox";
	private bool hasMeetPlayer = false; 
	public bool inRange = false; 
	public Conversation firstMeet = null;
	public List<Conversation> conversations = new List<Conversation>();

	public bool actionToTrigger = true; 

	void Update() 
	{
		if (inRange) {
			if (actionToTrigger) {
				ConversationManager.Instance.StartConversation(GetStartQuestTalk());
				actionToTrigger = false;
			} else {
				//ConversationManager.Instance.StartConversation(GetTalk());
			}
		}
	}

	private Conversation GetCurrentQuestConvo(ConversationType type)
	{
		foreach (var convo in conversations) {
			if (convo.type == type && convo.aboutQuest == QuestManager.Instance.currentQuest) {
				return convo; 
			}
		}
		return null; 
	}

	private List<Conversation> GetConvosByType(ConversationType type)
	{
		List<Conversation> conversations = null; 

		foreach (var convo in conversations) {
			if (convo.type == type && convo.aboutQuest == QuestManager.Instance.currentQuest) {
				conversations.Add(convo); 
			}
		}

		return conversations; 
	}

	private Conversation GetStartQuestTalk() 
	{
		return GetCurrentQuestConvo(ConversationType.STARTQUEST); 
	}

	private Conversation GetOnQuestTalk() 
	{
		return GetCurrentQuestConvo(ConversationType.ONQUEST); 
	} 

	private Conversation GetEndQuestTalk() 
	{
		return GetCurrentQuestConvo(ConversationType.ENDQUEST); 
	}

	private List<Conversation> GetRandomTalk(int index) 
	{
		List<Conversation> conversations = GetConvosByType (ConversationType.RANDOM); 

		return conversations; 
	}

	private Conversation GetTalk() 
	{
		Conversation convo = null; 

		if (!QuestManager.Instance.isOnQuest) {
			convo = GetStartQuestTalk(); 
		} else {
			if (QuestManager.Instance.currentQuestState == QuestState.ONQUEST) {
				convo = GetOnQuestTalk();
			} else if (QuestManager.Instance.currentQuestState == QuestState.COMPLETEDQUEST) {
				convo = GetEndQuestTalk();
			}
		}

		return convo; 
	}

	void OnCollisionStay2D(Collision2D col) {
		inRange = true; 
	}
}
