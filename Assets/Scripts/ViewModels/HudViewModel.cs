using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.ViewModels
{
    public class HudViewModel : UnityViewModel
    {
        [SerializeField]
        private Player _player;
        [SerializeField]
        private int _totalCrystals;

        private float _startTime;        

        private void Start()
        {
            _startTime = Time.time;
            StartCoroutine(UpdateClock());
        }

        private IEnumerator UpdateClock()
        {
            while (gameObject.activeSelf)
            {
                RaisePropertyChanged("LevelTime");
                RaisePropertyChanged("CrystalCount");
                RaisePropertyChanged("Damage");
                RaisePropertyChanged("Energy");
                RaisePropertyChanged("MaxEnergy");
                RaisePropertyChanged("EnergyPercentage");
                RaisePropertyChanged("DamageText");
                RaisePropertyChanged("DamagePercentage");
                yield return new WaitForSeconds(0.1f);
            }
        }

        public String LevelTime
        {
            get
            {
                var timeElapsed = TimeSpan.FromMilliseconds(Time.time - _startTime);
                return String.Format("{0}:{1}", timeElapsed.Minutes, timeElapsed.Seconds);
            }
        }

        public String CrystalCount
        {
            get
            {
                return String.Format("{0} / {1}", _player.CrystalCount, _totalCrystals);
            }
        }

        public String DamageText
        {
            get
            {
                return String.Format("{0} / {1}", _player.HitPoints, _player.MaxHitPoints);
            }
        }

        public int DamagePercentage
        {
            get
            {
                return (int)((_player.HitPoints / _player.MaxHitPoints) * 200);
            }
        }

        public float MaxEnergy
        {
            get { return _player.MaxEnergy; }
        }

        public float Energy
        {
            get { return _player.Energy; }
        }

        public int EnergyPercentage
        {
            get
            {
                return (int)((_player.Energy / _player.MaxEnergy) * 200);
            }
        }
    }
}
