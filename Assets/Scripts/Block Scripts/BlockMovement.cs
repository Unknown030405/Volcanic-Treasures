using UnityEngine;

namespace Block_Scripts
{
    public class BlockMovement : MonoBehaviour
    {
        private Transform _transform;

        private void Awake() => _transform = gameObject.GetComponent<Transform>();

        // Update is called once per frame  
        private void Update()
        {
            // Получить текущую скорость лавы
            var blockSpeed = Fields.Generation.BlockBaseSpeed + Time.timeSinceLevelLoad * 
                Fields.Generation.BlockSpeedIncrease;

            // Установить текущую позицию блока
            var position = _transform.position;
            position = new Vector3(position.x, position.y - blockSpeed * Time.deltaTime, position.z);
            _transform.position = position;
            
            if (_transform.position.y < Fields.Generation.LavaPosition)
                Destroy(gameObject);
        }
    }
}
