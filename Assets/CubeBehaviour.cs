using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    public InputReader Inputs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = new Vector3();
        float moveSpeed = 3f;
        float vertSpeed = 0;
        //if (InputReaderComponentExists)  //NOTE This returns true and vert speed is up if not commented out... but RightControllerFound returns false
        //    vertSpeed = 0.5f;
        if (Inputs.LeftControllerFound)
        //if(false)
        {
            Vector2 joystick = Inputs.rightJoystick;
            moveDir = new Vector3(joystick.x, vertSpeed, joystick.y);
            ////////buttons
            //////if(Inputs.ButtonA)
            //////{
            //////    //this.GetComponent<Material>().    got here
            //////}
            //////else if(Inputs.ButtonB)
            //////{

            //////}
            //if (Inputs.ButtonA)
            //    moveDir.x = +1f;
            //else if (Inputs.ButtonB)
            //    moveDir.x = -1f;
        }
        else
        {


            //just make some motion to show it's alive
            moveSpeed = 1; //slower
            int cycle = DateTime.Now.Second;
            if (cycle % 4 == 0) //modulus
            {
                moveDir.x = +1f;
            }
            else if (cycle % 4 == 1)
            {
                moveDir.z = +1f;
            }
            else if (cycle % 4 == 2)
            {
                moveDir.x = -1f;
            }
            else
            {
                moveDir.z = -1f;
            }
        }

        moveDir.y = vertSpeed;
        transform.position += moveDir * moveSpeed * Time.deltaTime;


    }
}
