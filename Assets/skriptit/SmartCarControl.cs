using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class SmartCarControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public Rigidbody rb;
        public Text GearText;
        public Text SpeedOMeter;
        public bool Reverse;
        public int ForceMultiplier = 5;
        public controlschemes ControlScheme;
        public enum controlschemes { Keyboard, Logitech, Thrustmaster };

        /*
        public float steer = 0;
        public float gas = 0;
        public float brake = 0;
        public float handbrake = 0;
        public bool getgearup = false;
        public bool getgeardown = false;
        */
        private void Awake()
        {
            string JoystickName = "";
            int i = 0;
            while(i < Input.GetJoystickNames().Length && JoystickName == "")
            {
                JoystickName = Input.GetJoystickNames()[i];
                i++;
            }

            if (JoystickName.Contains("G29") || JoystickName.Contains("G923"))
            {
                ControlScheme = controlschemes.Logitech;
            }
            else if (JoystickName.Contains("B6"))
            {
                ControlScheme = controlschemes.Thrustmaster;
            }
            else
            {
                ControlScheme = controlschemes.Keyboard;
            }

                // get the car controller
                m_Car = GetComponent<CarController>();
            rb = GetComponent<Rigidbody>();
            Debug.Log("SteeringInit:" + LogitechGSDK.LogiSteeringInitialize(false));
        }
        void OnApplicationQuit()
        {
            Debug.Log("SteeringShutdown:" + LogitechGSDK.LogiSteeringShutdown());
        }

        private void FixedUpdate()
        {
            if(SpeedOMeter != null)
            {
                SpeedOMeter.text = ((int)(rb.velocity.magnitude * 3.6f)).ToString();
            }

            if (GearText != null)
            {
                if (!Reverse)
                {
                    GearText.text = "D";
                }
                else
                {
                    GearText.text = "R";
                }
            }

            // pass the input to the car!

            float steer = 0;
            float gas = 0;
            float brake = 0;
            float handbrake = 0;
            bool getgearup = false;
            bool getgeardown = false;
            

            if (ControlScheme == controlschemes.Logitech)
            {
                steer = Input.GetAxis("Horizontal");
                gas = (Input.GetAxis("Axis3") - 1f) / -2f;
                brake = (Input.GetAxis("Axis4") - 1f) / -2f;
                handbrake = (Input.GetAxis("Vertical") + 1f) / 2f;
                getgearup = Input.GetKeyDown(KeyCode.JoystickButton4);
                getgeardown = Input.GetKeyDown(KeyCode.JoystickButton5);
            }
            else if (ControlScheme == controlschemes.Thrustmaster)
            {
                steer = Input.GetAxis("Horizontal");
                gas = (Input.GetAxis("Axis3") - 1f) / -2f;
                brake = (Input.GetAxis("Vertical") + 1f) / 2f;
                handbrake = (Input.GetAxis("Axis4")+ 1f) / 2f;
                getgearup = Input.GetKeyDown(KeyCode.JoystickButton1);
                getgeardown = Input.GetKeyDown(KeyCode.JoystickButton0);
            }
            else if (ControlScheme == controlschemes.Keyboard)
            {
                steer = Input.GetAxis("Horizontal");
                gas = Input.GetAxis("Vertical");
                brake = Input.GetAxis("Vertical");
                handbrake = Input.GetAxis("Jump");
            }

            if (getgearup && Reverse)
            {
                Reverse = false;
            }
            else if (getgeardown && !Reverse)
            {
                Reverse = true;
            }

            if(ControlScheme != controlschemes.Keyboard)
            {
                float UltimateBrakeValue = 0;
                float UltimateGasValue = 0;

                if(rb.transform.InverseTransformDirection(rb.velocity).z > 0)
                {
                    UltimateBrakeValue = -1;
                }
                else if (rb.transform.InverseTransformDirection(rb.velocity).z < 0)
                {
                    UltimateBrakeValue = 1;
                }

                UltimateGasValue = 1;
                if (Reverse)
                {
                    UltimateGasValue *= -1;
                }
                float Ratio = ((gas - brake) + 1) / 2;
                gas = brake = Mathf.Lerp(UltimateBrakeValue, UltimateGasValue, Ratio);
            }

            m_Car.Move(steer, gas, brake, handbrake);

            if (LogitechGSDK.LogiUpdate())
            {
                if (LogitechGSDK.LogiHasForceFeedback(0))
                {
                    LogitechGSDK.LogiPlayConstantForce(0, (int)(transform.InverseTransformDirection(rb.velocity).x * ForceMultiplier));
                }
            }
        }
    }
}