using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace UI
{
    public class FadeAnimation : Image
    {
        public override Material materialForRendering
        {
            get
            {
                var mat = new Material(base.materialForRendering);
                mat.SetInt(Fields.Fade.FadeMaterial, (int)CompareFunction.NotEqual);
                return mat;
            }
        }
    }
}
