using System;

namespace Core.Collectibles
{
    public interface ICollectible
    {
        public void Collect(Action Collected);
    }
}