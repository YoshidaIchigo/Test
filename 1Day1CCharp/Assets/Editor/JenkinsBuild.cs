using System.Collections.Generic;
using System.Linq;
using UnityEditor;

public static class JenkinsBuild
{
    [MenuItem("Build/ApplicationBuild/Windows")]
    public static void BuildWindows()
    {
        // Windows(64bit) に Switch Platform
        EditorUserBuildSettings.SwitchActiveBuildTarget(
            BuildTargetGroup.Standalone,
            BuildTarget.StandaloneWindows64
        );

        var scene_name_array = CreateBuildTargetScenes().ToArray();

        PlayerSettings.applicationIdentifier = "com.hogehoge.fugafuga";
        PlayerSettings.productName = "1Day1Charp";
        PlayerSettings.companyName = "Renacchi";

        // Splash Screen OFF（Personalでは無効）
        PlayerSettings.SplashScreen.show = false;
        PlayerSettings.SplashScreen.showUnityLogo = false;

        // Windows用ビルド
        BuildPipeline.BuildPlayer(
            scene_name_array,
            "Build/Windows/1Day1Charp.exe",
            BuildTarget.StandaloneWindows64,
            BuildOptions.Development
        );
    }

    #region Util

    private static IEnumerable<string> CreateBuildTargetScenes()
    {
        foreach (var scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
                yield return scene.path;
        }
    }

    #endregion
}
