using UnityEngine;

namespace Assets.Scripts
{
    public static class ComponentExtensions
    {
        public static TComponent GetComponentAntecendant<TComponent>(this Transform component) where TComponent : class
        {
            TComponent target = null;
            while(component != null && target == null)
            {
                target = component.GetComponent<TComponent>();
                component = component.parent;
            }
            return target;
        }
    }
}
