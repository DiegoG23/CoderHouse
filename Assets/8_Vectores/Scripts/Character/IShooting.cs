using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Vectores
{
    public interface IShooting
    {
        public Gun PrefabGun { get; }
        public Gun Gun { get; set; }

        public void ToggleShoot(bool isActive);

    }
}