using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.Netcode;
using System;

public class PlayerNetwork : NetworkBehaviour
{
    public InputReader Inputs;
    internal bool InputReaderGameObjectExists;  //false
    internal bool InputReaderComponentExists;  // false


    private void Start()
    {
        //debugging to see if objects exist
        GameObject go = GameObject.FindGameObjectWithTag("InputReaderTag");
        if (go != null)
        {
            InputReaderGameObjectExists = true;
            Inputs = go.GetComponent<InputReader>();
            if (Inputs != null)
            {
                InputReaderComponentExists = true;
            }
        }

        //
        //Inputs = GameObject.FindGameObjectWithTag("InputReaderTag").GetComponent<InputReader>(); 

        //int i = 1;

        //:  GameObject.FindObjectByTag("Input Manager").GetComponent<InputReader>()
    }
    private void Update()
    {
        if (!IsOwner) {
            return;
        }


        ////this worked for ball in box but not in CodeMonkeyNGO:
        //float moveSpeed = 3f;
        //Vector3 moveDir = new Vector3();
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //moveDir.x = moveHorizontal;
        //transform.position += moveDir * moveSpeed * Time.deltaTime;

        //assign Inputs again even though was done in the Start() method
        GameObject go = GameObject.FindGameObjectWithTag("InputReaderTag");
        if (go != null)
        {
            InputReaderGameObjectExists = true;
            Inputs = go.GetComponent<InputReader>();
            if (Inputs != null)
            {
                InputReaderComponentExists = true;
            }
        }

        Vector3 moveDir = new Vector3();
        float moveSpeed = 3f;
        float vertSpeed = 0;
        //if (InputReaderComponentExists)  //NOTE This returns true and vert speed is up if not commented out... but RightControllerFound returns false
        //    vertSpeed = 0.5f;
        if (Inputs.RightControllerFound)
        //if(false)
        {
            Vector2 joystick = Inputs.rightJoystick;
            moveDir = new Vector3(joystick.x, vertSpeed, joystick.y);
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

        ////////Vector3 moveDir = new Vector3();
        ////////float moveSpeed = 3f;
        ////////float vertSpeed = 0;
        ////////if (Inputs.RightControllerFound)
        //////////if(false)
        ////////{
        ////////    if (Inputs.ButtonXDown)
        ////////        moveDir.x = +1f;
        ////////    else if (Inputs.ButtonYDown)
        ////////        moveDir.x = -1f;
        ////////}
        ////////else
        ////////{
        ////////    //just make some motion to show it's alive
        ////////    moveSpeed = 1; //slower
        ////////    int cycle = DateTime.Now.Second;
        ////////    if (cycle % 4 == 0) //modulus
        ////////    {
        ////////        moveDir.x = +1f;
        ////////    }
        ////////    else if (cycle % 4 == 1)
        ////////    {
        ////////        moveDir.z = +1f;
        ////////    }
        ////////    else if (cycle % 4 == 2)
        ////////    {
        ////////        moveDir.x = -1f;
        ////////    }
        ////////    else
        ////////    {
        ////////        moveDir.z = -1f;
        ////////    }
        ////////}
        //////////Vector2 joystick = Inputs.rightJoystick;
        //////////moveDir = new Vector3(joystick.x, vertSpeed, joystick.y);
        ////////moveDir.y = vertSpeed;
        ////////transform.position += moveDir * moveSpeed * Time.deltaTime;

        //from here down works in Windows...
        //Vector3 moveDir = new Vector3(0, 0, 0);
        //if (Input.GetKey(KeyCode.W)) moveDir.z = +1f;
        //if (Input.GetKey(KeyCode.S)) moveDir.z = -1f;
        //if (Input.GetKey(KeyCode.A)) moveDir.x = -1f;
        //if (Input.GetKey(KeyCode.D)) moveDir.x = +1f;

        //float moveSpeed = 3f;
        //transform.position += moveDir * moveSpeed * Time.deltaTime;

        ////wve 8/30/23 this next code was taken from ball in box in hope it would led joystick work in oculus, but doesn't...

        //// The float variables, moveHorizontal and moveVertical, holds the value of the virtual axes, X and Z.

        //// It records input from the keyboard.
        //float moveHorizontal = Input.GetAxis("Horizontal");

        //float moveVertical = Input.GetAxis("Vertical");

        //// Vector3 variable, movement, holds 3D positions of the player ball in form of X, Y, and Z axes in the space.
        //Vector3 stickMovement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //// Adds force to the player ball to move around.
        ////rb.AddForce(stickMovement * speed * Time.deltaTime);

        //// add stick movement
        //transform.position += stickMovement * moveSpeed * Time.deltaTime;


    }
}
