using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Patrick.UI
{
    public class TimedUIScreen : UIScreen
    {
        #region Variables
        [Header("Timed Screen Properties")]
        public float ScreenTime = 2f;
        public UnityEvent onTimeCompleted = new UnityEvent();

        public float startTime;

        #endregion

        #region HelpMethod
        public override void StartScreen()
        {
            base.StartScreen();

            startTime = Time.time;
            StartCoroutine(WaitForTime());
        }

        IEnumerator WaitForTime()
        {
            yield return new WaitForSeconds(ScreenTime);

            if (onTimeCompleted != null)
            {
                onTimeCompleted.Invoke();
            }
        }
        #endregion

    }
}
