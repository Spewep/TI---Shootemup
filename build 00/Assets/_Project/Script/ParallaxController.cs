using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarColector
{
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField] Transform[] backgrounds; // Array of background layers
        [SerializeField] float smoothing = 10f; // How smooth the parallax effect is
        [SerializeField] float multiplier = 15f; // How much the parallax effect increments per layer

        Transform cam; //Reference to the main camera
        Vector3 previousCamPos; // Position of the camera in the previous frame

        void Awake()
        {
            cam = Camera.main.transform;
        }

        // Start is called before the first frame update
        void Start()
        {
            previousCamPos = cam.position;
        }

        // Update is called once per frame
        void Update()
        {
        // Interate thrugh each background layer
        for (var i = 0; i < backgrounds.Length; i++)
            {
                var parallax = (previousCamPos.y - cam.position.y) * (i * multiplier);
                var targetY = backgrounds[i].position.y + parallax;

                var targetPosition = new Vector3(backgrounds[i].position.x, y: targetY, backgrounds[i].position.z);

                backgrounds[i].position = Vector3.Lerp(a: backgrounds[i].position, b: targetPosition, t: smoothing * Time.deltaTime);
            }

            previousCamPos = cam.position;
        }
    }
}
