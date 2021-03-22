using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButtonDown( 0 ) )
        {
            if( Input.mousePosition.x < Screen.width / 3 )
            {
                // Take a screenshot and save it to Gallery/Photos
                StartCoroutine( TakeScreenshotAndSave() );
            }
            else
            {
                // Don't attempt to pick media from Gallery/Photos if
                // another media pick operation is already in progress
                if( NativeGallery.IsMediaPickerBusy() )
                    return;

                if( Input.mousePosition.x < Screen.width * 2 / 3 )
                {
                    // Pick a PNG image from Gallery/Photos
                    // If the selected image's width and/or height is greater than 512px, down-scale the image
                    //PickImage( 512 );
                }
                else
                {
                    // Pick a video from Gallery/Photos
                   // PickVideo();
                }
            }
        }
    }

    public void Test()
    {
        Debug.Log("Test");
        TakeScreenshotAndSave();
    }
    
    public void Test1()
    {
        Debug.Log("Test1");
    }
    
    public void Test2()
    {
        Debug.Log("Test2");
    }
    
    public void Test3()
    {
        Debug.Log("Test3");
    }
    
    private IEnumerator TakeScreenshotAndSave()
    {
        Debug.Log("TakeScreenshotAndSave");
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
        ss.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0 );
        ss.Apply();

        // Save the screenshot to Gallery/Photos
        NativeGallery.Permission permission = NativeGallery.SaveImageToGallery( ss, "GalleryTest", "Image.png", ( success, path ) => Debug.Log( "Media save result: " + success + " " + path ) );

        Debug.Log( "Permission result: " + permission );

        // To avoid memory leaks
        Destroy( ss );
    }
}
