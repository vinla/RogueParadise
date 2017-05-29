using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class LevelGoal : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collidee)
        {
            Debug.Log(collidee.gameObject.name);
            if (collidee.gameObject.name == "Player")
                Game.NextLevel();
        }
    }
}
