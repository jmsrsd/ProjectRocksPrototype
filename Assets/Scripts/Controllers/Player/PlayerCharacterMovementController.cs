using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterMovementController : MonoBehaviour
{
    public CharacterController characterController;

    public Vector3 Direction
    {
        get => new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical")).normalized;
    }

    public Vector3 FixHeightPosition
    {
        get
        {
            var position = transform.position;
            position.y = 0.0f;
            return position;
        }
    }

    void Update()
    {
        characterController.Move(Direction * Time.deltaTime * 10.0f);
        transform.position = FixHeightPosition;
    }
}
