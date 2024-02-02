using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //perspective cameras
        //this.transform.LookAt(Camera.main.transform);
        transform.rotation = Camera.main.transform.rotation;
        transform.Rotate(0, 180, 0, Space.Self);
    }
}
