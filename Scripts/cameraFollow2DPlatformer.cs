using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow2DPlatformer : MonoBehaviour
{
    public Transform target; // what camera is following
    public float smoothing; // dampening effect

    Vector3 offset;
    float lowY;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("ayo0000000000000");
        offset = transform.position - target.position;
        lowY = transform.position.y;
        //Debug.Log(lowY);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        //Debug.Log("bisa");
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

        if (transform.position.y < lowY) {
            //Debug.Log(lowY);
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z); 
        }
        
    }
}
