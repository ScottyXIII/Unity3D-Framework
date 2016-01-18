using System.Collections;
using UnityEngine;
using UnityEditor;
 
public class ConversationAssetCreator : MonoBehaviour {
	
	[MenuItem("Assets/Create/Conversation")]
	public static void CreateConversationAsset()
	{
		CustomAssetUtility.CreateAsset<Conversation> (); 
	}

 
}
