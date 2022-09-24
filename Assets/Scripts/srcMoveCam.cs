using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class srcMoveCam : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;

    public float speedRotation = 0f;
    public float speedZoom = 0f;
   
    public GameObject moon, camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotate();
        zoom();
    }

    private void rotate(){
        if(Input.GetKey("w")){
             transform.Rotate(Time.deltaTime * speedRotation, 0, 0, Space.Self);
        }
        if(Input.GetKey("s")){
             transform.Rotate(-Time.deltaTime * speedRotation, 0, 0, Space.Self);
        }
        if(Input.GetKey("a")){
             transform.Rotate(0, -Time.deltaTime * speedRotation,  0, Space.Self);
        }
        if(Input.GetKey("d")){
             transform.Rotate(0, Time.deltaTime * speedRotation,  0, Space.Self);
        }
    }

    private void zoom(){
        if(Input.GetAxis("Mouse ScrollWheel") > 0 && camera.transform.position.z < -30)
            camera.transform.position += new Vector3(0.00f, 0.00f, Input.GetAxis("Mouse ScrollWheel") * speedZoom * Time.deltaTime);

        if(Input.GetAxis("Mouse ScrollWheel") < 0 && camera.transform.position.z > -80)
            camera.transform.position += new Vector3(0.00f, 0.00f, Input.GetAxis("Mouse ScrollWheel") * speedZoom * Time.deltaTime);
    }
}

