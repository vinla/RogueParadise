using UnityEngine;

namespace Assets.Scripts
{
    public class Sentinel : Enemy
    {
        [SerializeField]
        private float _rotationSpeed = .5f;
        [SerializeField]
        private float _shootingRange = 10f;
        [SerializeField]
        private float _engagementRange = 7f;
        [SerializeField]
        private float _detectionRange = 20f;
        [SerializeField]
        private float _movementSpeed = 3f;
        [SerializeField]
        GameObject _target;
        
        private float _firingCooldown = 0f;
        private Vector3 _lastKnownPosition;
        private AiState _aiState;
        private Vector3 _movementVector;
        private Rigidbody _rigidBody;

        public override void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _aiState = AiState.Idle;
            base.Start();
        }

        public void Update()
        {
            if (_target == null || Time.timeScale < 0.1f)
                return;

            _movementVector = Vector3.zero;
            CoolDown();
            
            _aiState = DetectTarget(_target.transform.position.ReplaceY(transform.position.y));

            switch(_aiState)
            {
                case AiState.Idle:
                    return;
                case AiState.Seeking:
                    MoveToward(_lastKnownPosition);
                    break;
                case AiState.Closing:
                    if (Vector3.Distance(_lastKnownPosition, transform.position) < _engagementRange)
                        _aiState = AiState.Attack;
                    else
                        MoveToward(_lastKnownPosition);
                    break;
                case AiState.Attack:
                    if (Vector3.Distance(_lastKnownPosition, transform.position) < _shootingRange)
                        Attack();
                    else
                        _aiState = AiState.Closing;
                    break;
            }            
        }       

        private void FixedUpdate()
        {
            _rigidBody.MovePosition(transform.position + _movementVector);
        }
        
        private void CoolDown()
        {
            if (_firingCooldown > 0)
                _firingCooldown -= Time.deltaTime;
        }

        private void Attack()
        {
            LookToward(_lastKnownPosition);

            if (_firingCooldown < 0.01f)
            {
                var bullet = PrefabManager.Create("EnemyBullet");
                bullet.transform.rotation = transform.rotation;
                bullet.transform.position = transform.position + (transform.forward * 0.5f);
                _firingCooldown = 0.5f;
            }
        }

        private void LookToward(Vector3 position)
        {
            var heading = position - transform.position;
            var targetRotation = Quaternion.LookRotation(heading);
            var str = Mathf.Min(_rotationSpeed * Time.deltaTime, 1);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed);
        }

        private void MoveToward(Vector3 position)
        {
            var heading = position - transform.position;

            if(heading.magnitude < 0.2f)
            {
                _aiState = AiState.Idle;
                return;
            }

            LookToward(position);

            var angle = Vector3.Angle(transform.forward, heading);
                        
            if (angle < 60f)
                _movementVector = transform.forward * Time.deltaTime * _movementSpeed;
        }

        private AiState DetectTarget(Vector3 playerPosition)
        {            
            var toPlayer = playerPosition - transform.position;

            if (toPlayer.magnitude > _detectionRange)
                return _aiState == AiState.Idle ? AiState.Idle : AiState.Seeking;

            Ray detectionRay = new Ray(transform.position, toPlayer);
            RaycastHit hitInfo;
            if (Physics.Raycast(detectionRay, out hitInfo, toPlayer.magnitude))
            {
                if (hitInfo.collider.gameObject.name == "Player")
                {
                    _lastKnownPosition = playerPosition;
                    return _aiState != AiState.Attack ? AiState.Closing : AiState.Attack;
                }
            }

            return AiState.Seeking;
        }

        public enum AiState
        {
            Idle,
            Seeking,
            Closing,
            Attack
        }
    }
}