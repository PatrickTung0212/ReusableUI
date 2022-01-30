using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Patrick.UI
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CanvasGroup))]  //control transparency of UI element
    public class UIScreen : MonoBehaviour
    {
        #region Variables

        //[SerializeField]
        //UISystem uiSystem;

        [Header("Main Properties")]
        public Selectable m_StartSelectable;

        [Header("Screen Events")]
        public UnityEvent onScreenStart = new UnityEvent();
        public UnityEvent onScreenClose = new UnityEvent();

        Animator animator;
        #endregion

        #region Main Methods
        private void Awake()
        {
            animator = GetComponent<Animator>();

            if (m_StartSelectable)
            {
                EventSystem.current.SetSelectedGameObject(m_StartSelectable.gameObject);
                //m_StartSelectable.OnSelect(new BaseEventData(EventSystem.current));
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region Helper Methods
        public virtual void StartScreen()
        {
            if(onScreenStart != null)
            {
                onScreenStart.Invoke();
            }
            HandleAnimator("Show");
            Debug.Log(animator);
        }

        public virtual void CloseScreen(UIScreen screen)
        {
            onScreenClose.Invoke();

            HandleAnimator("Hide");
            //StartCoroutine(waitAnim(screen));
        }

        void HandleAnimator(string aTrigger)
        {
            if (animator)
            {
                animator.SetTrigger(aTrigger);
            }
        }

        //IEnumerator waitAnim(UIScreen screen)
        //{
        //    yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        //    uiSystem.StartAnotherScreen(screen);
        //}

        #endregion
    }

}
