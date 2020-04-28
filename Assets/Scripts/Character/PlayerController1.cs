using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{

    public float runSpeed, jumpValue;
    public LayerMask groundLayers;
    public Transform groundCheck;
    public float groundCheckRadius;


    private float middleOfScreen;
    private Rigidbody2D myRigid;
    private bool isOnGround;


    // Start is called before the first frame update
    void Start()
    {
        middleOfScreen = Screen.width / 2;
        myRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if player on ground
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers);

        //move player
        myRigid.velocity = new Vector2(runSpeed, myRigid.velocity.y);

        //check touch position and jump
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    if (touch.position.x < middleOfScreen)
                    {
                        if (isOnGround)
                        {
                            myRigid.velocity = new Vector2(myRigid.velocity.x, jumpValue);
                        }
                    }
                }
            }
        }

        //jump for test
        if (Input.GetKeyDown(KeyCode.X) == true)
        {
            if (isOnGround)
            {
                myRigid.velocity = new Vector2(myRigid.velocity.x, jumpValue);
            }

        }
    }
}
