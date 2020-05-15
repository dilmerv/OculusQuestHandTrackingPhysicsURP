#if UNITY_2018_2_OR_NEWER
using Assets.Oculus.VR.Editor;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

public class OVRShaderBuildProcessor : IPreprocessShaders
{
	public int callbackOrder { get { return 0; } }

	public void OnProcessShader(
		Shader shader, ShaderSnippetData snippet, IList<ShaderCompilerData> shaderCompilerData)
	{
		if (!OVRPlatformToolSettings.TryInitialize())
		{
			return;
		}

		if (!OVRPlatformToolSettings.SkipUnneededShaders)
		{
			return;
		}

		if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.Android)
		{
			return;
		}

		// Unity only uses shader Tier2 on Quest and Go (regardless of graphics API)

		var strippedGraphicsTiers = new HashSet<GraphicsTier>();
		switch (OVRPlatformToolSettings.TargetPlatform)
		{
			case OVRPlatformTool.TargetPlatform.OculusGoGearVR:
			case OVRPlatformTool.TargetPlatform.Quest:
				strippedGraphicsTiers.Add(GraphicsTier.Tier1);
				strippedGraphicsTiers.Add(GraphicsTier.Tier3);
				break;
			default:
				break;
		}

		if (strippedGraphicsTiers.Count == 0)
		{
			return;
		}

		for (int i = shaderCompilerData.Count - 1; i >= 0; --i)
		{
			if (strippedGraphicsTiers.Contains(shaderCompilerData[i].graphicsTier))
			{
				shaderCompilerData.RemoveAt(i);
			}
		}
	}
}
#endif
