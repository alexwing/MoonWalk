using UnityEngine;
using System.Collections;

public class RotateSample : MonoBehaviour
{	
	void Start(){
		iTween.RotateBy(gameObject, iTween.Hash("x", .01, "easeType", "easeInOutCirc", "loopType", "pingPong"));
	}
}

