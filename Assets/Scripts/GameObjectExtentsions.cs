using UnityEngine;

namespace Assets.Scripts
{
    public static class GameObjectExtentsions
    {
        public static void DestoryDeep(this GameObject gameObject)
        {
            foreach (Transform child in gameObject.transform)
                GameObject.Destroy(child.gameObject);
            GameObject.Destroy(gameObject);
        }
    }

    public static class Vector3Extensions
    {
        public static Vector3 ReplaceY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, y, vector.z);
        }
    }
}
