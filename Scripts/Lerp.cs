using UnityEngine;
using System.Collections;

public class Lerp : MonoBehaviour {

	public bool set_lerp = false;

	public float startTime; 

	public float journeyLength; 

	public Vector2 end_pos, start_pos; 

	public float speed = 1f; 

	public Vector2 offSet = Vector2.zero; 

	void Start () {

	}

	void Update () {
		
	}

	public virtual Vector3 moveTo(GameObject obj)
	{
		if (!set_lerp) {
			startTime = Time.time;
			end_pos = new Vector2(obj.transform.position.x + offSet.x, obj.transform.position.y+ offSet.y); 
			journeyLength = Vector3.Distance(transform.position, end_pos);
			set_lerp = true;
			start_pos = transform.position;
		} else {
			float distCovered = (Time.time - startTime);
			float fracJourney = (distCovered / journeyLength) * speed; 
			
			if (transform.position.x == end_pos.x) {
				set_lerp = false; 
			}

			return Vector3.Lerp(transform.position, end_pos, fracJourney);
		} 

		return Vector3.zero; 
	}
}
