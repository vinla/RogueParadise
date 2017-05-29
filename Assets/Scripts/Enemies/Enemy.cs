using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Enemy : MonoBehaviour, IDamageTarget
    {
        [SerializeField]
        private float _hitPoints;
        [SerializeField]
        private EnemyTracker _enemyTracker;

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
            if (_hitPoints < 0.1f)
                GameObject.Destroy(gameObject);
        }
    }
}
