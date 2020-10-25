using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //This script is for handling the input for moving a character around  
    //It translates the input into actions for any object that implements the IControllable interface
    //The character does not need to be a ball but for that is just what I chose for this example, hence the name BallController
   
    private IControllable character;

    IMovable moveable;
    IJumpable jumpable;

    private void Awake()
    {
        character = GetComponent<IControllable>();

        if (character != null)
        {
            if (character is IMovable)
            {
                moveable = character as IMovable;
            }
            if (character is IJumpable)
            {
                jumpable = character as IJumpable;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
            
        moveable?.MoveForward(Input.GetAxis("Vertical"));// if the character implements the Imovable interface it can move using the axes called Vertical and Horizontal
        moveable?.MoveRight(Input.GetAxis("Horizontal"));
        
        if (Input.GetButtonDown("Jump"))// if the character implements the Ijumpable interface, it can jump
        {
            jumpable?.Jump();
        }
    }

}


