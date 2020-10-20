using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalParallax : MonoBehaviour
{

    private float length;
    private float width;
    private float startPos;
    public GameObject camera;
    public float parallaxEffect;

    public bool isRight = false;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float sectionTest = (camera.transform.position.y * (1 - parallaxEffect));   //Test for if current pos is outside middle section
        float dist = (camera.transform.position.y * parallaxEffect);    //Distance to move

        float xPos = 0;

        if (isRight)
        {
            xPos = camera.GetComponent<Camera>().ViewportToWorldPoint(new Vector2(1,0)).x - (width/2);
        }
        else
        {
            xPos = camera.GetComponent<Camera>().ViewportToWorldPoint(new Vector2(0, 0)).x + (width/2);
        }

        transform.position = new Vector3(xPos, startPos + dist, transform.position.z);  //New position


        

        if (sectionTest > startPos + length)        //If past the right boundary
        {
            startPos += length;                     //Move startPos one section to the right 
        }
        else if (sectionTest < startPos - length)   //If past the right boundary
        {
            startPos -= length;                     //Move startPos one section to the left 
        }
    }
}
