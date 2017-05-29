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
        private float _hitPoints = 10f;
        
        private Camera _mainCamera;
        private PlayerController _playerController;
        private Quaternion _targetRotation;

        public void Start()
        {
            _playerController = GetComponent<PlayerController>();
            _mainCamera = Camera.main;
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
                _playerController.Fire();
            }
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

        public float HitPoints { get { return _hitPoints; } }        

        public float CrystalCount { get; set; }
    }
}