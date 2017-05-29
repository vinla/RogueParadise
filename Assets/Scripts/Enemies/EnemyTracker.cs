using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyTracker : MonoBehaviour
    {
        private List<Enemy> _trackedEnemies = new List<Enemy>();

        public void RegisterEnemy(Enemy enemy)
        {
            _trackedEnemies.Add(enemy);
        }

        public void EnemyDestoryed(Enemy enemy)
        {
            _trackedEnemies.Remove(enemy);
        }

        public Int32 ActiveEnemyCount
        {
            get { return _trackedEnemies.Count; }
        }
    }
}
