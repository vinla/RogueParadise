using UnityEngine;

namespace Assets.Scripts
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private float _projectileSpeed = 15f;
        [SerializeField]
        private float _maxRange = 500f;
        [SerializeField]
        private float _damage = 10f;
        [SerializeField]
        private LayerMask _layerMask;

        private float _totalDistanceTravelled;

        public void Update()
        {
            if (_totalDistanceTravelled > _maxRange)
                GameObject.Destroy(gameObject);

            var distanceToTravel = _projectileSpeed * Time.deltaTime;
            CheckCollisions(distanceToTravel);
            transform.position += transform.forward * distanceToTravel;
            _totalDistanceTravelled += distanceToTravel;
        }

        private void CheckCollisions(float moveDistance)
        {
            Ray path = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;

            if (Physics.Raycast(path, out hitInfo, moveDistance, _layerMask, QueryTriggerInteraction.Collide))
            {
                GameObject.Destroy(gameObject);
                var target = hitInfo.transform.GetComponentAntecendant<IDamageTarget>();
                if (target != null)
                    target.OnHit(new DamageInfo { Damage = _damage, Type = DamageType.Normal });
            }
        }
    }

    public enum DamageType
    {
        Normal,
        Explosive
    }

    public class DamageInfo
    {
        public float Damage { get; set; }
        public DamageType Type {get;set;}
    }

    public interface IDamageTarget
    {
        void OnHit(DamageInfo damageInfo);
    }
}
