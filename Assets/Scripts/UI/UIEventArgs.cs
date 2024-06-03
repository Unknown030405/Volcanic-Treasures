using System;
using UnityEngine;

namespace UI
{
    public class UIEventArgs : EventArgs
    {
        public Transform Image { get; set; }

        public UIEventArgs(Transform image) => Image = image;
    }
}
