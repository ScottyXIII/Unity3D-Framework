using UnityEngine;
using System.Collections;

public interface IStateTransition {

	bool Run();
	void Init();
 
}
