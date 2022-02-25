using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Firebase;
//using Firebase.Auth;
//using Firebase.Analytics;
using UnityEngine.UI;


   public class loginManager : MonoBehaviour
{

////        //FirebaseAuth auth;
////        //PhoneAuthProvider provider;

////        public InputField phoneNumber;
////        public InputField smsCode;

////        public GameObject enterPhoenPanel;
////        public GameObject enterOtpPanel;

////        public Text debugText;
////        private uint phoneAuthTimeOutMs = 60000;
////        private string verificationId;

////        public GameObject loginMenuPanel;
////        public GameObject mainMenuPanel;

////        private void Start()
////        {

////            FirebaseApp.CheckAndFixDependenciesAsync();
////            auth = FirebaseAuth.DefaultInstance;



////            if(auth.CurrentUser != null)
////            {
////                startGame();
////            }
////            else
////            {
////                debugText.text = "auto login is not working";
////            }


////        }

////        public void authenticate()
////        {
////            tester();
////        }

////        void tester()
////        {

////            try
////            {
////                provider = PhoneAuthProvider.GetInstance(auth);
////                provider.VerifyPhoneNumber(phoneNumber.text, phoneAuthTimeOutMs, null,
////                                                                                  verificationCompleted: (credential) => {
////                                                                                      // Auto-sms-retrieval or instant validation has succeeded (Android only).
////                                                                                      // There is no need to input the verification code.
////                                                                                      // `credential` can be used instead of calling GetCredential().
////                                                                                      debugText.text = "verificationCompleted";
////                                                                                  },
////                                                                                  verificationFailed: (error) => {
////                                                                                      // The verification code was not sent.
////                                                                                      // `error` contains a human readable explanation of the problem.
////                                                                                      debugText.text = error.ToString();
////                                                                                  },
////                                                                                  codeSent: (id, token) => {

////                                                                                      verificationId = id;
////                                                                                      debugText.text = "code sent";
////                                                                                      enterPhoenPanel.SetActive(false);
////                                                                                      enterOtpPanel.SetActive(true);
////                                                                                      // Verification code was successfully sent via SMS.
////                                                                                      // `id` contains the verification id that will need to passed in with
////                                                                                      // the code from the user when calling GetCredential().
////                                                                                      // `token` can be used if the user requests the code be sent again, to
////                                                                                      // tie the two requests together.
////                                                                                  },
////                                                                                  codeAutoRetrievalTimeOut: (id) => {
////                                                                                      // Called when the auto-sms-retrieval has timed out, based on the given
////                                                                                      // timeout parameter.
////                                                                                      // `id` contains the verification id of the request that timed out.
////                                                                                  });
////            }
////            catch(System.Exception e)
////            {
////                debugText.text = e.ToString();
////            }

////        }

////        public void signIn()
////        {

////            Credential credential = provider.GetCredential(verificationId, smsCode.text);


////            auth.SignInWithCredentialAsync(credential).ContinueWith(task =>
////            {
////                if (task.IsFaulted)
////                {
////                    debugText.text = ("SignInWithCredentialAsync encountered an error: " + task.Exception);

////                    return;
////                }

////                FirebaseUser newUser = task.Result;
////                debugText.text = ("User signed in successfully" + "" +

////                "Phone number: " + newUser.PhoneNumber + "" +

////                "Phone provider ID: " + newUser.ProviderId);
                

////                startGame();

////            });
////        }

////        void startGame()
////        {
////            loginMenuPanel.SetActive(false);
////            mainMenuPanel.SetActive(true);
////        }


    }
  

