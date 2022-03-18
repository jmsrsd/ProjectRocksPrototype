using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraPositionController : MonoBehaviour
{
    
    public PlayerCharacterMovementController playerCharacterMovementController;
    public PlayerCharacterForwardController playerCharacterForwardController;
    public float shakeTimer = 0.0f;

    void Update() {
        transform.position = playerCharacterMovementController.FixHeightPosition + (playerCharacterForwardController.Offset * 10.0f);

        if (shakeTimer > Time.time) {
            transform.position += new Vector3(Random.value - 0.5f, Random.value - 0.5f, Random.value - 0.5f) * 0.2f;
        }
    }
}
