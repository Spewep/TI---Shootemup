using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarColector
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] float speed = 2f;

        // Start is called before the first frame update
        void Start()
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }

        // Update is called once per frame
        void LateUpdate()
        {
            // Move the camera along the battlefield at a constant speed
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }
}
