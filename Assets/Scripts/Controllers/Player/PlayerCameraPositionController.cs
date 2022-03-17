using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraPositionController : MonoBehaviour
{
    public PlayerCharacterMovementController playerCharacterMovementController;
    public PlayerCharacterForwardController playerCharacterForwardController;

    void Update() {
        transform.position = playerCharacterMovementController.FixHeightPosition + (playerCharacterForwardController.Offset * 10.0f);
    }
}
