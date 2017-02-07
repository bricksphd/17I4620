using UnityEngine;
using System.Collections;

public class DeathStarScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.gameObject.transform.position += gameObject.transform.forward * Time.deltaTime;

        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            float amount = 10.0f;
            if (Input.GetKey(KeyCode.DownArrow))
                amount *= -1;

            Quaternion quat = Quaternion.AngleAxis(Time.deltaTime * amount, this.gameObject.transform.right);
            this.gameObject.transform.up = quat * this.gameObject.transform.up;
            this.gameObject.transform.forward = quat * this.gameObject.transform.forward;
            //this.gameObject.transform.right = Vector3.Cross(this.gameObject.transform.forward, this.gameObject.transform.up);

        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            float amount = 10.0f;
            if (Input.GetKey(KeyCode.RightArrow))
                amount *= -1;

            Quaternion quat = Quaternion.AngleAxis(Time.deltaTime * amount, this.gameObject.transform.up);
            this.gameObject.transform.right = quat * this.gameObject.transform.right;
            this.gameObject.transform.forward = quat * this.gameObject.transform.forward;
            //this.gameObject.transform.right = Vector3.Cross(this.gameObject.transform.forward, this.gameObject.transform.up);

        }

    }
}
