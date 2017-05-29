using UnityEngine;

namespace Assets.Scripts
{
    public class Tower : Enemy
    {        
        [SerializeField]
        private float _fireRate;
        [SerializeField]
        private float _rotationSpeed;

        private float _lastShot;
        private float _timeBetweenShots;

        public override void Start()
        {
            _timeBetweenShots = 1f / _fireRate;
            _lastShot = -100f;
            base.Start();
        }

        public void Update()
        {
            transform.Rotate(transform.up, _rotationSpeed * Time.deltaTime);

            if (_lastShot + _timeBetweenShots < Time.time)
            {
                _lastShot = Time.time;
                var bullet = PrefabManager.Create("ElectroOrb");
                bullet.transform.rotation = transform.rotation;
                bullet.transform.position = transform.position;
            }
        }        
    }
}
