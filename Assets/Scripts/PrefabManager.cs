using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class PrefabManager : MonoBehaviour
    {
        private static PrefabManager _instance;

        [SerializeField]
        private NamedItem[] _prefabs;

        public void Start()
        {
            _instance = this;
        }

        public static GameObject Create(String prefabName)
        {
            return _instance.CreateInternal(prefabName);
        }

        private GameObject CreateInternal(String prefabName)
        {
            var item = _prefabs.Single(p => p.Name == prefabName);
            if (item == null)
                throw new InvalidOperationException("Prefab was not found");
            
            return Instantiate(item.Object);
        }
    }

    [Serializable]
    public class NamedItem
    {
        public String Name;
        public GameObject Object;
    }
}
