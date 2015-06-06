using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
[System.Serializable]
public class StateMachine : MonoBehaviour
{
	public IState currentState; 

	public Dictionary<string, IState> states = new Dictionary<string, IState>();
	Dictionary<string, IStateTransition> transitionIn = new Dictionary<string, IStateTransition>();
	Dictionary<string, IStateTransition> transitionOut = new Dictionary<string, IStateTransition>();

	delegate void transitionDelegate();
	transitionDelegate transition_delegate;

	protected bool transist = false;

	public StateMachine GetNewInstance() 
	{
		StateMachine instance = new StateMachine();
		GameObject obj = null; 

		if (!GameObject.Find("StateMachine")) {
			obj = new GameObject();
			obj.name = "StateMachine"; 
			DontDestroyOnLoad(obj); 
		} else {
			obj = GameObject.Find("StateMachine");
		}

		instance = obj.AddComponent<StateMachine> ();
 
		return instance; 
	}

	public void Add(string name, IState state)
	{
		states[name] = state;
		this.gameObject.AddComponent (state.GetType());
	}

	public void Add(string name, IState state, IStateTransition transitionIn, IStateTransition transitionOut)
	{	  
		this.states[name] = state;
		this.transitionIn [name] = transitionIn;
		this.transitionOut [name] = transitionOut;
	}

	public void ChangeState(string state_name) 
	{
		this.currentState = states [state_name];

		this.currentState.Init (); 
	}

	public void ChangeState(string state_name, string scene_name) 
	{
		
		Game.GetInstance().last_scene = Application.loadedLevelName; 
		
		Game.GetInstance().current_scene = state_name; 

		Application.LoadLevel (scene_name);
			
		this.currentState = states [state_name];

		StartCoroutine (InitNewState(state_name)); 
	}
	
	public void ChangeState(string state_name, string scene_name, IStateTransition effectOut) 
	{	
		effectOut.Init (); 

		this.currentState.Init (); 

		StartCoroutine (TransitionOut(effectOut, state_name, scene_name)); 
	}

	public void ChangeState(string state_name, string scene_name, IStateTransition effectOut, IStateTransition effectIn) 
	{	
		Game.removePlayerFromBackground(); 

		effectOut.Init (); 

		transitionIn["TransitionIn"] = effectIn; 

		StartCoroutine (TransitionOut(effectOut, state_name, scene_name)); 
	}

	public IEnumerator InitNewState(string state_name) 
	{
		while (Application.loadedLevelName != state_name) {
			yield return new WaitForSeconds (0);
		}

		this.currentState.Init (); 

		StopCoroutine ("InitNewState"); 
	}

	public IEnumerator TransitionOut(IStateTransition effect, string state_name, string scene_name)
	{
		while (Application.loadedLevelName != state_name) {
			if (effect.Run ()) {
				ChangeState (state_name, scene_name); 
			}

			yield return new WaitForSeconds (0);
		}

		Game.addPlayerToBackground(); 
	
		if (transitionIn.ContainsKey ("TransitionIn")) {
			transitionIn ["TransitionIn"].Init (); 
		
			transitionIn.Remove ("TransitionIn");
		}

		if (Application.loadedLevelName == state_name) {
			StopCoroutine ("TransitionOut"); 
		}
	}

	public void Run ()
	{	 
		try {
			if (currentState != null) {
			this.currentState.Run ();
		}
		} catch {
		//	Debug.Log(this + " class has no states to run! add new states with StateMachine.Add(name, state)");
		}
	}


}
