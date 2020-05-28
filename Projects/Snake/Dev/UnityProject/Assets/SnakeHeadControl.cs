using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHeadControl : SnakeMovement
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            SetDirection(Direction.UP);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            SetDirection(Direction.DOWN);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SetDirection(Direction.LEFT);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SetDirection(Direction.RIGHT);
        }
    }

    public override void moveUpdate()
    {
        base.moveUpdate();
        Debug.Log("--" + GetDirection().ToString());
        rotateHead();
    }

    private void rotateHead()
    {
        if (GetRigidbody() == null)
        {
            transform.rotation = Quaternion.AngleAxis(GetDirection().GetAngle(), Vector3.forward);
            //transform.Rotate(new Vector3(0, 0, ));
        }
        else
        {
            GetRigidbody().MoveRotation(GetDirection().GetAngle());
            Debug.Log("Rotating head with RigidBody2d");
        }

    }
}
