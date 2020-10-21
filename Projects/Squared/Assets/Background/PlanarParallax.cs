using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanarParallax : MonoBehaviour
{

    private float height;
    private float width;
    private Vector2 startPos;
    public GameObject camera;
    public float parallaxEffect;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float sectionTestX = (camera.transform.position.x * (1 - parallaxEffect));   //Test for if current pos is outside middle section above
        float sectionTestY = (camera.transform.position.y * (1 - parallaxEffect));   //Test for if current pos is outside middle section below
        float distX = (camera.transform.position.x * parallaxEffect);    //Distance to move in X
        float distY = (camera.transform.position.y * parallaxEffect);    //Distance to move in Y

        transform.position = new Vector3(startPos.x + distX, startPos.y + distY, transform.position.z);  //New position

        if (sectionTestX > startPos.x + width)        //If past the right boundary
        {
            startPos.x += width;                     //Move startPos one section to the right 
        }
        else if (sectionTestX < startPos.x - width)   //If past the right boundary
        {
            startPos.x -= width;                     //Move startPos one section to the left 
        }

        if (sectionTestY > startPos.y + height)        //If past the top boundary
        {
            startPos.y += height;                     //Move startPos one section up
        }
        else if (sectionTestY < startPos.y - height)   //If past the bottom boundary
        {
            startPos.y -= height;                     //Move startPos one section down 
        }
    }
}
