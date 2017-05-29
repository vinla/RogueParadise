using UnityEngine;
namespace Assets.Scripts
{
    public class LazerBot : MonoBehaviour
    {
        [SerializeField]
        private GameObject _emitter;
        [SerializeField]
        private GameObject _target;
        private LineRenderer _lineRenderer;


        private void Start()
        {
            _lineRenderer = GetComponent<LineRenderer>();            
        }

        private void Update()
        {
            transform.Rotate(transform.up, 30 * Time.deltaTime);

            _lineRenderer.SetPosition(0, _emitter.transform.position);
            Ray laser = new Ray(_emitter.transform.position, _emitter.transform.forward);
            var endPoint = laser.GetPoint(50f);
            RaycastHit hitInfo;
            if(Physics.Raycast(laser, out hitInfo, 50f))
            {
                endPoint = laser.GetPoint(hitInfo.distance);
            }

            _lineRenderer.SetPosition(1, endPoint);
        }
    }
}