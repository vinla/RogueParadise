using UnityEngine;

namespace Assets.Scripts
{
    public class ObjectTracker : MonoBehaviour
    {
        [SerializeField]
        private Transform _objectToTrack;
        [SerializeField]
        private Transform _faceToward;
        [SerializeField]
        private Vector3 _offset;

        private void Update()
        {
            transform.position = _objectToTrack.position + _offset;
            if(_faceToward != null)
                transform.LookAt(_faceToward.transform);
        }
    }
}
