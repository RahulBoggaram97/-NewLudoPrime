using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEditor;
using SimpleJSON;


public class nativePluginTest : MonoBehaviour
{
    public int maxSize;

    public  Image profileImage;

    public Image downloadedImage;

     public Texture2D texture;

    public Texture2D downloadedTexture;

    public void imagePicker()
    {
        texture = null;
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                
                // Create Texture from selected image
              Texture2D tex = NativeGallery.LoadImageAtPath(path, maxSize);
                texture = duplicateTexture(tex);

                
               
                
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }

                profileImage.sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f);

                //Debug.Log(profileImage.sprite.texture.GetRawTextureData());


                

                Debug.Log(texture.isReadable);

            }
        });



    }

    public void couroutineStarter() => StartCoroutine(UploadAFile());

    public IEnumerator UploadAFile()
    {
        string url = "https://ludogame-backend.herokuapp.com/image";

        yield return new WaitForEndOfFrame();

        texture = profileImage.sprite.texture;

        Debug.Log(texture.isReadable);

        byte[] bytes = texture.EncodeToJPG(); //Can also encode to jpg, just make sure to change the file extensions down below


        Debug.Log(bytes);

        // Create a Web Form, this will be our POST method's data
        WWWForm form = new WWWForm();
        form.AddField("Phone", "9876543210");
        form.AddBinaryData("uploadimage", bytes, "screenshot.jpg", "image/jpg");

        //POST the screenshot to GameSparks
        using (UnityWebRequest request = UnityWebRequest.Post(url, form))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);

            }
        }



    }

    public void getUserDet() => StartCoroutine(getUserDeatails_coroutine());

    IEnumerator getUserDeatails_coroutine()
    {


        string uri = "https://ludogame-backend.herokuapp.com/api/getUserDetails/" + "9876543210";

        Debug.Log(uri);
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);

                JSONNode node = JSON.Parse(request.downloadHandler.text);

                //[{"UserId":"1643254696575",
                //"Phone":"7894561230",
                //"Joined":"2022-01-27T03:38:17.000Z",
                //"Name":"prime1643254696575",
                //"ProfilePic":"undefined",
                //"ReferralCode":null,
                //"Referrer":null,"
                //"Wallet":0,
                //"Points":100,
                //"Won":0,
                //"Lose":0,
                //"Drawn":0,
                //"Total":0,
                //"LastGame":0,
                //"MatchPoints":null}]

                Debug.Log(node[0]["UserId"].ToString());

                Debug.Log(node[0]["ProfilePic"].ToString());

                string imageurl = node[0]["ProfilePic"].ToString();
                Debug.Log("it starts:" + imageurl.Substring(1, imageurl.Length-2) + ":it ends");

                string imageurlFinalised = imageurl.Substring(1, imageurl.Length - 2);

                StartCoroutine(DownloadImage(imageurlFinalised));

            }
        }

    }


    public IEnumerator DownloadImage(string downloadUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(downloadUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("cant connect oof");
            Debug.Log(request.error);
        }
        else
        {
            downloadedTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }

        if (downloadedTexture != null)
            downloadedImage.sprite = Sprite.Create(downloadedTexture, new Rect(0f, 0f, downloadedTexture.width, downloadedTexture.height), new Vector2(0.5f, 0.5f), 100f);
        else Debug.Log("texuture is null");


    }

    

    Texture2D duplicateTexture(Texture2D source)
    {
        RenderTexture renderTex = RenderTexture.GetTemporary(
                    source.width,
                    source.height,
                    0,
                    RenderTextureFormat.Default,
                    RenderTextureReadWrite.Linear);

        Graphics.Blit(source, renderTex);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTex;
        Texture2D readableText = new Texture2D(source.width, source.height);
        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        readableText.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTex);
        return readableText;
    }

}

    



