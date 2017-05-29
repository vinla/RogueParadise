using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Missile : MonoBehaviour, IDamageTarget
    {
        [SerializeField]
        private float _damage = 20f;
        [SerializeField]
        private GameObject _target;
        [SerializeField]
        private float _thrust = 30f;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (_target == null)
                gameObject.SetActive(false);

            var target = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z);

            transform.LookAt(target);
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(transform.forward * _thrust);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == _target)
            {                
                var target = collision.gameObject.transform.GetComponentAntecendant<IDamageTarget>();
                if (target != null)
                    target.OnHit(new DamageInfo { Damage = _damage, Type = DamageType.Normal });
            }

            DestorySelf();
        }

        public virtual void OnHit(DamageInfo damageInfgo)
        {
            DestorySelf();
        }

        private void DestorySelf()
        {
            foreach (Transform child in transform)
                GameObject.Destroy(child.gameObject);
            GameObject.Destroy(this);
        }
    }
}
