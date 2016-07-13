using CsharpSDK;
using System;
using System.Collections.Generic;
using System.IO;
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


        static List<String> onlineList = new List<String>();

        static void Main(string[] args)
        {
            
            uint errorInfo = 0;

            bool isLogined = false;
            mcuHandle = myAPI.Kdm_CreateMcuSdk();
            Console.WriteLine("1");
            uint ret = myAPI.Kdm_Init(mcuHandle);
            Console.WriteLine("2");
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
            // 切换码流的浏览方式
            myAPI.Kdm_SetStreamPattern(mcuHandle, 0, ref errorCode);

            string strIP = "45.4.8.9";
            string strUserName = "sdktest@nnzw";
            string strPassWord = "kedacom888888";
            byte[] byteIP = stringToBytes(strIP, 257);
            byte[] byteUserName = stringToBytes(strUserName, 257);
            byte[] bytePassWord = stringToBytes(strPassWord, 257);

            // 初始化登录平台
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


                // 获取分组
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


                // 获取设备
                for (int i = 0; i < idsList.Count; i++)
                {
                    Console.WriteLine(i+1 + "/" + idsList.Count);
                    uint utID = myAPI.Kdm_GetDeviceByGroup(mcuHandle, idsList[i], ref errorInfo);
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
                
                // 获取状态
                ESubscriptInfo emDevSubType = (ESubscriptInfo.emOnline | ESubscriptInfo.emVidChn);
                TSUBSDEVS tSubsDEV = new TSUBSDEVS();
                tSubsDEV.m_bySubsDevNum = 1;
                tSubsDEV.m_vctDevID = new IDs[20];
                for (int i = 0; i < 20; i++)
                {
                    tSubsDEV.m_vctDevID[i].szID = new byte[max_id_len];
                }
                int l = 0;
                for (int j = 0; j < allDeviceList.Count; j++)
                {
                    if (l < 20)
                    {
                        Array.Copy(allDeviceList[j].deviceID.szID, 0, tSubsDEV.m_vctDevID[l].szID, 0, max_id_len);
                        l = l + 1;
                    }
                    if (l == 20||j == allDeviceList.Count-1)
                    {
                        myAPI.Kdm_SubscriptDeviceStatus(mcuHandle, tSubsDEV, emDevSubType, ref errorInfo);
                        l = 0;
                    }
                }

                System.Threading.Thread.Sleep(10000);
                Console.Write("按任意键继续...");
                Console.ReadKey();



                // 生成在线列表
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

                    DEVCHN tDevDst = new DEVCHN();
                    tDevDst.deviceID.szID = allDeviceList[j].deviceID.szID;
                    tDevDst.domainID.szID = allDeviceList[j].domainID.szID;
                    tDevDst.nSrc = 0;
                    tDevDst.nChn = 0;
                    
                    uint r1 = myAPI.Kdm_GetDevSrcStatus(mcuHandle, tDevSrc, ref _DEVSRC_ST, ref errorInfo);
                    uint r2 = myAPI.Kdm_GetDeviceGBID(mcuHandle, tDevSrc, ref tDevDst, ref errorInfo);
                    if (_DEVSRC_ST.bOnline)
                    {
                        onlineList.Add(bytesToString(tDevDst.deviceID.szID).Substring(0, 20));
                        //Console.WriteLine("gbId:" + bytesToString(tDevDst.deviceID.szID).Substring(0, 20));
                    }
                }

                // 生成xml文件

                if (File.Exists("online.xml"))
                {
                    File.Delete("online.xml");
                }

                for (int i = 0; i < onlineList.Count; i++)
                {
                    if (i == 0)
                    {
                        File.AppendAllText("online.xml", "<?xml version=\"1.0\" encoding=\"GBK\" standalone = \"no\" ?>\n", Encoding.GetEncoding("GBK"));
                        File.AppendAllText("online.xml", "<XmlRoot>\n", Encoding.GetEncoding("GBK"));
                        File.AppendAllText("online.xml", "<UserInfo>\n", Encoding.GetEncoding("GBK"));
                        File.AppendAllText("online.xml", "<UserName>admin</UserName>\n", Encoding.GetEncoding("GBK"));
                        File.AppendAllText("online.xml", "</UserInfo>\n", Encoding.GetEncoding("GBK"));
                        File.AppendAllText("online.xml", "<Switch>\n", Encoding.GetEncoding("GBK"));
                        File.AppendAllText("online.xml", "<!--0 无限制， 1 仅限主流， 2 仅限辅流-->\n", Encoding.GetEncoding("GBK"));
                        File.AppendAllText("online.xml", "<PriSec>1</PriSec>\n", Encoding.GetEncoding("GBK"));
                        File.AppendAllText("online.xml", "<!--0 无限制， 1 正选， 2 反选-->\n", Encoding.GetEncoding("GBK"));
                        File.AppendAllText("online.xml", "<IdLimit>1</IdLimit>\n", Encoding.GetEncoding("GBK"));
                        File.AppendAllText("online.xml", "</Switch>\n", Encoding.GetEncoding("GBK"));
                        File.AppendAllText("online.xml", "<!--国标限制，把有限制的设备国标ID列在此处，EntryNum为ID的总个数 -->\n", Encoding.GetEncoding("GBK"));
                        File.AppendAllText("online.xml", "<!---如<EntryNum>2</EntryNum><Entry0>31010000001120000086</Entry0><Entry1>31010000001120000090</Entry1>-->\n", Encoding.GetEncoding("GBK"));
                        File.AppendAllText("online.xml", "<GbId>\n", Encoding.GetEncoding("GBK"));
                        File.AppendAllText("online.xml", "<EntryNum>" + onlineList.Count + "</EntryNum>\n", Encoding.GetEncoding("GBK"));

                    }
                    File.AppendAllText("online.xml", "<Entry" + i + ">" + onlineList[i] + "</Entry" + i + ">\n", Encoding.GetEncoding("GBK"));
                }
                File.AppendAllText("online.xml", "</GbId>\n", Encoding.GetEncoding("GBK"));
                File.AppendAllText("online.xml", "</XmlRoot>\n", Encoding.GetEncoding("GBK"));
            }

            Console.Write("按任意键关闭...");
            Console.ReadKey();
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
