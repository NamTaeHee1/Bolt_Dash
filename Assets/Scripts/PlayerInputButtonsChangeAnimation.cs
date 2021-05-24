using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

namespace DanielLochner.Assets.SimpleScrollSnap
{
    public class PlayerInputButtonsChangeAnimation : MonoBehaviour
    {
        [SerializeField] SimpleScrollSnap InputScroll;
        [SerializeField] Image[] InputButtons;
        [SerializeField] GameObject BlockScrollRectButtonObject;
        private float AlphaThreshold = 0.1f;

        private void Start()
        {
            for (int i = 0; i < InputButtons.Length; i++)
                InputButtons[i].alphaHitTestMinimumThreshold = AlphaThreshold;
        }

        void Update()
         {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(StartAnimation());
                StartCoroutine(BlockScrollRect());
            }
         }

        IEnumerator StartAnimation()
        {
            InputScroll.AddVelocity(200 * Vector2.down);
            yield return new WaitForSeconds(0.5f);
            for(int i = 2; i <= 150; i += 2)
            {
                yield return new WaitForSeconds(0.01f);
                InputScroll.AddVelocity(i  * Vector2.up);
            }    
            for(int i = 5; i <= 50; i += 5)
            {
                yield return new WaitForSeconds(0.01f);
                InputScroll.AddVelocity(i * Vector2.down);
            }
        }

        IEnumerator BlockScrollRect()
        {
            BlockScrollRectButtonObject.SetActive(true);
            yield return new WaitForSeconds(15.0f);
            BlockScrollRectButtonObject.SetActive(false);
        }
    }

}
