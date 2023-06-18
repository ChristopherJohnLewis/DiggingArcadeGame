using UnityEngine;

namespace Player
{
    public class PlayerControls : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float jumpForce = 10f;
    
        public static event OnMovedChunk onMovedChunk;
        public delegate void OnMovedChunk(Vector3 location);

        private float _horizontalMovement;
        private float _verticalMovement;
        private int _jumps;
        private Rigidbody _playerRigidbody;
        
        void Start()
        {
            _playerRigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            _horizontalMovement = Input.GetAxisRaw("Horizontal");
            _verticalMovement = Input.GetAxisRaw("Vertical");

            if (Input.GetButtonDown("Jump"))
            {
                _playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        void FixedUpdate()
        {
            Vector3 forward = Camera.main.transform.forward; 
            forward.y = 0;
            forward = forward.normalized;

            Vector3 right = Camera.main.transform.right;
            right.y = 0;
            right = right.normalized;

            Vector3 movement = new Vector3(_horizontalMovement, 0f, _verticalMovement);
            movement = (forward * _verticalMovement + right * _horizontalMovement).normalized * moveSpeed * Time.fixedDeltaTime;
            _playerRigidbody.MovePosition(transform.position + movement);
        }

    
    }
}
