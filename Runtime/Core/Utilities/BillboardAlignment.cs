using UnityEngine;

namespace LearnXR.Core.Utilities
{
    public class BillboardAlignment : MonoBehaviour
    {
        private Transform cameraTransform;
        private bool startedTracking;

        public void Setup(Transform targetTransform)
        {
            cameraTransform = targetTransform;
            startedTracking = true;
        }

        void Update()
        {
            if (!startedTracking) return;

            Vector3 directionToCamera = cameraTransform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(directionToCamera);
            transform.rotation *= Quaternion.Euler(new Vector3(0, 180, 0));
        }
    }
}