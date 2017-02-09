using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float lerpAmount = Mathf.Min(1.0f, Time.deltaTime*10);

	    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target.position - target.forward*10, lerpAmount);

	    gameObject.transform.LookAt(target.position, target.up);

	}
}
