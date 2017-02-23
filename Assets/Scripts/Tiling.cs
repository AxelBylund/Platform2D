using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]


public class Tiling : MonoBehaviour {

    public int offsetX = 2;                 // offset so we don't get any weirds errors

    // these are used for checking if we need to instantiate stuff
    public bool hasARightBuddy = false;
    public bool hasALeftBuddy = false;

    public bool reverseScale = false;       // used iof the object is not tilable

    private float spriteWidth = 0f;         // the width of our element
    private Camera cam;
    private Transform myTransform;

    void Awake ()
    {
        cam = Camera.main;
        myTransform = transform;
    }

    // Use this for initialization
    void Start () {
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
        // does it still need buddies? if not do nothing
        if (hasALeftBuddy == false || hasARightBuddy == false)
        {
            // calculate the cameras extend (half the width) of twhat the camera can see in world coordinates
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

            // calculate the x position where the camera can see the edge of the sprite (element)
            float edgeVisiblePoisitionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
            float edgeVisiblePoisitionLeft = (myTransform.position.x - spriteWidth / 2) - camHorizontalExtend;

            if (cam.transform.position.x >= edgeVisiblePoisitionRight - offsetX && hasARightBuddy == false)
            {

            }
            else if (cam.transform.position.x <= edgeVisiblePoisitionLeft + offsetX && hasALeftBuddy == false)
            {

            }
        }
	}

    void MakeNewBuddy (int rightOrLeft)
    {

    }
}
