using System;
using UnityEngine;

namespace Player_Scripts
{
    // Данный скрипт висит на игроке и отвечает за управление им
    public class Movement : MonoBehaviour
    {
        
        private bool _isLadder;
        private static readonly int HorizontalMove = Animator.StringToHash("HorizontalMove");

        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Animator animator;
        [SerializeField] private SpriteRenderer sprite;
        
        [SerializeField] private Transform groundCheck;
        [SerializeField] private Transform ladderCheck;
        
        [SerializeField] private LayerMask slopeLayer;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private LayerMask ladderLayer;
        
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;

        public void SetSpeed(float acceleration) => speed *= acceleration;
        
        public void ResetSpeed(float acceleration) => speed /= acceleration;
        
        public void SetJumpForce(float acceleration) => jumpForce *= acceleration;
        
        public void ResetJumpForce(float acceleration) => jumpForce /= acceleration;
        
        private void Update()
        {
            // Подъём по лестнице (Зажим Spacebar)
            if (Input.GetButton("Jump") && IsOnLadder())
                rb.velocity = new Vector2(0, Fields.Player.ClimbSpeed);

            // Прыжок (Разовое нажатие Spacebar)
            if (Input.GetButton("Jump"))
            {
                if (IsGrounded())
                    rb.velocity = new Vector2(0, jumpForce);
                if (IsOnSlope())
                    rb.velocity = new Vector2(0, jumpForce + 2);
            }
        }

        private void FixedUpdate()
        {
            // Горизонтальное управление (A / D)
            var horizontal = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            
            // Анимация движения при беге
            animator.SetFloat(HorizontalMove, Math.Abs(horizontal));
            sprite.flipX = horizontal < 0;
        }
        
        // Проверка на сопрекосновение с полом
        private bool IsGrounded() => 
            Physics2D.OverlapCircle(groundCheck.position, Fields.Player.GroundCheckRadius, groundLayer);

        // Проверка на нахождение на лестнице
        private bool IsOnLadder() => 
            Physics2D.OverlapCircle(ladderCheck.position, Fields.Player.LadderCheckRadius, ladderLayer);
        
        // Проверка на нахождение на наклонной поверхности
        private bool IsOnSlope() => 
            Physics2D.OverlapCircle(groundCheck.position, Fields.Player.SlopeCheckRadius, slopeLayer);
    }
}
