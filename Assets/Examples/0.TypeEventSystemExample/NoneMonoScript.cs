using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Example
{
    public class NoneMonoScript : IUnRegisterList
    {
        public List<IUnRegister> UnregisterList { get; } = new List<IUnRegister>();

        void Start()
        {
            TypeEventSystem.Global.Register<EventA>(e =>
            {
                UnityEngine.Debug.Log(e.Count);
            }).AddToUnregisterList(this);
        }

        void OnDestroy()
        {
            this.UnRegisterAll();
        }
    }
}