using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CarColector
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputReader : MonoBehaviour
    {
        // NOTE: Make sure to set the Player Input component to C# events 
        PlayerInput playerInput;
        InputAction moveAction;

        public Vector2 Move => moveAction.ReadValue<Vector2>();

        void Start()
        {
            playerInput = GetComponent<PlayerInput>();
            moveAction = playerInput.actions["Move"];
        }

        void Update()
        {
        
        }
    }
}
