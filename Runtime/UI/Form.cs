using UnityEngine;
using System;

namespace ProjectRuntime.UI.PanelSystem
{
    [DisallowMultipleComponent]
    public class Form : MonoBehaviour, IDisposable
    {
        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
