using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace DanielLochner.Assets.SimpleScrollSnap
{
    public class PlayerInputButtonsChangeAnimation : MonoBehaviour
    {
        [SerializeField] SimpleScrollSnap InputScroll;
        [SerializeField] int VelocityPower;
        void Update()
         {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(StartAnimation());
            }
         }

        IEnumerator StartAnimation()
        {
            InputScroll.AddVelocity(-70 * Vector2.up);
            yield return new WaitForSeconds(0.5f);
            for(int i = 2; i <= 150; i += 2)
            {
                yield return new WaitForSeconds(0.01f);
                InputScroll.AddVelocity(i  * Vector2.up);
            }    
            //InputScroll.AddVelocity(VelocityPower * Vector2.up);
        }
    }

}
