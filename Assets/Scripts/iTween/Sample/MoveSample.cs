using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{	
	void Start(){
		iTween.MoveBy(this.gameObject, iTween.Hash("x", 20, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
		iTween.RotateBy(this.gameObject, iTween.Hash("x", .01, "easeType", "easeInOutCirc", "loopType", "pingPong"));
	}
}

