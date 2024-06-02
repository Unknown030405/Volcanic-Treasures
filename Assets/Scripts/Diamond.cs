using Interfaces;
using Player_Scripts;
using UnityEngine;

public class Diamond : MonoBehaviour, ILootable
{
    private Player _player;
    
    private void Awake() => _player = GameObject.FindWithTag(Fields.Tags.PlayerTag).GetComponent<Player>();

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameObject.CompareTag(Fields.Tags.Chest) && other.CompareTag(Fields.Tags.PlayerTag))
        {
            _player.AddDiamonds(Fields.DiamondsAmount);
            Destroy(gameObject);
            Debug.Log("Diamond claimed");
        }
    }

    public void GivePlayer()
    {
        _player.AddDiamonds(Fields.DiamondsAmount);
        Debug.Log("Diamond from chest claimed");
    }
}
