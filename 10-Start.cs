using UnityEngine;
using System.Collections;

public class ShipMotion : MonoBehaviour
{

    public bool autorotate = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.transform.position += gameObject.transform.forward * Time.deltaTime;

        Transform goTransform = this.gameObject.transform;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            float amount =Time.deltaTime * 50;
            if (Input.GetKey(KeyCode.DownArrow))
                amount *= -1;

            Quaternion quat = Quaternion.AngleAxis(amount, new Vector3(1,0,0));


            goTransform.Rotate(quat.eulerAngles, amount);

        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            float amount = -Time.deltaTime * 50;
            if (Input.GetKey(KeyCode.RightArrow))
                amount *= -1;

            Quaternion quat = Quaternion.AngleAxis(amount, new Vector3(0, 1, 0));


            goTransform.Rotate(quat.eulerAngles, amount);

        }
        if(Input.GetKey(KeyCode.PageUp) || Input.GetKey(KeyCode.PageDown))
        {

            //Debug.LogError("Roll");
            float amount = -Time.deltaTime*50;
            if (Input.GetKey(KeyCode.PageDown))
                amount *= -1;

            Quaternion quat = Quaternion.AngleAxis(amount, new Vector3(0, 0, 1));


            goTransform.Rotate(quat.eulerAngles, amount);

        }

        if (autorotate)
        {
            
            //First of all, see if we need to rotate
            //bool shouldRotate = Mathf.Abs(goTransform.up.x) > .01f;
            if (true)
            {




                float proposedAmount = Time.deltaTime * 25;
                float amount = proposedAmount;
                

                Quaternion noRotation = Quaternion.AngleAxis(0, new Vector3(0, 0, 1));
                Quaternion rotationPositive = Quaternion.AngleAxis(proposedAmount, new Vector3(0, 0, 1));
                Quaternion rotationNegative = Quaternion.AngleAxis(-proposedAmount, new Vector3(0, 0, 1));

                Quaternion chosenQuat = noRotation;

                Vector3 upRotationPositive = rotationPositive * goTransform.up;
                Vector3 upRotationNegative = rotationNegative * goTransform.up;

                float currentAbsUpY = Mathf.Abs(goTransform.up.y);

                if (Mathf.Abs(upRotationPositive.y) > currentAbsUpY)
                {
                    chosenQuat = rotationPositive;
                    amount = proposedAmount;
                }
                else if (Mathf.Abs(upRotationNegative.y) > currentAbsUpY)
                {
                    chosenQuat = rotationNegative;
                    amount = -proposedAmount;
                }
                else
                    amount = 0;

                Debug.LogError(goTransform.up.y);






                goTransform.Rotate(chosenQuat.eulerAngles, amount);
            }
        }



    }
}
