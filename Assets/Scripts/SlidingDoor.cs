using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    [SerializeField]
    private bool _locked;

    private Animator _animator;

    public void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider subject)
    {
        if(!_locked)
            _animator.SetBool("IsOpening", true);
    }	

    public void OnTriggerExit(Collider subject)
    {
        _animator.SetBool("IsOpening", false);
    }

    public void Unlock()
    {
        _locked = false;
    }
}
