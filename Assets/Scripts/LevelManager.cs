using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(EnemyTracker))]
    public class LevelManager : MonoBehaviour
    {
        private EnemyTracker _enemyTracker;
        private GameObject _player;

        public void Start()
        {
            _enemyTracker = GetComponent<EnemyTracker>();
            _player = GameObject.Find("Player");
        }

        public void Update()
        {
            if(_enemyTracker.ActiveEnemyCount == 0)
            {
                Debug.Log("LevelComplete");
                _player.SetActive(false);
                Game.LoadScene(0);
            }
        }
    }
}
