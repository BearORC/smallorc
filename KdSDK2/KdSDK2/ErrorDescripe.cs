using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum errCode_Text
{
    MCU_RECORD_ERR_CU_ErrBegin = 16000, //错误码从16000开始。
    MCU_RECORD_ERR_CU_ErrUnkown,		//16001 未知错误
    MCU_RECORD_ERR_CU_ErrNotSupport,				// 16002 不支持这个功能
    MCU_RECORD_ERR_CU_ErrInvalidParam,				// 16003 错误的参数
    MCU_RECORD_ERR_CU_ErrAlreadyLogin,				// 16004 已经登录，重复登录
    MCU_RECORD_ERR_CU_ErrNotLogin,					// 16005 没有登录
    MCU_RECORD_ERR_CU_ErrConnectFail,				// 16006 连接失败
    MCU_RECORD_ERR_CU_ErrDeviceNotFinish,			// 16007 设备获取未完成
    MCU_RECORD_ERR_CU_ErrUserListNotFinish,		// 16008 用户列表没有完成
    MCU_RECORD_ERR_CU_ErrDeviceGroupNotExist,		// 16009 设备组不存在
    MCU_RECORD_ERR_CU_ErrDeviceNotExist,			// 16010 设备不存在
    MCU_RECORD_ERR_CU_ErrVideoSrcNotExist,			// 16011 视频源不存在
    MCU_RECORD_ERR_CU_ErrEncoderChnNotExist,		// 16012 编码通道不存在
    MCU_RECORD_ERR_CU_ErrPtzCustomCmdAlreadyExist,	// 16013 自定义PTZ命令已经存在
    MCU_RECORD_ERR_CU_ErrPtzCustomCmdNotExist,		// 16014 自定义PTZ命令不存在
    MCU_RECORD_ERR_CU_ErrConfigInvalid,			// 16015 配置参数非法
    MCU_RECORD_ERR_CU_ErrDecoderNotCreated,	    // 16016 解码器还没有创建
    MCU_RECORD_ERR_CU_ErrDecoderFail,			    // 16017 解码器操作失败
    MCU_RECORD_ERR_CU_ErrDecoderNotSupport,	    // 16018 解码器不支持这个功能（外厂商的解码器很多功能都没有）
    MCU_RECORD_ERR_CU_ErrNatPunchFail,			    // 16019 Nat打洞失败
    MCU_RECORD_ERR_CU_ErrPortAssignedAlready,	    // 16020 端口已经分配
    MCU_RECORD_ERR_CU_ErrXMLParseFail,		        // 16021 XML解析失败
    MCU_RECORD_ERR_CU_ErrSaveConfigFail,	        // 16022 保存配置失败
    MCU_RECORD_ERR_CU_ErrNotConfigured,	        // 16023 没有配置过，比如没有配置过预案轮巡，没有配置过当前预案等
    MCU_RECORD_ERR_CU_ErrNotPlay,		            // 16024 没有播放
    MCU_RECORD_ERR_CU_ErrAlreadyRecord,            // 16025 已经开启录像
    MCU_RECORD_ERR_CU_ErrAssignedPortFail,         // 16026 分配端口失败
    MCU_RECORD_ERR_CU_ErrStartLocalRecFail,        // 16027 本地录像失败
    MCU_RECORD_ERR_CU_ErrDecoderStatisFail,        // 16028 获取码流信息失败
    MCU_RECORD_ERR_CU_ErrNotFound,                 // 16029 没有找到
    MCU_RECORD_ERR_CU_ErrCreateDirFail,            // 16030 创建目录失败
    MCU_RECORD_ERR_CU_ErrGetFileFail,              // 16031 获取文件列表失败
    MCU_RECORD_ERR_CU_ErrRecordPlayEnd,			// 16032 录像播放结束
    MCU_RECORD_ERR_CU_ErrEncoderNotCreated,	    // 16033 编码器还没有创建
    MCU_RECORD_ERR_CU_ErrEncoderFail,              // 16034 编码器操作失败
    MCU_RECORD_ERR_CU_ErrRpctrlError,              // 16035 录像下载组件内部错误
    MCU_RECORD_ERR_CU_ErrRecordDownloadNotCreated,	// 16036 录像下载器没有创建
    MCU_RECORD_ERR_CU_ErrRecordOutRange,			// 16037 超出录像范围
    MCU_RECORD_ERR_CU_ErrPUCallNotSupport,         // 16038 设备不支持音频呼叫
    MCU_RECORD_ERR_CU_ErrCalledByOthers,           // 16039 该视频源正在被其他人呼叫
    MCU_RECORD_ERR_CU_ErrAlarmLinkNotFinish,       // 16040 告警联动配置列表缓存未完成
    MCU_RECORD_ERR_CU_ErrTimeOutOrNotSupport,      // 16041 超时或者不支持
    MCU_RECORD_ERR_CU_ErrGetConfigFail,            // 16042 获取配置失败
    MCU_RECORD_ERR_CU_ErrInvalidMediaFormat,		// 16043 无效的媒体格式
    MCU_RECORD_ERR_CU_ErrInvalidTransChannel,		// 16044 无效的传输通道
    MCU_RECORD_ERR_CU_ErrInvalidNetAddr,           // 16045 非法的网络地址
    MCU_RECORD_ERR_CU_ErrDeviceOffline,			// 16046 设备不在线
    MCU_RECORD_ERR_CU_ErrDatabaseNotInited,		// 16047 数据库没有初始化
    MCU_RECORD_ERR_CU_ErrDeviceGroupAlreadyExist,	// 16048 设备组已经存在了
    MCU_RECORD_ERR_CU_ErrDatabaseException,		// 16049 数据库出现异常
    MCU_RECORD_ERR_CU_ErrExceedMaxLocalRecNum,		// 16050 超过了最大录像数目
    MCU_RECORD_ERR_CU_ErrRecordDownloaderBusy,		// 16051 录像下载器正在下载
    MCU_RECORD_ERR_CU_ErrStartLocalRecWithSameChn, // 16052 同一时间对同一个通道开启多路本地录像
    MCU_RECORD_ERR_CU_ErrQueryMappedAddrFailed,    // 16053 查询本地端口的外网地址失败
    MCU_RECORD_ERR_CU_ErrSpaceOverLoad,            // 16054 磁盘空间不足
    MCU_RECORD_ERR_CU_ErrPuChnBindNotFinish,       // 16055 录像绑定磁盘分区获取未完成
    MCU_RECORD_ERR_CU_ErrTimeRangeInvalid,			// 16056 无效的时间段
    MCU_RECORD_ERR_CU_ErrCreateIPCFailed,			// 16057 创建管道失败
    MCU_RECORD_ERR_CU_ErrCreateProcessFailed,		// 16058 创建编解码进程失败
    MCU_RECORD_ERR_CU_ErrLocked,					// 16059 其他的处理正忙，锁定中
    MCU_RECORD_ERR_CU_Err_RD_OK,					// 16060 录像下载操作成功
    MCU_RECORD_ERR_CU_Err_RD_ERR,					// 16061 录像下载操作失败
    MCU_RECORD_ERR_CU_Err_RD_WRITE_DATA_ERR,		// 16062 录像下载写数据错误
    MCU_RECORD_ERR_CU_Err_RD_TIMEOUT,				// 16063 录像下载超时
    MCU_RECORD_ERR_CU_Err_RD_DOWNLOAD_FAIL,		// 16064 录像下载失败
    MCU_RECORD_ERR_CU_Err_RD_DOWNLOADING,			// 16065 录像下载正在进行
    MCU_RECORD_ERR_CU_Err_RD_QUERY_INVALID,		// 16066 录像下载请求不合法
    MCU_RECORD_ERR_CU_Err_RD_DOWNLOAD_END,			// 16067 录像下载结束
    MCU_RECORD_ERR_CU_Err_RD_DOWNLOAD_START,		// 16068 录像下载开始
    MCU_RECORD_ERR_CU_Err_RD_DOWNLOAD_CANCEL,		// 16069 录像下载取消
    MCU_RECORD_ERR_CU_Err_RD_DOWNLOAD_WAITING,		// 16070 录像下载等待开始
    MCU_RECORD_ERR_CU_Err_RD_NOREC_SELPER,			// 16071 所选时段没有录像文件存在
    MCU_RECORD_ERR_CU_Err_RD_GETDLPARAM_ERR,		// 16072 获取下载参数失败
    MCU_RECORD_ERR_CU_Err_RD_GETFILEPARAM_ERR,		// 16073 录像下载获取文件参数失败
    MCU_RECORD_ERR_CU_Err_RD_CREATEFTP_ERR,		// 16074 录像下载创建FTP失败，譬如说端口被占用等
    MCU_RECORD_ERR_CU_Err_RD_STARTREV_ERR,			// 16075 录像下载开始接收文件数据失败
    MCU_RECORD_ERR_CU_Err_RD_GETINTERFACE_ERR,		// 16076 录像下载获取录像接口失败
    MCU_RECORD_ERR_CU_Err_RD_GETRTCPPORT_ERR,		// 16077 录像下载获取RTCP端口失败
    MCU_RECORD_ERR_CU_Err_RD_DOWNLOAD_REQ_ERR,		// 16078 录像下载请求下载失败
    MCU_RECORD_ERR_CU_Err_RD_DLEND_BYIDLECHK,		// 16079 录像下载空闲监测导致下载结束
    MCU_RECORD_ERR_CU_Err_RD_File_Empty,			// 16080 录像文件是空的
    MCU_RECORD_ERR_CU_ErrNotGetData,               // 16081 还没有获取到数据
    MCU_RECORD_ERR_CU_ErrPlayOver,                 // 16082 播放结束
    MCU_RECORD_ERR_CU_ErrReversePlayFailed,        // 16083 倒放失败
    MCU_RECORD_ERR_CU_ErrNoPermission,				// 16084 没有权限
    MCU_RECORD_ERR_CU_ErrNoRecordFile,				// 16085 没有可播放录像（为了和录像播放器转跳到没有录像的位置的那个错误码区分出来，这样cu界面才能知道是因为还没有添加录像而播放失败还是因为转跳失败不能播放，从而给出正确的提示）
    MCU_RECORD_ERR_CU_ErrOpenProcessFailed,		// 16086 打开进程并获得进程的句柄失败
    MCU_RECORD_ERR_CU_ErrTerminateProcessFailed,	// 16087 关闭一个解码器进程失败
    MCU_RECORD_ERR_CU_Err_RD_CreateDecoder_Failed,	// 16088 下载录像创建解码器失败
    MCU_RECORD_ERR_CU_ErrStartPlayRecordFileFailed,// 16089 开启本地录像失败
    MCU_RECORD_ERR_CU_ErrStopPlayRecordFileFailed,	// 16090 停止本地录像失败
    MCU_RECORD_ERR_CU_ErrLocalRecordFileIsPlaying,	// 16091 播放状态下不能改变本地录像文件路径
    MCU_RECORD_ERR_CU_ErrSnapShotCreateFileNameFailed, // 16092 无法生成抓拍图片文件名
    MCU_RECORD_ERR_CU_ErrManuNoSupport,			// 16093 没有找到该厂商的解码插件或者厂商名错误
    MCU_RECORD_ERR_CU_ErrNameExist,                // 16094 名称已经存在
    MCU_RECORD_ERR_CU_ErrNoAudioInputDevice,		// 16095 没有语音输入设备
    MCU_RECORD_ERR_CU_ErrSaveRecordFileFail,		// 16096 保存录像文件失败
    MCU_RECORD_ERR_CU_ErrPrerecordDisabled,		// 16097 预录没有开启
    MCU_RECORD_ERR_CU_ErrGetG900InfoFail,			// 16098 获取G900信息失败
    MCU_RECORD_ERR_CU_ErrGetDeviceGBIDFail,		// 16099 查询设备的GBID失败
    MCU_RECORD_ERR_CU_ErrInitStreamMediaFail,		// 16100 用mediasdk创建TCP组件失败

    MODUAL_INVALID = 60001, // 无效模块
    TASK_INVALID, // 无效任务
    TASK_CREATE_ERROR, // 创建任务失败
    INPUT_ERROR, // 输入错误
    GET_DATA_ERROR, // 获取数据错误
    NET_ERROR, // 网络错误
    SNAPSHOT_ERROR, //抓拍错误
    DGROUP_ROOT_INFO_ERROR,//DGROUP_Root信息错误

    //add by xql 20140916 for startplay error
    MCU_PLAYER_ERR_MVC_CONNECT_MVS_FAILED = 10120,//MVC连接MVS时TCP链路建链失败
    MCU_PLAYER_ERR_STREAM_GET_IDLE_STREAM = 61000,//传输模块分配空闲失败
    MCU_PLAYER_ERR_DECODER_GET_IDLE_DECODER = 61001,//解码模块分配空闲失败
    MCU_PLAYER_ERR_DECODER_CREATE = 61002,			//解码器创建失败
    MCU_PLAYER_ERR_DECODER_START_PLAY_STREAM = 61003,//启动解码模块失败
    MCU_PLAYER_ERR_DECODER_START_PLAY_WND = 61004,//显示模块初始化失败
    MCU_PLAYER_ERR_CONVERT_GB_DEVICED_ID = 61005,//devicedID转国标ID失败
    MCU_PLAYER_ERR_G900_INIT_FAIL = 61006,			//G900模块初始化失败
    MCU_PLAYER_ERR_FROM_G900_GET_URL = 61007,		//从G900获取URL失败
    MCU_PLAYER_ERR_G900_START_REQ_FAIL = 61008,	//G900模块发送浏览请求失败

    MUC_PLAYER_ERR_NO_KEY_FRAME_COME = 61100,//码流关键帧没有过来
    MCU_PLAYER_ERR_CONNECT_MVC_FAIL = 61102,//MVC连接MVS失败
    MCU_PLAYER_ERR_DISCONNECT_MVC_NTF = 61105,//收到MVS断链通知
    MCU_PLAYER_ERR_CONNECT_MVC_TIMEOUT = 61106,//MVC连接MVS超时

    MCU_PLAYER_ERR_G900_ERR_FAIL = 61901,			//G900错误
    MCU_PLAYER_ERR_G900_ERR_UNINIT = 61902,			//G900未初始化
    MCU_PLAYER_ERR_G900_ERR_UNCONNECT = 61903, //未连接G900
    MCU_PLAYER_ERR_G900_ERR_PARAM = 61904,			//G900参数错误
    MCU_PLAYER_ERR_G900_ERR_INVALID_PLAYEID = 61905,	//G900 playid无效
    MCU_PLAYER_ERR_G900_TIMEOUT = 61906,						//G900请求超时
    //end


    //录像文件错误码
    MCU_RECORD_QUERY_RECORD_THREAD_NOT_NULL = 62000,	//查询录像文件线程已存在
    MCU_ERRCODE_QUERY_RECORD_TASKID_NOT_EXITS = 62001, //查询平台录像的taskID不存在
    MCU_ERRCODE_QUERY_RECORD_MANAGER_NULL = 62002,//查询平台录像时数据管理模块为NULL
    MCU_ERRCODE_QUERY_RECORD_MANAGER_GET_DATA_NULL = 62003,//查询平台录像时数据管理模块获取数据为NULL
    MCU_ERRCODE_QUERY_RECORD_QUERY_REQ_FAILED = 62004,	//查询平台录像出现错误
    MCU_ERRCODE_QUERY_RECORD_QUERY_RSP_FAILED = 62005,//查询平台录像返回结果出现错误
    MCU_ERRCODE_QUERY_RECORD_QUERY_NUM_ZERO = 62006,//平台从20获取的录像文件个数为0
    MCU_ERRCODE_RECORD_SEEK_TIME_OUT_RANG = 62007,//vcr操作时seektime时间跨文件
    MCU_ERRCODE_RECORD_STOP_PLAY_NTF = 62008,//收到MVS录像回放停止通知
    MCU_ERRCODE_RECORD_TYPE_WRONG = 62009,//录像类型参数错误
    MCU_ERRCODE_RECORD_GET_DEV_CHN_WRONG = 62010,//录像回放时查询设备信息错误
    MCU_ERRCODE_RECORD_GET_TIME_RANGE = 62011,//录像回放时获取录像开始结束时间错误

    //搜索设备错误码
    MCU_SEARCH_DVC_OK = 62100,	//MCU_SEARCH_DVC_OK
    MCU_SERACH_DVC_THREAD_EXITS = 62101, //查询录像文件线程已存在
    MCU_SERACH_DVC_NO_DEVICES = 62102, //MCU_SERACH_DVC_NO_DEVICES
    //录像下载错误码
    MCU_RECORD_ERR_CREATE_KEDAPLAYER_ERR = 62110,//录像下载创建kedaplayer错误
    MCU_RECORD_ERR_PLATFORM_CONNECT_FAIL = 62111,//录像下载连接平台出错
    MCU_RECORD_ERR_PLATFORM_DIRCRIPTION_NULL = 62112,//录像下载描述文件为空
    MCU_RECORD_ERR_LOCAL_DISK_FULL = 62113,//本地磁盘空间已满
    MCU_RECORD_ERR_LOCAL_FULL_NAME_NULL = 62114,//本地保存文件名为空
    //
    OCX_INIT_ERR = 66000,//初始化错误
    OCX_WAIT_REC_OVERTIME,//录像查询等待结束标志超时
    OCX_UNINIT_ERR,//反初始化错误
};

