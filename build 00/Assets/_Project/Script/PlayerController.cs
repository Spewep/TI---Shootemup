using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarColector
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed = 5f;
        [SerializeField] float smoothness = 0.1f;
        [SerializeField] float leanAngle = 15f;
        [SerializeField] float leanSpeed = 5f;

        //Rotation??
        [Header("Camera Bounds")]
        [SerializeField] Transform cameraFollow;
        [SerializeField] float minX = -8f;
        [SerializeField] float maxX = 8f;
        [SerializeField] float minY = -4f;
        [SerializeField] float maxY = 4f;

        InputReader input;

        Vector3 currentVelocity;
        Vector3 targetPosition;

        // Start is called before the first frame update
        void Start()
        {
        input = GetComponent<InputReader>();
        }

        // Update is called once per frame
        void Update()
        {
            targetPosition += new Vector3(input.Move.x, input.Move.y, z: 0f) * (speed * Time.deltaTime);

            // Calculate the min and max X and Y positions for the player based on the camera view
            var minPlayerX = cameraFollow.position.x + minX;
            var maxPlayerX = cameraFollow.position.x + maxX;
            var minPlayerY = cameraFollow.position.y + minY;
            var maxPlayerY = cameraFollow.position.y + maxY;

            //Clamp the player's position to the camera view
            targetPosition.x = Mathf.Clamp(value: targetPosition.x, minPlayerX, maxPlayerX);
            targetPosition.y = Mathf.Clamp(value: targetPosition.y, minPlayerY, maxPlayerY);

            
            //Lerp the Player's position to the target position
            transform.position = Vector3.SmoothDamp(current: transform.position, targetPosition, ref currentVelocity, smoothness);

            //Calculate the rotation effect
            var targetRotationAngle = -input.Move.x * leanAngle;

            var currentYRotation = transform.localEulerAngles.y;
            var newYRotation = Mathf.LerpAngle(a: currentYRotation, b: targetRotationAngle, t: leanSpeed * Time.deltaTime);

            //Apply the rotation effect
            transform.localEulerAngles = new Vector3(x: 0f, newYRotation, z:0f);
        }
    }
}