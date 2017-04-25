using UnityEngine;
using System.Collections;

public class moveCamera : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.gameObject.transform.position = target.transform.position + new Vector3(0, 0, -3);

        //if I can't see the cube, move

        Ray ray = new Ray();
        ray.origin = this.gameObject.transform.position;
        ray.direction = new Vector3(0, 0, 1);

        if(Physics.Raycast(ray, 2))
        {
            //can't see
            this.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
            this.gameObject.transform.position = target.transform.position + new Vector3(0, 3, 0);
        }
        else
        {
            //can see
            this.gameObject.transform.rotation = Quaternion.identity;
            this.gameObject.transform.position = target.transform.position + new Vector3(0, 0, -3);

        }

    }
}
