using UnityEngine;

namespace Block_Scripts
{
    public abstract class Generation : MonoBehaviour
    {
        protected static void CreateBlock(GameObject randomBlock, Vector3 pos)
        {
            var block = Instantiate(randomBlock, pos, Quaternion.identity);
            var movement = block.AddComponent<BlockMovement>();
            
            movement.BlockBaseSpeed = Fields.Generation.BlockBaseSpeed;
            movement.BlockSpeedInc = Fields.Generation.BlockSpeedIncrease;
            movement.LavaPosition = Fields.Generation.LavaPosition;
        }
    }
    
    public class BlockGeneration : Generation
    {
        private GameObject[] _blocks;
        private bool _hasSpawned;
        
        private void Awake() => _blocks = Resources.LoadAll<GameObject>(Fields.Paths.Blocks);

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Fields.Tags.PlayerTag) && !_hasSpawned)
            {
                _hasSpawned = true;
                
                var yPos = GetComponentsInParent<Transform>();
                var pos = new Vector3(0,
                    yPos[Fields.Generation.TransformPos].position.y
                    + Fields.Generation.BlocksNumberOffset * Fields.Generation.BlockSize, 0);

                CreateBlock(_blocks[Random.Range(0, _blocks.Length)], pos);
            }
        }
    }
}
