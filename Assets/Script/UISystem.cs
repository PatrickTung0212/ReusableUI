using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Patrick.UI;
using System;

namespace Patrick.UI
{   
    public class UISystem : MonoBehaviour
    {
        #region Variables 
        [Header("Main Properties")]
        public UIScreen StartScreen;

        [Header("System Events")]
        public UnityEvent onSwitchedScreen = new UnityEvent();

        [Header("Fader Properties")]
        public Image fader;
        public float fadeInDuration = 1f;
        public float fadeOutDuration = 1f;

        [Header("Capture Screen when start")]
        [SerializeField]
        private Component[] screens = new Component[0];  //look for screen(it is a component becoz it has monobaviour)

        private UIScreen previousScreen;
        public UIScreen PreviousScreen
        {
            get
            {
                return previousScreen;
            }

            set
            {
                previousScreen = value;
            }
        }

        private UIScreen currentScreen;
        public UIScreen CurrentScreen 
        { 
            get
            { 
                return currentScreen; 
            }

            set
            {
                currentScreen = value;
            }
        }

        #endregion

        #region Main Methods
        private void Awake()
        {
            screens = GetComponentsInChildren<UIScreen>(true);
        }

        void Start()
        {
            //onSwitchedScreen.AddListener(FadeIn);
            //onSwitchedScreen.AddListener(FadeOut);
            InitializeScreens();

            if (StartScreen)
            {
                SwitchScreen(StartScreen); //init startscreen
            }

            //currentScreen = screens[0].GetComponent<UIScreen>();

            if (fader)
            {
                fader.gameObject.SetActive(true);
            }

            FadeOut();
            //currentScreen.StartScreen();
        }

       


        #endregion

        #region Helper Methods

        //[ContextMenu("SwitchScreen")]
        public void SwitchScreen(UIScreen screen)
        {
            
            if (screen)
            {
                if (currentScreen)
                {
                    currentScreen.CloseScreen(screen);
                    previousScreen = currentScreen;
                }


                //wait until animation get back to idle               


                currentScreen = screen;
                currentScreen.gameObject.SetActive(true);
                currentScreen.StartScreen();

                if (onSwitchedScreen != null)
                {
                    onSwitchedScreen.Invoke();
                }

            }
        }

        public void FadeIn()
        {
            if (fader)
            {
                fader.CrossFadeAlpha(1, fadeInDuration, false);
            }
        }

        public void FadeOut()
        {
            if (fader)
            {
                fader.CrossFadeAlpha(0, fadeOutDuration, false);
            }
        }


        public void GoToPreviousScreen()
        {
            if (previousScreen)
            {
                SwitchScreen(previousScreen);
            }
        }

        public void LoadScene(int sceneIndex)
        {
            StartCoroutine(WaitToLoadScene(sceneIndex));
        }

        IEnumerator WaitToLoadScene(int sceneIndex)
        {
            yield return null;
        }

        private void InitializeScreens()
        {
            foreach(var screen in screens)
            {
                screen.gameObject.SetActive(true);
            }
        }

        

        public void StartAnotherScreen(UIScreen screen)
        {

            currentScreen = screen;
            currentScreen.gameObject.SetActive(true);
            currentScreen.StartScreen();

            if (onSwitchedScreen != null)
            {
                onSwitchedScreen.Invoke();
            }
        }

        #endregion
    }
}

