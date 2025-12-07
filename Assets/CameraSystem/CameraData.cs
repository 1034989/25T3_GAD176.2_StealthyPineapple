using UnityEngine;

[CreateAssetMenu(fileName = "CameraData", menuName = "CameraData")]

public class CameraData : ScriptableObject
{
    public float cameraDetectionRange; //how far is the range
    public float turningCameraSpeed;
    public float minimumCameraAngle;
    public float maxCameraAngle;
}
