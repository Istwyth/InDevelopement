using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeControl : MonoBehaviour
{
    [SerializeField] private GameObject bodySegment;
    [SerializeField] private GameObject headSegment;
    [SerializeField] private GameObject tailSegment;


    [SerializeField] private Sprite straight;
    [SerializeField] private Sprite corner;
    //[SerializeField] private G tailSegment;

    private List<GameObject> BodySegments = new List<GameObject>();
    private SegmentMovement tailMovement;
    private SegmentMovement headMovement;

    [SerializeField] private int beginSize;

    private Direction currentDirection;

    private SegmentMovement penultimateSegment;

    // Start is called before the first frame update
    void Start()
    {
        AddHeadSegment();
        AddTailSegment();
        for (int i = 1; i < beginSize - 1; i++)
        {
            //Debug.Log("Drawing Body Segment: " + i + ":" + beginSize);
            AddBodySegment(Vector3.down);
        }

        foreach (GameObject gameObject in BodySegments)
        {
            if (gameObject.GetComponent<SegmentMovement>() == null)
            {
                gameObject.AddComponent<SegmentMovement>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentDirection = GetInputDirection();
    }

    public void setUpSnake()
    {

    }

    public void MoveSnake()
    {
        headMovement.SetDirection(currentDirection);
        //tailMovement.Rotate(tailMovement.getSegmentInfront().GetDirection());
        tailMovement.MoveUpdate();
        headMovement.RotateUpdate();
    }

    private Direction GetInputDirection()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (currentDirection.GetOpposite() == Direction.UP)
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

    public void AddBodySegment(Vector3 spawnDisplacement)
    {
        GameObject growingSegment = BodySegments[BodySegments.Count - 1];
        if (growingSegment.GetComponent<SpriteRenderer>().sprite.name.Equals("SlipperyC"))
        {
            if (growingSegment.GetComponent<SpriteRenderer>().flipX == true)
            {
                spawnDisplacement = Quaternion.AngleAxis(90, Vector3.forward) * spawnDisplacement;
            }
            else
            {
                spawnDisplacement = Quaternion.AngleAxis(-90, Vector3.forward) * spawnDisplacement;
            }
        }

        Vector3 spawnPosition = growingSegment.transform.position + spawnDisplacement;
        GameObject newSegment = Instantiate(bodySegment, spawnPosition, growingSegment.transform.rotation);

        SegmentMovement segmentMovement = newSegment.GetComponent<SegmentMovement>();
        segmentMovement.setSegmentInfront(penultimateSegment);
        penultimateSegment.setSegmentBehind(segmentMovement);
        if(penultimateSegment == headMovement)
        {
            headMovement.setSegmentBehind(segmentMovement);
        }
        segmentMovement.setSegmentBehind(tailMovement);
        tailMovement.setSegmentInfront(segmentMovement);
        penultimateSegment = segmentMovement;

        //newSegment.SetParent(transform);

        newSegment.transform.SetParent(transform);
        BodySegments.Add(newSegment);
        tailMovement.transform.Translate(spawnDisplacement);
        //Debug.Log("Body Segment Added: " + BodySegments.Count);
    }

    private void AddHeadSegment()
    {
        Vector3 spawnPosition = transform.position;
        GameObject newSegment = Instantiate(headSegment, spawnPosition, transform.rotation);

        SegmentMovement segmentMovement = newSegment.GetComponent<SegmentMovement>();
        segmentMovement.setSegmentInfront(null);
        penultimateSegment = segmentMovement;
        headMovement = segmentMovement;

        newSegment.transform.SetParent(transform);
        BodySegments.Add(newSegment);
        //Debug.Log("Head Segment Added: " + BodySegments.Count);
    }

    private void AddTailSegment()
    {
        Vector3 spawnPosition = BodySegments[BodySegments.Count - 1].transform.position + Vector3.down;
        GameObject newSegment = Instantiate(tailSegment, spawnPosition, BodySegments[BodySegments.Count - 1].transform.rotation) ;

        SegmentMovement segmentMovement = newSegment.GetComponent<SegmentMovement>();
        segmentMovement.setSegmentBehind(null);
        segmentMovement.setSegmentInfront(penultimateSegment);

        tailMovement = segmentMovement;
        newSegment.transform.SetParent(transform);
        //Debug.Log("Tail Segment Added: " + BodySegments.Count);
    }
}
