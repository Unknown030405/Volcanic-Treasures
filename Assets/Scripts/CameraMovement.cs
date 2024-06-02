using Unity.Mathematics;
using UnityEngine;

public class CameraMovement : MonoBehaviour 
{
    private Vector3 _velocity = Vector3.zero;
    private Transform _playerPosition;

    private void Start() 
    {
        _playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        var yPos = math.max(_playerPosition.position.y, Fields.CameraMovement.YOffset);
        var targetPosition = new Vector3(0, yPos, Fields.CameraMovement.ZOffset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, 
            ref _velocity, Fields.CameraMovement.SmoothTime);
    }
}