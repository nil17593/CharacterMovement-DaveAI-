using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevAI.CharacterMovement
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform lookAt;
        [SerializeField] private float distance;

        #region private fields
        private float currentX = 0.0f;
        private float currentY = 0.0f;
        private const float YMin = -50.0f;
        private const float YMax = 50.0f;
        #endregion

        public float sensivity = 4.0f;

        void LateUpdate()
        {
            currentX += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
            currentY += Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

            currentY = Mathf.Clamp(currentY, YMin, YMax);

            Vector3 Direction = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            transform.position = lookAt.position + rotation * Direction;

            transform.LookAt(lookAt.position);
        }
    }
}