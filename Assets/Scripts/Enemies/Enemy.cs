using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Enemy : MonoBehaviour, IDamageTarget
    {
        [SerializeField]
        private GameObject _explosionEffect;

        [SerializeField]
        private GameObject _criticalEffect;

        [SerializeField]
        private float _hitPoints;
        [SerializeField]
        private EnemyTracker _enemyTracker;

        private bool _isCritical = false;

        public virtual void Start()
        {
            if (_enemyTracker != null)
                _enemyTracker.RegisterEnemy(this);
        }

        public virtual void OnDestroy()
        {
            if (_enemyTracker != null)
                _enemyTracker.EnemyDestoryed(this);
        }

        public virtual void OnHit(DamageInfo damageInfgo)
        {
            _hitPoints -= damageInfgo.Damage;

            if (!_isCritical && _hitPoints < 25f && _criticalEffect != null)
            {
                var effect = Instantiate(_criticalEffect, transform);
                effect.transform.localPosition = Vector3.zero;
            }

            if (_hitPoints < 0.1f)
            {
                if (_explosionEffect != null)
                {
                    var exp = Instantiate(_explosionEffect, transform.position, transform.rotation);
                    GameObject.Destroy(exp, 1.8f);
                }
                gameObject.DestoryDeep();                
            }
        }
    }
}
