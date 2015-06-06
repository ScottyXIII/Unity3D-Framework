using UnityEngine;
using System.Collections;

public interface IState 
{
	void Run();
	void Init();

	//public virtual void OnExit();
}
