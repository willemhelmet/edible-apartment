using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class ControllButtonPress : MonoBehaviour
{
    public TextController _textController;
    private int _bumperIndex;
    public GameObject FruitTray;
    public GameObject Hydroponics_1;
    public GameObject Hydroponics_2;
    public GameObject Hydroponics_3;


    MLInputController _controller;
    public enum ButtonStates
    {
        Normal,
        Pressed,
        JustReleased
    };
    public ButtonStates BtnState;
    public AudioSource _audioSource;


    private void Start()
    {
        MLInput.Start();
        // Add button callbacks
        MLInput.OnControllerButtonDown += HandleOnButtonDown;
        MLInput.OnControllerButtonUp += HandleOnButtonUp;

        _controller = MLInput.GetController(MLInput.Hand.Left);

        // Initial State of the Control is Normal
        BtnState = ButtonStates.Normal;
        _bumperIndex = 0;
    }

    private void OnDestroy()
    {
        // Stop input
        MLInput.Stop();

        // Remove button callbacks
        MLInput.OnControllerButtonDown -= HandleOnButtonDown;
        MLInput.OnControllerButtonUp -= HandleOnButtonUp;
    }

    void HandleOnButtonUp(byte controller_id, MLInputControllerButton button)
    {
        // Callback - Button Up
        if (button == MLInputControllerButton.Bumper)
        {
            BtnState = ButtonStates.JustReleased;
            Debug.Log("Goodbye!");
        }
    }

    void HandleOnButtonDown(byte controller_id, MLInputControllerButton button)
    {
        // Callback - Button Down
        if (button == MLInputControllerButton.Bumper)
        {
            _bumperIndex++;
            BtnState = ButtonStates.Pressed;

            //Our code
            if (_bumperIndex < 3)
            {
                _audioSource.Play();
                _textController.NextItem();
            }
            
            if (_bumperIndex == 3)
            {
                _textController.gameObject.SetActive(false);
                FruitTray.SetActive(true);
            }

            if (_bumperIndex == 4)
            {
                Hydroponics_1.SetActive(true);
                FruitTray.SetActive(false);

            }
            if (_bumperIndex == 5)
            {
                Hydroponics_2.SetActive(true);
            }
            if (_bumperIndex == 6)
            {
                Hydroponics_3.SetActive(true);
            }
        }
    }
}
