using UnityEngine;
using UnityEngine.Audio;

namespace UI
{
    public class OffSound : MonoBehaviour
    {
        
        [SerializeField] private AudioMixer mixer;
        private bool _muted;
        
        public void SwitchSound() 
        {
            mixer.SetFloat(Fields.Audio.MasterVolumeName, _muted ? Fields.Audio.NormalVolume : Fields.Audio.MinVolume);
            _muted = !_muted;
        }
    }
}
