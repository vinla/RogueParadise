using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(SlidingDoor))]
    public class BitLock : MonoBehaviour
    {        
        [SerializeField]
        private Player _player;
        [SerializeField]
        private int _bitsRequired;

        private SlidingDoor _door;

        private void Start()
        {
            _door = GetComponent<SlidingDoor>();
            StartCoroutine(CheckLock());
        }

        private IEnumerator CheckLock()
        {
            while(_player.CrystalCount < _bitsRequired)
            {
                yield return new WaitForSeconds(1f);
            }

            _door.Unlock();
        }
    }
}
