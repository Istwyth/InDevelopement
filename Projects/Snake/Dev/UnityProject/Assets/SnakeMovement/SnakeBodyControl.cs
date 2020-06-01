using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyControl : MonoBehaviour
{
    [SerializeField] private GameObject bodySegment;
    [SerializeField] private GameObject headSegment;
    [SerializeField] private GameObject tailSegment;


    [SerializeField] private Sprite straight;
    [SerializeField] private Sprite corner;
    //[SerializeField] private G tailSegment;

    private List<GameObject> BodySegments = new List<GameObject>();
    private GameObject tailObject;

    [SerializeField] private int beginSize;

    private GameObject CurBodySegment;
    private GameObject PrevBodySegment;

    private Direction currentDirection;


    // Start is called before the first frame update
    void Start()
    {
        AddHeadSegment();
        AddTailSegment();
        for (int i = 1; i < beginSize-1; i++)
        {
            Debug.Log("Drawing Body Segment: " + i + ":"+ beginSize);
            AddBodySegment(Vector3.down);
        } 

        foreach(GameObject gameObject in BodySegments)
        {
            if(gameObject.GetComponent<SegmentMovement>() == null)
            {
                gameObject.AddComponent<SegmentMovement>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AddBodySegment(BodySegments[BodySegments.Count-1].GetComponent<SegmentMovement>().GetDirection().GetOpposite().GetVector());
        }
        SetDirection(GetInputDirection());
    }

    public Direction GetDirection()
    {
        return currentDirection;
    }

    public void SetDirection(Direction newDir)
    {
        currentDirection = newDir;
    }

    public Rigidbody2D GetRigidbody(int index)
    {
        return BodySegments[index].GetComponent<Rigidbody2D>();
    }

    private Direction GetInputDirection()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(currentDirection.GetOpposite() == Direction.UP)
            {
                return currentDirection;
            }
            return Direction.UP;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (currentDirection.GetOpposite() == Direction.DOWN)
            {
                return currentDirection;
            }
            return Direction.DOWN;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (currentDirection.GetOpposite() == Direction.LEFT)
            {
                return currentDirection;
            }
            return Direction.LEFT;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (currentDirection.GetOpposite() == Direction.RIGHT)
            {
                return currentDirection;
            }
            return Direction.RIGHT;
        }
        return currentDirection;
    }

    public void Move()
    {
        //float currentSpeed = linearSpeed;
        Queue<Direction> newDirections = new Queue<Direction>();
        for (int i = BodySegments.Count - 1; i > 0; i--)
        {
            Direction PrevDirection = Direction.UP;
            if (i == 0)
            {
                PrevDirection = currentDirection;
            }
            else
            {
                PrevDirection = BodySegments[i - 1].GetComponent<SegmentMovement>().GetDirection();
            }
            CurBodySegment = BodySegments[i];

            if (i != BodySegments.Count - 1) {
                newDirections.Enqueue(CurBodySegment.GetComponent<SegmentMovement>().GetDirection());
            }
            CurBodySegment.GetComponent<SegmentMovement>().Move(PrevDirection);
            


            /*CurBodySegment = BodySegments[i];
            PrevBodySegment = BodySegments[i - 1];

            dis = Vector2.Distance(PrevBodySegment.transform.position, CurBodySegment.transform.position);

            /*Vector2 newPos = PrevBodySegment.position;

            float T = Time.deltaTime * dis / minDistance * currentSpeed;

            if (T > 0.5f)
            {
                T = 0.5f;
            }

            CurBodySegment.position = Vector3.Slerp(CurBodySegment.position, newPos, T);*/

            /*float angleBetween = Vector2.SignedAngle(PrevBodySegment.transform.position, Vector3.forward);
            Direction newDirection = DirectionsExtension.getDirection(angleBetween);
            GetRigidbody(i).MovePosition(GetRigidbody(i).position + newDirection.getNormalisedDirection());
            GetRigidbody(i).MoveRotation(newDirection.getAngle());
            Debug.Log("Moving: " + i + "| ");*/
        }
        newDirections.Enqueue(BodySegments[0].GetComponent<SegmentMovement>().GetDirection());
        BodySegments[0].GetComponent<SegmentMovement>().Move(currentDirection);
        BodySegments[0].GetComponent<SegmentMovement>().Rotate(currentDirection);
        Direction tailMoveDirection = BodySegments[BodySegments.Count - 1].GetComponent<SegmentMovement>().GetDirection();
        Direction tailRotateDirection = BodySegments[BodySegments.Count - 2].GetComponent<SegmentMovement>().GetDirection();
        tailObject.GetComponent<SegmentMovement>().Move(tailMoveDirection);
        tailObject.GetComponent<SegmentMovement>().Rotate(tailRotateDirection);

        /*GetRigidbody(0).MovePosition(GetRigidbody(0).position + currentDirection.getNormalisedDirection());
        GetRigidbody(0).MoveRotation(GetDirection().getAngle());*/
        for (int i = BodySegments.Count - 1; i > 0; i--)
        {
            BodySegments[i].GetComponent<SegmentMovement>().Rotate(newDirections.Dequeue());
        }
        //tailSegment.GetComponent<SegmentMovement>().Rotate(newDirections.Dequeue());

        List<Direction> directions = getDirectionsFromBodySegments();
        for (int i = 1; i <= BodySegments.Count - 1; i++)
        {
            Direction CurrDirection = directions[i];
            Direction NextDirection = directions[i - 1];

            Orientation properOrientation = CurrDirection.GetCornerWith(NextDirection);

            switch (properOrientation)
            {
                case Orientation.UP_LEFT:
                    BodySegments[i].GetComponent<SpriteRenderer>().sprite = corner;
                    BodySegments[i].GetComponent<SpriteRenderer>().flipX = true;
                    Debug.Log("UP LEFT");
                    break;
                case Orientation.UP_RIGHT:
                    BodySegments[i].GetComponent<SpriteRenderer>().sprite = corner;
                    BodySegments[i].GetComponent<SpriteRenderer>().flipX = false;
                    Debug.Log("UP RIGHT");
                    break;
                case Orientation.DOWN_LEFT:
                    BodySegments[i].GetComponent<SpriteRenderer>().sprite = corner;
                    BodySegments[i].GetComponent<SpriteRenderer>().flipX = false;
                    Debug.Log("DOWN LEFT");
                    break;
                case Orientation.DOWN_RIGHT:
                    BodySegments[i].GetComponent<SpriteRenderer>().sprite = corner;
                    BodySegments[i].GetComponent<SpriteRenderer>().flipX = true;
                    Debug.Log("DOWN RIGHT");
                    break;
                case Orientation.LEFT_UP:
                    BodySegments[i].GetComponent<SpriteRenderer>().sprite = corner;
                    BodySegments[i].GetComponent<SpriteRenderer>().flipX = false;
                    Debug.Log("LEFT UP");
                    break;
                case Orientation.RIGHT_UP:
                    BodySegments[i].GetComponent<SpriteRenderer>().sprite = corner;
                    BodySegments[i].GetComponent<SpriteRenderer>().flipX = true;
                    Debug.Log("RIGHT UP");
                    break;
                case Orientation.LEFT_DOWN:
                    BodySegments[i].GetComponent<SpriteRenderer>().sprite = corner;
                    BodySegments[i].GetComponent<SpriteRenderer>().flipX = true;
                    Debug.Log("LEFT DOWN");
                    break;
                case Orientation.RIGHT_DOWN:
                    BodySegments[i].GetComponent<SpriteRenderer>().sprite = corner;
                    BodySegments[i].GetComponent<SpriteRenderer>().flipX = false;
                    Debug.Log("RIGHT DOWN");
                    break;
                default:
                    BodySegments[i].GetComponent<SpriteRenderer>().sprite = straight;
                    break;
            }
        }

    }

    private List<Direction> getDirectionsFromBodySegments()
    {
        List<Direction> directions = new List<Direction>();
        foreach(GameObject gameObject in BodySegments)
        {
            if(gameObject.GetComponent<SegmentMovement>() != null)
            {
                directions.Add(gameObject.GetComponent<SegmentMovement>().GetDirection());
            }
        }
        return directions;
    }

    public void AddBodySegment(Vector3 spawnDisplacement)
    {
        GameObject growingSegment = BodySegments[BodySegments.Count - 1];
        if (growingSegment.GetComponent<SpriteRenderer>().sprite.name.Equals("SlipperyC")) {
            if (growingSegment.GetComponent<SpriteRenderer>().flipX == true)
            {
                spawnDisplacement = Quaternion.AngleAxis(90, Vector3.forward) * spawnDisplacement;
            } else
            {
                spawnDisplacement = Quaternion.AngleAxis(-90, Vector3.forward) * spawnDisplacement;
            }
        }

        Vector3 spawnPosition = growingSegment.transform.position + spawnDisplacement;
        GameObject newSegment = Instantiate(bodySegment, spawnPosition, growingSegment.transform.rotation);

        //newSegment.SetParent(transform);

        BodySegments.Add(newSegment);
        tailObject.transform.Translate(spawnDisplacement);
        Debug.Log("Body Segment Added: " + BodySegments.Count);
    }

    private void AddHeadSegment()
    {
        Vector3 spawnPosition = transform.position;
        GameObject newSegment = Instantiate(headSegment, spawnPosition, transform.rotation);

        BodySegments.Add(newSegment);
        Debug.Log("Head Segment Added: " + BodySegments.Count);
    }

    private void AddTailSegment()
    {
        Vector3 spawnPosition = BodySegments[BodySegments.Count - 1].transform.position + Vector3.down;
        GameObject newSegment = Instantiate(tailSegment, spawnPosition, BodySegments[BodySegments.Count - 1].transform.rotation);

        tailObject = newSegment;
        Debug.Log("Tail Segment Added: " + BodySegments.Count);
    }
}
