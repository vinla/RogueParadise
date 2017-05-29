using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(PlayerController))]
    public class Player : MonoBehaviour, IDamageTarget
    {
        [SerializeField]
        private float _moveSpeed = 5f;
        [SerializeField]
        private float _maxHitPoints = 50f;
        [SerializeField]
        private float _hitPoints = 10f;
        [SerializeField]
        private float _energyRecoveryRate = .3f;
        [SerializeField]
        private float _maxEnergy = 10f;
        [SerializeField]
        private float _energyPerShot = 1f;
        
        private Camera _mainCamera;
        private PlayerController _playerController;
        private Quaternion _targetRotation;
        private float _energy;

        public void Start()
        {
            _playerController = GetComponent<PlayerController>();
            _mainCamera = Camera.main;
            _energy = _maxEnergy;
            _hitPoints = _maxHitPoints;
        }

        public void Update()
        {
            if (Time.timeScale < 0.01f)
                return;

            var moveInput = new Vector3(Input.GetAxisRaw(UnityAxisStrings.Horizontal), 0, Input.GetAxisRaw(UnityAxisStrings.Vertical));
            var moveVelocity = moveInput.normalized *  _moveSpeed;
            _playerController.Move(moveVelocity);

            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;

            if (groundPlane.Raycast(ray, out rayDistance))
            {
                var targetPoint = ray.GetPoint(rayDistance);
                _playerController.LookAt(targetPoint);
            }

            if (Input.GetKeyDown(KeyCode.Space))
                _playerController.Boost();

            if (Input.GetMouseButton(0))
            {
                if (_energy > _energyPerShot && _playerController.Fire())
                {
                    _energy -= _energyPerShot;                    
                }
            }

            _energy += Time.deltaTime * _energyRecoveryRate;
            if (_energy > _maxEnergy)
                _energy = _maxEnergy;
        }

        public void OnHit(DamageInfo damageInfo)
        {
            _hitPoints -= damageInfo.Damage;

            if (_hitPoints < 0.1f)
            {
                GameObject.Destroy(gameObject);
                Game.GameOver();
            }
        }

        public float MaxHitPoints { get { return _maxHitPoints; } }

        public float HitPoints { get { return _hitPoints; } }        

        public float CrystalCount { get; set; }

        public float Energy { get { return _energy; } }

        public float MaxEnergy { get { return _maxEnergy; } }
    }
}