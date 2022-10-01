using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class srcMoveCam : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;

    public float speedRotation = 0f;
    public float speedZoom = 0f;
   
    public GameObject globalCamera, camera;

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
             globalCamera.transform.Rotate(Time.deltaTime * speedRotation, 0, 0, Space.Self);
        }
        if(Input.GetKey("s")){
             globalCamera.transform.Rotate(-Time.deltaTime * speedRotation, 0, 0, Space.Self);
        }
        if(Input.GetKey("a")){
             globalCamera.transform.Rotate(0, Time.deltaTime * speedRotation,  0, Space.Self);
        }
        if(Input.GetKey("d")){
             globalCamera.transform.Rotate(0, -Time.deltaTime * speedRotation,  0, Space.Self);
        }
        if(Input.GetKey("q")){
             globalCamera.transform.Rotate(0, 0,  Time.deltaTime * speedRotation, Space.Self);
        }
        if(Input.GetKey("e")){
             globalCamera.transform.Rotate(0, 0,  -Time.deltaTime * speedRotation, Space.Self);
        }
    }

    private void zoom(){
        if(Input.GetAxis("Mouse ScrollWheel") > 0 && camera.transform.localPosition.z < -30)
            camera.transform.localPosition += new Vector3(0.00f, 0.00f, Input.GetAxis("Mouse ScrollWheel") * speedZoom * Time.deltaTime);

        if(Input.GetAxis("Mouse ScrollWheel") < 0 && camera.transform.localPosition.z > -80)
            camera.transform.localPosition += new Vector3(0.00f, 0.00f, Input.GetAxis("Mouse ScrollWheel") * speedZoom * Time.deltaTime);
    }
}

