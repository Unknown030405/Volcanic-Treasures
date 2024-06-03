using Interfaces;
using Player_Scripts;
using UnityEngine;

public class Diamond : MonoBehaviour, ILootable
{
    private Player _player;
    private AudioSource _audioSource;

    private void Awake()
    {
        _player = GameObject.FindWithTag(Fields.Tags.PlayerTag).GetComponent<Player>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameObject.CompareTag(Fields.Tags.Chest) && other.CompareTag(Fields.Tags.PlayerTag))
        {
            _audioSource.Play();
            _player.AddDiamonds(Fields.DiamondsAmount);
            Invoke(nameof(LetsDestroy), 1f);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            
            Debug.Log("Diamond claimed");
        }
    }
    
    private void LetsDestroy() => Destroy(gameObject);

    public void GivePlayer()
    {
        _player.AddDiamonds(Fields.DiamondsAmount);
        Debug.Log("Diamond from chest claimed");
    }
}
