using UnityEngine;
using System.Collections;

public class Values : MonoBehaviour {
	
	/*
	 * Takes two values and increments of deincrements the return 
	 * Note the function inc/dec 1 by 1
	 */
	public static int getNextValue(int value, int value_to_follow, int speed) {

		// work out gap and automaticllay set a speed. 
		if (value > value_to_follow) {
			return value-speed;
		} else if (value < value_to_follow) {
			return value+speed; 
		}

		return value;
	}
}
