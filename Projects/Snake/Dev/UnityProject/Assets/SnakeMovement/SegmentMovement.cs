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
        SetDirection(Direction.UP);
    }

    /**
     * Sets the Segment infront of this Segment
     */
    public void setSegmentInfront(SegmentMovement infront)
    {
        this.segmentInfront = infront;
    }

    /**
     * Sets the Segment behind this Segment
     */
    public void setSegmentBehind(SegmentMovement behind)
    {
        this.segmentBehind = behind;
    }

    /**
     * Gets the Segment infront of this Segment
     */
    public SegmentMovement getSegmentInfront()
    {
        return segmentInfront;
    }

    /**
     * Gets the Segment behind this Segment
     */
    public SegmentMovement getSegmentBehind()
    {
        return segmentBehind;
    }

    /**
     * Gets the Direction of the Segment, which way it is currently travelling
     */
    public Direction GetDirection()
    {
        return currentDirection;
    }

    /**
     * Sets the Direction of the Segment, which way it is should be travelling
     */
    public void SetDirection(Direction newDir)
    {
        currentDirection = newDir;
    }

    /**
     * Gets the Rigidbody2D of the Segment
     */
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

    /**
     * Sets the Rigidbody2D of the Segment
     */
    public void SetRigidbody(Rigidbody2D newRb)
    {
        rb = newRb;
    }

    /**
     * Gets the Position of the Transform of the Segment
     */
    public Vector2 GetPosition()
    {
        return transform.position;
    }

     /**
     * Gets the Rotation of the Transform of the Segment
     */
    public Quaternion GetRotation()
    {
        return transform.rotation;
    }

    public void MoveUpdate()
    {
        if (segmentInfront != null)
        {
            Move(getSegmentInfront().GetPosition());
            getSegmentInfront().MoveUpdate();
        } else
        {
            Move(currentDirection);
        }
    }

    private void Move(Direction nextDirection)
    {
        if (GetRigidbody() != null)
        {
            GetRigidbody().MovePosition(GetRigidbody().position + nextDirection.GetVector());
        }
        else
        {
            Debug.Log("No rigidbody (move) at: " + transform.position.ToString());
        }
        //Debug.Log("Moving: " + i + "| ");
    }

    private void Move(Vector2 position)
    {
        if (GetRigidbody() != null)
        {
            GetRigidbody().MovePosition(position);
        }
        else
        {
            Debug.Log("No rigidbody (move) at: " + transform.position.ToString());
        }
        //Debug.Log("Moving: " + i + "| ");
    }

    public void RotateUpdate()
    {
        Rotate();
        if (getSegmentBehind() != null)
        {
            getSegmentBehind().RotateUpdate();
        }
    }

    private void Rotate()
    {
        if (GetRigidbody() != null)
        {
            if (getSegmentInfront() != null) {
                GetRigidbody().MoveRotation(getSegmentInfront().GetRotation());
            } else
            {
                GetRigidbody().MoveRotation(currentDirection.GetAngle());
                Debug.Log("No infront: " + transform.name);
            }
        }
        else
        {
            Debug.Log("No rigidbody (rotate) at: " + transform.position.ToString());
        }
        //SetDirection(nextDirection);
    }

}
