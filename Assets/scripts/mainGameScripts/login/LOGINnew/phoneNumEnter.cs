using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using UnityEngine.UI;
using System.Threading.Tasks;

namespace com.impactionalGames.LudoPrime
{
    public class phoneNumEnter : MonoBehaviour
    {
        [Header("Firebase")]
        FirebaseAuth auth;
        PhoneAuthProvider provider;

        [Header("variables")]
        private uint phoneAuthTimeOutMs = 600000;
        private string verificationId;


        public Text debugText;
 

        private void Start()
        {
            if (auth == null)
            {

                auth = FirebaseAuth.DefaultInstance;

            }

            

            if (auth.CurrentUser != null)
            {


                playerPermData.setPhoneNumber(auth.CurrentUser.PhoneNumber.Substring(3));
                debugText.text = auth.CurrentUser.PhoneNumber;

                if(playerPermData.getUserName() == string.Empty)
                {
                    authManager.instance.updateLoginState(loginState.createUser);

                    debugText.text = "the user name is :  " + playerPermData.getUserName();
                }
                else
                {
                    authManager.instance.updateLoginState(loginState.loggedIn);
                    debugText.text = "the user name is :  " + playerPermData.getUserName();
                }
            }
            else
            {
                authManager.instance.debugText.text = "No user Found";
            }


        }

        public void authenticate()
        {
            tester();
        }

        void tester()
        {
            debugText.text = "Sending the code...";
            try
            {
                provider = PhoneAuthProvider.GetInstance(auth);
                //debugText.text = "tester got called" + " provider:" + provider;

                //debugText.text = "tester got called" + " provider:  " + provider + authManager.instance.phoneNoField.text;
                provider.VerifyPhoneNumber(authManager.instance.countyCodeField.text +  authManager.instance.phoneNoField.text, phoneAuthTimeOutMs, null,
                                                                                  verificationCompleted: (credential) =>
                                                                                  {
                                                                                      //Auto - sms - retrieval or instant validation has succeeded(Android only).
                                                                                      //    There is no need to input the verification code.
                                                                                      //         `credential` can be used instead of calling GetCredential().
                                                                                      authManager.instance.debugText.text = "VerificationCompleted automatically";
                                                                                  },
                                                                                  verificationFailed: (error) =>
                                                                                  {
                                                                                      //The verification code was not sent.
                                                                                      //         `error` contains a human readable explanation of the problem.
                                                                                      authManager.instance.debugText.text = error.ToString();
                                                                                  },
                                                                                  codeSent: (id, token) =>
                                                                                  {

                                                                                      verificationId = id;
                                                                                      authManager.instance.debugText.text = "Code sent. Please enter the otp.";
                                                                                      authManager.instance.updateLoginState(loginState.enterOtpNum);
                                                                                      //Verification code was successfully sent via SMS.
                                                                                      //         `id` contains the verification id that will need to passed in with
                                                                                      //         the code from the user when calling GetCredential().
                                                                                      //         `token` can be used if the user requests the code be sent again, to
                                                                                      //         tie the two requests together.
                                                                                          },
                                                                                  codeAutoRetrievalTimeOut: (id) =>
                                                                                  {
                                                                                      //Called when the auto-sms - retrieval has timed out, based on the given
                                                                                      //  timeout parameter.
                                                                                      //         `id` contains the verification id of the request that timed out.
                                                                                      authManager.instance.debugText.text = debugText.text + "timed out";
                                                                                  });
            }
            catch (System.Exception e)
            {
                authManager.instance.debugText.text = e.ToString() + " didnt enter the the authentication";
            }

        }

        public void signIn()
        {
            


                
                Credential credential = provider.GetCredential(verificationId, authManager.instance.OTPField.text);

                

                

                auth.SignInWithCredentialAsync(credential).ContinueWith(task =>
                {
                    debugText.text = "async got called";

                    if (task.IsFaulted)
                    {
                        authManager.instance.debugText.text = ("SignInWithCredentialAsync encountered an error: " + task.Exception);

                        return;
                    }

                    FirebaseUser newUser = task.Result;
                    authManager.instance.debugText.text = ("User signed in successfully" + "" +

                    "Phone number: " + newUser.PhoneNumber + "" +

                    "Phone provider ID: " + newUser.ProviderId);

                    //playerPermData.setPhoneNumber(newUser.PhoneNumber);

                    //authManager.instance.updateLoginState(loginState.authenticated);

                    //debugText.text = authManager.instance.state.ToString();

                });

            debugText.text = "Authentication is complete please restart the app.";



        }


        public void signout()
        {
            auth.SignOut();

            debugText.text = auth.CurrentUser.ToString();
        }






    }
}