namespace SimpleTest
{
    class ErrorDescripe
    {
        static public string errDesc(uint errCode)
        {
            string errText = "";

            switch ((errCode_Text)errCode)
            {
                case errCode_Text.MCU_RECORD_ERR_CU_ErrBegin:
                    errText = "错误码从16000开始";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrUnkown:
                    errText = "未知错误";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrNotSupport:
                    errText = "不支持这个功能";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrInvalidParam:
                    errText = "错误的参数";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrAlreadyLogin:
                    errText = "已经登录，重复登录";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrNotLogin:
                    errText = "没有登录";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrConnectFail:
                    errText = "连接失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrDeviceNotFinish:
                    errText = "设备获取未完成";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrUserListNotFinish:
                    errText = "用户列表没有完成";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrDeviceGroupNotExist:
                    errText = "设备组不存在";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrDeviceNotExist:
                    errText = "设备不存在";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrVideoSrcNotExist:
                    errText = "视频源不存在";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrEncoderChnNotExist:
                    errText = "编码通道不存在";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrPtzCustomCmdAlreadyExist:
                    errText = "自定义PTZ命令已经存在";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrPtzCustomCmdNotExist:
                    errText = "自定义PTZ命令不存在";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrConfigInvalid:
                    errText = "配置参数非法";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrDecoderNotCreated:
                    errText = "解码器还没有创建";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrDecoderFail:
                    errText = "解码器操作失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrDecoderNotSupport:
                    errText = "解码器不支持这个功能（外厂商的解码器很多功能都没有）";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrNatPunchFail:
                    errText = "Nat打洞失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrPortAssignedAlready:
                    errText = "端口已经分配";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrXMLParseFail:
                    errText = "XML解析失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrSaveConfigFail:
                    errText = "保存配置失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrNotConfigured:
                    errText = "没有配置过，比如没有配置过预案轮巡，没有配置过当前预案等";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrNotPlay:
                    errText = "没有播放";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrAlreadyRecord:
                    errText = "已经开启录像";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrAssignedPortFail:
                    errText = "分配端口失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrStartLocalRecFail:
                    errText = "本地录像失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrDecoderStatisFail:
                    errText = "获取码流信息失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrNotFound:
                    errText = "没有找到";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrCreateDirFail:
                    errText = "创建目录失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrGetFileFail:
                    errText = "获取文件列表失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrRecordPlayEnd:
                    errText = "录像播放结束";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrEncoderNotCreated:
                    errText = "编码器还没有创建";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrEncoderFail:
                    errText = "编码器操作失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrRpctrlError:
                    errText = "录像下载组件内部错误";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrRecordDownloadNotCreated:
                    errText = "录像下载器没有创建";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrRecordOutRange:
                    errText = "超出录像范围";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrPUCallNotSupport:
                    errText = "设备不支持音频呼叫";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrCalledByOthers:
                    errText = "该视频源正在被其他人呼叫";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrAlarmLinkNotFinish:
                    errText = "告警联动配置列表缓存未完成";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrTimeOutOrNotSupport:
                    errText = "超时或者不支持";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrGetConfigFail:
                    errText = "获取配置失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrInvalidMediaFormat:
                    errText = "无效的媒体格式";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrInvalidTransChannel:
                    errText = "无效的传输通道";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrInvalidNetAddr:
                    errText = "非法的网络地址";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrDeviceOffline:
                    errText = "设备不在线";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrDatabaseNotInited:
                    errText = "数据库没有初始化";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrDeviceGroupAlreadyExist:
                    errText = "设备组已经存在了";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrDatabaseException:
                    errText = "数据库出现异常";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrExceedMaxLocalRecNum:
                    errText = "超过了最大录像数目";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrRecordDownloaderBusy:
                    errText = "录像下载器正在下载";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrStartLocalRecWithSameChn:
                    errText = "同一时间对同一个通道开启多路本地录像";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrQueryMappedAddrFailed:
                    errText = "查询本地端口的外网地址失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrSpaceOverLoad:
                    errText = "磁盘空间不足";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrPuChnBindNotFinish:
                    errText = "录像绑定磁盘分区获取未完成";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrTimeRangeInvalid:
                    errText = "无效的时间段";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrCreateIPCFailed:
                    errText = "创建管道失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrCreateProcessFailed:
                    errText = "创建编解码进程失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrLocked:
                    errText = "其他的处理正忙，锁定中";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_OK:
                    errText = "录像下载操作成功";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_ERR:
                    errText = "录像下载操作失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_WRITE_DATA_ERR:
                    errText = "录像下载写数据错误";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_TIMEOUT:
                    errText = "录像下载超时";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_DOWNLOAD_FAIL:
                    errText = "录像下载失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_DOWNLOADING:
                    errText = "录像下载正在进行";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_QUERY_INVALID:
                    errText = "录像下载请求不合法";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_DOWNLOAD_END:
                    errText = "录像下载结束";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_DOWNLOAD_START:
                    errText = "录像下载开始";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_DOWNLOAD_CANCEL:
                    errText = "录像下载取消";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_DOWNLOAD_WAITING:
                    errText = "录像下载等待开始";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_NOREC_SELPER:
                    errText = "所选时段没有录像文件存在";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_GETDLPARAM_ERR:
                    errText = "获取下载参数失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_GETFILEPARAM_ERR:
                    errText = "录像下载获取文件参数失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_CREATEFTP_ERR:
                    errText = "录像下载创建FTP失败，譬如说端口被占用等";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_STARTREV_ERR:
                    errText = "录像下载开始接收文件数据失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_GETINTERFACE_ERR:
                    errText = "录像下载获取录像接口失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_GETRTCPPORT_ERR:
                    errText = "录像下载获取RTCP端口失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_DOWNLOAD_REQ_ERR:
                    errText = "录像下载请求下载失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_DLEND_BYIDLECHK:
                    errText = "录像下载空闲监测导致下载结束";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_File_Empty:
                    errText = "录像文件是空的";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrNotGetData:
                    errText = "还没有获取到数据";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrPlayOver:
                    errText = "播放结束";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrReversePlayFailed:
                    errText = "倒放失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrNoPermission:
                    errText = "没有权限";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrNoRecordFile:
                    errText = "没有可播放录像（为了和录像播放器转跳到没有录像的位置的那个错误码区分出来，这样cu界面才能知道是因为还没有添加录像而播放失败还是因为转跳失败不能播放，从而给出正确的提示）";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrOpenProcessFailed:
                    errText = "打开进程并获得进程的句柄失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrTerminateProcessFailed:
                    errText = "关闭一个解码器进程失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_Err_RD_CreateDecoder_Failed:
                    errText = "下载录像创建解码器失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrStartPlayRecordFileFailed:
                    errText = "开启本地录像失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrStopPlayRecordFileFailed:
                    errText = "停止本地录像失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrLocalRecordFileIsPlaying:
                    errText = "播放状态下不能改变本地录像文件路径";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrSnapShotCreateFileNameFailed:
                    errText = "无法生成抓拍图片文件名";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrManuNoSupport:
                    errText = "没有找到该厂商的解码插件或者厂商名错误";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrNameExist:
                    errText = "名称已经存在";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrNoAudioInputDevice:
                    errText = "没有语音输入设备";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrSaveRecordFileFail:
                    errText = "保存录像文件失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrPrerecordDisabled:
                    errText = "预录没有开启";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrGetG900InfoFail:
                    errText = "获取G900信息失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrGetDeviceGBIDFail:
                    errText = "查询设备的GBID失败";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CU_ErrInitStreamMediaFail:
                    errText = "用mediasdk创建TCP组件失败";
                    break;
                case errCode_Text.MODUAL_INVALID:
                    errText = "无效模块";
                    break;
                case errCode_Text.TASK_INVALID:
                    errText = "无效任务";
                    break;
                case errCode_Text.TASK_CREATE_ERROR:
                    errText = "创建任务失败";
                    break;
                case errCode_Text.INPUT_ERROR:
                    errText = "输入错误";
                    break;
                case errCode_Text.GET_DATA_ERROR:
                    errText = "获取数据错误";
                    break;
                case errCode_Text.NET_ERROR:
                    errText = "网络错误";
                    break;
                case errCode_Text.SNAPSHOT_ERROR:
                    errText = "抓拍错误";
                    break;
                case errCode_Text.DGROUP_ROOT_INFO_ERROR:
                    errText = "DGROUP_Root信息错误";
                    break;
                case errCode_Text.MCU_PLAYER_ERR_MVC_CONNECT_MVS_FAILED:
                    errText = "MVC连接MVS时TCP链路建链失败";
                    break;
                case errCode_Text.MCU_PLAYER_ERR_STREAM_GET_IDLE_STREAM:
                    errText = "传输模块分配空闲失败";
                    break;
                case errCode_Text.MCU_PLAYER_ERR_DECODER_GET_IDLE_DECODER:
                    errText = "解码模块分配空闲失败";
                    break;
                case errCode_Text.MCU_PLAYER_ERR_DECODER_CREATE:
                    errText = "解码器创建失败";
                    break;
                case errCode_Text.MCU_PLAYER_ERR_DECODER_START_PLAY_STREAM:
                    errText = "启动解码模块失败";
                    break;
                case errCode_Text.MCU_PLAYER_ERR_DECODER_START_PLAY_WND:
                    errText = "显示模块初始化失败";
                    break;
                case errCode_Text.MCU_PLAYER_ERR_CONVERT_GB_DEVICED_ID:
                    errText = "devicedID转国标ID失败";
                    break;
                case errCode_Text.MCU_PLAYER_ERR_G900_INIT_FAIL:
                    errText = "G900模块初始化失败";
                    break;
                case errCode_Text.MCU_PLAYER_ERR_FROM_G900_GET_URL:
                    errText = "从G900获取URL失败";
                    break;
                case errCode_Text.MCU_PLAYER_ERR_G900_START_REQ_FAIL:
                    errText = "G900模块发送浏览请求失败";
                    break;
                case errCode_Text.MUC_PLAYER_ERR_NO_KEY_FRAME_COME:
                    errText = "码流关键帧没有过来";
                    break;
                case errCode_Text.MCU_PLAYER_ERR_CONNECT_MVC_FAIL:
                    errText = "MVC连接MVS失败";
                    break;
                case errCode_Text.MCU_PLAYER_ERR_DISCONNECT_MVC_NTF:
                    errText = "收到MVS断链通知";
                    break;
                case errCode_Text.MCU_PLAYER_ERR_CONNECT_MVC_TIMEOUT:
                    errText = "MVC连接MVS超时";
                    break;
                case errCode_Text.MCU_PLAYER_ERR_G900_ERR_FAIL:
                    errText = "G900错误";
                    break;
                case errCode_Text.MCU_PLAYER_ERR_G900_ERR_UNINIT:
                    errText = "G900未初始化";
                    break;
                case errCode_Text.MCU_PLAYER_ERR_G900_ERR_UNCONNECT:
                    errText = "未连接G900";
                    break;
                case errCode_Text.MCU_PLAYER_ERR_G900_ERR_PARAM:
                    errText = "G900参数错误";
                    break;
                case errCode_Text.MCU_PLAYER_ERR_G900_ERR_INVALID_PLAYEID:
                    errText = "G900 playid无效";
                    break;
                case errCode_Text.MCU_PLAYER_ERR_G900_TIMEOUT:
                    errText = "G900请求超时";
                    break;
                case errCode_Text.MCU_RECORD_QUERY_RECORD_THREAD_NOT_NULL:
                    errText = "查询录像文件线程已存在";
                    break;
                case errCode_Text.MCU_ERRCODE_QUERY_RECORD_TASKID_NOT_EXITS:
                    errText = "查询平台录像的taskID不存在";
                    break;
                case errCode_Text.MCU_ERRCODE_QUERY_RECORD_MANAGER_NULL:
                    errText = "查询平台录像时数据管理模块为NULL";
                    break;
                case errCode_Text.MCU_ERRCODE_QUERY_RECORD_MANAGER_GET_DATA_NULL:
                    errText = "查询平台录像时数据管理模块获取数据为NULL";
                    break;
                case errCode_Text.MCU_ERRCODE_QUERY_RECORD_QUERY_REQ_FAILED:
                    errText = "查询平台录像出现错误";
                    break;
                case errCode_Text.MCU_ERRCODE_QUERY_RECORD_QUERY_RSP_FAILED:
                    errText = "查询平台录像返回结果出现错误";
                    break;
                case errCode_Text.MCU_ERRCODE_QUERY_RECORD_QUERY_NUM_ZERO:
                    errText = "平台从20获取的录像文件个数为0";
                    break;
                case errCode_Text.MCU_ERRCODE_RECORD_SEEK_TIME_OUT_RANG:
                    errText = "vcr操作时seektime时间跨文件";
                    break;
                case errCode_Text.MCU_ERRCODE_RECORD_STOP_PLAY_NTF:
                    errText = "收到MVS录像回放停止通知";
                    break;
                case errCode_Text.MCU_ERRCODE_RECORD_TYPE_WRONG:
                    errText = "录像类型参数错误";
                    break;
                case errCode_Text.MCU_ERRCODE_RECORD_GET_DEV_CHN_WRONG:
                    errText = "录像回放时查询设备信息错误";
                    break;
                case errCode_Text.MCU_ERRCODE_RECORD_GET_TIME_RANGE:
                    errText = "录像回放时获取录像开始结束时间错误";
                    break;
                case errCode_Text.MCU_SEARCH_DVC_OK:
                    errText = "MCU_SEARCH_DVC_OK";
                    break;
                case errCode_Text.MCU_SERACH_DVC_THREAD_EXITS:
                    errText = "查询录像文件线程已存在";
                    break;
                case errCode_Text.MCU_SERACH_DVC_NO_DEVICES:
                    errText = "MCU_SERACH_DVC_NO_DEVICES";
                    break;
                case errCode_Text.MCU_RECORD_ERR_CREATE_KEDAPLAYER_ERR:
                    errText = "录像下载创建kedaplayer错误";
                    break;
                case errCode_Text.MCU_RECORD_ERR_PLATFORM_CONNECT_FAIL:
                    errText = "录像下载连接平台出错";
                    break;
                case errCode_Text.MCU_RECORD_ERR_PLATFORM_DIRCRIPTION_NULL:
                    errText = "录像下载描述文件为空";
                    break;
                case errCode_Text.MCU_RECORD_ERR_LOCAL_DISK_FULL:
                    errText = "本地磁盘空间已满";
                    break;
                case errCode_Text.MCU_RECORD_ERR_LOCAL_FULL_NAME_NULL:
                    errText = "本地保存文件名为空";
                    break;
                case errCode_Text.OCX_INIT_ERR:
                    errText = "初始化错误";
                    break;
                case errCode_Text.OCX_WAIT_REC_OVERTIME:
                    errText = "录像查询等待结束标志超时";
                    break;
                case errCode_Text.OCX_UNINIT_ERR:
                    errText = "反初始化错误";
                    break;
            }

            return errText;
        }
    }
}
