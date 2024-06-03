using System;
using Player_Scripts;
using Unity.VisualScripting;
using UnityEngine;

// Данный скрипт весит на "Ключах" и позволяет открывать сундуки и двери с помощью них
public class Key : MonoBehaviour
{
    public Rigidbody2D Rigidbody { get; private set; }
    
    private bool _active;
    private Player _player;
    
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        _player = GameObject.FindWithTag(Fields.Tags.PlayerTag).GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q) && _active)
        {
            var direction = transform.position - _player.transform.position;
            _active = false;
            _player.Key = null;
            // Rigidbody.AddForce(new Vector2(direction.x, direction.y).normalized);
            Rigidbody.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        // Проверяет подобрал ли игрок ключ, а затем заставляет ключ двигаться за игроком
        if (_active)
        {
            var direction = _player.transform.position - transform.position + Vector3.up;
            if (direction.magnitude >= Fields.Key.Epsilon)
                Rigidbody.velocity = new Vector2(direction.x, direction.y) * Fields.Key.Speed;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Если контактирующий объект игрок
        if (other.CompareTag(Fields.Tags.PlayerTag) && !_player.Key)
        {
            _player.Key = this;
            _active = true;
        } 
    }
}
