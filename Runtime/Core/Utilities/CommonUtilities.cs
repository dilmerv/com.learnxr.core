using UnityEngine;

namespace LearnXR.Core.Utilities
{
    public class CommonUtilities : Singleton<CommonUtilities>
    {
        private Camera mainCamera;

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        public void PlaceObjectInFrontOfCamera(Transform targetObject, float cameraForwardOffset = 0.5f)
        {
            var mainCameraTransform = mainCamera.transform;
            Vector3 newPosition = mainCameraTransform.position + mainCameraTransform.forward * cameraForwardOffset;
            targetObject.position = newPosition;

            Vector3 directionToCamera = mainCameraTransform.position - targetObject.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);

            targetObject.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
            targetObject.rotation *= Quaternion.Euler(0, 180, 0);
        }
    }
}