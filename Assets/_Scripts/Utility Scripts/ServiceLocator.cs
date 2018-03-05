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

    #region DataComps
    private static DataComps m_dataComps;

    public static DataComps dataComps
    {
        get
        {
            Assert.IsNotNull(m_dataComps, "No Data Comps is available");
            return m_dataComps;
        }
        set
        {
            m_dataComps = value;
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

    #region Inputcontrol
    private static InputControl m_inputControl;

    public static InputControl inputControl
    {
        get
        {
            Assert.IsNotNull(m_inputControl, "No Input Control is available");
            return m_inputControl;
        }
        set
        {
            m_inputControl = value;
        }
    }
    #endregion

    #region FPSplayer
    private static FPSPlayer m_FPSPlayer;

    public static FPSPlayer fpsPlayer
    {
        get
        {
            Assert.IsNotNull(m_FPSPlayer, "No FPSPlayer is available");
            return m_FPSPlayer;
        }
        set
        {
            m_FPSPlayer = value;
        }
    }
    #endregion

    #region WeaponsEffects
    private static WeaponEffects m_WeaponEffects;

    public static WeaponEffects weaponEffects
    {
        get
        {
            Assert.IsNotNull(m_WeaponEffects, "No WeaponEffects is available");
            return m_WeaponEffects;
        }
        set
        {
            m_WeaponEffects = value;
        }
    }
    #endregion

    #region SmoothMouseLook
    private static SmoothMouseLook m_SmoothMouseLook;

    public static SmoothMouseLook smoothMouseLook
    {
        get
        {
            Assert.IsNotNull(m_SmoothMouseLook, "No Smooth Mouse Look is available");
            return m_SmoothMouseLook;
        }
        set
        {
            m_SmoothMouseLook = value;
        }
    }
    #endregion

}
