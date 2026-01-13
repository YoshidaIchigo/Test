using UImGui;
using UnityEngine;

public class ImGuiManager : MonoBehaviour
{
    private void OnEnable()
    {
        UImGuiUtility.Layout += OnLayout;
    }

    private void OnDisable()
    {
        UImGuiUtility.Layout -= OnLayout;
    }

    private void OnLayout(UImGui.UImGui uImGui)
    {
        // ひとまずデモウィンドウを表示
        ImGuiNET.ImGui.ShowDemoWindow();
    }
}