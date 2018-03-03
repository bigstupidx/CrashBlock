using UnityEngine;
using UnityEngine.Assertions;

public class ServiceLocator
{

    #region Camera 
    private static CameraControl m_cameraControl;

    public static CameraControl cameraControl
    {
        get
        {
            Assert.IsNotNull(m_cameraControl, "No camera control is available");
            return m_cameraControl;
        }
        set
        {
            m_cameraControl = value;
        }
    }
    #endregion



    #region PlayerWeapons
    private static PlayerWeapons m_playerWeapons;

    public static PlayerWeapons playerWeapons
    {
        get
        {
            Assert.IsNotNull(m_playerWeapons, "No player weapons is available");
            return m_playerWeapons;
        }
        set
        {
            m_playerWeapons = value;
        }
    }
    #endregion

    #region FPSRigidBodyWalker
    private static FPSRigidBodyWalker m_fpsRigidBodyWalker;

    public static FPSRigidBodyWalker fpsRigidBodyWalker
    {
        get
        {
            Assert.IsNotNull(m_playerWeapons, "No FPS Rigid Body Walker is available");
            return m_fpsRigidBodyWalker;
        }
        set
        {
            m_fpsRigidBodyWalker = value;
        }
    }

    #endregion





    #region Enemies 



    #endregion


}
