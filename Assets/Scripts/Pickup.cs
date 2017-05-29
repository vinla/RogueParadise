using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Pickup : MonoBehaviour
    {
        [SerializeField]
        private float _rotationSpeed = 120f;
        [SerializeField]
        private float _gatherRange = 2f;
        [SerializeField]
        private float _gatherSpeed = 10f;

        private Player _player;        
        
        private void Start()
        {
            _player = GameObject.Find("Player").GetComponent<Player>();
        }

        private void Update()
        {
            transform.Rotate(transform.up, _rotationSpeed * Time.deltaTime);

            if (_player != null)
            {
                var toPlayer = _player.transform.position.ReplaceY(transform.position.y) - transform.position;

                if(toPlayer.magnitude < .3f)
                {
                    gameObject.DestoryDeep();
                    _player.CrystalCount++;
                }
                if(toPlayer.magnitude < _gatherRange)
                {
                    transform.position += toPlayer.normalized * Time.deltaTime * _gatherSpeed;
                }
            }
        }
    }
}
