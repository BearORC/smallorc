using CsharpSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace KdSDK2
{
    class Program
    {
        static uint max_str_len = 257;
        static uint max_id_len = 129;
        static uint max_display_content_len = 129;
        static uint max_desc_len = 129;
        static uint addr_str_len = 33;
        static IntPtr mcuHandle;
        uint prePlayId;
        uint preAudioCallId;
        static myAPI.cbFreshDevStatusD cbFun;
        static myAPI.cbSDKEventCallbackD cbEventInfo;
        bool isLogined = false;
        bool isHavePlay = false;
        bool isAudioCall = false;
        bool isFullScreen = false;
        bool isAlreadyRecord = false;
        int showWidth = 0;
        int showHeight = 0;
        static List<IDs> idsList = new List<IDs>();
        static List<DeviceInfo> allDeviceList = new List<DeviceInfo>();
        static List<DevGPSInfo> devGpsInfoList = new List<DevGPSInfo>();
        static List<TRecordInfo> mRecorderInfoList = new List<TRecordInfo>();
        static List<TTvWallInfoData> mAllTvWall = new List<TTvWallInfoData>();
        static List<TTvWallScheme> mAllTvWallScheme = new List<TTvWallScheme>();
        static int onLineCBCount = 0;
        static object locker = new object();

        int _PTZ_CTRL_TYPE_MOVE_ = 0;
        int _PTZ_CTRL_TYPE_ZOOM_ = 1;
        int _PTZ_CTRL_TYPE_HOME_ = 2;

        public static DateTime m_startTime;
        public static DateTime m_endTime;
        public static uint mCurrentRecordTask = 0;

        static void Main(string[] args)
        {

            uint errorInfo = 0;

            bool isLogined = false;

            mcuHandle = myAPI.Kdm_CreateMcuSdk();
            uint ret = myAPI.Kdm_Init(mcuHandle);
            myAPI.Kdm_SetScreenShowLog(mcuHandle, 1);
            byte[] filename;
            filename = stringToBytes("c:\\log", max_id_len);
            myAPI.Kdm_SetSaveLogFile(mcuHandle, 1, filename);
            cbFun = new myAPI.cbFreshDevStatusD(cbFreshDevStatus);
            cbEventInfo = new myAPI.cbSDKEventCallbackD(cbSDKEventCallback);
            myAPI.Kdm_SetSDKEventCallback(mcuHandle, cbEventInfo, 0);
            DateTime myNow = DateTime.Now;
            m_startTime = new DateTime(myNow.Year, myNow.Month, myNow.Day, 0, 0, 0, 0);
            m_endTime = m_startTime.AddDays(1);

            //startTime.Text = m_startTime.Date.ToString();
            //endTime.Text = m_endTime.Date.ToString();
            //cb_platform.Checked = true;
            uint errorCode = 0;
            myAPI.Kdm_SetStreamPattern(mcuHandle, 0, ref errorCode);

            string strIP = "45.4.8.9";
            string strUserName = "sdktest@nnzw";
            string strPassWord = "kedacom888888";
            byte[] byteIP = stringToBytes(strIP, 257);
            byte[] byteUserName = stringToBytes(strUserName, 257);
            byte[] bytePassWord = stringToBytes(strPassWord, 257);
            EBussinessMod type = myAPI.Kdm_PlatTypeDetect(mcuHandle, byteIP, ref errorInfo);
            myAPI.Kdm_ModualSelect(mcuHandle, type, EStreamMod.emG900, EDecoderMod.emBaseDec);
            ret = myAPI.Kdm_Login(mcuHandle, byteUserName, bytePassWord, byteIP, "windows", ref errorInfo);
            if (ret != 1)
            {
                isLogined = false;
                Console.WriteLine("登录失败");
            }
            else
            {
                isLogined = true;
                //设置设备状态回调
                myAPI.Kdm_SetDevStatusCallback(mcuHandle, cbFun, 0);
                Console.WriteLine("登录成功");

                string temp = "";
                IDs root = new IDs();
                root.szID = stringToBytes(temp, max_id_len);
                uint utaskID = myAPI.Kdm_GetGroupByGroup(mcuHandle, root, ref errorInfo);
                DeviceGroupInfo groupInfo = new DeviceGroupInfo();
                groupInfo.szGroupName = new byte[max_str_len];
                idsList.Clear();
                
                uint _uRtn = myAPI.Kdm_GetGroupNext(mcuHandle, utaskID, ref groupInfo, ref errorInfo);
                while (_uRtn != 0)
                {
                    string deviceName = bytesToString(groupInfo.szGroupName);
                    string deviceGroupID = bytesToString(groupInfo.groupID.szID);
                    string groupUnnamed = "IsUnnamedGroup";
                    if (deviceGroupID.Substring(0, groupUnnamed.Length) == groupUnnamed)
                    {
                        deviceName = "未分组";
                    }
                    idsList.Add(groupInfo.groupID);
                    addDevicestoNode(groupInfo.groupID);
                    _uRtn = myAPI.Kdm_GetGroupNext(mcuHandle, utaskID, ref groupInfo, ref errorInfo);

                }

                //new Thread(sub_thrd_fun).Start();

                for (int i = 0; i < idsList.Count; i++)
                {
                    Console.WriteLine(i + "/" + idsList.Count);
                    uint utID = myAPI.Kdm_GetDeviceByGroup(mcuHandle, idsList[i], ref errorInfo);
                    string deviceName = bytesToString(idsList[i].szID);
                    uint uRet = 1;
                    Console.WriteLine("deviceName:"+deviceName);
                    while (uRet != 0)
                    {
                        DeviceInfo deviceInfo = new DeviceInfo();
                        deviceInfo.deviceID = new IDs();
                        deviceInfo.deviceID.szID = new byte[max_id_len];
                        deviceInfo.domainID = new IDs();
                        deviceInfo.domainID.szID = new byte[max_id_len];
                        deviceInfo.szDevSrcAlias = new byte[max_str_len];
                        deviceInfo.szManufacturer = new byte[max_str_len];
                        deviceInfo.aDevSrcChn = new VIDSRC[128];
                        deviceInfo.parentGroupID = new IDs();
                        deviceInfo.parentGroupID.szID = new byte[max_id_len];
                        for (int x = 0; x < 128; x++)
                        {
                            deviceInfo.aDevSrcChn[x].szSrcName = new byte[max_str_len];
                        }
                        uRet = myAPI.Kdm_GetDeviceNext(mcuHandle, utID, ref deviceInfo, ref errorInfo);

                        if (uRet != 0)
                        {
                            if ((deviceInfo.nDevType == (UInt16)eDeviceType.emTypeEncoder)
                                || (deviceInfo.nDevType == (UInt16)eDeviceType.emTypeSVR)
                                || (deviceInfo.nDevType == (UInt16)eDeviceType.emTypeNVR))
                            {
                                allDeviceList.Add(deviceInfo);
                            }
                        }
                    }
                }

                Console.ReadKey();
                ESubscriptInfo emDevSubType = (ESubscriptInfo.emOnline | ESubscriptInfo.emVidChn | ESubscriptInfo.emGPSInfo | ESubscriptInfo.emRecStatus);
                TSUBSDEVS tSubsDEV = new TSUBSDEVS();
                tSubsDEV.m_bySubsDevNum = 1;
                tSubsDEV.m_vctDevID = new IDs[20];
                for (int x = 0; x < 20; x++)
                {
                    tSubsDEV.m_vctDevID[x].szID = new byte[max_id_len];
                }
                for (int j = 0; j < allDeviceList.Count; j++)
                {
                    Array.Copy(allDeviceList[j].deviceID.szID, 0, tSubsDEV.m_vctDevID[0].szID, 0, max_id_len);
                    myAPI.Kdm_SubscriptDeviceStatus(mcuHandle, tSubsDEV, emDevSubType, ref errorInfo);
                    DEVSRC_ST _DEVSRC_ST = new DEVSRC_ST();
                    _DEVSRC_ST.bEnable = new bool();
                    _DEVSRC_ST.bOnline = new bool();

                    DEVCHN tDevSrc = new DEVCHN();
                    tDevSrc.deviceID.szID = allDeviceList[j].deviceID.szID;
                    tDevSrc.domainID.szID = allDeviceList[j].domainID.szID;
                    //tDevSrc.nSrc = allDeviceList[j].nDevSrcNum;
                    //tDevSrc.nChn = allDeviceList[j].nEncoderChnNum;

                    tDevSrc.nSrc = 0;
                    tDevSrc.nChn = 0;

                    Console.WriteLine("deviceID:" + bytesToString(allDeviceList[j].deviceID.szID));
                    Console.WriteLine("domainID:" + bytesToString(allDeviceList[j].domainID.szID));
                    Console.WriteLine("nDevSrcNum:" + allDeviceList[j].nDevSrcNum);
                    Console.WriteLine("nEncoderChnNum:" + allDeviceList[j].nEncoderChnNum);

                    uint r = myAPI.Kdm_GetDevSrcStatus(mcuHandle, tDevSrc, ref _DEVSRC_ST, ref errorInfo);
                    Console.WriteLine("deviceName:" + bytesToString(allDeviceList[j].szDevSrcAlias));
                    Console.WriteLine("bOnline:" + _DEVSRC_ST.bOnline);
                    Console.WriteLine("bEnable:" + _DEVSRC_ST.bEnable);
                    Console.WriteLine("ret:" + r);
                }
                Console.ReadKey();
                for (int j = 0; j < allDeviceList.Count; j++)
                {
                    DEVSRC_ST _DEVSRC_ST = new DEVSRC_ST();
                    _DEVSRC_ST.bEnable = new bool();
                    _DEVSRC_ST.bOnline = new bool();

                    DEVCHN tDevSrc = new DEVCHN();
                    tDevSrc.deviceID.szID = allDeviceList[j].deviceID.szID;
                    tDevSrc.domainID.szID = allDeviceList[j].domainID.szID;
                    tDevSrc.nSrc = 0;
                    tDevSrc.nChn = 0;

                    uint r = myAPI.Kdm_GetDevSrcStatus(mcuHandle, tDevSrc, ref _DEVSRC_ST, ref errorInfo);
                    Console.Write("deviceName:" + bytesToString(allDeviceList[j].szDevSrcAlias));
                    Console.WriteLine("bOnline:" + _DEVSRC_ST.bOnline);
                }
                Console.ReadKey();
            }
        }
        private static byte[] stringToBytes(string str, uint size)
        {
            byte[] p1 = Encoding.UTF8.GetBytes(str);
            byte[] result = new byte[size];
            Array.Copy(p1, 0, result, 0, p1.Length);
            return result;
        }

        public static unsafe int cbFreshDevStatus(IDs id, ref DeviceStatus1 status, UInt32 userData)
        {
            string strCBName = bytesToString(id.szID);
            for (int i = 0; i < allDeviceList.Count; i++)
            {
                string strLocal = bytesToString(allDeviceList[i].deviceID.szID);
                if (strCBName == strLocal)
                {
                    if (status.m_emStatusType == eStatusType.emDevOnline)
                    {
                        onLineCBCount++;
                        string strOnlineInfo = "****** emDevOnline Info CallBack devID = " + bytesToString(id.szID)
                        + "   All Device Count = " + allDeviceList.Count.ToString()
                        + "   CallBackCount = " + onLineCBCount.ToString() + "\n";
                        Console.WriteLine(strOnlineInfo);
                        //Console.WriteLine("\n");
                    }

                    if (status.m_emStatusType == eStatusType.emDevConfig)
                    {
                        Console.WriteLine("**********emDevConfig Info CallBack\n");
                    }

                    if (status.m_emStatusType == eStatusType.emDevGpsInfo)
                    {
                        uint errorInfo = 0;
                        Console.WriteLine("*****************GPS Info CallBack \n");
                        DEVCHN tDevSrc = new DEVCHN();
                        tDevSrc.deviceID.szID = allDeviceList[i].deviceID.szID;
                        tDevSrc.domainID.szID = allDeviceList[i].domainID.szID;
                        tDevSrc.nSrc = 0;
                        tDevSrc.nChn = 0;
                        DevGPSInfo _DevGpsInfo = new DevGPSInfo();
                        _DevGpsInfo.deviceID.szID = new byte[max_id_len];

                        while (myAPI.Kdm_GetDevGpsInfo(mcuHandle, tDevSrc, ref _DevGpsInfo, ref errorInfo) != 0)
                        {
                            lock (locker)
                            {
                                devGpsInfoList.Add(_DevGpsInfo);
                            }

                            tDevSrc.nSrc++;
                            tDevSrc.nChn++;
                        }
                    }

                    if (status.m_emStatusType == eStatusType.emDevRecStatus)
                    {
                        uint errorInfo = 0;
                        TDevRecordStatus tDevSrcStat = new TDevRecordStatus();

                        uint nRtn = myAPI.Kdm_GetDevRecordStatus(mcuHandle, allDeviceList[i].deviceID, ref tDevSrcStat, ref errorInfo);
                        if (nRtn == 1)
                        {
                            string strDevRecStatus = "Device Record Status :" + bytesToString(tDevSrcStat.m_tDevID.szID);
                            Console.WriteLine(strDevRecStatus);
                            //lbGpsInfo.Items.Add(strDevRecStatus);
                        }
                    }
                    break;
                }
            }

            return 1;
        }

        public static unsafe int cbSDKEventCallback(ref EVENTINFO status, UInt32 userData)
        {
            if (status.m_emWork == 12 && status.m_dwErrorCode == 0)
            {
                mRecorderInfoList.Clear();
                uint errorCode = 0;
                TimeSpan ts = m_startTime - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                UInt32 time = Convert.ToUInt32(ts.TotalSeconds);
                TRecordInfo tri = new TRecordInfo();
                tri.m_dwRecID = new byte[max_str_len];
                tri.m_recordDomainName = new byte[max_str_len];
                uint ret = myAPI.Kdm_GetRecordNext(mcuHandle, mCurrentRecordTask, time, ref tri, ref errorCode);
                while (ret != 0)
                {

                    mRecorderInfoList.Add(tri);
                    time = tri.m_tRecPeriod.m_dwEndTime + 1;
                    tri = new TRecordInfo();
                    tri.m_dwRecID = new byte[max_str_len];
                    tri.m_recordDomainName = new byte[max_str_len];
                    ret = myAPI.Kdm_GetRecordNext(mcuHandle, mCurrentRecordTask, time, ref tri, ref errorCode);
                }


            }

            return 1;
        }
        private static string bytesToString(byte[] data)
        {
            string str = System.Text.Encoding.UTF8.GetString(data);
            return str;//remove_end_char_zero(str);
        }
        private static void addDevicestoNode(IDs groupID)
        {
            uint errorInfo = 0;
            uint utaskID = myAPI.Kdm_GetGroupByGroup(mcuHandle, groupID, ref errorInfo);
            DeviceGroupInfo groupInfo = new DeviceGroupInfo();
            groupInfo.szGroupName = new byte[max_str_len];

            uint _uRtn = myAPI.Kdm_GetGroupNext(mcuHandle, utaskID, ref groupInfo, ref errorInfo);
            while (_uRtn != 0)
            {
                idsList.Add(groupInfo.groupID);
                addDevicestoNode(groupInfo.groupID);
                _uRtn = myAPI.Kdm_GetGroupNext(mcuHandle, utaskID, ref groupInfo, ref errorInfo);
            }
        }
        static void sub_thrd_fun()
        {
            ESubscriptInfo emDevSubType = (ESubscriptInfo.emOnline | ESubscriptInfo.emVidChn | ESubscriptInfo.emGPSInfo | ESubscriptInfo.emRecStatus);
            TSUBSDEVS tSubsDEV = new TSUBSDEVS();
            tSubsDEV.m_bySubsDevNum = 1;
            tSubsDEV.m_vctDevID = new IDs[20];
            for (int x = 0; x < 20; x++)
            {
                tSubsDEV.m_vctDevID[x].szID = new byte[max_id_len];
            }
            uint errorInfo = 0;
            for (int index = 0; index < allDeviceList.Count; index++)
            {
                Array.Copy(allDeviceList[index].deviceID.szID, 0, tSubsDEV.m_vctDevID[0].szID, 0, max_id_len);
                myAPI.Kdm_UnSubscriptDeviceStatus(mcuHandle, tSubsDEV, emDevSubType, ref errorInfo);
            }

            allDeviceList.Clear();
            lock (locker)
            {
                devGpsInfoList.Clear();
                onLineCBCount = 0;
            }

            for (int i = 0; i < idsList.Count; i++)
            {
                uint utaskID = myAPI.Kdm_GetDeviceByGroup(mcuHandle, idsList[i], ref errorInfo);
                string deviceName = bytesToString(idsList[i].szID);


                uint uRet = 1;

                while (uRet != 0)
                {
                    DeviceInfo deviceInfo = new DeviceInfo();
                    deviceInfo.deviceID = new IDs();
                    deviceInfo.deviceID.szID = new byte[max_id_len];
                    deviceInfo.domainID = new IDs();
                    deviceInfo.domainID.szID = new byte[max_id_len];
                    deviceInfo.szDevSrcAlias = new byte[max_str_len];
                    deviceInfo.szManufacturer = new byte[max_str_len];
                    deviceInfo.aDevSrcChn = new VIDSRC[128];
                    deviceInfo.parentGroupID = new IDs();
                    deviceInfo.parentGroupID.szID = new byte[max_id_len];
                    for (int x = 0; x < 128; x++)
                    {
                        deviceInfo.aDevSrcChn[x].szSrcName = new byte[max_str_len];
                    }
                    uRet = myAPI.Kdm_GetDeviceNext(mcuHandle, utaskID, ref deviceInfo, ref errorInfo);
                    if (uRet != 0)
                    {
                        string aaaaaaaaa = bytesToString(deviceInfo.szManufacturer);
                        if ((deviceInfo.nDevType == (UInt16)eDeviceType.emTypeEncoder)
                            || (deviceInfo.nDevType == (UInt16)eDeviceType.emTypeSVR)
                            || (deviceInfo.nDevType == (UInt16)eDeviceType.emTypeNVR))
                        {
                            allDeviceList.Add(deviceInfo);
                        }
                    }
                }
            }

            for (int k = 0; k < allDeviceList.Count; k++)
            {
                Array.Copy(allDeviceList[k].deviceID.szID, 0, tSubsDEV.m_vctDevID[0].szID, 0, max_id_len);
                myAPI.Kdm_SubscriptDeviceStatus(mcuHandle, tSubsDEV, emDevSubType, ref errorInfo);
            }
        }

    }
}
