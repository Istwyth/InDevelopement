using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentMovement : MonoBehaviour
{

    private Direction currentDirection;
    private Rigidbody2D rb;

    private SegmentMovement segmentInfront;
    private SegmentMovement segmentBehind;

    private bool hasRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(rb == null)
        {
            hasRigidbody = false;
        } else
        {
            hasRigidbody = true;
        }
        currentDirection = Direction.UP;
    }

    public void setSegmentInfront(SegmentMovement infront)
    {
        this.segmentInfront = infront;
    }

    public void setSegmentBehind(SegmentMovement behind)
    {
        this.segmentBehind = behind;
    }

    public SegmentMovement getSegmentInfront()
    {
        return segmentInfront;
    }

    public SegmentMovement getSegmentBehind()
    {
        return segmentBehind;
    }

    public void Move(Direction nextDirection)
    {
        if (GetRigidbody() != null)
        {
            GetRigidbody().MovePosition(GetRigidbody().position + nextDirection.GetVector());
        } else
        {
            Debug.Log("No rigidbody (move) at: " + transform.position.ToString());
        }
        //Debug.Log("Moving: " + i + "| ");
    }

    public void Rotate(Direction nextDirection)
    {
        if (GetRigidbody() != null)
        {
            GetRigidbody().MoveRotation(nextDirection.GetAngle());
        }
        else
        {
            Debug.Log("No rigidbody (rotate) at: " + transform.position.ToString());
        }
        SetDirection(nextDirection);
    }

    public Direction GetDirection()
    {
        return currentDirection;
    }

    public void SetDirection(Direction newDir)
    {
        currentDirection = newDir;
    }

    public Rigidbody2D GetRigidbody()
    {
        if (hasRigidbody)
        {
            return rb;
        } else
        {
            return null;
        }
    }

    public void SetRigidbody(Rigidbody2D newRb)
    {
        rb = newRb;
    }

}
