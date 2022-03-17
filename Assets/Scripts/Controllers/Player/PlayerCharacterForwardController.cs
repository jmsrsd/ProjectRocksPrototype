using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterForwardController : MonoBehaviour
{
    public Camera playerCamera;

    public Vector3 Offset
    {
        get
        {
            var viewportPoint = playerCamera.ScreenToViewportPoint(Input.mousePosition);
            viewportPoint.x -= 0.5f;
            viewportPoint.y -= 0.5f;

            return new Vector3(viewportPoint.x, 0, viewportPoint.y);
        }
    }

    public Vector3 Forward
    {
        get
        {
            return Offset.normalized;
        }
    }

    void Update()
    {
        transform.forward = Forward;
    }
}
