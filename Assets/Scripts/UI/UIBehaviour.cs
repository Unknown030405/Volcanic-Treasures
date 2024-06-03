using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Player_Scripts;
using TMPro;

namespace UI
{
    public class UIBehaviour : MonoBehaviour
    {
        // надо определиться с тем, как считать высоту, пройденную игроком
        // например, зная скорость движения каждого блока вниз, с той же частотой прибавлять 1 к высоте
        // округлять до целочисленных
        [SerializeField] private TMP_Text coinsText;
        [SerializeField] private TMP_Text diamondsText;
        [SerializeField] private TMP_Text distanceText;
        
        private Player _player;
        private Dictionary<Transform, float> _buffs;

        // Start is called before the first frame update
        private void Start()
        {
            _player = GameObject.FindWithTag(Fields.Tags.PlayerTag).GetComponent<Player>();
            _buffs = _player.Effects;
        }

        // Update is called once per frame
        private void Update()
        {
            coinsText.text = _player.Coins.ToString();
            diamondsText.text = _player.Diamonds.ToString();
            var intDistance = (int)_player.Distance;
            distanceText.text = intDistance.ToString();
            CheckDelay();
            // _player.BuffEvent += StartCooldown;
        }

        private void CheckDelay()
        {
            foreach (var key in _buffs.Keys.ToList())
            {
                AddBuffToCanvas(key);
                _buffs[key] -= Time.deltaTime;
                if (_buffs[key] < 0)
                {
                    _buffs.Remove(key);
                    key.gameObject.SetActive(false);
                    MoveLeft();
                    continue;
                }
                var imageState = _buffs[key] / Fields.UIBehaviour.MaxDelay;
                key.GetChild(1).GetComponent<Image>().fillAmount = imageState;
            }
        }

        // private void StartCooldown(object sender, EventArgs e)
        // {
        //     var args = (UIEventArgs)e;
        //     StartCoroutine(BuffCooldown(args.Image));
        // }

        // private IEnumerator BuffCooldown(Transform key)
        // {
        //     AddBuffToCanvas(key);
        //     
        //     if (_buffs.ContainsKey(key))
        //     {
        //         while (_buffs[key] > 0)
        //         {
        //             var imageState = _buffs[key] / Fields.Buffs.UsingTime;
        //             key.GetChild(1).GetComponent<Image>().fillAmount = imageState;
        //             _buffs[key] -= Time.deltaTime;
        //             yield return new WaitForEndOfFrame();
        //         }
        //
        //         _buffs.Remove(key);
        //         key.gameObject.SetActive(false);
        //         StartCoroutine(MoveLeft);
        //     }
        //
        //     yield return null;
        // }
        //
        // private void StartCoroutine(Action methodName)
        // {
        //     throw new NotImplementedException();
        // }

        private void AddBuffToCanvas(Transform key)
        {
            // добавляет новый бафф справа
            // проверять на наличие баффа в канвасе
            if (!key.gameObject.activeSelf)
            {
                key.gameObject.SetActive(true);
                var pointX = _buffs.Count * (Fields.UIBehaviour.Space + key.localScale.x);
                key.position = new Vector3(pointX, Fields.UIBehaviour.PointY, key.position.z);
            }
        }

        private void MoveLeft()
        {
            // сдвигает список баффов влево
            var shiftPosition = Fields.UIBehaviour.Shift;
            foreach (var key in _buffs.Keys)
            {
                var pointX = shiftPosition * (Fields.UIBehaviour.Space + key.localScale.x);
                key.position = new Vector3(pointX, Fields.UIBehaviour.PointY, key.position.z);
                shiftPosition++;
            }
        }
        
        // private IEnumerator SmoothedMoveLeft()
        // {
        //     // сдвигает список баффов влево
        //     var shiftPosition = Fields.UIBehaviour.Shift;
        //     foreach (var key in _buffs.Keys)
        //     {
        //         var pointX = shiftPosition * (Fields.UIBehaviour.Space + key.localScale.x);
        //         key.position = new Vector3(pointX, Fields.UIBehaviour.PointY, key.position.z);
        //         shiftPosition++;
        //     }
        //     yield return null;
        // }
    }
}
