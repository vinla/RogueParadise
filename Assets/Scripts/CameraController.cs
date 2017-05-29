using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _objectToTrack;

        public void Update()
        {
            transform.position = new Vector3(_objectToTrack.transform.position.x, transform.position.y, _objectToTrack.transform.position.z);
            transform.LookAt(_objectToTrack.transform);
        }
    }
}
