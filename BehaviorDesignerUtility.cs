using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

public static class BehaviorDesignerUtility
{
    private static Texture2D taskConnectionRunningTopTexture = null;
    private static Texture2D taskConnectionRunningBottomTexture = null;
    private static GUIStyle taskRunningGUIStyle = null;


    private static Dictionary<string, Texture2D> textureCache = new Dictionary<string, Texture2D>();

    public static Texture2D TaskConnectionRunningTopTexture
    {
        get
        {
            if(BehaviorDesignerUtility.taskConnectionRunningTopTexture == null)
            {
                BehaviorDesignerUtility.InitTaskConnectionRunningTopTexture();
            }
            return BehaviorDesignerUtility.taskConnectionRunningTopTexture;
        }
    }
    public static Texture2D TaskConnectionRunningBottomTexture
    {
        get
        {
            if (BehaviorDesignerUtility.taskConnectionRunningBottomTexture == null)
            {
                BehaviorDesignerUtility.InitTaskConnectionRunningBottomTexture();
            }
            return BehaviorDesignerUtility.taskConnectionRunningBottomTexture;
        }
    }
    public static GUIStyle TaskRunningGUIStyle
    {
        get
        {
            if(BehaviorDesignerUtility.taskRunningGUIStyle == null)
            {
                BehaviorDesignerUtility.InitTaskRunningGUIStyle();
            }
            return BehaviorDesignerUtility.taskRunningGUIStyle;
        }
    }

    private static Texture2D LoadTaskTexture(string imageName)
    {
        if (BehaviorDesignerUtility.textureCache.ContainsKey(imageName))
        {
            return BehaviorDesignerUtility.textureCache[imageName];
        }
        Texture2D texture2D = null;
        Stream rStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(imageName);
        texture2D = new Texture2D(0, 0, TextureFormat.RGBA32, false, true);
        texture2D.LoadImage(BehaviorDesignerUtility.ReadToEnd(rStream));
        texture2D.hideFlags = HideFlags.HideAndDontSave;

        return texture2D;
    }

    private static byte[] ReadToEnd(Stream stream)
    {
        byte[] array = new byte[16384];
        byte[] result;
        using (MemoryStream memoryStream = new MemoryStream())
        {
            int count;
            while ((count = stream.Read(array, 0, array.Length)) > 0)
            {
                memoryStream.Write(array, 0, count);
            }
            result = memoryStream.ToArray();
        }
        return result;
    }

    private static void InitTaskConnectionRunningTopTexture()
    {
        BehaviorDesignerUtility.taskConnectionRunningTopTexture = BehaviorDesignerUtility.LoadTaskTexture("TaskConnectionRunningTop.png");
    }
    private static void InitTaskConnectionRunningBottomTexture()
    {
        BehaviorDesignerUtility.taskConnectionRunningBottomTexture = BehaviorDesignerUtility.LoadTaskTexture("TaskConnectionRunningBottom.png");    
    }
    private static void InitTaskRunningGUIStyle()
    {
        BehaviorDesignerUtility.taskRunningGUIStyle = BehaviorDesignerUtility.InitTaskGUIStyle(BehaviorDesignerUtility.LoadTaskTexture("TaskRunning.png"));
    }
    private static GUIStyle InitTaskGUIStyle(Texture2D texture2D)
    {
        return new GUIStyle() { };
    }
}
