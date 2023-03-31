using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Progression
{
    public interface IProgressable
    {
        public void SetStat(BaseStats baseStats);
    }
}
