using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using Cinemachine;

[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")]
public class CameraOffset : CinemachineExtension
{
    [Tooltip("Offset the camera's position by this much (camera space)")]
    public Vector3 m_Offset = Vector3.zero;

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Aim)
        {
            state.PositionCorrection += state.FinalOrientation * m_Offset;
        }
    }
}
