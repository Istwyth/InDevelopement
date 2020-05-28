using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTailControl : SnakeMovement
{

    private SnakeMovement pieceToFollow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPieceToFollow(SnakeMovement toFollow)
    {
        pieceToFollow = toFollow;
    }

    public override void moveUpdate()
    {
        //base.moveUpdate();
        //updateDirection();
    }

    private void updateDirection()
    {
        if (pieceToFollow != null)
        {
            SetDirection(pieceToFollow.GetDirection());
        }
    }
}
