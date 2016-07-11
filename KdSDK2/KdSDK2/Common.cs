using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Runtime.InteropServices;


[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TREPCTLINFO
{
    public byte m_byCtrlType;
    public int m_dwRange;
    public UInt32 m_dwPlayId;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TRecordPlayInfo
{
    public TPeriod m_tRecPeriod;
    public UInt32 m_byRecordType;
    public IntPtr m_pDrawWnd;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 257)]
    public byte[] m_szManufactor;
    public UInt32 m_dwReserve1;
    public UInt32 m_dwReserve2;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TSupportResolution
{
    public char m_byVideoFormat;
    public UInt32 m_dwSupportResolution;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TEncoderParam
{
    public char m_byVideoFormat;
    public UInt32 m_dwVideoResolution;
    public char m_byFrameRate;
    public char m_byQuality;
    public UInt32 m_dwBitRate;
    public UInt16 m_wInterval;
    public char m_byBrightness;
    public char m_byContrast;
    public char m_bySaturation;
    public UInt16 m_wSharpness;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TEncoderParamTotal
{
    public TEncoderParam m_tEncoderParam;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public TSupportResolution[] m_atSpResolution;
}


[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TDevLatiLongTude
{
    public IDs deviceID;
    public int DevSrcId;
    public int DevChnId;
    public double longitude;
    public double latitude;
}

/*[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct DevGPSInfo
{
    UInt32 revTime;
    IDs deviceID;
    double longitude;
    double latitude;
    double marLongitude;
    double marLatitude;
    double speed;
}*/

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TStreamTranRemote
{
    public UInt16 STRemoteVideoRtpPort;
    public UInt16 STRemoteVideoRtcpPort;
    public UInt16 STRemoteAudioRtpPort;
    public UInt16 STRemoteAudioRtcpPort;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
    public byte[] STRemoteIP;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
    public byte[] STRemoteNatIP;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
    public byte[] RemoteStreamType;
    public int STRemoteNatPort;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TStreamTramLocal
{
    public UInt16 STLocalVideoRtpPort;
    public UInt16 STLocalVideoRtcpPort;
    public UInt16 STLocalAudioRtpPort;
    public UInt16 STLocalAudioRtcpPort;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
    public byte[] STLocalIP;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TPTZAUTHORITY
{
    public UInt16 m_wPtzRange;
    public byte m_byLevel;
    public UInt32 m_dwHoldTimer;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TWatchPrePos
{
    public byte m_byPrePosEnable;
    public byte m_byPrePosTime;
    public byte m_byPrePos;
    public TPTZAUTHORITY m_PtzAuthority;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TWatchTask
{
    public byte m_byWatchTaskEnable;
    public byte m_byWatchTaskMinutes;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public byte[] m_byWatchTaskIntervals;
    public TPTZAUTHORITY m_PtzAuthority;
}

public enum ELocalRecType
{
    emMp4 = 0,
    em3gp = 1,
    emAsf = 2,
};

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TRecordDownloadInfo_V2
{
    public TPeriod m_tRecPeriod;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 257)]
    public byte[] m_pFileFullName;
    public ELocalRecType m_emFileType;
    public eRecordType m_byRecordType;
    public UInt32 m_dwReserve1;
    public UInt32 m_dwReserve2;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TDevRecordStatus
{
    public IDs m_tDevID;
    public TRecPlatPuStat m_emDevRecStat;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
    public TRecStat[] m_emPlatRecStat;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
    public TRecStat[] m_emPuRecStat;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TDevChannel
{
    public IDs deviceId;
    public int channelId;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TTvWallSchemeTvDivPollStep
{
    public TDevChannel encoderChn;
    public int duration;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TTvWallSchemeTvDiv
{
    public int divId;
    public char* tvWallSchTvDivPollStepArray;//TTvWallSchemeTvDivPollStep
    public int tvWallSchTvDivPollStepArrayRealSize;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TTvWallSchemeTv
{
    public int tvId;
    public IDs DeviceID;
    public UInt32 divStyle;
    public char* tvWallScheTvDivArray;//TTvWallSchemeTvDiv
    public int tvWallScheTvDivArrRealSize;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TTvWallScheme
{
    UInt32 schemeSN;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
    public byte[] m_tClientID;
    public byte byOwnerType;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
    public byte[] schemeName;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
    public byte[] tvWallId;
    public char* tvSchemeTvArray; //TTvWallSchemeTv
    public int tvSchemeTvArrayRealSize;
}


[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TTvWallSchemeTotal
{
    public int tvWallSchemeMaxSize;
    public int tvWallSchemeTvMaxSize;
    public int tvWallSchemeTvDivMaxSize;
    public int tvWallSchemeTvDivPollStepMaxSize;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TTvWallCommonData
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
    public byte[] m_TvWallID;
    public int m_tvId;
    public int m_tvDivId;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TTvWallPlayData
{
    public TTvWallCommonData m_TvWallComData;
    public IDs m_devURI;
    public int m_ChnID;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TTvDivNumData
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
    public byte[] m_TvWallID;
    public int m_tvId;
    public int m_tvDivTotal;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public unsafe struct TTvWallInfoData
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
    public byte[] m_TvWallID;
    public IDs m_domainId;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
    public byte[] m_name;
    public UInt32 m_tvNum;
    public UInt32 m_tvwallStyle;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1281)]
    public byte[] m_tvwallCustomStyleData;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
    public byte[] m_desc;
    UInt32 m_createTime;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
    public byte[] m_tClientID;
    public UInt32 m_tvDecoderBindListSize;
    public char* m_tvDecoderBindArray;//TTVDecoderBind
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public struct TTVDecoderBind
{
    public UInt32 m_tvId;
    public UInt32 m_tvDivNum;
    public IDs m_decoderId;
    public UInt32 m_decoderOutputId;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public struct TTvWallTotal
{
    public UInt32 tvWallTotal;
    public UInt32 tvWallDecoderBindTotal;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public struct TRecordInfo
{
    public TPeriod m_tRecPeriod;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 257)]
    public byte[] m_dwRecID;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 257)]
    public byte[] m_recordDomainName;
    public DEVCHN m_tDevChn;
    public UInt32 m_eRecType;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public struct TPeriod
{
    public UInt32 m_dwStartTime;
    public UInt32 m_dwEndTime;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public struct EVENTINFO
{
    public UInt32 m_dwErrorCode;
    public UInt32 m_emWork;
    public UInt32 m_dwWorkID;
    public UInt32 m_dwReserve1;
    public UInt32 m_dwReserve2;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public struct IDs
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
    public byte[] szID;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public struct VIDSRC
{
    public int nSn; // Video Source id(No.)
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 257)]
    public byte[] szSrcName; // video source alias
    public int nPtzLevel; // video source ptz level
    public int bFitCondition;//add by xw.
    public int bChanIsOnline;//add by xw.
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public struct DeviceInfo
{
    public int nSn; // device sn, create by mcusdk (nouse in this version)
    public IDs deviceID; // device id, from plat
    public IDs domainID; // domain id, from plat
    public UInt16 nDevSrcNum; // device video source number
    public UInt16 nEncoderChnNum; // device encoder channel number
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 257)]
    public byte[] szDevSrcAlias; // device alias
    public UInt16 nDevType; // device type
    public UInt16 nDevCap; // device capability
    public UInt16 nCallType; // device call type
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
    public VIDSRC[] aDevSrcChn; // device video source infomation
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 257)]
    public byte[] szManufacturer; // device manufacturer
    public int bDvcIsOnline;//add by xw.
    public IDs parentGroupID;//add by xw.
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public struct DeviceGroupInfo
{
    public IDs groupID; // group id, from plat
    public IDs parentID; // parent group id, from plat
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 257)]
    public byte[] szGroupName; // group name, from plat
    public bool bHasDevice; // is the group has device, from plat
}

[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 17)]
public struct DeviceStatus1
{
    [FieldOffset(0)]
    public eStatusType m_emStatusType; // device status type
    [FieldOffset(4)]
    public UInt32 m_bOnline; // device online: 1 offline: 0
}

[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 17)]
public struct DeviceStatus2
{
    [FieldOffset(0)]
    public eStatusType m_emStatusType; // device status type
    [FieldOffset(4)]
    public UInt32 m_dwAlarmType; // alarm type
    [FieldOffset(8)]
    byte m_byAlarmStatus; // alarm status: Occur, resume
    [FieldOffset(9)]
    public UInt32 m_dwTime; // alarm Occur or Resume time
    [FieldOffset(11)]
    public UInt32 m_wAlarmChn; // 
    [FieldOffset(15)]
    public UInt32 m_bOnline;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public struct TSUBSDEVS
{
    public byte m_bySubsDevNum; // subscript device number
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
    public IDs[] m_vctDevID; // subscript device id
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public struct DEVCHN
{
    public IDs domainID; //device domain id
    public IDs deviceID; // device id
    public UInt16 nSrc; // device source No.
    public UInt16 nChn; // device channel No.
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public struct DevGPSInfo
{
    public UInt32 revTime;
    public IDs deviceID; // device id
    public double longitude;
    public double latitude;
    public double marLongitude;
    public double marLatitude;
    public double speed;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public struct PTZCMD
{
    public UInt32 m_emPtzCmd; // ptz command
    public UInt16 m_wPtzRange; // ptz range
    public byte m_byLevel; // device source ptz level (option)
    public UInt32 m_dwHoldTimer; // ptz hold time (option)
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public struct POINTMOVE
{
    public UInt16 m_wPosX; // position x coordinate in screen
    public UInt16 m_wPosY; // position y coordinate in screen
    public UInt16 m_wScreenWidth; // screen width
    public UInt16 m_wScreenHeight; // screen height
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public struct TVidOSD
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
    public byte[] abyContent;
    public UInt16 wLeftMargin; // device channel No.
    public UInt16 wTopMargin; // device source No.
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
// stream parameter
public struct SPARAM
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 257)]
    public byte[] m_szServerIp;// connect stream server ip(no use now)
    public UInt16 m_wServerPort;				 // connect stream server port(no use now)

    public UInt16 m_wScreenWidth;				 // play screen width
    public UInt16 m_wScreenHeight;				 // play screen height

    public IntPtr m_pDrawWnd; // play window handle

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 257)]
    public byte[] m_szManufactor; // device manufactor
    //Add by xql 20140825
    public UInt32 m_wHighDefinition;
    //end

    //add by xql 20141008
    public UInt32 m_emVideoType;
    public UInt32 m_startTime;
    public UInt32 m_endTime;
    public UInt32 m_playTime;
    public UInt32 m_byRecordType;
    //end
    public UInt32 m_dwDownloadStartTime;
    public UInt32 m_dwDownloadEndTime;
    public UInt32 m_dwDownloadFirstPlayTime; //用于跨文件计算下载进度
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode, Size = 32)]
//Frame Header Structure
public struct PFRAMEHDR1
{
    public byte m_byMediaType; // media type ( eRecvStreamType )
    //public UInt32 m_pData;       // stream data
    [MarshalAs(UnmanagedType.LPStr)]
    public string m_pData;
    public UInt32 m_dwPreBufSize;
    public UInt32 m_dwDataSize;
    public byte m_byFrameRate;
    public UInt32 m_dwFrameID;
    public UInt32 m_dwTimeStamp;
    public UInt32 m_dwSSRC;
    //union
    //{
    //    struct{
    //        BOOL32    m_bKeyFrame;
    //        u16       m_wVideoWidth;
    //        u16       m_wVideoHeight;
    //    }m_tVideoParam;
    public byte m_byAudioMode;
    //};
}

[StructLayout(LayoutKind.Explicit, Pack = 1, CharSet = CharSet.Unicode)]
public struct PFRAMEHDR2
{
    [FieldOffset(0)]
    public byte m_byAudioMode;
    [FieldOffset(4)]
    public UInt32 m_bKeyFrame;
    [FieldOffset(8)]
    public ushort m_wVideoWidth;
    [FieldOffset(9)]
    public ushort m_wVideoHeight;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
// stream callback
public struct CB_SDKMEDIA
{
    public IntPtr m_pSDKFrameCB; // stream frame callback
    public IntPtr m_pSDKYUVCB; // stream yuv data callback,after decode
    public IntPtr m_pSDKUrlCB; // select stream url callback,for chose an accord url in application
    public UInt32 m_dwSDKUserData; // user data
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
// stream url infomation (from stream server)
public struct URLINFO
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 257)]
    public byte[] m_szUrl; // stream url
    public UInt32 m_dwWidth; // stream width
    public UInt32 m_dwHeight; // stream height
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
    public byte[] m_szDesc; // stream description
    //add by xw
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
    public byte[] m_manuFactory; // stream ManuFactory
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
    public byte[] m_reserve; // stream Reserve
    //end
    public UInt32 m_UrlType;
}

// stream url list
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public struct URLLIST
{
    public byte m_byUrlNum; // url number
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
    public URLINFO[] m_aStreamUrl; // stream url info
}

public enum TRecStat
{
    emRecInvalid = 0,
    emRecIdel = 1,
    emRecOk = 2,
    emRecTry = 3,
    emRecStopping = 4,
};

public enum TRecPlatPuStat
{
    emRecPlatPuInvalid = 0,
    emRecPlat = 1,
    emRecPu = 2,
    emRecPlatPu = 3,
};

public enum eDeviceType // device type
{
    emTypeUnknown = 0,
    emTypeEncoder,
    emTypeDecoder,
    emTypeCodecer,
    emTypeTVWall,
    emTypeNVR,
    emTypeSVR,
    emAlarmHost,
};

public enum EDecoderMod
{
    emDecoderModUnable = 0,
    emBaseDec = 1,
};

public enum EStreamMod
{
    emStreamModUnable = 0,
    emPlat1 = 1,
    emPlat2 = 2,
    emG900 = 3,
};

public enum EBussinessMod
{
    emBussinessModUnable = 0,
    emPlat1BS = 1,
    emPlat2BS = 2,
};

public enum eStatusType
{
    emDevOnline = 0,
    emDevAlarm = 1,
    emDevConfig = 2,
    emDevGpsInfo = 3,
    emDevRecStatus = 4,
    emDevTransDataNtf = 5,
    emTvWallNewNtf = 10,
    emTvWallDelNtf = 11,
    emTvWallModNtf = 12,
    emTvWallStaChgNtf = 13,
};

public enum ESubscriptInfo
{
    emOnline = 0x01,
    emAlarm = 0x02,
    emVidChn = 0x04,
    emDevState = emOnline | emAlarm | emVidChn,
    emGPSInfo = 0x08,
    emAllSub = emDevState | emGPSInfo,
    emTvWallState = 0x100,
    emRecStatus = 0x200,
    emRecvTransData = 0x400,
};

public enum ePtzCmd
{
    emMoveLeft = 0,
    emMoveRight = 1,
    emMoveUp = 2,
    emMoveDown = 3,
    emMoveLeftUp = 4,
    emMoveLeftDown = 5,
    emMoveRightUp = 6,
    emMoveRightDown = 7,
    emMoveStop = 8,
    emZoomIn = 9,
    emZoomOut = 10,
    emZoomStop = 11,
    emHome = 12,
    emAutoScanStart = 128,
    emAutoScanStop = 129,
};

public enum ePlayVideoType
{
    emInvailedVideoPlay = -1,
    emRecordVideoPlay = 0,
    emRealVideoPlay = 1,
    emRecordVideoDownLoad = 2,
    emRecordPlayBySETime = 3,
};
public enum eRecordType
{
    emInvailedRecord = 0,
    emPlatFormRecord = 1,
    emIpcRecord = 2,
    emLocalRecord = 4,
};

public enum EAudioEncType
{
    emInvailed = 0,
    emg711 = 1,
    enaaclc = 2,
    emadpcm = 3,
};

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public struct VideoFrame
{
    public UInt16 dwFrameRate; // YUV data length
    public UInt16 dwWidth; // image width
    public UInt16 dwHeight; // image height

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public UInt16[] strike; // stream url info
}

[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
public struct PFRAMEYUV
{
    //public UInt32 m_pData; // YUV data
    [MarshalAs(UnmanagedType.LPStr)]
    public string pbyRawBuf;
    public UInt32 dwRawlen; // YUV data length
    public UInt32 dwMediaType; // image width
    public UInt32 dwSubMediaType; // image height
    public UInt32 dwFrameIndex; // frame time stamp
    public UInt64 dwNetTimeStamp; // image width
    public UInt64 dwMediaTimeStamp; // image height
    public UInt32 dwMediaEncode; // image width
    public VideoFrame tVideo;
    public UInt16 wBitRate; // image height
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public URLINFO[] wReverse; // stream url info
}

public struct DEVSRC_ST
{
    public bool bEnable; //视频源是否启用
    public bool bOnline; //视频源是否在线
}


public enum EStreamFlowPattern
{
    emStreamPatenTCP = 0,
    emStreamPatenUDP = 1,
    emStreamPatenPIC = 2,
};

public delegate void Stream_Callback(UInt32 dwPlayID, PFRAMEHDR1 pFrmHdr, UInt32 dwContext);
public delegate void StreamYuv_Callback(UInt32 dwPlayID, PFRAMEYUV pFrmYuv, UInt32 dwContext);
public delegate void SelectStreamUrl_Callback(ref URLLIST pUrlList, UInt32 lUserData);

namespace CsharpSDK
{
    public class myAPI
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int cbFreshDevStatusD(IDs id, ref DeviceStatus1 status, UInt32 userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int cbSDKEventCallbackD(ref EVENTINFO info, UInt32 userData);
        //-----------------------------------------------
        [DllImport(@"mcusdk.dll")]
        //创建sdk实例
        public extern static IntPtr Kdm_CreateMcuSdk();
        [DllImport(@"mcusdk.dll")]
        //销毁sdk实例
        public extern static void Kdm_DestroyMcuSdk(IntPtr mcuHandle);
        //-----------------------------------------------

        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        //选择平台
        public extern static EBussinessMod Kdm_PlatTypeDetect(IntPtr mcuHandle, byte[] strnsAddr, ref uint errorCode);

        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        //选择平台
        public extern static uint Kdm_ModualSelect(IntPtr mcuHandle, EBussinessMod emBuss, EStreamMod emStream, EDecoderMod emDec);

        [DllImport(@"mcusdk.dll")]
        //初始化
        public extern static uint Kdm_Init(IntPtr mcuHandle);
        [DllImport(@"mcusdk.dll")]
        //登录
        public extern static uint Kdm_Login(IntPtr mcuHandle, byte[] strUser, byte[] strPassword, byte[] strnsAddr, string strClientType, ref uint errorCode);
        [DllImport(@"mcusdk.dll")]
        //登出
        public extern static uint Kdm_Logout(IntPtr mcuHandle, ref uint errorCode);

        /*[DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        // real stream
        public extern static uint Kdm_SetStreamPattern(IntPtr pMcuHandle, EStreamFlowPattern eStreamPattern, ref uint pErrorCode);*/

        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        // real stream
        public extern static uint Kdm_StartRealPlay(IntPtr pMcuHandle, DEVCHN tDevChn, SPARAM tStreamParam, CB_SDKMEDIA tCbSdkMedia, ref uint pErrorCode);

        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static UInt32 Kdm_StopRealPlay(IntPtr pMcuHandle, UInt32 dwPlayID, ref uint pErrorCode);

        //-----------------------------------------------
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        //获得特定组的“组查询任务ID”
        public extern static uint Kdm_GetGroupByGroup(IntPtr mcuHandle, [In, MarshalAs(UnmanagedType.Struct)] IDs groupID, ref uint errorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        //通过“组查询任务ID”获得组信息
        public extern static uint Kdm_GetGroupNext(IntPtr mcuHandle, uint taskID, ref DeviceGroupInfo groupID, ref uint errorCode);
        [DllImport(@"mcusdk.dll")]
        //获得特定组的“设备查询任务ID”
        public extern static uint Kdm_GetDeviceByGroup(IntPtr mcuHandle, [In, MarshalAs(UnmanagedType.Struct)] IDs groupID, ref uint errorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        //通过“设备查询任务ID”获得设备信息
        public extern static uint Kdm_GetDeviceNext(IntPtr mcuHandle, uint taskID, ref DeviceInfo deviceInfo, ref uint errorCode);

        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        //订阅设备状态
        public extern static uint Kdm_SubscriptDeviceStatus(IntPtr mcuHandle, TSUBSDEVS vctDeviceID, ESubscriptInfo emSbs, ref uint errorCode);
        [DllImport(@"mcusdk.dll")]
        //反订阅设备状态7
        public extern static uint Kdm_UnSubscriptDeviceStatus(IntPtr mcuHandle, TSUBSDEVS vctDeviceID, ESubscriptInfo emSbs, ref uint errorCode);
        [DllImport(@"mcusdk.dll", CallingConvention = CallingConvention.StdCall)]
        //获取视频源状态
        public extern static uint Kdm_GetDevSrcStatus(IntPtr mcuHandle, DEVCHN tDevSrc, ref DEVSRC_ST srcStatus, ref uint errorCode);
        [DllImport(@"mcusdk.dll")]
        //设置设备状态的回调函数
        public extern static unsafe uint Kdm_SetDevStatusCallback(IntPtr mcuHandle, cbFreshDevStatusD cbFunc, UInt32 deUserData);
        [DllImport(@"mcusdk.dll")]
        public extern static uint Kdm_SetSaveLogFile(IntPtr mcuHandle, uint mSaveFlag, byte[] filename);
        [DllImport(@"mcusdk.dll")]
        public extern static uint Kdm_SetScreenShowLog(IntPtr mcuHandle, uint dwShowLogLev);

        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        //获取设备的GPS信息
        public extern static uint Kdm_GetDevGpsInfo(IntPtr mcuHandle, DEVCHN tDevChn, ref DevGPSInfo devGpsInfo, ref uint errorCode);

        //PTZ Control
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_SendPtzControl(IntPtr mcuHandle, DEVCHN tDevChn, PTZCMD tPtzCmd, ref uint errorCode);

        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_SendPointMoveControl(IntPtr mcuHandle, DEVCHN tDevChn, POINTMOVE tPointCmd, ref uint errorCode);

        //Voice call
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static UInt32 Kdm_StartVoiceCall(IntPtr mcuHandle, DEVCHN temDevchn, EAudioEncType temAudioEncType, ref uint errorCode);

        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_StopVoiceCall(IntPtr mcuHandle, UInt32 dwPlayID, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_SetSDKEventCallback(IntPtr pMcuHandle, cbSDKEventCallbackD EventCBFunc, UInt32 dwUserData);
        //-----------------------------------------------
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_CreateRecordTask(IntPtr pMcuHandle, [In, MarshalAs(UnmanagedType.Struct)] DEVCHN tDevChn, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_PreLoadRecord(IntPtr pMcuHandle, UInt32 dwTaskID, [In, MarshalAs(UnmanagedType.Struct)] TPeriod tPreLoadTime, UInt32 ERecType, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_GetRecordNext(IntPtr pMcuHandle, UInt32 dwTaskID, UInt32 dwSeekTime, ref TRecordInfo pRecordInfo, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_DestroyRecordTask(IntPtr pMcuHandle, UInt32 dwTaskID);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_StartRecordPlay(IntPtr pMcuHandle, UInt32 dwTaskID, UInt32 dwPlayTime, SPARAM stSparam, CB_SDKMEDIA tCbSdkMedia, ref UInt32 pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_StopRecordPlay(IntPtr pMcuHandle, UInt32 dwPlayID, ref UInt32 pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_PlayRecordBySETime(IntPtr pMcuHandle, UInt32 dwTaskID, TRecordPlayInfo tRecordPlayInfo, CB_SDKMEDIA tCbSdkMedia, ref uint pErrorCode);
        //-----------------------------------------------
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_GetTVWallTotal(IntPtr mcuHandle, ref int TvWalltotalNum, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_GetTVWall(IntPtr mcuHandle, uint tvWallIdx, ref TTvWallInfoData tTvWallInfo, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public unsafe extern static char* Kdm_CreateTVWall(IntPtr pMcuHandle, TTvWallInfoData CreatTvWallReq, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public unsafe extern static uint Kdm_DelTVWall(IntPtr pMcuHandle, byte[] tvWallId, byte[] tvWallName, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_ModifyTVWall(IntPtr pMcuHandle, TTvWallInfoData tTvWallInfo, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_GetTVWallById(IntPtr pMcuHandle, byte[] tvWallId, ref TTvWallInfoData tTvWallInfo, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_GetTVDivNum(IntPtr pMcuHandle, byte[] tvWallId, int tvId, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_SetTVDivNum(IntPtr pMcuHandle, TTvDivNumData tvSetDivNumData, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_TVWallStartPlay(IntPtr pMcuHandle, TTvWallPlayData tvWallStartPlyData, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_TVWallStopPlay(IntPtr pMcuHandle, TTvWallPlayData tvWallStopPlyData, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_TVWallStartPlayRecord(IntPtr pMcuHandle, UInt32 dwPlayID, TTvWallCommonData tvWallComData, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_TVWallStopPlayRecord(IntPtr pMcuHandle, UInt32 dwPlayID, TTvWallCommonData tvWallComData, ref uint pErrorCode);
        //-------------------------------------------------
        /*[DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_PlatTypeDetect(IntPtr pMcuHandle, byte[] strnsAddr, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_ModualSelect(IntPtr pMcuHandle, UInt32 emBuss, UInt32 emStream, UInt32 emDec);*/
        //-------------------------------------------------
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_TVWallQuerySchemeTotal(IntPtr pMcuHandle, byte[] tvWallId, ref int tvWallSchemeTotal, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_TVWallQueryScheme(IntPtr pMcuHandle, int SchIndx, ref TTvWallScheme tvWallScheme, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_TVWallLoadScheme(IntPtr pMcuHandle, byte[] tvWallId, byte[] SchemeName, UInt32 bLoadWithSave, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_TVWallModifyScheme(IntPtr pMcuHandle, TTvWallScheme tvWallScheme, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_TVWallDelScheme(IntPtr pMcuHandle, byte[] tvWallId, byte[] SchemeName, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_TVWallCreatScheme(IntPtr pMcuHandle, TTvWallScheme tvWallScheme, ref uint pErrorCode);
        //-------------------------------------------------
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_SetStreamPattern(IntPtr pMcuHandle, EStreamFlowPattern eStreamPattern, ref uint pErrorCode);
        //-------------------------------------------------
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_StartRecordDownLoad_V2(IntPtr pMcuHandle, UInt32 dwTaskID, TRecordDownloadInfo_V2 tDownloadInfo, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_StopRecordDownLoad(IntPtr pMcuHandle, UInt32 dwPlayID, ref uint pErrorCode);
        //-------------------------------------------------
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_SendPtzPreSet(IntPtr pMcuHandle, DEVCHN tDevChn, int tPreSetPosition, TPTZAUTHORITY tPtzAuthority, ref uint pErrCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_TaskWatcher(IntPtr pMcuHandle, DEVCHN tDevChn, TWatchTask tWatchTask, ref uint pErrCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_PrePosWatcher(IntPtr pMcuHandle, DEVCHN tDevChn, TWatchPrePos tWatchPrePos, ref uint pErrCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_SetUpStreamTrans(IntPtr pMcuHandle, DEVCHN tDevChn, TStreamTramLocal tStrTranLoc, ref TStreamTranRemote tStrTranRemote, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_StartStreamTrans(IntPtr pMcuHandle, UInt32 StrTranId, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_StopStreamTrans(IntPtr pMcuHandle, UInt32 StrTranId, ref uint pErrorCode);
        //[DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        //public extern static uint Kdm_GetDevGpsInfo(IntPtr pMcuHandle, DEVCHN tDevChn, ref DevGPSInfo tDevGpsInfo,ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_GetDevLatiLongTude(IntPtr pMcuHandle, DEVCHN tDevChn, ref TDevLatiLongTude tDevLatiLongtude, ref uint pErrorCode);
        // plat rec.
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_StartPlatRec(IntPtr pMcuHandle, DEVCHN tDevChn, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_StopPlatRec(IntPtr pMcuHandle, DEVCHN tDevChn, ref uint pErrorCode);

        // pu rec.
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_StartPuRec(IntPtr pMcuHandle, DEVCHN tDevChn, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_StopPuRec(IntPtr pMcuHandle, DEVCHN tDevChn, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_GetPuEncoderParam(IntPtr pMcuHandle, DEVCHN tDevChn, ref TEncoderParamTotal pEncoderParamTotal, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll", CharSet = CharSet.Auto)]
        public extern static uint Kdm_SetPuEncoderParam(IntPtr pMcuHandle, DEVCHN tDevChn, ref TEncoderParam pEncoderParam, ref uint pErrorCode);
        [DllImport(@"mcusdk.dll")]
        public extern static uint Kdm_RecordPlayCtrl(IntPtr pMcuHandle, TREPCTLINFO stRecPlyInfo, ref uint pErrorCode);

        [DllImport(@"mcusdk.dll")]
        //设置OSD信息
        public extern static uint Kdm_SetVideoOSD(IntPtr mcuHandle, DEVCHN tDevChn, TVidOSD tInfo, ref uint errorCode);

        [DllImport(@"mcusdk.dll")]
        //抓拍
        public extern static uint Kdm_SaveSnapshot(IntPtr mcuHandle, UInt32 dwPlayID, byte[] strPicName, UInt32 emPicType);

        [DllImport(@"mcusdk.dll")]
        //根据deviceID获取录像状态，设备需要先订阅emRecStatus，回调类型为emDevRecStatus
        public extern static uint Kdm_GetDevRecordStatus(IntPtr mcuHandle, IDs deviceID, ref TDevRecordStatus tDevSrcStat, ref uint errorCode);
    }
}