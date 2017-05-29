using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Boolean _useAlternateMovementScheme = false;
        [SerializeField]
        private GameObject _muzzlePoint;
        [SerializeField]
        private float _fireRate = 1f; 

        private Rigidbody _rigidbody;
        private Vector3 _moveVelocity;
        private Quaternion _targetRotation;
        private float _lastShot;
        private float _timeBetweenShots;
        private int _boostFrames = 0;

        public void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _timeBetweenShots = 1f / _fireRate;
            _lastShot = -100f;
        }

        public void Move(Vector3 velocity)
        {
            if(_boostFrames < 1)
                _moveVelocity = velocity;
        }

        public void Boost()
        {
            if (_boostFrames == 0)
            {
                _boostFrames = 5;
                _moveVelocity *= 3;
            }
        }

        public void LookAt(Vector3 target)
        {
            var adjustedTarget = new Vector3(target.x, transform.position.y, target.z);            
            Vector3 toTarget = adjustedTarget - transform.position;
            _targetRotation = Quaternion.LookRotation(toTarget.normalized);            
        }

        public void Fire()
        {
            if (_boostFrames < 1 && _lastShot + _timeBetweenShots < Time.time)
            {
                _lastShot = Time.time;
                var bullet = PrefabManager.Create("Bullet");
                bullet.transform.rotation = _muzzlePoint.transform.rotation;
                bullet.transform.position = _muzzlePoint.transform.position;
            }
        }

        public void FixedUpdate()
        {
            if (_boostFrames > 0)
            {
                _boostFrames--;
                if (_boostFrames == 0)
                    _boostFrames = -10;
            }

            if (_boostFrames < 0)
                _boostFrames++;
            
            if(_targetRotation.w > 0f)            
                _rigidbody.MoveRotation(_targetRotation);

            if (_useAlternateMovementScheme)
            {
                var x = transform.forward * _moveVelocity.z + transform.right * _moveVelocity.x;
                _rigidbody.MovePosition(transform.position + x * Time.fixedDeltaTime);
            }
            else
            {
                _rigidbody.MovePosition(transform.position + _moveVelocity * Time.fixedDeltaTime);
            }            
        }
    }
}
