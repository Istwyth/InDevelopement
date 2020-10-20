using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour { 

    private float length;
    private float startPos;
    public GameObject camera;
    public float parallaxEffect;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float sectionTest = (camera.transform.position.x * (1 - parallaxEffect));   //Test for if current pos is outside middle section
        float dist = (camera.transform.position.x * parallaxEffect);    //Distance to move

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);  //New position

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
