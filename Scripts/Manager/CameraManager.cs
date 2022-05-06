using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    /* ------------------------------------------ */

    public static CameraManager instance
    {
        get
        {
            if (!_instance)
                _instance = FindObjectOfType<CameraManager>();

            return _instance;
        }
    }
    static CameraManager _instance;

    /* ------------------------------------------ */

    public Transform Target;

    public float SmoothSpeed = 0f;

    public Vector3 Offset;

    /* ------------------------------------------ */

    Camera _camera;

    /* ------------------------------------------ */

    private void Awake()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        CameraZoom();
        CameraFollow();
    }

    /* ------------------------------------------ */

    void CameraZoom()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Offset += new Vector3(0, -0.3f, 0);
            Offset.y = Mathf.Clamp(Offset.y, 5, 40);

        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Offset += new Vector3(0, 0.3f, 0);
            Offset.y = Mathf.Clamp(Offset.y, 5, 40);
        }
        Offset.z = 0;
    }

    void CameraFollow()
    {
        Vector3 desiredPosition = Target.position + Offset;


        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);


        transform.position = smoothedPosition;

        transform.LookAt(Target);
    }
}
    /* ------------------------------------------ */
    