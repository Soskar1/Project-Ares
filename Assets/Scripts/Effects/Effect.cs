using UnityEngine;

namespace Core.Effects
{
    public class Effect : MonoBehaviour, IPooledObject
    {
        [SerializeField] private int _poolID;
        protected EffectsPool _pool;

        public int ID => _poolID;

        public void Initialize(EffectsPool effectsPool) => _pool = effectsPool;
    }
}