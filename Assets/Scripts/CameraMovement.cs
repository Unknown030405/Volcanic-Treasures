using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraMovement : MonoBehaviour 
{
    private Vector3 vellocity = Vector3.zero;
    private Transform _playerPosition;

    private void Start() {
        _playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update() {
        var targetPosition = new Vector3(0, math.max(_playerPosition.position.y, Fields.CameraMovement.yOffset), Fields.CameraMovement.zOffset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vellocity, Fields.CameraMovement.smoothTime);
    }
}