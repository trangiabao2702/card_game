using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float smoothSpeed = 1.0f; // Tốc độ di chuyển mượt của camera
    public float delayTime = 3f;
    private bool cameraFollowX = false;
    private bool cameraFollowY = false;
    // Start is called before the first frame update


    public Transform target;
    void Start()
    {
        Invoke("StartCameraFollow", delayTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position.x < 0 || target.transform.position.x > 55)
        {
            cameraFollowX = false;
        } else
        {
            cameraFollowX = true; 
        }

        if (target.transform.position.y > 4.5 || target.transform.position.y < -3)
        {
            cameraFollowY = false;
        }
        else
        {
            cameraFollowY = true;
        }

    }

    //private void FixedUpdate()
    //{
    //    transform.LookAt(target);
    //}
    void LateUpdate()
    {
        if ((cameraFollowX || cameraFollowY) && target != null)
        {
            // Tính toán vị trí mới của camera dựa trên vị trí của đối tượng nhân vật
            Vector3 desiredPosition = new Vector3(cameraFollowX ? target.position.x : transform.position.x, cameraFollowY ? target.position.y : transform.position.y, transform.position.z);
            // Sử dụng SmoothDamp để làm cho di chuyển của camera mượt mà
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
    void StartCameraFollow()
    {
        cameraFollowX = true;
        cameraFollowY = true;
    }
}
