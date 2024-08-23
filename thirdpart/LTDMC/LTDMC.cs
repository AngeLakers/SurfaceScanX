using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace csLTDMC //�����ռ����Ӧ�ó����޸�
{

    public struct struct_hs_cmp_info
    {
    double start_pos;   //���ԱȽ���ʼ��λ��.
    double interval;    //���.
    int count;//����
    };


    public delegate uint DMC3K5K_OPERATE(IntPtr operate_data); 
    public partial class LTDMC
    {
        //���úͶ�ȡ��ӡģʽ����������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_debug_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_debug_mode(UInt16 mode, string FileName);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_debug_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_debug_mode(ref UInt16 mode, IntPtr FileName);
        //---------------------   �忨��ʼ�����ú���  ----------------------
        //��ʼ�����ƿ�����������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_board_init", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_board_init();
        //Ӳ����λ����������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_board_reset", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_board_reset();
        //�رտ��ƿ�����������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_board_close", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_board_close();
        //���ƿ��ȸ�λ��������EtherCAT��RTEX���߿���  
        [DllImport("LTDMC.dll")]
        public static extern short dmc_soft_reset(ushort CardNo);
        //���ƿ��临λ����������������/���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cool_reset(ushort CardNo);
        //���ƿ���ʼ��λ��������EtherCAT���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_original_reset", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_original_reset(ushort CardNo);
        //��ȡ���ƿ���Ϣ�б�����������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_CardInfList", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_CardInfList(ref UInt16 CardNum, UInt32[] CardTypeList, UInt16[] CardIdList);
        //��ȡ�����汾�ţ�������DMC3000/DMC5X10ϵ�����忨��EtherCAT���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_card_version", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_card_version(UInt16 CardNo, ref UInt32 CardVersion);
        //��ȡ���ƿ�Ӳ���Ĺ̼��汾����������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_card_soft_version", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_card_soft_version(UInt16 CardNo, ref UInt32 FirmID, ref UInt32 SubFirmID);
        //��ȡ���ƿ���̬��汾����������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_card_lib_version", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_card_lib_version(ref UInt32 LibVer);
        //��ȡ�����汾�ţ�������DMC3000/DMC5X10ϵ�����忨��EtherCAT���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_release_version", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_release_version(ushort ConnectNo, byte[] ReleaseVersion);
        //��ȡָ�����������������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_total_axes", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_total_axes(UInt16 CardNo, ref UInt32 TotalAxis);
        //��ȡ����IO��������������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_total_ionum", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_total_ionum(ushort CardNo, ref ushort TotalIn, ref ushort TotalOut);
        //��ȡ����ADDA������������������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_total_adcnum", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_total_adcnum(ushort CardNo, ref ushort TotalIn, ref ushort TotalOut);
        //��ȡָ�����岹����ϵ����������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_total_liners", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_total_liners(UInt16 CardNo, ref UInt32 TotalLiner);
        //�����ࣨ������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_board_init_onecard", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_board_init_onecard(ushort CardNo);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_board_close_onecard", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_board_close_onecard(ushort CardNo);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_board_reset_onecard", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_board_reset_onecard(ushort CardNo);

        //���뺯������������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_sn", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_sn(UInt16 CardNo, string new_sn);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_check_sn", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_check_sn(UInt16 CardNo, string check_sn);
        //����sn20191101��������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_enter_password_ex(UInt16 CardNo, string str_pass);

        //---------------------�˶�ģ������ģʽ------------------
        //����ģʽ���������������忨��	
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_pulse_outmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_pulse_outmode(UInt16 CardNo, UInt16 axis, UInt16 outmode);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_pulse_outmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_pulse_outmode(UInt16 CardNo, UInt16 axis, ref UInt16 outmode);
        //���嵱����������EtherCAT���߿���RTEX���߿���DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_equiv", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_equiv(UInt16 CardNo, UInt16 axis, ref double equiv);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_equiv", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_equiv(UInt16 CardNo, UInt16 axis, double equiv);
        //�����϶(����)��������DMC5000ϵ�����忨��	
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_backlash_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_backlash_unit(UInt16 CardNo, UInt16 axis, double backlash); 
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_backlash_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_backlash_unit(UInt16 CardNo, UInt16 axis, ref double backlash);

        //ͨ���ļ�����
        [DllImport("LTDMC.dll", EntryPoint = "dmc_download_file", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_download_file(ushort CardNo, string pfilename, byte[] pfilenameinControl, ushort filetype);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_upload_file", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_upload_file(ushort CardNo, string pfilename, byte[] pfilenameinControl, ushort filetype);
        //�����ڴ��ļ� ���߿���������EtherCAT���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_download_memfile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_download_memfile(ushort CardNo, byte[] pbuffer, uint buffsize, byte[] pfilenameinControl, ushort filetype);
        //�ϴ��ڴ��ļ���������EtherCAT���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_upload_memfile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_upload_memfile(ushort CardNo, byte[] pbuffer, uint buffsize, byte[] pfilenameinControl, ref uint puifilesize, ushort filetype);
        //�ļ����ȣ���������������/���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_progress(ushort CardNo, ref float process);
        //���ز����ļ�����������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_download_configfile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_download_configfile(UInt16 CardNo, String FileName);
        //���ع̼��ļ�����������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_download_firmware", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_download_firmware(UInt16 CardNo, String FileName);

        //----------------------��λ�쳣����-------------------------------	
        //���ö�ȡ����λ������������E3032���߿���R3032���߿���DMC3000/5000/5X10ϵ�����忨��	
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_softlimit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_softlimit(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 source_sel, UInt16 SL_action, Int32 N_limit, Int32 P_limit);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_softlimit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_softlimit(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 source_sel, ref UInt16 SL_action, ref Int32 N_limit, ref Int32 P_limit);
        //���ö�ȡ����λ����unit��������DMC5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_softlimit_unit(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 source_sel, UInt16 SL_action, double N_limit, double P_limit);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_softlimit_unit(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 source_sel, ref UInt16 SL_action, ref double N_limit, ref double P_limit);
        //���ö�ȡEL�źţ��������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_el_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_el_mode(UInt16 CardNo, UInt16 axis, UInt16 el_enable, UInt16 el_logic, UInt16 el_mode);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_el_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_el_mode(UInt16 CardNo, UInt16 axis, ref UInt16 el_enable, ref UInt16 el_logic, ref UInt16 el_mode);
        //���ö�ȡEMG�źţ���������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_emg_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_emg_mode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 emg_logic);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_emg_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_emg_mode(UInt16 CardNo, UInt16 axis, ref UInt16 enbale, ref UInt16 emg_logic);
        //�ⲿ����ֹͣ�źż�����ֹͣʱ�����ã�����Ϊ��λ��������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_dstp_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_dstp_mode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 logic, UInt32 time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_dstp_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_dstp_mode(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 logic, ref UInt32 time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_dstp_time", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_dstp_time(UInt16 CardNo, UInt16 axis, UInt32 time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_dstp_time", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_dstp_time(UInt16 CardNo, UInt16 axis, ref UInt32 time);
        //�ⲿ����ֹͣ�źż�����ֹͣʱ�����ã���Ϊ��λ���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_io_dstp_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_io_dstp_mode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 logic);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_io_dstp_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_io_dstp_mode(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 logic);
        //��λ�˶�����ֹͣʱ�����ö�ȡ���������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_dec_stop_time", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_dec_stop_time(UInt16 CardNo, UInt16 axis, double stop_time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_dec_stop_time", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_dec_stop_time(UInt16 CardNo, UInt16 axis, ref double stop_time);
        //�岹����ֹͣ�źźͼ���ʱ�����ã�������DMC5X10ϵ�����忨��EthreCAT���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_vector_dec_stop_time(UInt16 CardNo, UInt16 Crd, double stop_time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_vector_dec_stop_time(UInt16 CardNo, UInt16 Crd, ref double stop_time);
        //IO����ֹͣ���루������DMC3000��DMC5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_dec_stop_dist(UInt16 CardNo, UInt16 axis, Int32 dist);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_dec_stop_dist(UInt16 CardNo, UInt16 axis, ref Int32 dist);
        //IO����ֹͣ��֧��pmove/vmove�˶���������DMC3000��DMC5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_io_exactstop(UInt16 CardNo, UInt16 axis, UInt16 ioNum, UInt16[] ioList, UInt16 enable, UInt16 valid_logic, UInt16 action, UInt16 move_dir);       
        //����ͨ������ڵ�һλ����ֹͣIO�ڣ�������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_io_dstp_bitno(UInt16 CardNo, UInt16 axis, UInt16 bitno, double filter);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_io_dstp_bitno(UInt16 CardNo, UInt16 axis, ref UInt16 bitno, ref double filter);

        //---------------------------�����˶�----------------------
        //�趨��ȡ�ٶ����߲���	���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_profile(UInt16 CardNo, UInt16 axis, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double stop_vel);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_profile(UInt16 CardNo, UInt16 axis, ref double Min_Vel, ref double Max_Vel, ref double Tacc, ref double Tdec, ref double stop_vel);
        //�ٶ�����(���嵱��)��������EtherCAT���߿���RTEX���߿���DMC5000/5X10ϵ�����忨��	
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_profile_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_profile_unit(UInt16 CardNo, UInt16 Axis, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Stop_Vel);   //�����ٶȲ���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_profile_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_profile_unit(UInt16 CardNo, UInt16 Axis, ref double Min_Vel, ref double Max_Vel, ref double Tacc, ref double Tdec, ref double Stop_Vel);
        //�ٶ��������ã����ٶ�ֵ��ʾ(����)���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_acc_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_acc_profile(UInt16 CardNo, UInt16 axis, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double stop_vel);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_acc_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_acc_profile(UInt16 CardNo, UInt16 axis, ref double Min_Vel, ref double Max_Vel, ref double Tacc, ref double Tdec, ref double stop_vel);
        //�ٶ��������ã����ٶ�ֵ��ʾ(����)��������EtherCAT���߿���RTEX���߿���DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_profile_unit_acc", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_profile_unit_acc(UInt16 CardNo, UInt16 Axis, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Stop_Vel);   //�����ٶȲ���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_profile_unit_acc", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_profile_unit_acc(UInt16 CardNo, UInt16 Axis, ref double Min_Vel, ref double Max_Vel, ref double Tacc, ref double Tdec, ref double Stop_Vel);      
        //���ö�ȡƽ���ٶ����߲�������������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_s_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_s_profile(UInt16 CardNo, UInt16 axis, UInt16 s_mode, double s_para);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_s_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_s_profile(UInt16 CardNo, UInt16 axis, UInt16 s_mode, ref double s_para);            
        //��λ�˶�(����)���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_pmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_pmove(UInt16 CardNo, UInt16 axis, Int32 Dist, UInt16 posi_mode);
        //��λ�˶�(����)��������EtherCAT���߿���RTEX���߿���DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_pmove_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_pmove_unit(UInt16 CardNo, UInt16 axis, double Dist, UInt16 posi_mode);  
        //ָ����������λ���˶� ͬʱ�����ٶȺ�Sʱ��(����)��������DMC5X10ϵ�����忨��	
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pmove_extern(UInt16 CardNo, UInt16 axis, double dist, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double stop_Vel, double s_para, UInt16 posi_mode);
        //���߱�λ(����)���˶��иı�Ŀ��λ�ã��������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_reset_target_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_reset_target_position(UInt16 CardNo, UInt16 axis, Int32 dist, UInt16 posi_mode);
        //���ٱ�λ(����)��������EtherCAT���߿���RTEX���߿���DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_reset_target_position_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_reset_target_position_unit(UInt16 CardNo, UInt16 Axis, double New_Pos); 
        //���߱���(����)���˶��иı�ָ����ĵ�ǰ�˶��ٶȣ��������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_change_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_change_speed(UInt16 CardNo, UInt16 axis, double Curr_Vel, double Taccdec);
        //���߱���(����)���˶��иı�ָ����ĵ�ǰ�˶��ٶȣ�������EtherCAT���߿���RTEX���߿���DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_change_speed_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_change_speed_unit(UInt16 CardNo, UInt16 Axis, double New_Vel, double Taccdec);    
        //�����˶����ǿ�иı�Ŀ��λ�ã��������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_update_target_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_update_target_position(UInt16 CardNo, UInt16 axis, Int32 dist, UInt16 posi_mode);
        //ǿ�б�λ��չ��������DMC5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_update_target_position_extern(UInt16 CardNo, UInt16 axis, double mid_pos, double aim_pos, double vel, UInt16 posi_mode);
        //���߱���(����)���˶��иı�ָ����ĵ�ǰ�˶��ٶȣ�������EtherCAT���߿���RTEX���߿���DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_update_target_position_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_update_target_position_unit(UInt16 CardNo, UInt16 Axis, double New_Pos);

      

        //---------------------JOG�˶�--------------------
        //���������ٶ��˶�����������������/���߿���	
        [DllImport("LTDMC.dll", EntryPoint = "dmc_vmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_vmove(UInt16 CardNo, UInt16 axis, UInt16 dir);

        //---------------------�岹�˶�--------------------
        //�岹�ٶ�����(����)��������DMC3000ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_vector_profile_multicoor", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_vector_profile_multicoor(UInt16 CardNo, UInt16 Crd, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Stop_Vel);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_vector_profile_multicoor", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_vector_profile_multicoor(UInt16 CardNo, UInt16 Crd, ref double Min_Vel, ref double Max_Vel, ref double Taccdec, ref double Tdec, ref double Stop_Vel);       
        //���ö�ȡƽ���ٶ����߲�����������DMC3000ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_vector_s_profile_multicoor(UInt16 CardNo, UInt16 Crd, UInt16 s_mode, double s_para);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_vector_s_profile_multicoor(UInt16 CardNo, UInt16 Crd, UInt16 s_mode, ref double s_para);
        //�岹�ٶȲ���(����)��������EtherCAT���߿���RTEX���߿���DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_vector_profile_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_vector_profile_unit(UInt16 CardNo, UInt16 Crd, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Stop_Vel);   //���β岹�ٶȲ���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_vector_profile_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_vector_profile_unit(UInt16 CardNo, UInt16 Crd, ref double Min_Vel, ref double Max_Vel, ref double Tacc, ref double Tdec, ref double Stop_Vel);
        //����ƽ���ٶ����߲�����������EtherCAT���߿���RTEX���߿���DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_vector_s_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_vector_s_profile(UInt16 CardNo, UInt16 Crd, UInt16 s_mode, double s_para);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_vector_s_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_vector_s_profile(UInt16 CardNo, UInt16 Crd, UInt16 s_mode, ref double s_para);
        //ֱ�߲岹�˶���������DMC3000ϵ�����忨��	
        [DllImport("LTDMC.dll", EntryPoint = "dmc_line_multicoor", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_line_multicoor(UInt16 CardNo, UInt16 crd, UInt16 axisNum, UInt16[] axisList, Int32[] DistList, UInt16 posi_mode);
        //Բ���岹�˶���������DMC3000ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_arc_move_multicoor", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_arc_move_multicoor(UInt16 CardNo, UInt16 crd, UInt16[] AxisList, Int32[] Target_Pos, Int32[] Cen_Pos, UInt16 Arc_Dir, UInt16 posi_mode);
        //ֱ�߲岹(����)��������EtherCAT���߿���RTEX���߿���DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_line_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_line_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, UInt16 posi_mode);    //����ֱ��
        //Բ��Բ���岹(����)��������EtherCAT���߿���RTEX���߿���DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_arc_move_center_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_arc_move_center_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, double[] Cen_Pos, UInt16 Arc_Dir, Int32 Circle, UInt16 posi_mode);     //Բ���յ�ʽԲ��/������/������
        //�뾶Բ���岹(����)��������EtherCAT���߿���RTEX���߿���DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_arc_move_radius_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_arc_move_radius_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, double Arc_Radius, UInt16 Arc_Dir, Int32 Circle, UInt16 posi_mode);    //�뾶�յ�ʽԲ��/������
        //����Բ���岹(����)��������EtherCAT���߿���RTEX���߿���DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_arc_move_3points_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_arc_move_3points_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, double[] Mid_Pos, Int32 Circle, UInt16 posi_mode);     //����ʽԲ��/������
        //���β岹(����)��������EtherCAT���߿���RTEX���߿���DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_rectangle_move_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_rectangle_move_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] TargetPos, double[] MaskPos, Int32 Count, UInt16 rect_mode, UInt16 posi_mode);     //��������岹�����β岹ָ��

        //----------------------PVT�˶�---------------------------
        //PVT�˶��ɰ� ���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_PvtTable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_PvtTable(UInt16 CardNo, UInt16 iaxis, UInt32 count, double[] pTime, Int32[] pPos, double[] pVel);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_PtsTable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_PtsTable(UInt16 CardNo, UInt16 iaxis, UInt32 count, double[] pTime, Int32[] pPos, double[] pPercent);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_PvtsTable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_PvtsTable(UInt16 CardNo, UInt16 iaxis, UInt32 count, double[] pTime, Int32[] pPos, double velBegin, double velEnd);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_PttTable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_PttTable(UInt16 CardNo, UInt16 iaxis, UInt32 count, double[] pTime, int[] pPos);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_PvtMove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_PvtMove(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList);
        //PVT����������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_PttTable_add(UInt16 CardNo, UInt16 iaxis, UInt16 count, double[] pTime, long[] pPos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_PtsTable_add(UInt16 CardNo, UInt16 iaxis, UInt16 count, double[] pTime, long[] pPos, double[] pPercent);
        //��ȡpvtʣ��ռ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pvt_get_remain_space(UInt16 CardNo, UInt16 iaxis);
        //PVT�˶� ���߿��¹滮��������EtherCAT���߿�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pvt_table_unit(UInt16 CardNo, UInt16 iaxis, UInt32 count, double[] pTime, double[] pPos, double[] pVel);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pts_table_unit(UInt16 CardNo, UInt16 iaxis, UInt32 count, double[] pTime, double[] pPos, double[] pPercent);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pvts_table_unit(UInt16 CardNo, UInt16 iaxis, UInt32 count, double[] pTime, double[] pPos, double velBegin, double velEnd);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ptt_table_unit(UInt16 CardNo, UInt16 iaxis, UInt32 count, double[] pTime, double[] pPos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pvt_move(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList);
        //�����ࣨ������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_SetGearProfile(UInt16 CardNo, UInt16 axis, UInt16 MasterType, UInt16 MasterIndex, Int32 MasterEven, Int32 SlaveEven, UInt32 MasterSlope);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_GetGearProfile(UInt16 CardNo, UInt16 axis, ref UInt16 MasterType, ref UInt16 MasterIndex, ref UInt32 MasterEven, ref UInt32 SlaveEven, ref UInt32 MasterSlope);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_GearMove(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList);
              
        //--------------------�����˶�---------------------
        //���ö�ȡHOME�źţ��������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_home_pin_logic", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_home_pin_logic(UInt16 CardNo, UInt16 axis, UInt16 org_logic, double filter);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_home_pin_logic", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_home_pin_logic(UInt16 CardNo, UInt16 axis, ref UInt16 org_logic, ref double filter);
        //�趨��ȡָ����Ļ�ԭ��ģʽ���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_homemode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_homemode(UInt16 CardNo, UInt16 axis, UInt16 home_dir, double vel, UInt16 mode, UInt16 EZ_count);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_homemode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_homemode(UInt16 CardNo, UInt16 axis, ref UInt16 home_dir, ref double vel, ref UInt16 home_mode, ref UInt16 EZ_count);
        //���û�������λ�Ƿ��ң�������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_home_el_return(UInt16 CardNo, UInt16 axis, UInt16 enable);
        //��ȡ��������λ����ʹ�ܣ�������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_home_el_return(UInt16 CardNo, UInt16 axis, ref UInt16 enable);
        //�������㣨�������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_home_move", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_home_move(UInt16 CardNo, UInt16 axis);
        //���ö�ȡ�����ٶȲ�����������Rtex���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_home_profile_unit(ushort CardNo, ushort axis, double Low_Vel, double High_Vel, double Tacc, double Tdec);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_home_profile_unit(ushort CardNo, ushort axis, ref double Low_Vel, ref double High_Vel, ref double Tacc, ref double Tdec);
        //��ȡ����ִ��״̬����������������/���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_home_result(UInt16 CardNo, UInt16 axis, ref UInt16 state);
        //���ö�ȡ����ƫ����������ģʽ��������DMC5X10���忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_home_position_unit(UInt16 CardNo, UInt16 axis, UInt16 enable, double position);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_home_position_unit(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref double position);
        //��������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_el_home(UInt16 CardNo, UInt16 axis, UInt16 mode);
        //����ƫ��ģʽ������������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_home_shift_param(UInt16 CardNo, UInt16 axis, UInt16 pos_clear_mode, double ShiftValue);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_home_shift_param(UInt16 CardNo, UInt16 axis, ref UInt16 pos_clear_mode, ref double ShiftValue);
        //���û���ƫ������ƫ��ģʽ��������DMC3000ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_home_position(UInt16 CardNo, UInt16 axis, UInt16 enable, double position);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_home_position(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref double position);
        //���û�����λ���루������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_home_soft_limit(UInt16 CardNo, UInt16 Axis, Int32 N_limit, Int32 P_limit);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_home_soft_limit(UInt16 CardNo, UInt16 Axis, ref Int32 N_limit, ref Int32 P_limit);
       
        //--------------------ԭ������-------------------
        //���ö�ȡEZ����ģʽ���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_homelatch_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_homelatch_mode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 logic, UInt16 source);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_homelatch_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_homelatch_mode(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 logic, ref UInt16 source);
        //��ȡԭ�������־���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_homelatch_flag", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_homelatch_flag(UInt16 CardNo, UInt16 axis);
        //���ԭ�������־���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_reset_homelatch_flag", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_reset_homelatch_flag(UInt16 CardNo, UInt16 axis);
        //��ȡԭ������ֵ���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_homelatch_value", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 dmc_get_homelatch_value(UInt16 CardNo, UInt16 axis);
        //��ȡԭ������ֵ��unit����������DMC5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_homelatch_value_unit(UInt16 CardNo, UInt16 axis, ref double pos);

        //--------------------EZ����-------------------
        //���ö�ȡEZ����ģʽ���������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_ezlatch_mode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 logic, UInt16 source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_ezlatch_mode(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 logic, ref UInt16 source);
        //��ȡEZ�����־���������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_ezlatch_flag(UInt16 CardNo, UInt16 axis);
        //���EZ�����־���������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_reset_ezlatch_flag(UInt16 CardNo, UInt16 axis);
        //��ȡEZ����ֵ���������������忨��
        [DllImport("LTDMC.dll")]
        public static extern Int32 dmc_get_ezlatch_value(UInt16 CardNo, UInt16 axis);
        //��ȡEZ����ֵ��unit����������DMC5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_ezlatch_value_unit(UInt16 CardNo, UInt16 axis, ref double pos);

        //--------------------�����˶�---------------------	
        //���ö�ȡ����ͨ�����������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_handwheel_channel", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_handwheel_channel(UInt16 CardNo, UInt16 index);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_handwheel_channel", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_handwheel_channel(UInt16 CardNo, ref UInt16 index);
        //���ö�ȡ�������������źŵĹ�����ʽ����������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_handwheel_inmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_handwheel_inmode(UInt16 CardNo, UInt16 axis, UInt16 inmode, Int32 multi, double vh);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_handwheel_inmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_handwheel_inmode(UInt16 CardNo, UInt16 axis, ref UInt16 inmode, ref Int32 multi, ref double vh);
        //���ö�ȡ�������������źŵĹ�����ʽ�������ͱ��ʣ�������DMC5X10ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_handwheel_inmode_decimals", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_handwheel_inmode_decimals(UInt16 CardNo, UInt16 axis, UInt16 inmode, double multi, double vh);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_handwheel_inmode_decimals", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_handwheel_inmode_decimals(UInt16 CardNo, UInt16 axis, ref UInt16 inmode, ref double multi, ref double vh);
        //���ö�ȡ�������������źŵĹ�����ʽ����������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_handwheel_inmode_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_handwheel_inmode_extern(UInt16 CardNo, UInt16 inmode, UInt16 AxisNum, UInt16[] AxisList, Int32[] multi);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_handwheel_inmode_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_handwheel_inmode_extern(UInt16 CardNo, ref UInt16 inmode, ref UInt16 AxisNum, UInt16[] AxisList, Int32[] multi);
        //���ö�ȡ�������������źŵĹ�����ʽ�������ͱ��ʣ�������DMC5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_handwheel_inmode_extern_decimals(UInt16 CardNo, UInt16 inmode, UInt16 AxisNum, UInt16[] AxisList, double[] multi);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_handwheel_inmode_extern_decimals(UInt16 CardNo, ref UInt16 inmode, ref UInt16 AxisNum, UInt16[] AxisList, double[] multi);
        //���������˶�����������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_handwheel_move", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_handwheel_move(UInt16 CardNo, UInt16 axis);    
        //�����˶� �������ߵ�����ģʽ  (����)
        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_set_axislist(UInt16 CardNo, UInt16 AxisSelIndex, UInt16 AxisNum, UInt16[] AxisList);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_get_axislist(UInt16 CardNo, UInt16 AxisSelIndex, ref UInt16 AxisNum, UInt16[] AxisList);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_set_ratiolist(UInt16 CardNo, UInt16 AxisSelIndex, UInt16 StartRatioIndex, UInt16 RatioSelNum, double[] RatioList);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_get_ratiolist(UInt16 CardNo, UInt16 AxisSelIndex, UInt16 StartRatioIndex, UInt16 RatioSelNum, double[] RatioList);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_set_mode(UInt16 CardNo, UInt16 InMode, UInt16 IfHardEnable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_get_mode(UInt16 CardNo, ref UInt16 InMode, ref UInt16 IfHardEnable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_set_index(UInt16 CardNo, UInt16 AxisSelIndex, UInt16 RatioSelIndex);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_get_index(UInt16 CardNo, ref UInt16 AxisSelIndex, ref UInt16 RatioSelIndex);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_stop(UInt16 CardNo);
        
        //-------------------------��������-------------------
        //���ö�ȡָ�����LTC�źţ��������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_ltc_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_ltc_mode(UInt16 CardNo, UInt16 axis, UInt16 ltc_logic, UInt16 ltc_mode, Double filter);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_ltc_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_ltc_mode(UInt16 CardNo, UInt16 axis, ref UInt16 ltc_logic, ref UInt16 ltc_mode, ref Double filter);
        //���ö������淽ʽ���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_latch_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_latch_mode(UInt16 CardNo, UInt16 axis, UInt16 all_enable, UInt16 latch_source, UInt16 triger_chunnel);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_latch_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_latch_mode(UInt16 CardNo, UInt16 axis, ref UInt16 all_enable, ref UInt16 latch_source, ref UInt16 triger_chunnel);
        //��ȡ��������������ֵ���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_latch_value", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 dmc_get_latch_value(UInt16 CardNo, UInt16 axis);
        //��ȡ��������������ֵunit��������DMC5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_latch_value_unit(UInt16 CardNo, UInt16 axis, ref double pos_by_mm);
        //��ȡ��������־���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_latch_flag", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_latch_flag(UInt16 CardNo, UInt16 axis);
        //��λ��������־���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_reset_latch_flag", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_reset_latch_flag(UInt16 CardNo, UInt16 axis);
        //������ȡֵ������DMC3000ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_latch_value_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 dmc_get_latch_value_extern(UInt16 CardNo, UInt16 axis, UInt16 Index);
        //�������棨Ԥ����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_latch_value_extern_unit(UInt16 CardNo, UInt16 axis, UInt16 index, ref double pos_by_mm);//������ȡֵ��ȡ 
        //��ȡ�������������DMC3000ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_latch_flag_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_latch_flag_extern(UInt16 CardNo, UInt16 axis);
        //���ö�ȡLTC����������������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_SetLtcOutMode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_SetLtcOutMode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 bitno);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_GetLtcOutMode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_GetLtcOutMode(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 bitno);
        //LTC�˿ڴ�����ʱ��ͣʱ�� ��λus���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_latch_stop_time", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_latch_stop_time(UInt16 CardNo, UInt16 axis, Int32 time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_latch_stop_time", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_latch_stop_time(UInt16 CardNo, UInt16 axis, ref Int32 time);
        //����/�ض�LTC�˿ڴ�����ʱ��ͣ�����ã�������EtherCAT����ϵ�п���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_latch_stop_axis(ushort CardNo, ushort latch, ushort num, ushort[] axislist);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_latch_stop_axis(ushort CardNo, ushort latch, ref ushort num, ushort[] axislist);

        //----------------------�������� ���߿�---------------------------
        //����������������ģʽ0-�������棬1-�������棻�������0-�½��أ�1-�����أ�2-˫���أ��˲�ʱ�䣬��λus���������������߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_set_mode(ushort CardNo, ushort latch, ushort ltc_mode, ushort ltc_logic, double filter);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_get_mode(ushort CardNo, ushort latch, ref ushort ltc_mode, ref ushort ltc_logic, ref double filter);
        //��������Դ��0-ָ��λ�ã�1-����������λ�ã��������������߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_set_source(ushort CardNo, ushort latch, ushort axis, ushort ltc_source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_get_source(ushort CardNo, ushort latch, ushort axis, ref ushort ltc_source);
        //��λ���������������������߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_reset(ushort CardNo, ushort latch);
        //��ȡ����������������������߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_get_number(ushort CardNo, ushort latch, ushort axis, ref int number);
        //��ȡ����ֵ���������������߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_get_value_unit(ushort CardNo, ushort latch, ushort axis, ref double value);

        //-----------------------������ ���п�---------------------------------
        //����������������ģʽ0-�������棬1-�������棻�������0-�½��أ�1-�����أ�2-˫���أ��˲�ʱ�䣬��λus��������DMC5X10/3000ϵ�����忨�����߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_set_mode(ushort ConnectNo, ushort latch, ushort ltc_enable, ushort ltc_mode, ushort ltc_inbit, ushort ltc_logic, double filter);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_get_mode(ushort ConnectNo, ushort latch, ref ushort ltc_enable, ref ushort ltc_mode, ref ushort ltc_inbit, ref ushort ltc_logic, ref double filter);
        //��������Դ��0-ָ��λ�ã�1-����������λ�ã�������DMC5X10/3000ϵ�����忨�����߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_set_source(ushort ConnectNo, ushort latch, ushort axis, ushort ltc_source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_get_source(ushort ConnectNo, ushort latch, ushort axis, ref ushort ltc_source);
        //��λ��������������DMC5X10/3000ϵ�����忨�����߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_reset(ushort ConnectNo, ushort latch);
        //��ȡ���������������DMC5X10/3000ϵ�����忨�����߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_get_number(ushort ConnectNo, ushort latch, ushort axis, ref int number);
        //��ȡ����ֵ��������DMC5X10ϵ�����忨���������߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_get_value_unit(ushort ConnectNo, ushort latch, ushort axis, ref double value);

        //----------------------�������λ�ñȽ�-----------------------	
        //���ö�ȡ�Ƚ�������������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_set_config", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_set_config(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 cmp_source);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_config", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_config(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 cmp_source);
        //������бȽϵ㣨��������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_clear_points", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_clear_points(UInt16 CardNo, UInt16 axis);
        //���ӱȽϵ㣨�������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_add_point", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_add_point(UInt16 CardNo, UInt16 axis, int pos, UInt16 dir, UInt16 action, UInt32 actpara);
        //���ӱȽϵ㣨����������DMC5X10���忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_unit(UInt16 CardNo, UInt16 cmp, double pos, UInt16 dir, UInt16 action, UInt32 actpara);        
        //���ӱȽϵ㣨������E3032/R3032��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_cycle(UInt16 CardNo, UInt16 cmp, Int32 pos, UInt16 dir, UInt32 bitno, UInt32 cycle, UInt16 level);
        //���ӱȽϵ�unit��������E5032��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_cycle_unit(UInt16 CardNo, UInt16 cmp, double pos, UInt16 dir, UInt32 bitno, UInt32 cycle, UInt16 level);
        //��ȡ��ǰ�Ƚϵ㣨�������������忨��Rtex���߿���E3032����
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_current_point", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_current_point(UInt16 CardNo, UInt16 axis, ref Int32 pos);
        //��ȡ��ǰ�Ƚϵ㣨������DMC5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_get_current_point_unit(UInt16 CardNo, UInt16 cmp, ref double pos);
        //��ѯ�Ѿ��ȽϹ��ĵ㣨��������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_points_runned", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_points_runned(UInt16 CardNo, UInt16 axis, ref Int32 pointNum);
        //��ѯ���Լ���ıȽϵ���������������������/���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_points_remained", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_points_remained(UInt16 CardNo, UInt16 axis, ref Int32 pointNum);
        
        //-------------------��ά����λ�ñȽ�-----------------------
        //���ö�ȡ�Ƚ������������������忨��EtherCAT���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_set_config_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_set_config_extern(UInt16 CardNo, UInt16 enable, UInt16 cmp_source);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_config_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_config_extern(UInt16 CardNo, ref UInt16 enable, ref UInt16 cmp_source);
        //������бȽϵ㣨�������������忨��EtherCAT���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_clear_points_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_clear_points_extern(UInt16 CardNo);
        //��������λ�ñȽϵ㣨�������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_add_point_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_add_point_extern(UInt16 CardNo, UInt16[] axis, Int32[] pos, UInt16[] dir, UInt16 action, UInt32 actpara);
        //��ȡ��ǰ�Ƚϵ㣨�������������忨��EtherCAT���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_current_point_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_current_point_extern(UInt16 CardNo, Int32[] pos);
        //��ȡ��ǰ�Ƚϵ�unit��������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_get_current_point_extern_unit(UInt16 CardNo, double[] pos);
        //��������λ�ñȽϵ㣨������DMC5X10���忨��      
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_extern_unit(UInt16 CardNo, UInt16[] axis, double[] pos, UInt16[] dir, UInt16 action, UInt32 actpara);
        //���Ӷ�ά����λ�ñȽϵ㣨������EtherCAT����ϵ�п���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_cycle_2d(ushort CardNo, ushort[] axis, double[] pos, ushort[] dir, uint bitno, uint cycle, ushort level);
        //��ѯ�Ѿ��ȽϹ��ĵ㣨�������������忨��EtherCAT���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_points_runned_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_points_runned_extern(UInt16 CardNo, ref Int32 pointNum);
        //��ѯ���Լ���ıȽϵ��������������������忨��EtherCAT���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_points_remained_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_points_remained_extern(UInt16 CardNo, ref Int32 pointNum);
        //����λ�ñȽϣ�������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_set_config_multi(UInt16 CardNo, UInt16 queue, UInt16 enable, UInt16 axis, UInt16 cmp_source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_get_config_multi(UInt16 CardNo, UInt16 queue, ref UInt16 enable, ref UInt16 axis, ref UInt16 cmp_source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_multi(UInt16 CardNo, UInt16 cmp, Int32 pos, UInt16 dir, UInt16 action, UInt32 actpara, double times);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_multi_unit(UInt16 CardNo, UInt16 cmp, double pos, UInt16 dir, UInt16 action, UInt32 actpara, double times);//���ӱȽϵ� ��ǿ
        
        //----------- �������λ�ñȽ�-----------------------        
        //���ö�ȡ���ٱȽ�ģʽ���������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_set_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_set_mode(UInt16 CardNo, UInt16 hcmp, UInt16 cmp_enable);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_get_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_get_mode(UInt16 CardNo, UInt16 hcmp, ref UInt16 cmp_enable);
        //���ø��ٱȽϲ������������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_set_config", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_set_config(UInt16 CardNo, UInt16 hcmp, UInt16 axis, UInt16 cmp_source, UInt16 cmp_logic, Int32 time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_get_config", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_get_config(UInt16 CardNo, UInt16 hcmp, ref UInt16 axis, ref UInt16 cmp_source, ref UInt16 cmp_logic, ref Int32 time);
        //���ٱȽ�ģʽ��չ��������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_set_config_extern(UInt16 CardNo, UInt16 hcmp, UInt16 axis, UInt16 cmp_source, UInt16 cmp_logic, UInt16 cmp_mode, Int32 dist, Int32 time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_get_config_extern(UInt16 CardNo, UInt16 hcmp, ref UInt16 axis, ref UInt16 cmp_source, ref UInt16 cmp_logic, ref UInt16 cmp_mode, ref Int32 dist, ref Int32 time);
        //���ӱȽϵ㣨�������������忨��E3032���߿���R3032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_add_point", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_add_point(UInt16 CardNo, UInt16 hcmp, Int32 cmp_pos);
        //���ӱȽϵ�unit��������DMC5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_add_point_unit(UInt16 CardNo, UInt16 hcmp, double cmp_pos);       
        //���ö�ȡ����ģʽ�������������������忨��E3032���߿���R3032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_set_liner", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_set_liner(UInt16 CardNo, UInt16 hcmp, Int32 Increment, Int32 Count);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_get_liner", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_get_liner(UInt16 CardNo, UInt16 hcmp, ref Int32 Increment, ref Int32 Count);
        //��������ģʽ������������DMC5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_set_liner_unit(UInt16 CardNo, UInt16 hcmp, double Increment, Int32 Count);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_get_liner_unit(UInt16 CardNo, UInt16 hcmp, ref double Increment, ref Int32 Count);
        //��ȡ���ٱȽ�״̬���������������忨��E3032���߿���R3032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_get_current_state", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_get_current_state(UInt16 CardNo, UInt16 hcmp, ref Int32 remained_points, ref Int32 current_point, ref Int32 runned_points);
        //��ȡ���ٱȽ�״̬��������DMC5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_get_current_state_unit(UInt16 CardNo, UInt16 hcmp, ref Int32 remained_points, ref double current_point, ref Int32 runned_points); //��ȡ���ٱȽ�״̬
        //����Ƚϵ㣨�������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_clear_points", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_clear_points(UInt16 CardNo, UInt16 hcmp);
        //��ȡָ��CMP�˿ڵĵ�ƽ��������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_cmp_pin", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_cmp_pin(UInt16 CardNo, UInt16 hcmp);
        //����cmp�˿������������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_cmp_pin", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_cmp_pin(UInt16 CardNo, UInt16 hcmp, UInt16 on_off);
        //1��	���û��淽ʽ���ӱȽ�λ�ã���������DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_set_mode(UInt16 CardNo, UInt16 hcmp, UInt16 fifo_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_get_mode(UInt16 CardNo, UInt16 hcmp, ref UInt16 fifo_mode);
        //2��	��ȡʣ�໺��״̬����λ��ͨ���˺����ж��Ƿ�������ӱȽ�λ�ã�������DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_get_state(UInt16 CardNo, UInt16 hcmp, ref long remained_points);
        //3��	������ķ�ʽ�������ӱȽ�λ�ã�������DMC5000ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_add_point_unit(UInt16 CardNo, UInt16 hcmp, UInt16 num, double[] cmp_pos);
        //4��	����Ƚ�λ��,Ҳ���FPGA��λ��ͬ���������������DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_clear_points(UInt16 CardNo, UInt16 hcmp);
        //���Ӵ����ݣ������һ��ʱ�䣬ָ������������ɣ�������DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_add_table(UInt16 CardNo, UInt16 hcmp, UInt16 num, double[] cmp_pos);
        //һά���ٱȽϣ�����ģʽ���ӵıȽϵ�����˶����������������ݣ�������DMC5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_add_point_dir_unit(ushort CardNo, ushort hcmp, ushort num, double[] cmp_pos, uint dir);
        //һά���ٱȽϣ�����ģʽ���ӵıȽϵ�����˶��������Ӵ������ݣ�������DMC5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_add_table_dir(ushort CardNo, ushort hcmp, ushort num, double[] cmp_pos, uint dir);
        //----------- ��ά����λ�ñȽ�-----------------------        
        //���ö�ȡ���ٱȽ�ʹ�ܣ��������������忨��EtherCAT���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_set_enable(UInt16 CardNo, UInt16 hcmp, UInt16 cmp_enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_get_enable(UInt16 CardNo, UInt16 hcmp, ref UInt16 cmp_enable);
        //���ö�ȡ��ά���ٱȽ������������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_set_config(UInt16 CardNo, UInt16 hcmp, UInt16 cmp_mode, UInt16 x_axis, UInt16 x_cmp_source, UInt16 y_axis, UInt16 y_cmp_source, Int32 error, UInt16 cmp_logic, Int32 time, UInt16 pwm_enable, double duty, Int32 freq, UInt16 port_sel, UInt16 pwm_number);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_get_config(UInt16 CardNo, UInt16 hcmp, ref UInt16 cmp_mode, ref UInt16 x_axis, ref UInt16 x_cmp_source, ref UInt16 y_axis, ref UInt16 y_cmp_source, ref Int32 error, ref UInt16 cmp_logic, ref Int32 time, ref UInt16 pwm_enable, ref double duty, ref Int32 freq, ref UInt16 port_sel, ref UInt16 pwm_number);
        //���ö�ȡ��ά���ٱȽ�����������DMC5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_set_config_unit(UInt16 CardNo, UInt16 hcmp, UInt16 cmp_mode, UInt16 x_axis, UInt16 x_cmp_source, double x_cmp_error, UInt16 y_axis, UInt16 y_cmp_source, double y_cmp_error, UInt16 cmp_logic, int time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_get_config_unit(UInt16 CardNo, UInt16 hcmp, ref UInt16 cmp_mode, ref UInt16 x_axis, ref UInt16 x_cmp_source, ref double x_cmp_error, ref UInt16 y_axis, ref UInt16 y_cmp_source, ref double y_cmp_error, ref UInt16 cmp_logic, ref int time);
        //���Ӷ�ά����λ�ñȽϵ㣨�������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_add_point(UInt16 CardNo, UInt16 hcmp, Int32 x_cmp_pos, Int32 y_cmp_pos);
        //���Ӷ�ά����λ�ñȽϵ�unit��������DMC5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_add_point_unit(UInt16 CardNo, UInt16 hcmp, double x_cmp_pos, double y_cmp_pos, UInt16 cmp_outbit);
        //��ȡ��ά���ٱȽϲ������������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_get_current_state(UInt16 CardNo, UInt16 hcmp, ref Int32 remained_points, ref Int32 x_current_point, ref Int32 y_current_point, ref Int32 runned_points, ref UInt16 current_state);
        //��ȡ��ά���ٱȽϲ�����������DMC5X10ϵ�����忨��EtherCAT���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_get_current_state_unit(UInt16 CardNo, UInt16 hcmp, ref int remained_points, ref double x_current_point, ref double y_current_point, ref int runned_points, ref UInt16 current_state, ref UInt16 current_outbit); 
        //�����ά����λ�ñȽϵ㣨�������������忨��EtherCAT���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_clear_points(UInt16 CardNo, UInt16 hcmp);
        //ǿ�ƶ�ά���ٱȽ�������������������忨��EtherCAT���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_force_output(UInt16 CardNo, UInt16 hcmp, UInt16 cmp_outbit);
        //���ö�ȡ��ά�Ƚ�PWM���ģʽ��������DMC5X10ϵ�����忨��EtherCAT���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_set_pwmoutput(UInt16 CardNo, UInt16 hcmp, UInt16 pwm_enable, double duty, double freq, UInt16 pwm_number);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_get_pwmoutput(UInt16 CardNo, UInt16 hcmp, ref UInt16 pwm_enable, ref double duty, ref double freq, ref UInt16 pwm_number);
        
        //------------------------ͨ��IO-----------------------
        //��ȡ����ڵ�״̬���������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_inbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_inbit(UInt16 CardNo, UInt16 bitno);
        //��������ڵ�״̬���������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_outbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_outbit(UInt16 CardNo, UInt16 bitno, UInt16 on_off);
        //��ȡ����ڵ�״̬���������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_outbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_outbit(UInt16 CardNo, UInt16 bitno);
        //��ȡ����˿ڵ�ֵ���������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_inport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 dmc_read_inport(UInt16 CardNo, UInt16 portno);
        //��ȡ����˿ڵ�ֵ���������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_outport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 dmc_read_outport(UInt16 CardNo, UInt16 portno);
        //������������˿ڵ�ֵ���������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_outport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_outport(UInt16 CardNo, UInt16 portno, UInt32 outport_val);
        //����ͨ������˿ڵ�ֵ��������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_outport_16X", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_outport_16X(UInt16 CardNo, UInt16 portno, UInt32 outport_val);
        //---------------------------ͨ��IO������ֵ���----------------------
        //��ȡ����ڵ�״̬��������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_inbit_ex(ushort CardNo, ushort bitno, ref ushort state);
        //��ȡ����ڵ�״̬��������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_outbit_ex(ushort CardNo, ushort bitno, ref ushort state);
        //��ȡ����˿ڵ�ֵ��������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_inport_ex(ushort CardNo, ushort portno, ref UInt32 state);
        //��ȡ����˿ڵ�ֵ��������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_outport_ex(ushort CardNo, ushort portno, ref UInt32 state);
        
        //���ö�ȡ����IOӳ���ϵ���������������忨�� 
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_io_map_virtual", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_io_map_virtual(UInt16 CardNo, UInt16 bitno, UInt16 MapIoType, UInt16 MapIoIndex, double Filter);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_io_map_virtual", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_io_map_virtual(UInt16 CardNo, UInt16 bitno, ref UInt16 MapIoType, ref UInt16 MapIoIndex, ref double Filter);
        //��ȡ��������ڵ�״̬���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_inbit_virtual", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_inbit_virtual(UInt16 CardNo, UInt16 bitno);
        //IO��ʱ��ת���������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_reverse_outbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_reverse_outbit(UInt16 CardNo, UInt16 bitno, double reverse_time);
        //���ö�ȡIO����ģʽ���������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_io_count_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_io_count_mode(UInt16 CardNo, UInt16 bitno, UInt16 mode, double filter_time);        
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_io_count_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_io_count_mode(UInt16 CardNo, UInt16 bitno, ref UInt16 mode, ref double filter_time);
        //����IO����ֵ���������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_io_count_value", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_io_count_value(UInt16 CardNo, UInt16 bitno, UInt32 CountValue);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_io_count_value", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_io_count_value(UInt16 CardNo, UInt16 bitno, ref UInt32 CountValue);
                 
        //-----------------------ר��IO ���忨ר��-------------------------
        //���ö�ȡ��IOӳ���ϵ���������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_axis_io_map", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_axis_io_map(UInt16 CardNo, UInt16 Axis, UInt16 IoType, UInt16 MapIoType, UInt16 MapIoIndex, double Filter);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_axis_io_map", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_axis_io_map(UInt16 CardNo, UInt16 Axis, UInt16 IoType, ref UInt16 MapIoType, ref UInt16 MapIoIndex, ref double Filter);
        //��������ר��IO�˲�ʱ�䣨�������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_special_input_filter", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_special_input_filter(UInt16 CardNo, double Filter);
        // ��ԭ������ź����ã�(DMC3410ר��)
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_sd_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_sd_mode(UInt16 CardNo, UInt16 axis, UInt16 sd_logic, UInt16 sd_mode);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_sd_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_sd_mode(UInt16 CardNo, UInt16 axis, ref UInt16 sd_logic, ref UInt16 sd_mode);
        //���ö�ȡINP�źţ��������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_inp_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_inp_mode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 inp_logic);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_inp_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_inp_mode(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 inp_logic);
        //���ö�ȡRDY�źţ�������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_rdy_mode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 rdy_logic);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_rdy_mode(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 rdy_logic);
        //���ö�ȡERC�źţ�������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_erc_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_erc_mode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 erc_logic, UInt16 erc_width, UInt16 erc_off_time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_erc_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_erc_mode(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 erc_logic, ref UInt16 erc_width, ref UInt16 erc_off_time);
        //���ö�ȡALM�źţ��������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_alm_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_alm_mode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 alm_logic, UInt16 alm_action);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_alm_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_alm_mode(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 alm_logic, ref UInt16 alm_action);
        //���ö�ȡEZ�źţ��������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_ez_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_ez_mode(UInt16 CardNo, UInt16 axis, UInt16 ez_logic, UInt16 ez_mode, double filter);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_ez_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_ez_mode(UInt16 CardNo, UInt16 axis, ref UInt16 ez_logic, ref UInt16 ez_mode, ref double filter);
        //�����ȡSEVON�źţ��������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_sevon_pin", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_sevon_pin(UInt16 CardNo, UInt16 axis, UInt16 on_off);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_sevon_pin", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_sevon_pin(UInt16 CardNo, UInt16 axis);
        //����ERC�ź�������������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_erc_pin", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_erc_pin(UInt16 CardNo, UInt16 axis, UInt16 sel);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_erc_pin", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_erc_pin(UInt16 CardNo, UInt16 axis);
        //��ȡRDY״̬���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_rdy_pin", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_rdy_pin(UInt16 CardNo, UInt16 axis);
        //����ŷ���λ�źţ�������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_write_sevrst_pin(UInt16 CardNo, UInt16 axis, UInt16 on_off);
        //���ŷ���λ�źţ�������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_sevrst_pin(UInt16 CardNo, UInt16 axis);

        //---------------------������ ���忨---------------------
        //�趨��ȡ�������ļ�����ʽ���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_counter_inmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_counter_inmode(UInt16 CardNo, UInt16 axis, UInt16 mode);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_counter_inmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_counter_inmode(UInt16 CardNo, UInt16 axis, ref UInt16 mode);
        //������ֵ���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_encoder", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 dmc_get_encoder(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_encoder", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_encoder(UInt16 CardNo, UInt16 axis, Int32 encoder_value);
        //������ֵ(����)��������DMC5000/5X10ϵ�����忨���������߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_encoder_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_encoder_unit(UInt16 CardNo, UInt16 axis, double pos);     //��ǰ����λ��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_encoder_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_encoder_unit(UInt16 CardNo, UInt16 axis, ref double pos);        
        //---------------------���������� ���߿�---------------------
        //���ֱ����������ã�ͬdmc_set_extra_encoder��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_handwheel_encoder(ushort CardNo, ushort channel, int pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_handwheel_encoder(ushort CardNo, ushort channel, ref int pos);
        //���ø�������ģʽ���������������߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_extra_encoder_mode(ushort CardNo, ushort channel, ushort inmode, ushort multi);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_extra_encoder_mode(ushort CardNo, ushort channel, ref ushort inmode, ref ushort multi);
        //���ø���������ֵ���������������߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_extra_encoder(ushort CardNo, ushort channel, int pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_extra_encoder(ushort CardNo, ushort channel, ref int pos);
        //---------------------λ�ü�������---------------------
        //��ǰλ��(����)��������DMC5000/5X10ϵ�����忨���������߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_position_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_position_unit(UInt16 CardNo, UInt16 axis, double pos);   //��ǰָ��λ��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_position_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_position_unit(UInt16 CardNo, UInt16 axis, ref double pos);
        //��ǰλ��(����)���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 dmc_get_position(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_position(UInt16 CardNo, UInt16 axis, Int32 current_position);
        //--------------------�˶�״̬----------------------	
        //��ȡָ����ĵ�ǰ�ٶȣ��������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_current_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern double dmc_read_current_speed(UInt16 CardNo, UInt16 axis);
        //��ȡ��ǰ�ٶ�(����)��������DMC5000/5X10ϵ�����忨���������߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_current_speed_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_current_speed_unit(UInt16 CardNo, UInt16 Axis, ref double current_speed);   //�ᵱǰ�����ٶ�
        //��ȡ��ǰ���Ĳ岹�ٶȣ�������DMC5X10ϵ�����忨���������߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_vector_speed_unit(UInt16 CardNo, UInt16 Crd, ref double current_speed);	//��ȡ��ǰ���Ĳ岹�ٶ�
        //��ȡָ�����Ŀ��λ�ã��������������忨��R3032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_target_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 dmc_get_target_position(UInt16 CardNo, UInt16 axis);
        //��ȡָ�����Ŀ��λ��(����)��������DMC5X10ϵ�����忨������EtherCAT����ϵ�п���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_target_position_unit(UInt16 CardNo, UInt16 axis, ref double pos);
        //��ȡָ������˶�״̬���������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_check_done", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_check_done(UInt16 CardNo, UInt16 axis);
        //��ȡָ������˶�״̬�����������п���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_check_done_ex(ushort CardNo, ushort axis, ref ushort state);
        //�岹�˶�״̬���������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_check_done_multicoor", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_check_done_multicoor(UInt16 CardNo, UInt16 crd);
        //��ȡָ�����й��˶��źŵ�״̬���������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_axis_io_status", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 dmc_axis_io_status(UInt16 CardNo, UInt16 axis);
        //��ȡָ�����й��˶��źŵ�״̬�����������п���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_axis_io_status_ex(ushort CardNo, ushort axis, ref uint state);
        //����ֹͣ���������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_stop(UInt16 CardNo, UInt16 axis, UInt16 stop_mode);
        //ֹͣ�岹�����������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_stop_multicoor", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_stop_multicoor(UInt16 CardNo, UInt16 crd, UInt16 stop_mode);
        //����ֹͣ�����ᣨ�������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_emg_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_emg_stop(UInt16 CardNo);
        //���忨ָ�� ��������ߺ�ͨѶ״̬���������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_LinkState", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_LinkState(UInt16 CardNo, ref UInt16 State);
        //��ȡָ������˶�ģʽ��������DMC5000/5X10ϵ�����忨���������߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_axis_run_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_axis_run_mode(UInt16 CardNo, UInt16 axis, ref UInt16 run_mode);  
        //��ȡ��ֹͣԭ���������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_stop_reason", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_stop_reason(UInt16 CardNo, UInt16 axis, ref Int32 StopReason);    
        //�����ֹͣԭ���������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_clear_stop_reason", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_clear_stop_reason(UInt16 CardNo, UInt16 axis);
        //trace���ܣ��ڲ�ʹ�ú�����
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_trace", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_trace(UInt16 CardNo, UInt16 axis, UInt16 enable);   //trace����
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_trace", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_trace(UInt16 CardNo, UInt16 axis, ref UInt16 enable);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_trace_data", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_trace_data(UInt16 CardNo, UInt16 axis, UInt16 data_option, ref Int32 ReceiveSize, double[] time, double[] data, ref Int32 remain_num);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_trace_start(ushort CardNo, ushort AxisNum, ushort[] AxisList);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_trace_stop(ushort CardNo);

        //�������㣨���ã�
        [DllImport("LTDMC.dll", EntryPoint = "dmc_calculate_arclength_center", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_calculate_arclength_center(double[] start_pos, double[] target_pos, double[] cen_pos, UInt16 arc_dir, double circle, ref double ArcLength);      //����Բ��Բ������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_calculate_arclength_3point", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_calculate_arclength_3point(double[] start_pos, double[] mid_pos, double[] target_pos, double circle, ref double ArcLength);      //��������Բ������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_calculate_arclength_radius", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_calculate_arclength_radius(double[] start_pos, double[] target_pos, double arc_radius, UInt16 arc_dir, double circle, ref double ArcLength);     //����뾶Բ������

        //--------------------CAN-IO��չ----------------------	
        //CAN-IO��չ���ɽӿں�����������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_can_state", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_can_state(UInt16 CardNo, UInt16 NodeNum, UInt16 state, UInt16 Baud);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_can_state", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_can_state(UInt16 CardNo, ref UInt16 NodeNum, ref UInt16 state);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_can_outbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_can_outbit(UInt16 CardNo, UInt16 Node, UInt16 bitno, UInt16 on_off);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_can_outbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_can_outbit(UInt16 CardNo, UInt16 Node, UInt16 bitno);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_can_inbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_can_inbit(UInt16 CardNo, UInt16 Node, UInt16 bitno);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_can_outport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_can_outport(UInt16 CardNo, UInt16 Node, UInt16 PortNo, UInt32 outport_val);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_can_outport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 dmc_read_can_outport(UInt16 CardNo, UInt16 Node, UInt16 PortNo);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_can_inport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 dmc_read_can_inport(UInt16 CardNo, UInt16 Node, UInt16 PortNo);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_can_errcode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_can_errcode(UInt16 CardNo, ref UInt16 Errcode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_can_errcode_extern(UInt16 CardNo, ref UInt16 Errcode, ref UInt16 msg_losed, ref UInt16 emg_msg_num, ref UInt16 lostHeartB, ref UInt16 EmgMsg);
        //����CAN io������������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_outbit(ushort CardNo, ushort NodeID, ushort IoBit, ushort IoValue);
        //��ȡCAN io������������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_outbit(ushort CardNo, ushort NodeID, ushort IoBit, ref ushort IoValue);
        //��ȡCAN io���루�������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_inbit(ushort CardNo, ushort NodeID, ushort IoBit, ref ushort IoValue);
        //����CAN io���32λ���������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_outport(ushort CardNo, ushort NodeID, ushort PortNo, UInt32 IoValue);
        //��ȡCAN io���32λ���������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_outport(ushort CardNo, ushort NodeID, ushort PortNo, ref UInt32 IoValue);
        //��ȡCAN io����32λ���������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_inport(ushort CardNo, ushort NodeID, ushort PortNo, ref UInt32 IoValue);
        //---------------------------CAN IO������ֵ���----------------------
        //����CAN io�����������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_outbit_ex(ushort CardNo, ushort NoteID, ushort IoBit, ushort IoValue, ref ushort state);
        //��ȡCAN io�����������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_outbit_ex(ushort CardNo, ushort NoteID, ushort IoBit, ref ushort IoValue, ref ushort state);
        //��ȡCAN io���루������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_inbit_ex(ushort CardNo, ushort NoteID, ushort IoBit, ref ushort IoValue, ref ushort state);
        //����CAN io���32λ��������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_outport_ex(ushort CardNo, ushort NoteID, ushort portno, UInt32 outport_val, ref ushort state);
        //��ȡCAN io���32λ��������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_outport_ex(ushort CardNo, ushort NoteID, ushort portno, ref UInt32 outport_val, ref ushort state);
        //��ȡCAN io����32λ��������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_inport_ex(ushort CardNo, ushort NoteID, ushort portno, ref UInt32 inport_val, ref ushort state);
        //---------------------------CAN ADDA----------------------
        //CAN ADDAָ�� ����DA���� ���������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_da_output(ushort CardNo, ushort NoteID, ushort channel, double Value);
        //��ȡCAN DA�������������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_da_output(ushort CardNo, ushort NoteID, ushort channel, ref double Value);
        //��ȡCAN AD�������������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_ad_input(ushort CardNo, ushort NoteID, ushort channel, ref double Value);
        //����CAN ADģʽ���������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_ad_mode(ushort CardNo, ushort NoteID, ushort channel, ushort mode, uint buffer_nums);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_ad_mode(ushort CardNo, ushort NoteID, ushort channel, ref ushort mode, uint buffer_nums);
        //����CAN DAģʽ���������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_da_mode(ushort CardNo, ushort NoteID, ushort channel, ushort mode, uint buffer_nums);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_da_mode(ushort CardNo, ushort NoteID, ushort channel, ref ushort mode, uint buffer_nums);
        //CAN����д��flash���������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_to_flash(ushort CardNo, ushort PortNum, ushort NodeNum);
        //CAN�������ӣ��������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_connect_state(UInt16 CardNo, UInt16 NodeNum, UInt16 state, UInt16 baud);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_connect_state(UInt16 CardNo, ref UInt16 NodeNum, ref UInt16 state);
        //---------------------------CAN ADDA������ֵ���----------------------
        //����CAN DA������������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_da_output_ex(ushort CardNo, ushort NoteID, ushort channel, double Value, ref ushort state);
        //��ȡCAN DA������������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_da_output_ex(ushort CardNo, ushort NoteID, ushort channel, ref double Value, ref ushort state);
        //��ȡCAN AD������������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_ad_input_ex(ushort CardNo, ushort NoteID, ushort channel, ref double Value, ref ushort state);
        //����CAN ADģʽ��������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_ad_mode_ex(ushort CardNo, ushort NoteID, ushort channel, ushort mode, UInt32 buffer_nums, ref ushort state);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_ad_mode_ex(ushort CardNo, ushort NoteID, ushort channel, ref ushort mode, UInt32 buffer_nums, ref ushort state);
        //����CAN DAģʽ��������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_da_mode_ex(ushort CardNo, ushort NoteID, ushort channel, ushort mode, UInt32 buffer_nums, ref ushort state);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_da_mode_ex(ushort CardNo, ushort NoteID, ushort channel, ref ushort mode, UInt32 buffer_nums, ref ushort state);
        //����д��flash��������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_to_flash_ex(ushort CardNo, ushort PortNum, ushort NodeNum, ref ushort state);

        //--------------------�����岹����----------------------	
        //��������������������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_open_list", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_open_list(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList);
        //�ر�������������������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_close_list", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_close_list(UInt16 CardNo, UInt16 Crd);
        //��λ������������Ԥ����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_reset_list(UInt16 CardNo, UInt16 Crd);
        //�����岹��ֹͣ��������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_stop_list", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_stop_list(UInt16 CardNo, UInt16 Crd, UInt16 stop_mode);
        //�����岹����ͣ��������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_pause_list", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_pause_list(UInt16 CardNo, UInt16 Crd);
        //��ʼ�����岹��������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_start_list", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_start_list(UInt16 CardNo, UInt16 Crd);
        //��������岹�˶�״̬��0-���У�1-��ͣ��2-����ֹͣ��DMC5X10��֧�֣���3-δ������4-���У�������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_run_state", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_run_state(UInt16 CardNo, UInt16 Crd);
        //��������岹�˶�״̬��0-���У�1-ֹͣ��Ԥ����
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_check_done", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_check_done(UInt16 CardNo, UInt16 Crd);  
        //�������岹ʣ�໺������������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_remain_space", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 dmc_conti_remain_space(UInt16 CardNo, UInt16 Crd);
        //��ȡ��ǰ�����岹�εı�ţ�������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_read_current_mark", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 dmc_conti_read_current_mark(UInt16 CardNo, UInt16 Crd);
        //blend�սǹ���ģʽ��������DMC5000ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_blend", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_blend(UInt16 CardNo, UInt16 Crd, UInt16 enable);      
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_blend", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_blend(UInt16 CardNo, UInt16 Crd, ref UInt16 enable);
        //����ÿ���ٶȱ���  ������ָ�������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_override", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_override(UInt16 CardNo, UInt16 Crd, double Percent);      
        //���ò岹�ж�̬���٣�������DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_change_speed_ratio", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_change_speed_ratio(UInt16 CardNo, UInt16 Crd, double Percent);
        //С�߶�ǰհ��������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_lookahead_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_lookahead_mode(UInt16 CardNo, UInt16 Crd, UInt16 enable, Int32 LookaheadSegments, double PathError, double LookaheadAcc);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_lookahead_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_lookahead_mode(UInt16 CardNo, UInt16 Crd, ref UInt16 enable, ref Int32 LookaheadSegments, ref double PathError, ref double LookaheadAcc);
        //--------------------�����岹IO����----------------------
        //�ȴ�IO���루������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_wait_input", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_wait_input(UInt16 CardNo, UInt16 Crd, UInt16 bitno, UInt16 on_off, double TimeOut, Int32 mark);
        //����ڹ켣���IO�ͺ������������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_delay_outbit_to_start", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_delay_outbit_to_start(UInt16 CardNo, UInt16 Crd, UInt16 bitno, UInt16 on_off, double delay_value, UInt16 delay_mode, double ReverseTime);      
        //����ڹ켣�յ�IO�ͺ������������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_delay_outbit_to_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_delay_outbit_to_stop(UInt16 CardNo, UInt16 Crd, UInt16 bitno, UInt16 on_off, double delay_time, double ReverseTime);      
        //����ڹ켣�յ�IO��ǰ�����������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_ahead_outbit_to_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_ahead_outbit_to_stop(UInt16 CardNo, UInt16 Crd, UInt16 bitno, UInt16 on_off, double ahead_value, UInt16 ahead_mode, double ReverseTime);  
        //�����岹��ȷλ��CMP�����������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_accurate_outbit_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_accurate_outbit_unit(UInt16 CardNo, UInt16 Crd, UInt16 cmp_no, UInt16 on_off, UInt16 map_axis, double abs_pos, UInt16 pos_source, double ReverseTime);    
        //�����岹����IO�����������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_write_outbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_write_outbit(UInt16 CardNo, UInt16 Crd, UInt16 bitno, UInt16 on_off, double ReverseTime);     
        //�������δִ�����IO��������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_clear_io_action", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_clear_io_action(UInt16 CardNo, UInt16 Crd, UInt32 IoMask);    
        //�����岹��ͣ���쳣ʱIO���״̬��������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_pause_output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_pause_output(UInt16 CardNo, UInt16 Crd, UInt16 action, Int32 mask, Int32 state);     //��ͣʱIO��� action 0, ��������1�� ��ͣʱ���io_state; 2 ��ͣʱ���io_state, ��������ʱ���Ȼָ�ԭ����io; 3,��2�Ļ����ϣ�ֹͣʱҲ��Ч��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_pause_output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_pause_output(UInt16 CardNo, UInt16 Crd, ref UInt16 action, ref Int32 mask, ref Int32 state);
        //��ʱָ�������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_delay", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_delay(UInt16 CardNo, UInt16 Crd, double delay_time, Int32 mark);     //������ʱָ��
        //IO�����ʱ��ת��������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_reverse_outbit(UInt16 CardNo, UInt16 Crd, UInt16 bitno, double reverse_time);
        //IO��ʱ�����������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_delay_outbit(UInt16 CardNo, UInt16 Crd, UInt16 bitno, UInt16 on_off, double delay_time);
        //�����岹�����˶���������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_pmove_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_pmove_unit(UInt16 CardNo, UInt16 Crd, UInt16 Axis, double dist, UInt16 posi_mode, UInt16 mode, Int32 mark); //�����岹�п���ָ�������˶�
        //�����岹ֱ�߲岹��������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_line_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_line_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, UInt16 posi_mode, Int32 mark); //�����岹ֱ��
        //�����岹Բ��Բ���岹��������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_arc_move_center_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_arc_move_center_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, double[] Cen_Pos, UInt16 Arc_Dir, Int32 Circle, UInt16 posi_mode, Int32 mark);    
        //�����岹�뾶Բ���岹��������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_arc_move_radius_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_arc_move_radius_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, double Arc_Radius, UInt16 Arc_Dir, Int32 Circle, UInt16 posi_mode, Int32 mark);   
        //�����岹3��Բ���岹��������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_arc_move_3points_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_arc_move_3points_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, double[] Mid_Pos, Int32 Circle, UInt16 posi_mode, Int32 mark);     
        //�����岹���β岹��������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_rectangle_move_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_rectangle_move_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] TargetPos, double[] MaskPos, Int32 Count, UInt16 rect_mode, UInt16 posi_mode, Int32 mark);     
        //���������߲岹�˶�ģʽ��������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_involute_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_involute_mode(UInt16 CardNo, UInt16 Crd, UInt16 mode);      //�����������Ƿ���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_involute_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_involute_mode(UInt16 CardNo, UInt16 Crd, ref UInt16 mode);   //��ȡ�������Ƿ�������
        //�����ã�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_line_unit_extern(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, double[] Cen_Pos, UInt16 posi_mode, Int32 mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_arc_move_center_unit_extern(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, double[] Cen_Pos, double Arc_Radius, UInt16 posi_mode, Int32 mark);
        //���ö�ȡ���Ÿ���ģʽ��������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_gear_follow_profile(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 master_axis, double ratio);//˫Z��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_gear_follow_profile(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 master_axis, ref double ratio);
              
        //--------------------PWM����----------------------
        //PWM���ƣ����ã�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_pwm_pin(UInt16 CardNo, UInt16 portno, UInt16 ON_OFF, double dfreqency, double dduty);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pwm_pin(UInt16 CardNo, UInt16 portno, ref UInt16 ON_OFF, ref double dfreqency, ref double dduty);
        //���ö�ȡPWMʹ�ܣ�������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_pwm_enable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_pwm_enable(UInt16 CardNo, UInt16 enable);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_pwm_enable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_pwm_enable(UInt16 CardNo, ref UInt16 enable);
        //���ö�ȡPWM���������������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_pwm_output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_pwm_output(UInt16 CardNo, UInt16 pwm_no, double fDuty, double fFre);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_pwm_output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_pwm_output(UInt16 CardNo, UInt16 pwm_no, ref double fDuty, ref double fFre);        
        //�����岹PWM�����������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_pwm_output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_pwm_output(UInt16 CardNo, UInt16 Crd, UInt16 pwm_no, double fDuty, double fFre);
        //����PWM���ܣ����ã�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_pwm_enable_extern(UInt16 CardNo, UInt16 channel, UInt16 enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pwm_enable_extern(UInt16 CardNo, UInt16 channel, ref UInt16 enable);
        //����PWM���ض�Ӧ��ռ�ձȣ�������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_pwm_onoff_duty", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_pwm_onoff_duty(UInt16 CardNo, UInt16 PwmNo, double fOnDuty, double fOffDuty);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_pwm_onoff_duty", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_pwm_onoff_duty(UInt16 CardNo, UInt16 PwmNo, ref double fOnDuty, ref double fOffDuty);
        //�����岹PWM�ٶȸ��棨������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_pwm_follow_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_pwm_follow_speed(UInt16 CardNo, UInt16 Crd, UInt16 pwm_no, UInt16 mode, double MaxVel, double MaxValue, double OutValue);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_pwm_follow_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_pwm_follow_speed(UInt16 CardNo, UInt16 Crd, UInt16 pwm_no, ref UInt16 mode, ref double MaxVel, ref double MaxValue, ref double OutValue);
        //�����岹��Թ켣���PWM�ͺ������������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_delay_pwm_to_start", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_delay_pwm_to_start(UInt16 CardNo, UInt16 Crd, UInt16 pwmno, UInt16 on_off, double delay_value, UInt16 delay_mode, double ReverseTime);
        //�����岹��Թ켣�յ�PWM��ǰ�����������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_ahead_pwm_to_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_ahead_pwm_to_stop(UInt16 CardNo, UInt16 Crd, UInt16 pwmno, UInt16 on_off, double ahead_value, UInt16 ahead_mode, double ReverseTime);
        //�����岹PWM���������������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_write_pwm", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_write_pwm(UInt16 CardNo, UInt16 Crd, UInt16 pwmno, UInt16 on_off, double ReverseTime);

        //--------------------ADDA���----------------------
        //���ƿ����ߺ�DA���������DA���ʹ�ܣ��������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_da_enable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_da_enable(UInt16 CardNo, UInt16 enable);      
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_da_enable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_da_enable(UInt16 CardNo, ref UInt16 enable);
        //����DA������������������忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_da_output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_da_output(UInt16 CardNo, UInt16 channel, double Vout);   
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_da_output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_da_output(UInt16 CardNo, UInt16 channel, ref double Vout);
        //���ƿ����ߺ�AD���룬��ȡAD���루�������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_ad_input(ushort CardNo, ushort channel, ref double Vout);
        //��������DAʹ�ܣ�������DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_da_output(UInt16 CardNo, UInt16 Crd, UInt16 channel, double Vout);
        //��������DAʹ�ܣ�������DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_da_enable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_da_enable(ushort CardNo, ushort Crd, ushort enable, ushort channel, int mark);
        //������da���棨Ԥ����
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_encoder_da_follow_enable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_encoder_da_follow_enable(ushort CardNo, ushort axis, ushort enable);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_encoder_da_follow_enable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_encoder_da_follow_enable(ushort CardNo, ushort axis, ref ushort enable);
        //�����岹DA�ٶȸ��棨������DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_da_follow_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_da_follow_speed(ushort CardNo, ushort Crd, ushort da_no, double MaxVel, double MaxValue, double acc_offset, double dec_offset, double acc_dist, double dec_dist);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_da_follow_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_da_follow_speed(ushort CardNo, ushort Crd, ushort da_no, ref double MaxVel, ref double MaxValue, ref double acc_offset, ref double dec_offset, ref double acc_dist, ref double dec_dist);

        //СԲ����ʹ�ܣ�������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_arc_limit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_arc_limit(UInt16 CardNo, UInt16 Crd, UInt16 Enable, double MaxCenAcc, double MaxArcError);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_arc_limit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_arc_limit(UInt16 CardNo, UInt16 Crd, ref UInt16 Enable, ref double MaxCenAcc, ref double MaxArcError);
        //��Ԥ����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_IoFilter(UInt16 CardNo, UInt16 bitno, double filter);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_IoFilter(UInt16 CardNo, UInt16 bitno, ref double filter);
        //�ݾಹ������ָ���ʹ�ã�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_lsc_index_value(UInt16 CardNo, UInt16 axis, UInt16 IndexID, Int32 IndexValue);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_lsc_index_value(UInt16 CardNo, UInt16 axis, UInt16 IndexID, ref Int32 IndexValue);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_lsc_config(UInt16 CardNo, UInt16 axis, UInt16 Origin, UInt32 Interal, UInt32 NegIndex, UInt32 PosIndex, double Ratio);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_lsc_config(UInt16 CardNo, UInt16 axis, ref UInt16 Origin, ref UInt32 Interal, ref UInt32 NegIndex, ref UInt32 PosIndex, ref double Ratio);
        //���Ź���ָ���ʹ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_watchdog(UInt16 CardNo, UInt16 enable, UInt32 time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_call_watchdog(UInt16 CardNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_diagnoseData(UInt16 CardNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_cmd_end(UInt16 CardNo, UInt16 Crd, UInt16 enable);
        //��������λ��������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_zone_limit_config(UInt16 CardNo, UInt16[] axis, UInt16[] Source, Int32 x_pos_p, Int32 x_pos_n, Int32 y_pos_p, Int32 y_pos_n, UInt16 action_para);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_zone_limit_config(UInt16 CardNo, UInt16[] axis, UInt16[] Source, ref Int32 x_pos_p, ref Int32 x_pos_n, ref Int32 y_pos_p, ref Int32 y_pos_n, ref UInt16 action_para);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_zone_limit_enable(UInt16 CardNo, UInt16 enable);
        //�ụ�����ܣ�������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_interlock_config(UInt16 CardNo, UInt16[] axis, UInt16[] Source, Int32 delta_pos, UInt16 action_para);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_interlock_config(UInt16 CardNo, UInt16[] axis, UInt16[] Source, ref Int32 delta_pos, ref UInt16 action_para);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_interlock_enable(UInt16 CardNo, UInt16 enable);
        //����ģʽ��������������DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_grant_error_protect(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt32 dstp_error, UInt32 emg_error);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_grant_error_protect(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt32 dstp_error, ref UInt32 emg_error);
        //����ģʽ����������������������DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_grant_error_protect_unit(UInt16 CardNo, UInt16 axis, UInt16 enable, double dstp_error, double emg_error);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_grant_error_protect_unit(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref double dstp_error, ref double emg_error);

        //����ּ��� ���ּ�̼�ר�ã�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_camerablow_config(UInt16 CardNo, UInt16 camerablow_en, Int32 cameraPos, UInt16 piece_num, Int32 piece_distance, UInt16 axis_sel, Int32 latch_distance_min);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_camerablow_config(UInt16 CardNo, ref UInt16 camerablow_en, ref Int32 cameraPos, ref UInt16 piece_num, ref Int32 piece_distance, ref UInt16 axis_sel, ref Int32 latch_distance_min);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_clear_camerablow_errorcode(UInt16 CardNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_camerablow_errorcode(UInt16 CardNo, ref UInt16 errorcode);
        //����ͨ�����루0~15����Ϊ�����λ�źţ�������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_io_limit_config(UInt16 CardNo, UInt16 portno, UInt16 enable, UInt16 axis_sel, UInt16 el_mode, UInt16 el_logic);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_io_limit_config(UInt16 CardNo, UInt16 portno, ref UInt16 enable, ref UInt16 axis_sel, ref UInt16 el_mode, ref UInt16 el_logic);
        //�����˲�������������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_handwheel_filter(UInt16 CardNo, UInt16 axis, double filter_factor);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_handwheel_filter(UInt16 CardNo, UInt16 axis, ref double filter_factor);
        //��ȡ����ϵ����ĵ�ǰ�滮���꣨������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_interp_map(UInt16 CardNo, UInt16 Crd, ref UInt16 AxisNum, UInt16[] AxisList, double[] pPosList);
        //����ϵ������� ��������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_crd_errcode(UInt16 CardNo, UInt16 Crd, ref UInt16 errcode);
        //����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_line_unit_follow(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Dist, UInt16 posi_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_line_unit_follow(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] pPosList, UInt16 posi_mode, Int32 mark);
        //�����岹������DA������������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_da_action(UInt16 CardNo, UInt16 Crd, UInt16 mode, UInt16 portno, double dvalue);
        //���������ٶȣ�������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_encoder_speed(UInt16 CardNo, UInt16 Axis, ref double current_speed);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_axis_follow_line_enable(UInt16 CardNo, UInt16 Crd, UInt16 enable_flag);
        //�岹�����岹����������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_interp_compensation(UInt16 CardNo, UInt16 axis, double dvalue, double time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_interp_compensation(UInt16 CardNo, UInt16 axis, ref double dvalue, ref double time);
        //��ȡ��������ľ��루������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_distance_to_start(UInt16 CardNo, UInt16 Crd, ref double distance_x, ref double distance_y, Int32 imark);
        //���ñ�־λ ��ʾ�Ƿ�ʼ���������㣨������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_start_distance_flag(UInt16 CardNo, UInt16 Crd, UInt16 flag);

        //������棨������DMC5000/5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_gear_unit(UInt16 CardNo, UInt16 Crd, UInt16 axis, double dist, UInt16 follow_mode, Int32 imark);
        //�켣���ʹ�����ã�������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_path_fitting_enable(UInt16 CardNo, UInt16 Crd, UInt16 enable);
        //--------------------�ݾಹ��----------------------
        //�ݾಹ������(��)���������������忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_enable_leadscrew_comp(UInt16 CardNo, UInt16 axis, UInt16 enable);
        //�����߼��������������壩���������������忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_leadscrew_comp_config(UInt16 CardNo, UInt16 axis, UInt16 n, Int32 startpos, Int32 lenpos, Int32[] pCompPos, Int32[] pCompNeg);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_leadscrew_comp_config(UInt16 CardNo, UInt16 axis, ref UInt16 n, ref int startpos, ref int lenpos, int[] pCompPos, int[] pCompNeg);
        //�����߼�������������������������DMC5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_leadscrew_comp_config_unit(UInt16 CardNo, UInt16 axis, UInt16 n, double startpos, double lenpos, double[] pCompPos, double[] pCompNeg);       
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_leadscrew_comp_config_unit(UInt16 CardNo, UInt16 axis, ref UInt16 n, ref double startpos, ref double lenpos, double[] pCompPos, double[] pCompNeg);
        //�ݾಹ��ǰ������λ�ã�������λ��//20191025��������DMC3000ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_position_ex(UInt16 CardNo, UInt16 axis, ref double pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_encoder_ex(UInt16 CardNo, UInt16 axis, ref double pos);
        //�ݾಹ��ǰ������λ�ã�������λ�� ������������DMC5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_position_ex_unit(UInt16 CardNo, UInt16 axis, ref double pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_encoder_ex_unit(UInt16 CardNo, UInt16 axis, ref double pos);

        //ָ����������λ���˶� ���̶������˶���������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_t_pmove_extern(UInt16 CardNo, UInt16 axis, double MidPos, double TargetPos, double Min_Vel, double Max_Vel, double stop_Vel, double acc, double dec, UInt16 posi_mode);
        //
        [DllImport("LTDMC.dll")]
        public static extern short dmc_t_pmove_extern_unit(UInt16 CardNo, UInt16 axis, double MidPos, double TargetPos, double Min_Vel, double Max_Vel, double stop_Vel, double acc, double dec, UInt16 posi_mode);
        //�����������ֵ�ͱ���������ֵ֮���ֵ�ı�����ֵ��������DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_pulse_encoder_count_error(UInt16 CardNo, UInt16 axis, UInt16 error);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pulse_encoder_count_error(UInt16 CardNo, UInt16 axis, ref UInt16 error);
        //����������ֵ�ͱ���������ֵ֮���ֵ�Ƿ񳬹�������ֵ��������DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_check_pulse_encoder_count_error(UInt16 CardNo, UInt16 axis, ref Int32 pulse_position, ref Int32 enc_position);
        //����/�ض��������ֵ�ͱ���������ֵ֮���ֵ�ı�����ֵunit��������DMC5X10���忨��EtherCAT���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_pulse_encoder_count_error_unit(ushort CardNo, ushort axis, double error);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pulse_encoder_count_error_unit(ushort CardNo, ushort axis, ref double error);
        //����������ֵ�ͱ���������ֵ֮���ֵ�Ƿ񳬹�������ֵunit��������DMC5X10���忨��EtherCAT���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_check_pulse_encoder_count_error_unit(ushort CardNo, ushort axis, ref double pulse_position, ref double enc_position);
        //ʹ�ܺ����ø��ٱ��������ڷ�Χ��ʱ���ֹͣģʽ��������DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_encoder_count_error_action_config(UInt16 CardNo, UInt16 enable, UInt16 stopmode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_encoder_count_error_action_config(UInt16 CardNo, ref UInt16 enable, ref UInt16 stopmode);
        
        //������ּ��� �ּ�̼�ר��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_close(UInt16 CardNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_start(UInt16 CardNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_init_config(UInt16 CardNo, UInt16 cameraCount, Int32[] pCameraPos, UInt16[] pCamIONo, UInt32 cameraTime, UInt16 cameraTrigLevel, UInt16 blowCount, Int32[] pBlowPos, UInt16[] pBlowIONo, UInt32 blowTime, UInt16 blowTrigLevel, UInt16 axis, UInt16 dir, UInt16 checkMode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_camera_trig_count(UInt16 CardNo, UInt16 cameraNum, UInt32 cameraTrigCnt);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_camera_trig_count(UInt16 CardNo, UInt16 cameraNum, ref UInt32 pCameraTrigCnt, UInt16 count);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_blow_trig_count(UInt16 CardNo, UInt16 blowNum, UInt32 blowTrigCnt);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_blow_trig_count(UInt16 CardNo, UInt16 blowNum, ref UInt32 pBlowTrigCnt, UInt16 count);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_camera_config(UInt16 CardNo, UInt16 index, ref Int32 pos, ref UInt32 trigTime, ref UInt16 ioNo, ref UInt16 trigLevel);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_blow_config(UInt16 CardNo, UInt16 index, ref Int32 pos, ref UInt32 trigTime, ref UInt16 ioNo, ref UInt16 trigLevel);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_blow_status(UInt16 CardNo, ref Int32 trigCntAll, ref UInt16 trigMore, ref UInt16 trigLess);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_trig_blow(UInt16 CardNo, UInt16 blowNum);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_blow_enable(UInt16 CardNo, UInt16 blowNum, UInt16 enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_piece_config(UInt16 CardNo, UInt32 maxWidth, UInt32 minWidth, UInt32 minDistance, UInt32 minTimeIntervel);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_piece_status(UInt16 CardNo, ref UInt32 pieceFind, ref UInt32 piecePassCam, ref UInt32 dist2next, ref UInt32 pieceWidth);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_cam_trig_phase(UInt16 CardNo, UInt16 blowNo, double coef);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_blow_trig_phase(UInt16 CardNo, UInt16 blowNo, double coef);
        
        //�ڲ�ʹ�ã�������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_sevon_enable(UInt16 CardNo, UInt16 axis, UInt16 on_off);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_sevon_enable(UInt16 CardNo, UInt16 axis);

        //����������da���棨������DMC5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_encoder_da_follow_enable(UInt16 CardNo, UInt16 Crd, UInt16 axis, UInt16 enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_encoder_da_follow_enable(UInt16 CardNo, UInt16 Crd, ref UInt16 axis, ref UInt16 enable);
        //����λ���������������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_factor_error", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_factor_error(UInt16 CardNo, UInt16 axis, double factor, Int32 error);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_factor_error", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_factor_error(UInt16 CardNo, UInt16 axis, ref double factor, ref Int32 error);
        //����/�ض�λ������unit��������DMC5X10���忨��EtherCAT���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_factor_error_unit(ushort CardNo, ushort axis, double factor, double error);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_factor_error_unit(ushort CardNo, ushort axis, ref double factor, ref double error);
        //����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_check_done_pos(UInt16 CardNo, UInt16 axis, UInt16 posi_mode);
        //����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_factor(UInt16 CardNo, UInt16 axis, double factor);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_error(UInt16 CardNo, UInt16 axis, Int32 error);
        //���ָ�λ���������������忨�����߿���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_check_success_pulse", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_check_success_pulse(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_check_success_encoder", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_check_success_encoder(UInt16 CardNo, UInt16 axis);

        //IO���������������ܣ�������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_io_count_profile(UInt16 CardNo, UInt16 chan, UInt16 bitno,UInt16 mode,double filter, double count_value, UInt16[] axis_list, UInt16 axis_num, UInt16 stop_mode );
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_io_count_profile(UInt16 CardNo, UInt16 chan, ref UInt16 bitno,ref UInt16 mode,ref double filter, ref double count_value, UInt16[] axis_list, ref UInt16 axis_num, ref UInt16 stop_mode );
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_io_count_enable(UInt16 CardNo, UInt16 chan, UInt16 ifenable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_clear_io_count(UInt16 CardNo, UInt16 chan);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_io_count_value_extern(UInt16 CardNo, UInt16 chan, ref Int32 current_value);
        //����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_change_speed_extend(UInt16 CardNo,UInt16 axis,double Curr_Vel, double Taccdec, UInt16 pin_num, UInt16 trig_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_follow_vector_speed_move(UInt16 CardNo,UInt16 axis,UInt16 Follow_AxisNum,UInt16[] Follow_AxisList,double ratio);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_line_unit_extend(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] pPosList, UInt16 posi_mode, double Extend_Len, UInt16 enable,Int32 mark); //�����岹ֱ��
     
        //���߲���
        [DllImport("LTDMC.dll", EntryPoint = "nmc_download_configfile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_download_configfile(UInt16 CardNo, UInt16 PortNum, String FileName);//����ENI�����ļ�
        [DllImport("LTDMC.dll", EntryPoint = "nmc_download_mapfile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_download_mapfile(UInt16 CardNo, String FileName);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_upload_configfile(UInt16 CardNo, UInt16 PortNum, String FileName);
        [DllImport("LTDMC.dll", EntryPoint = "nmc_set_manager_para", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_set_manager_para(UInt16 CardNo, UInt16 PortNum, Int32 baudrate, UInt16 ManagerID);
        [DllImport("LTDMC.dll", EntryPoint = "nmc_get_manager_para", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_get_manager_para(UInt16 CardNo, UInt16 PortNum, ref UInt32 baudrate, ref UInt16 ManagerID);
        [DllImport("LTDMC.dll", EntryPoint = "nmc_set_manager_od", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_set_manager_od(UInt16 CardNo, UInt16 PortNum, UInt16 index, UInt16 subindex, UInt16 valuelength, UInt32 value);
        [DllImport("LTDMC.dll", EntryPoint = "nmc_get_manager_od", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_get_manager_od(UInt16 CardNo, UInt16 PortNum, UInt16 index, UInt16 subindex, UInt16 valuelength, ref UInt32 value);

        [DllImport("LTDMC.dll", EntryPoint = "nmc_get_total_axes", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_get_total_axes(ushort CardNo, ref uint TotalAxis);
        [DllImport("LTDMC.dll", EntryPoint = "nmc_get_total_ionum", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_get_total_ionum(UInt16 CardNo, ref UInt16 TotalIn, ref UInt16 TotalOut);
        [DllImport("LTDMC.dll", EntryPoint = "nmc_get_LostHeartbeat_Nodes", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_get_LostHeartbeat_Nodes(UInt16 CardNo, UInt16 PortNum, UInt16[] NodeID, ref UInt16 NodeNum);
        [DllImport("LTDMC.dll", EntryPoint = "nmc_get_EmergeneyMessege_Nodes", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_get_EmergeneyMessege_Nodes(UInt16 CardNo, UInt16 PortNum, UInt32[] NodeMsg, ref UInt16 MsgNum);
        [DllImport("LTDMC.dll", EntryPoint = "nmc_SendNmtCommand", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_SendNmtCommand(UInt16 CardNo, UInt16 PortNum, UInt16 NodeID, UInt16 NmtCommand);
        [DllImport("LTDMC.dll", EntryPoint = "nmc_syn_move", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_syn_move(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList, Int32[] Position, UInt16[] PosiMode);
        //
        [DllImport("LTDMC.dll")]
        public static extern short nmc_syn_move_unit(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList, double[] Position, UInt16[] PosiMode);
        //���߶���ͬ���˶�
        [DllImport("LTDMC.dll")]
        public static extern short nmc_sync_pmove_unit(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList, double[] Dist, UInt16[] PosiMode);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_sync_vmove_unit(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList, UInt16[] Dir);
        //������վ����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_master_para(UInt16 CardNo, UInt16 PortNum, UInt16 Baudrate, UInt32 NodeCnt, UInt16 MasterId);
        //��ȡ��վ����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_master_para(UInt16 CardNo, UInt16 PortNum, ref UInt16 Baudrate, ref UInt32 NodeCnt, ref UInt16 MasterId);
        //��ȡ����ADDA�����������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_total_adcnum(ushort CardNo, ref ushort TotalIn, ref ushort TotalOut);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_controller_workmode(ushort CardNo, ushort controller_mode);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_controller_workmode(ushort CardNo, ref ushort controller_mode);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_cycletime(ushort CardNo, ushort FieldbusType, int CycleTime);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_cycletime(ushort CardNo, ushort FieldbusType, ref int CycleTime);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_node_od(ushort CardNo, ushort PortNum, ushort nodenum, ushort index, ushort subindex, ushort valuelength, ref int value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_node_od(ushort CardNo, ushort PortNum, ushort nodenum, ushort index, ushort subindex, ushort valuelength, int value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_reset_to_factory(ushort CardNo, ushort PortNum, ushort NodeNum);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_alarm_clear(ushort CardNo, ushort PortNum, ushort nodenum);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_slave_nodes(ushort CardNo, ushort PortNum, ushort BaudRate, ref ushort NodeId, ref ushort NodeNum);
        
        //��״̬��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_state_machine(ushort CardNo, ushort axis, ref ushort Axis_StateMachine);
        //��ȡ��״̬��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_statusword(ushort CardNo, ushort axis, ref int statusword);
        //��ȡ�����ÿ���ģʽ������ֵ��6����ģʽ��8cspģʽ��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_setting_contrlmode(ushort CardNo, ushort axis, ref int contrlmode);
        //���������������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_axis_contrlword(ushort CardNo, ushort axis, int contrlword);
        //��ȡ�����������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_contrlword(ushort CardNo, ushort axis, ref int contrlword);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_type(ushort CardNo, ushort axis, ref ushort Axis_Type);
        //��ȡ����ʱ������ƽ��ʱ�䣬���ʱ�䣬ִ��������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_consume_time_fieldbus(ushort CardNo, ushort Fieldbustype, ref uint Average_time, ref uint Max_time, ref UInt64 Cycles);
        //���ʱ����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_clear_consume_time_fieldbus(ushort CardNo, ushort Fieldbustype);
        //���ߵ���ʹ�ܺ��� 255��ʾȫʹ��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_axis_enable(ushort CardNo, ushort axis);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_axis_disable(ushort CardNo, ushort axis);
        // ��ȡ��Ĵ�վ��Ϣ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_node_address(ushort CardNo, ushort axis, ref ushort SlaveAddr, ref ushort Sub_SlaveAddr);
        //��ȡ��������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_total_slaves(ushort CardNo, ushort PortNum, ref ushort TotalSlaves);
        [DllImport("LTDMC.dll")]
        //���߻�ԭ�㺯��
        public static extern short nmc_set_home_profile(ushort CardNo, ushort axis, ushort home_mode, double Low_Vel, double High_Vel, double Tacc, double Tdec, double offsetpos);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_home_profile(ushort CardNo, ushort axis, ref ushort home_mode, ref double Low_Vel, ref double High_Vel, ref double Tacc, ref double Tdec, ref double offsetpos);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_home_move(ushort CardNo, ushort axis);
        //
        [DllImport("LTDMC.dll")]
        public static extern short nmc_start_scan_ethercat(ushort CardNo, ushort AddressID);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_stop_scan_ethercat(ushort CardNo, ushort AddressID);
        //�����������ģʽ 1Ϊppģʽ��6Ϊ����ģʽ��8Ϊcspģʽ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_axis_run_mode(ushort CardNo, ushort axis, ushort run_mode);
        //����˿ڱ���
        [DllImport("LTDMC.dll")]
        public static extern short nmc_clear_alarm_fieldbus(ushort CardNo, ushort PortNum);
        //ֹͣethercat����,����0��ʾ�ɹ�������������ʾ���ɹ�
        [DllImport("LTDMC.dll")]
        public static extern short nmc_stop_etc(ushort CardNo, ref ushort ETCState);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_contrlmode(ushort CardNo, ushort Axis, ref int Contrlmode);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_io_in(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_axis_io_out(UInt16 CardNo, UInt16 axis, UInt32 iostate);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_io_out(UInt16 CardNo, UInt16 axis);
        // ��ȡ���߶˿ڴ�����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_errcode(ushort CardNo, ushort channel, ref ushort errcode);
        // ������߶˿ڴ�����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_clear_errcode(ushort CardNo, ushort channel);
        // ��ȡ�����������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_errcode(ushort CardNo, ushort axis, ref ushort Errcode);
        // ��������������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_clear_axis_errcode(ushort CardNo, ushort axis);

        //RTEX�����Ӻ���
        [DllImport("LTDMC.dll")]
        public static extern short nmc_start_connect(UInt16 CardNo, UInt16 chan, ref UInt16 info, ref UInt16 len);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_vendor_info(UInt16 CardNo, UInt16 axis, Byte[] info, ref UInt16 len);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_slave_type_info(UInt16 CardNo, UInt16 axis, Byte[] info, ref UInt16 len);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_slave_name_info(UInt16 CardNo, UInt16 axis, Byte[] info, ref UInt16 len);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_slave_version_info(UInt16 CardNo, UInt16 axis, Byte[] info, ref UInt16 len);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_parameter(UInt16 CardNo, UInt16 axis, UInt16 index, UInt16 subindex, UInt32 para_data);
        /**************************************************************
        *����˵����RTEX������дEEPROM����
        **************************************************************/
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_slave_eeprom(UInt16 CardNo, UInt16 axis);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_parameter(UInt16 CardNo, UInt16 axis, UInt16 index, UInt16 subindex, ref UInt32 para_data);
        /**************************************************************
         * *index:rtex�������Ĳ�������
         * *subindex:rtex��������index����µĲ������
         * *para_data:�����Ĳ���ֵ
         * **************************************************************/
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_parameter_attributes(UInt16 CardNo, UInt16 axis, UInt16 index, UInt16 subindex, ref UInt32 para_data);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_cmdcycletime(UInt16 CardNo, UInt16 PortNum, UInt32 cmdtime);
        //����RTEX�������ڱ�(us)
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_cmdcycletime(UInt16 CardNo, UInt16 PortNum, ref UInt32 cmdtime);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_config_atuo_log(UInt16 CardNo, UInt16 ifenable, UInt16 dir, UInt16 byte_index, UInt16 mask, UInt16 condition, UInt32 counter);

        //��չPDO
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_rxpdo_extra(UInt16 CardNo, UInt16 PortNum, UInt16 address, UInt16 DataLen, Int32 Value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_rxpdo_extra(UInt16 CardNo, UInt16 PortNum, UInt16 address, UInt16 DataLen, ref Int32 Value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_txpdo_extra(UInt16 CardNo, UInt16 PortNum, UInt16 address, UInt16 DataLen, ref Int32 Value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_rxpdo_extra_uint(UInt16 CardNo, UInt16 PortNum, UInt16 address, UInt16 DataLen, UInt32 Value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_rxpdo_extra_uint(UInt16 CardNo, UInt16 PortNum, UInt16 address, UInt16 DataLen, ref UInt32 Value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_txpdo_extra_uint(UInt16 CardNo, UInt16 PortNum, UInt16 address, UInt16 DataLen, ref UInt32 Value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_log_state(UInt16 CardNo, UInt16 chan, ref UInt32 state);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_driver_reset(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_offset_pos(UInt16 CardNo, UInt16 axis, double offset_pos);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_offset_pos(UInt16 CardNo, UInt16 axis, ref double offset_pos);
        //���rtex����ֵ�������Ķ�Ȧֵ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_clear_abs_driver_multi_cycle(UInt16 CardNo, UInt16 axis);
        //---------------------------EtherCAT IO��չģ�����ָ��----------------------
        //����io���32λ������չ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_outport_extern(UInt16 CardNo, UInt16 Channel, UInt16 NoteID, UInt16 portno, UInt32 outport_val);
        //��ȡio���32λ������չ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_outport_extern(UInt16 CardNo, UInt16 Channel, UInt16 NoteID, UInt16 portno, ref UInt32 outport_val);
        //��ȡio����32λ������չ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_inport_extern(UInt16 CardNo, UInt16 Channel, UInt16 NoteID, UInt16 portno, ref UInt32 inport_val);
        //����io���
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_outbit_extern(UInt16 CardNo, UInt16 Channel, UInt16 NoteID, UInt16 IoBit, UInt16 IoValue);
        //��ȡio���
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_outbit_extern(UInt16 CardNo, UInt16 Channel, UInt16 NoteID, UInt16 IoBit, ref UInt16 IoValue);
        //��ȡio����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_inbit_extern(UInt16 CardNo, UInt16 Channel, UInt16 NoteID, UInt16 IoBit, ref UInt16 IoValue);
        
        //�������������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_current_fieldbus_state_info(UInt16 CardNo, UInt16 Channel, ref UInt16 Axis, ref UInt16 ErrorType, ref UInt16 SlaveAddr, ref UInt32 ErrorFieldbusCode);
        // ������ʷ������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_detail_fieldbus_state_info(UInt16 CardNo, UInt16 Channel, UInt32 ReadErrorNum, ref UInt32 TotalNum, ref UInt32 ActualNum, UInt16[] Axis, UInt16[] ErrorType, UInt16[] SlaveAddr, UInt32[] ErrorFieldbusCode);
        //�����ɼ�
        [DllImport("LTDMC.dll")]
        public static extern short nmc_start_pdo_trace(UInt16 CardNo, UInt16 Channel, UInt16 SlaveAddr, UInt16 Index_Num, UInt32 Trace_Len, UInt16[] Index, UInt16[] Sub_Index);
        //��ȡ�ɼ�����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_pdo_trace(UInt16 CardNo, UInt16 Channel, UInt16 SlaveAddr, ref UInt16 Index_Num, ref UInt32 Trace_Len, UInt16[] Index, UInt16[] Sub_Index);
        //���ô����ɼ�����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_pdo_trace_trig_para(UInt16 CardNo, UInt16 Channel, UInt16 SlaveAddr, UInt16 Trig_Index, UInt16 Trig_Sub_Index, int Trig_Value, UInt16 Trig_Mode);
        //��ȡ�����ɼ�����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_pdo_trace_trig_para(UInt16 CardNo, UInt16 Channel, UInt16 SlaveAddr, ref UInt16 Trig_Index, ref UInt16 Trig_Sub_Index, ref int Trig_Value, ref UInt16 Trig_Mode);
        //�ɼ����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_clear_pdo_trace_data(UInt16 CardNo, UInt16 Channel, UInt16 SlaveAddr);
        //�ɼ�ֹͣ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_stop_pdo_trace(UInt16 CardNo, UInt16 Channel, UInt16 SlaveAddr);
        //�ɼ����ݶ�ȡ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_pdo_trace_data(UInt16 CardNo, UInt16 Channel, UInt16 SlaveAddr, UInt32 StartAddr, UInt32 Readlen, ref UInt32 ActReadlen, Byte[] Data);
        //�Ѳɼ�����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_pdo_trace_num(UInt16 CardNo, UInt16 Channel, UInt16 SlaveAddr, ref UInt32 Data_num, ref UInt32 Size_of_each_bag);
        //�ɼ�״̬
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_pdo_trace_state(UInt16 CardNo, UInt16 Channel, UInt16 SlaveAddr, ref UInt16 Trace_state);
        //����ר��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_reset_canopen(UInt16 CardNo);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_reset_rtex(UInt16 CardNo);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_reset_etc(UInt16 CardNo);
        //���ߴ���������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_fieldbus_error_switch(UInt16 CardNo, UInt16 channel, UInt16 data);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_fieldbus_error_switch(UInt16 CardNo, UInt16 channel, ref UInt16 data);

        ////����CST�л���CSP���������������ܼ�ʱͬ����վĿ��λ�ã���ʱʱ������վ����ͬ��������ʵ��λ�ã���ȡ���ù���
        //[DllImport("LTDMC.dll")]
        //public static extern short nmc_torque_set_delay_cycle(ushort CardNo, ushort axis, int delay_cycle);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_torque_move(UInt16 CardNo, UInt16 axis, int Torque, UInt16 PosLimitValid, double PosLimitValue, UInt16 PosMode);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_change_torque(UInt16 CardNo, UInt16 axis, int Torque);
        //��ȡת�ش�С
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_torque(UInt16 CardNo, UInt16 axis, ref int Torque);
        //modbus����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_modbus_active_COM1(UInt16 id, string COMID,int speed, int bits, int check, int stop);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_modbus_active_COM2(UInt16 id, string COMID, int speed, int bits, int check, int stop);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_modbus_active_ETH(UInt16 id, UInt16 port);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_modbus_0x(UInt16 CardNo, UInt16 start, UInt16 inum, byte[] pdata);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_modbus_0x(UInt16 CardNo, UInt16 start, UInt16 inum, byte[] pdata);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_modbus_4x(UInt16 CardNo, UInt16 start, UInt16 inum, UInt16[] pdata);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_modbus_4x(UInt16 CardNo, UInt16 start, UInt16 inum, UInt16[] pdata);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_modbus_4x_float(UInt16 CardNo, UInt16 start, UInt16 inum, float[] pdata);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_modbus_4x_float(UInt16 CardNo, UInt16 start, UInt16 inum, float[] pdata);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_modbus_4x_int(UInt16 CardNo, UInt16 start, UInt16 inum, int[] pdata);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_modbus_4x_int(UInt16 CardNo, UInt16 start, UInt16 inum, int[] pdata);
        //����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_line_io_union(UInt16 CardNo,UInt16 Crd,UInt16 AxisNum,UInt16[] AxisList,double[] pPosList,UInt16 posi_mode,UInt16 bitno,UInt16 on_off,double io_value,UInt16 io_mode,UInt16 MapAxis,UInt16 pos_source,double ReverseTime,long mark);
        //���ñ���������������DMC3000ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_encoder_dir(UInt16 CardNo, UInt16 axis,UInt16 dir);
        
        //Բ����������λ��������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_arc_zone_limit_config(UInt16 CardNo, UInt16[] AxisList, UInt16 AxisNum, double[] Center, double Radius, UInt16 Source,UInt16 StopMode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_arc_zone_limit_config(UInt16 CardNo, UInt16[] AxisList, ref UInt16 AxisNum, double[] Center, ref double Radius, ref UInt16 Source,ref UInt16 StopMode);
        //Բ����������λunit��������DMC5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_arc_zone_limit_config_unit(ushort CardNo, ushort[] AxisList, ushort AxisNum, double[] Center, double Radius, ushort Source, ushort StopMode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_arc_zone_limit_config_unit(ushort CardNo, ushort[] AxisList, ref ushort AxisNum, double[] Center, ref double Radius, ref ushort Source, ref ushort StopMode);
        //��ѯ��Ӧ���״̬��������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_arc_zone_limit_axis_status(UInt16 CardNo, UInt16 axis);
        //Բ����λʹ�ܣ�������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_arc_zone_limit_enable(UInt16 CardNo, UInt16 enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_arc_zone_limit_enable(UInt16 CardNo, ref UInt16 enable);
        
        //���ƿ����ߺж��ߺ��Ƿ��ʼ�������ƽ
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_output_status_repower(UInt16 CardNo, UInt16 enable);
        //�ɽӿڣ�������������ʹ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_t_pmove_extern_softlanding(UInt16 CardNo, UInt16 axis, double MidPos, double TargetPos, double start_Vel, double Max_Vel, double stop_Vel, UInt32 delay_ms, double Max_Vel2, double stop_vel2, double acc_time, double dec_time, UInt16 posi_mode);
        //����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_XD(UInt16 CardNo, UInt16 cmp, long pos, UInt16 dir, UInt16 action, UInt32 actpara, long startPos);//���綨�ƱȽϺ���
        
        //---------------------------ORG���봥�����߱��ٱ�λ----------------------
        //����ORG���봥�����߱��ٱ�λ��������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pmove_change_pos_speed_config(UInt16 CardNo, UInt16 axis, double tar_vel, double tar_rel_pos, UInt16 trig_mode, UInt16 source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pmove_change_pos_speed_config(UInt16 CardNo, UInt16 axis, ref double tar_vel, ref double tar_rel_pos, ref UInt16 trig_mode, ref UInt16 source);
        //ORG���봥�����߱��ٱ�λʹ�ܣ�������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pmove_change_pos_speed_enable(UInt16 CardNo, UInt16 axis, UInt16 enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pmove_change_pos_speed_enable(UInt16 CardNo, UInt16 axis, ref UInt16 enable);
        //��ȡORG���봥�����߱��ٱ�λ��״̬  trig_num ����������trig_pos ����λ�ã�������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pmove_change_pos_speed_state(ushort CardNo, ushort axis, ref ushort trig_num, double[] trig_pos);
        //IO���ٱ�λ������io����ڣ�������EtherCAT����ϵ�п���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pmove_change_pos_speed_inbit(ushort CardNo, ushort axis, ushort inbit, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pmove_change_pos_speed_inbit(ushort CardNo, ushort axis, ref ushort inbit, ref ushort enable);
        //����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_extend(UInt16 CardNo, UInt16 axis, long pos, UInt16 dir, UInt16 action, UInt16 para_num, ref UInt32 actpara, UInt32 compare_time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_cmd_position(UInt16 CardNo, UInt16 axis, ref double pos);
        //�߼��������ã��ڲ�ʹ�ã�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_logic_analyzer_config(UInt16 CardNo, UInt16 channel, UInt32 SampleFre, UInt32 SampleDepth, UInt16 SampleMode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_start_logic_analyzer(UInt16 CardNo, UInt16 channel, UInt16 enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_logic_analyzer_counter(UInt16 CardNo, UInt16 channel, ref UInt32 counter);
        //20190923�޸�kg���ƺ����ӿڣ��ͻ����ƣ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_inbit_append(UInt16 CardNo, UInt16 bitno);//��ȡ����ڵ�״̬
        [DllImport("LTDMC.dll")]
        public static extern short dmc_write_outbit_append(UInt16 CardNo, UInt16 bitno, UInt16 on_off);//��������ڵ�״̬
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_outbit_append(UInt16 CardNo, UInt16 bitno);//��ȡ����ڵ�״̬
        [DllImport("LTDMC.dll")]
        public static extern UInt32 dmc_read_inport_append(UInt16 CardNo, UInt16 portno);//��ȡ����˿ڵ�ֵ
        [DllImport("LTDMC.dll")]
        public static extern UInt32 dmc_read_outport_append(UInt16 CardNo, UInt16 portno);//��ȡ����˿ڵ�ֵ
        [DllImport("LTDMC.dll")]
        public static extern short dmc_write_outport_append(UInt16 CardNo, UInt16 portno, UInt32 port_value);//������������˿ڵ�ֵ

        //---------------------------��Բ�岹���������----------------------
        // ��������ϵ������棨������DMC5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_tangent_follow(UInt16 CardNo, UInt16 Crd, UInt16 axis, UInt16 follow_curve, UInt16 rotate_dir, double degree_equivalent);
        // ��ȡָ������ϵ������������������DMC5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_tangent_follow_param(UInt16 CardNo, UInt16 Crd, ref UInt16 axis, ref UInt16 follow_curve, ref UInt16 rotate_dir, ref double degree_equivalent);
        // ȡ������ϵ���棨������DMC5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_disable_follow_move(UInt16 CardNo, UInt16 Crd);
        // ��Բ�岹��������DMC5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ellipse_move(UInt16 CardNo, UInt16 Crd, UInt16 axisNum, UInt16[] Axis_List, double[] Target_Pos, double[] Cen_Pos, double A_Axis_Len, double B_Axis_Len, UInt16 Dir, UInt16 Pos_Mode);

        //---------------------------���Ź�����----------------------
        //���ÿ��ſڴ�����Ӧ�¼���������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_watchdog_action_event(UInt16 CardNo, UInt16 event_mask);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_watchdog_action_event(UInt16 CardNo, ref UInt16 event_mask);
        //ʹ�ܿ��ſڱ������ƣ�������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_watchdog_enable(UInt16 CardNo, double timer_period, UInt16 enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_watchdog_enable(UInt16 CardNo, ref double timer_period, ref UInt16 enable);
        //��λ���Ź���ʱ����������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_reset_watchdog_timer(UInt16 CardNo);

        //io���ƹ��ܣ������ࣩ
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_io_check_control(UInt16 CardNo, UInt16 sensor_in_no, UInt16 check_mode, UInt16 A_out_no, UInt16 B_out_no, UInt16 C_out_no, UInt16 output_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_io_check_control(UInt16 CardNo, ref UInt16 sensor_in_no, ref UInt16 check_mode, ref UInt16 A_out_no, ref UInt16 B_out_no, ref UInt16 C_out_no, ref UInt16 output_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_stop_io_check_control(UInt16 CardNo);

        //������λ����ƫ�ƾ��루������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_el_ret_deviation(UInt16 CardNo, UInt16 axis, UInt16 enable, double deviation);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_el_ret_deviation(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref double deviation);

        //����λ�õ��ӣ����ٱȽϹ��ܣ�����ʹ�ã�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_set_config_overlap(UInt16 CardNo, UInt16 hcmp, UInt16 axis, UInt16 cmp_source, UInt16 cmp_logic, Int32 time, UInt16 axis_num, UInt16 aux_axis, UInt16 aux_source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_get_config_overlap(UInt16 CardNo, UInt16 hcmp, ref UInt16 axis, ref UInt16 cmp_source, ref UInt16 cmp_logic, ref Int32 time, ref UInt16 axis_num, ref UInt16 aux_axis, ref UInt16 aux_source);
        
        //�������߹ر�RTCP����,��������

        //�����岹(����ʹ�ã�DMC5000/5X10ϵ�����忨��E5032���߿�)
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_helix_move_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AixsList, double[] StartPos, double[] TargetPos, UInt16 Arc_Dir, int Circle, UInt16 mode, int mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_helix_move_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] StartPos, double[] TargetPos, UInt16 Arc_Dir, int Circle, UInt16 mode);

        //PDO����20190715���ڲ�ʹ�ã�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pdo_buffer_enter(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pdo_buffer_stop(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pdo_buffer_clear(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pdo_buffer_run_state(UInt16 CardNo,UInt16 axis, ref int RunState, ref int Remain, ref int NotRunned, ref int Runned);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pdo_buffer_add_data(UInt16 CardNo,UInt16 axis, int size, int[] data_table);       
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pdo_buffer_start_multi(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList, UInt16[] ResultList);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pdo_buffer_pause_multi(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList, UInt16[] ResultList);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pdo_buffer_stop_multi(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList, UInt16[] ResultList);
        //[DllImport("LTDMC.dll")]
        //public static extern short dmc_pdo_buffer_add_data_multi(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList, int size, int[][] data_table);
        //����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_calculate_arccenter_3point(double[] start_pos, double[] mid_pos, double[] target_pos, double[] cen_pos);

        //---------------------ָ��������˶�------------------
        //ָ��������˶���������DMC3000/5000ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_set_muti_profile_unit(ushort card, ushort group, ushort axis_num, ushort[] axis_list, double[] start_vel, double[] max_vel, double[] tacc, double[] tdec, double[] stop_vel);//�����ٶ�����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_set_profile_unit(ushort card, ushort group, ushort axis, double start_vel, double max_vel, double tacc, double tdec, double stop_vel);//�����ٶ�����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_sigaxis_moveseg_data(ushort card, ushort group, ushort axis, double Target_pos, ushort process_mode, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_sigaxis_move_twoseg_data(ushort card, ushort group, ushort axis, double Target_pos, double second_pos, double second_vel, double second_endvel, ushort process_mode, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_mutiaxis_moveseg_data(ushort card, ushort group, ushort axisnum, ushort[] axis_list, double[] Target_pos, ushort process_mode, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_mutiaxis_move_twoseg_data(ushort card, ushort group, ushort axisnum, ushort[] axis_list, double[] Target_pos, double[] second_pos, double[] second_vel, double[] second_endvel, ushort process_mode, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_ioTrig_movseg_data(ushort card, ushort group, ushort axisNum, ushort[] axisList, double[] Target_pos, ushort process_mode, ushort trigINbit, ushort trigINstate, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_mutiposTrig_movseg_data(ushort card, ushort group, ushort axis, double Target_pos, ushort process_mode, ushort trigaxisNum, ushort[] trigAxisList, double[] trigPos, ushort[] trigPosType, ushort[] trigMode, uint mark);//λ�ô����ƶ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_mutiposTrig_mov_twoseg_data(ushort card, ushort group, ushort axis, double Target_pos, double softland_pos, double softland_vel, double softland_endvel, ushort process_mode, ushort trigAxisNum, ushort[] trigAxisList, double[] trigPos, ushort[] trigPosType, ushort[] trigMode, uint mark);//����λ�ô����ƶ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_upseg_data(ushort card, ushort group, ushort axis, double Target_pos, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_up_twoseg_data(ushort card, ushort group, ushort axis, double Target_pos, double second_pos, double second_vel, double second_endvel, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_ioPosTrig_movseg_data(ushort card, ushort group, ushort axisNum, ushort[] axisList, double[] Target_pos, ushort process_mode, ushort trigAxis, double trigPos, ushort trigPosType, ushort trigMode, ushort TrigINNum, ushort[] trigINList, ushort[] trigINstate, uint mark);//λ��+io�����ƶ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_ioPosTrig_mov_twoseg_data(ushort card, ushort group, ushort axisNum, ushort[] axisList, double[] Target_pos, double[] second_pos, double[] second_vel, double[] second_endvel, ushort process_mode, ushort trigAxis, double trigPos, ushort trigPosType, ushort trigMode, ushort TrigINNum, ushort[] trigINList, ushort[] trigINstate, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_posTrig_movseg_data(ushort card, ushort group, ushort axisNum, ushort[] axisList, double[] Target_pos, ushort process_mode, ushort trigAxis, double trigPos, ushort trigPosType, ushort trigMode, uint mark);//λ�ô����ƶ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_posTrig_mov_twoseg_data(ushort card, ushort group, ushort axisNum, ushort[] axisList, double[] Target_pos, double[] second_pos, double[] second_vel, double[] second_endvel, ushort process_mode, ushort trigAxis, double trigPos, ushort trigPosType, ushort trigMode, uint mark);//λ�ô����ƶ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_ioPosTrig_down_seg_data(ushort card, ushort group, ushort axis, double safePos, double Target_pos, ushort trigAxisNum, ushort[] trigAxisList, double[] trigPos, ushort[] trigPosType, ushort[] trigMode, ushort trigIN, ushort trigINstate, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_ioPosTrig_down_twoseg_data(ushort card, ushort group, ushort axis, double safePos, double Target_pos, double second_pos, double second_vel, double second_endvel, ushort trigAxisNum, ushort[] trigAxisList, double[] trigPos, ushort[] trigPosType, ushort[] trigMode, ushort trigIN, ushort trigINstate, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_posTrig_down_seg_data(ushort card, ushort group, ushort axis, double safePos, double Target_pos, ushort trigAxisNum, ushort[] trigAxisList, double[] trigPos, ushort[] trigPosType, ushort[] trigMode, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_posTrig_down_twoseg_data(ushort card, ushort group, ushort axis, double safePos, double Target_pos, double second_pos, double second_vel, double second_endvel, ushort trigAxisNum, ushort[] trigAxisList, double[] trigPos, ushort[] trigPosType, ushort[] trigMode, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_posTrig_down_seg_cmd_data(ushort card, ushort group, ushort axis, double safePos, double Target_pos, ushort trigAxisNum, ushort[] trigAxisList, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_posTrig_down_twoseg_cmd_data(ushort card, ushort group, ushort axis, double safePos, double Target_pos, double second_pos, double second_vel, double second_endvel, ushort trigAxisNum, ushort[] trigAxisList, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_mutiposTrig_singledown_seg_data(ushort card, ushort group, ushort axis, double safePos, double Target_pos, ushort process_mode, ushort trigAxisNum, ushort[] trigAxisList, double[] trigPos, ushort[] trigPosType, ushort[] trigMode, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_mutiposTrig_mutidown_seg_data(ushort card, ushort group, ushort axisnum, ushort[] axis_list, double[] safePos, double[] Target_pos, ushort process_mode, ushort trigAxisNum, ushort[] trigAxisList, double[] trigPos, ushort[] trigPosType, ushort[] trigMode, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_posTrig_outbit(ushort card, ushort group, ushort bitno, ushort on_off, ushort ahead_axis, double ahead_value, ushort ahead_PosType, ushort ahead_Mode, uint mark);//λ�ô���IO���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_mutiposTrig_outbit(ushort card, ushort group, ushort bitno, ushort on_off, ushort process_mode, ushort trigaxisNum, ushort[] trigAxisList, double[] trigPos, ushort[] trigPosType, ushort[] trigMode, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_immediate_write_outbit(ushort card, ushort group, ushort bitno, ushort on_off, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_wait_input(ushort card, ushort group, ushort bitno, ushort on_off, double time_out, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_delay_time(ushort card, ushort group, double delay_time, uint mark);//��ʱָ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_get_run_state(ushort card, ushort group, ref ushort state, ref ushort enable, ref uint stop_reason, ref ushort trig_phase, ref uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_open_list(ushort card, ushort group, ushort axis_num, ushort[] axis_list);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_close_list(ushort card, ushort group);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_start_list(ushort card, ushort group);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_stop_list(ushort card, ushort group, ushort stopMode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_pause_list(ushort card, ushort group, ushort stopMode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_set_encoder_error_allow(ushort card, ushort group, double allow_error);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_get_encoder_error_allow(ushort card, ushort group, ref double allow_error);

        //��ȡ����AD���루������DMC5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_ad_input_all(ushort CardNo, ref double Vout);
        //�����岹��ͣ��ʹ��pmove��������DMC5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_pmove_unit_pausemode(ushort CardNo, ushort axis, double TargetPos, double Min_Vel, double Max_Vel, double stop_Vel, double acc, double dec, double smooth_time, ushort posi_mode);
        //�����岹��ͣʹ��pmove�󣬻ص���ͣλ�ã�������DMC5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_return_pausemode(ushort CardNo, ushort Crd, ushort axis);
        //������ߺ��Ƿ�֧��ͨѶУ�飨������DMC3000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_check_if_crc_support(ushort CardNo);

        //����ײ��⹦�ܽӿ� ��������DMC3000ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_axis_conflict_config(ushort CardNo, ushort[] axis_list, ushort[] axis_depart_dir, double home_dist, double conflict_dist, ushort stop_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_conflict_config(ushort CardNo, ushort[] axis_list, ushort[] axis_depart_dir, ref double home_dist, ref double conflict_dist, ref ushort stop_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_axis_conflict_config_en(ushort CardNo, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_conflict_config_en(ushort CardNo, ref ushort enable);
       
        //����ּ��ͨ��,�ּ�̼�ר��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_close_ex(ushort CardNo, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_start_ex(ushort CardNo, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_init_config_ex(ushort CardNo, ushort cameraCount, int[] pCameraPos, ushort[] pCamIONo, UInt32 cameraTime, ushort cameraTrigLevel, ushort blowCount, int[] pBlowPos, ushort[] pBlowIONo, UInt32 blowTime, ushort blowTrigLevel, ushort axis, ushort dir, ushort checkMode, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_camera_trig_count_ex(ushort CardNo, ushort cameraNum, UInt32 cameraTrigCnt, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_camera_trig_count_ex(ushort CardNo, ushort cameraNum, ref UInt32 pCameraTrigCnt, ushort count, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_blow_trig_count_ex(ushort CardNo, ushort blowNum, UInt32 blowTrigCnt, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_blow_trig_count_ex(ushort CardNo, ushort blowNum, ref UInt32 pBlowTrigCnt, ushort count, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_camera_config_ex(ushort CardNo, ushort index, ref int pos, ref UInt32 trigTime, ref ushort ioNo, ref ushort trigLevel, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_blow_config_ex(ushort CardNo, ushort index, ref int pos, ref UInt32 trigTime, ref ushort ioNo, ref ushort trigLevel, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_blow_status_ex(ushort CardNo, ref UInt32 trigCntAll, ref ushort trigMore, ref ushort trigLess, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_trig_blow_ex(ushort CardNo, ushort blowNum, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_blow_enable_ex(ushort CardNo, ushort blowNum, ushort enable, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_piece_config_ex(ushort CardNo, UInt32 maxWidth, UInt32 minWidth, UInt32 minDistance, UInt32 minTimeIntervel, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_piece_status_ex(ushort CardNo, ref UInt32 pieceFind, ref UInt32 piecePassCam, ref UInt32 dist2next, ref UInt32 pieceWidth, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_cam_trig_phase_ex(ushort CardNo, ushort blowNo, double coef, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_blow_trig_phase_ex(ushort CardNo, ushort blowNo, double coef, ushort sortModuleNo);
        //��ȡ�ּ�ָ����������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_sortdev_blow_cmd_cnt(ushort CardNo, ushort blowDevNum, ref long cnt);
        //��ȡδ����ָ��������������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_sortdev_blow_cmderr_cnt(ushort CardNo, ushort blowDevNum, ref long errCnt);
        //�ּ����״̬
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_sortqueue_status(ushort CardNo, ref long curSorQueueLen, ref long passCamWithNoCmd);

        // ��Բ�����岹��������DMC5X10ϵ�����忨��E5032���߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_ellipse_move_unit(ushort CardNo, ushort Crd,ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] Cen_Pos, double A_Axis_Len, double B_Axis_Len, ushort Dir, ushort Pos_Mode,long mark);
        //��ȡ��״̬������Ԥ����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_status_advance(ushort CardNo, ushort axis_no, ushort motion_no, ref ushort axis_plan_state, ref UInt32 ErrPlulseCnt, ref ushort fpga_busy);
        //�����岹vmove��DMC5000ϵ�п�����ʹ�ã�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_vmove_unit(ushort CardNo, ushort Crd, ushort axis, double vel, double acc, ushort dir, Int32 imark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_vmove_stop(ushort CardNo, ushort Crd, ushort axis, double dec, Int32 imark);

        //---------------------��д���籣����------------------//
        //д���ַ����ݵ��ϵ籣������DMC3000/5000ϵ�п�����ʹ�ã�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_persistent_reg_byte(ushort CardNo, uint start, uint inum, byte[] pdata);
        //�Ӷϵ籣������ȡд����ַ���DMC3000/5000ϵ�п�����ʹ�ã�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_persistent_reg_byte(ushort CardNo, uint start, uint inum, byte[] pdata);
        //д�븡�������ݵ��ϵ籣������DMC3000/5000ϵ�п�����ʹ�ã�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_persistent_reg_float(ushort CardNo, uint start, uint inum, float[] pdata);
        //�Ӷϵ籣������ȡд��ĸ��������ݣ�DMC3000/5000ϵ�п�����ʹ�ã�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_persistent_reg_float(ushort CardNo, uint start, uint inum, float[] pdata);
        //д���������ݵ��ϵ籣������DMC3000/5000ϵ�п�����ʹ�ã�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_persistent_reg_int(ushort CardNo, uint start, uint inum, int[] pdata);
        //�Ӷϵ籣������ȡд����������ݣ�DMC3000/5000ϵ�п�����ʹ�ã�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_persistent_reg_int(ushort CardNo, uint start, uint inum, int[] pdata);
        //----------------------------------------------------//

        //EtherCAT���߸�λIOģ��������ֿ�������202001������������EtherCAT���߿���
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_slave_output_retain(ushort CardNo, ushort Enable);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_slave_output_retain(ushort CardNo, ref ushort Enable);

        //���������дflash��ʵ�ֶϵ籣�漱ͣ�ź����ã�������DMC3000ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_persistent_param_config(ushort CardNo, ushort axis, uint item);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_persistent_param_config(ushort CardNo, ushort axis, ref uint item);               

        //��ȡ����ʱ�����������̼����Ǳ��ݹ̼���������DMC3000/5000/5X10ϵ�����忨��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_firmware_boot_type(ushort CardNo, ref ushort boot_type);

        /**************************�жϹ��� ��������DMC5X10ϵ�����忨��************************/
        //�������ƿ��жϹ���
        [DllImport("LTDMC.dll")]
        public static extern uint dmc_int_enable(ushort CardNo, DMC3K5K_OPERATE funcIntHandler, IntPtr operate_data);
        //��ֹ���ƿ����ж�
        [DllImport("LTDMC.dll")]
        public static extern uint dmc_int_disable(ushort CardNo);
        //����/��ȡָ�����ƿ��ж�ͨ��ʹ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_intmode_enable(ushort Cardno,ushort Intno,ushort Enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_intmode_enable(ushort Cardno,ushort Intno,ref ushort Status);
        //����/��ȡָ�����ƿ��ж�����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_intmode_config(ushort Cardno,ushort Intno,ushort IntItem,ushort IntIndex,ushort IntSubIndex,ushort Logic);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_intmode_config(ushort Cardno,ushort Intno,ref ushort IntItem,ref ushort IntIndex,ref ushort IntSubIndex,ref ushort Logic);
        //��ȡָ�����ƿ��ж�ͨ�����ж�״̬
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_int_status(ushort Cardno,ref uint IntStatus);
        //��λָ�����ƿ�����ڵ��ж�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_reset_int_status(ushort Cardno, ushort Intno);
        /**************************************************************************************/


        /******************************************2021.10.26 ��ʼ�޸�**********************/

        ////20160105�������ٶ������Լ��ٶ� ���ٶ� �����ٶ�����ʾ(����)
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_profile_extern(UInt16 CardNo, UInt16 axis, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Ajerk, double Djerk, double stop_vel);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_profile_extern(UInt16 CardNo, UInt16 axis, ref double Min_Vel, ref double Max_Vel, ref double Tacc, ref double Tdec, ref double Ajerk, ref double Djerk, ref double stop_vel);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_delay_pwm_to_stop(UInt16 CardNo, UInt16 Crd, UInt16 pwmno, UInt16 on_off, double delay_time, double ReverseTime);


        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_profile_limit(UInt16 CardNo, UInt16 axis, double Max_Vel, double Max_Acc, double EvenTime);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_profile_limit(UInt16 CardNo, UInt16 axis,ref double Max_Vel,ref double Max_Acc,ref double EvenTime);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_vector_profile_limit(UInt16 CardNo, UInt16 Crd, double Max_Vel, double Max_Acc, double EvenTime);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_vector_profile_limit(UInt16 CardNo, UInt16 Crd,ref double Max_Vel,ref double Max_Acc,ref double EvenTime);





        //��ά����λ�ñȽϻ���
        //1��	���û��淽ʽ���ӱȽ�λ�ã�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_fifo_set_mode(UInt16 CardNo, UInt16 hcmp, UInt16 fifo_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_fifo_get_mode(UInt16 CardNo, UInt16 hcmp,ref UInt16 fifo_mode);
        //2��	��ȡʣ�໺��״̬����λ��ͨ���˺����ж��Ƿ�������ӱȽ�λ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_fifo_get_state(UInt16 CardNo, UInt16 hcmp, ref long remained_points);
        //3��	������ķ�ʽ�������ӱȽ�λ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_fifo_add_point_unit(UInt16 CardNo, UInt16 hcmp, UInt16 num, double[] x_cmp_pos, double[] y_cmp_pos, UInt16[] cmp_outbit);
        //4��	����Ƚ�λ��,Ҳ���FPGA��λ��ͬ�������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_fifo_clear_points(UInt16 CardNo, UInt16 hcmp);
        //���Ӵ����ݣ������һ��ʱ�䣬ָ�������������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_fifo_add_table(UInt16 CardNo, UInt16 hcmp, UInt16 num, double[] x_cmp_pos, double[] y_cmp_pos);



        //���˶�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_move_unit(UInt16 CardNo, UInt16 Crd, UInt16 axis_num, UInt16[] axis_list, double[] mid_pos, double[] target_pos, double[] saftpos, UInt16 pos_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_m_move_config(UInt16 CardNo, UInt16 Crd,ref UInt16 axis_num, UInt16[] axis_list, double[] mid_pos, double[] target_pos, double[] saftpos,ref UInt16 pos_mode);


        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_to_pci(UInt16 CardNo, UInt16 PortNum, UInt16 NodeNum);


        //TypeIndex:0~6  m_Averagetime ; ƽ��ʱ�� m_Maxtime;���ʱ�� uint64  m_Cycles;��ǰʱ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_perline_time(UInt16 CardNo, UInt16 TypeIndex, ref int Averagetime, ref int Maxtime,ref UInt64 Cycles);



        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_axis_contrlmode(UInt16 CardNo, UInt16 Axis, long Contrlmode);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_contrlmode(UInt16 CardNo, UInt16 Axis, ref long Contrlmode);



        // ��ȡ���ƿ�������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_card_errcode(UInt16 CardNo, ref UInt16 Errcode);
        // ������ƿ�������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_clear_card_errcode(UInt16 CardNo);




        [DllImport("LTDMC.dll")]
        public static extern short nmc_start_log(UInt16 CardNo, UInt16 chan, UInt16 node, UInt16 Ifenable);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_log(UInt16 CardNo, UInt16 chan, UInt16 node,ref UInt32 data);


        //�°����˶�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_move_set_coodinate(UInt16 card, UInt16 liner, UInt16 axis_num, UInt16[] axis_list, UInt32 in_io_num, UInt16 trig_flag, UInt16 pos_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_move_get_coodinate_para(UInt16 card, UInt16 liner, ref UInt16 axis_num, UInt16[] axis_list, ref UInt32 in_io_num, ref UInt16 trig_flag, ref UInt16 pos_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_move_set_z_para(UInt16 card, UInt16 liner, double z_up_safe_pos, double z_up_target_pos, double z_down_safe_pos, double z_down_target_pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_move_get_z_para(UInt16 card, UInt16 liner, ref double z_up_safe_pos, ref double z_up_target_pos, ref double z_down_safe_pos, ref double z_down_target_pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_move_set_xy_para(UInt16 card, UInt16 liner, double x_first_safe_pos, double x_second_safe_pos, double x_target_pos, UInt16 y_num, double[] y_target_pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_move_get_xy_para(UInt16 card, UInt16 liner, ref double x_first_safe_pos, ref double x_second_safe_pos, ref double x_target_pos, UInt16 y_num, double[] y_target_pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_move_axes(UInt16 card, UInt16 liner);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_move_get_run_phase(UInt16 card, UInt16 liner,ref UInt16 run_phase);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_move_stop(UInt16 card, UInt16 liner, UInt16 stop_mode);






        //�����������������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_set_kinematic_type(ushort CardNo, ushort Crd, ushort machine_type);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_get_kinematic_type(ushort CardNo, ushort Crd, ref ushort machine_type);
        //�������߹ر�RTCP����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_set_enable(ushort CardNo, ushort Crd, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_get_enable(ushort CardNo, ushort Crd, ref ushort enable);
        //����A�������ԭ�������ǰһ������ϵ��ƫ��, xyz��ƫ��a_offset[3]
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_set_vector_a(ushort CardNo, ushort Crd, double[] a_offset);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_get_vector_a(ushort CardNo, ushort Crd, double[] a_offset);
        //����B�������ԭ�������ǰһ������ϵ��ƫ��, xyz��ƫ��b_offset[3]
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_set_vector_b(ushort CardNo, ushort Crd, double[] b_offset);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_get_vector_b(ushort CardNo, ushort Crd, double[] b_offset);
        //����C�������ԭ�������ǰһ������ϵ��ƫ��, xyz��ƫ��c_offset[3]
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_set_vector_c(ushort CardNo, ushort Crd, double[] c_offset);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_get_vector_c(ushort CardNo, ushort Crd, double[] c_offset);
        //����A��B��C���ƫ��λ��,
        //A,B,C�ڻ�0�����ƶ�����ʼ��̬��λ�ã����ʱ���A/B/C��ƫ�ƽǶȣ�
        //������˳�ʼ��̬��λ�ò�������0�����ʱ���Ҫ����ƫ�ƽǶ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_set_rotate_joint_offset(ushort CardNo, ushort Crd, double A, double B, double C);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_get_rotate_joint_offset(ushort CardNo, ushort Crd, ref double A, ref double B, ref double C);
        //���ø���ķ����빤������ϵ�Ĺ�ϵ
        //������ڹ����ķ�������������˶���ʱ��������������ڹ���Ҳ�������˶��ģ��趨Ϊ1
        //������Ϊ-1����ʼ����Ϊ1
        //dir[5],��Ӧ����X,Y,Z,��ת��1����ת��2
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_set_joints_direction(ushort CardNo, ushort Crd, int[] dir);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_get_joints_direction(ushort CardNo, ushort Crd, int[] dir);
        //���õ��߳��ȣ���˫��ͷ��������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_set_tool_length(ushort CardNo, ushort Crd, double tool);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_get_tool_length(ushort CardNo, ushort Crd, ref double tool);
        //���ô���ת����ٶ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_set_max_rotate_param(ushort CardNo, ushort Crd, double rotate_speed, double rotate_acc);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_get_max_rotate_param(ushort CardNo, ushort Crd, ref double rotate_speed, ref double rotate_acc);
        //���ù���ԭ��ƫ��ֵ
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_set_workpiece_offset(ushort CardNo, ushort Crd, ushort workpiece_index, double[] offset);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_get_workpiece_offset(ushort CardNo, ushort Crd, ushort workpiece_index, double[] offset);
        //��ȡ����λ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_get_actual_pos(ushort CardNo, ushort Crd, ushort AxisNum, double[] actual_pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_get_command_pos(ushort CardNo, ushort Crd, ushort AxisNum, double[] command_pos);
        //��е�����빤������ת��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_kinematics_forward(ushort CardNo, ushort Crd, double[] joint_pos, double[] axis_pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_kinematics_forward_ex(ushort CardNo, ushort Crd, double[] joint_pos, double[] axis_pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_kinematics_inverse(ushort CardNo, ushort Crd, double[] axis_pos, double[] joint_pos);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_set_workpiece_mode(ushort CardNo, ushort Crd, ushort enable, ushort workpiece_index);    //����ϵ��0-3��ʹ���ĸ���������ϵ
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_get_workpiece_mode(ushort CardNo, ushort Crd,ref ushort enable,ref ushort workpiece_index);    //����ϵ��0-3��ʹ���ĸ���������ϵ


        //λ�������������ͣ�0-��������ϵλ�ã�1-��е����ϵλ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_set_position_type(ushort CardNo, ushort Crd, ushort position_type);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_get_position_type(ushort CardNo, ushort Crd, ref ushort position_type);




        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmd_buf_open(ushort CardNo, ushort group, ushort axis_num, ushort[] axis_list);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmd_buf_close(ushort CardNo, ushort group);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmd_buf_start(ushort CardNo, ushort group);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmd_buf_stop(ushort CardNo, ushort group, ushort stop_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmd_buf_get_group_config(ushort CardNo, ushort group,ref ushort enable, ref ushort axis_num, ushort[] axis_list);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmd_buf_get_group_run_info(ushort CardNo, ushort group, ref ushort enable, ref UInt32 array_id, ref UInt32 stop_reason, ref ushort trig_phase, ref ushort phase);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmd_buf_add_cmd(ushort CardNo, ushort group, UInt32 index, ushort cmd_type, ushort ProcessMode, ushort Dim, ushort[] AxisList, double[] TargetPositionFirst,
            double[] m_TargetPositionSecond, ushort[] m_SoftlandFlag, double[] SoftLandVel, double[] SoftLandEndVel, ushort[] m_PosMode, double[] m_TrigAheadPos,
            ushort m_TrigFlag, ushort m_TrigAxisNum, ushort[] m_TrigAxislist, ushort[] m_TrigPosType, ushort[] m_TrigAxisPosRelationgship, double[] m_TrigAxisPos,
            ushort m_TrigIONum, ushort[] m_TrigIOState, ushort[] m_TrigINIOList, UInt32 m_DelayCmdTime, ushort m_IOList, ushort m_IOState, ushort m_TrigError);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmd_buf_set_axis_profile(ushort CardNo, ushort group, ushort axis_num, ushort[] axis_list, double[] start_vel, double[] max_vel, double[] stop_vel, double[] tacc, double[] tdec);



        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_posTrig_torque_movseg_data(ushort CardNo, ushort group, ushort axis, double torque, double PosLimitValue, ushort PosLimitValid, ushort PosMode, ushort trigAxis, double trigPos, ushort trigPosType, ushort trigMode, UInt32 mark);//λ�ô���ת���ƶ�


        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmd_buf_temp_stop(ushort CardNo, ushort group, ushort stop_mode);












        //���ӳ��ֹ���

        [DllImport("LTDMC.dll")]
        public static extern short dmc_gear_in(ushort CardNo, ushort master_axis, ushort slave_axis, ushort follow_source, double ratio_numerator, double ratio_denominator, double acc, double dec, double s_time, ushort buffer_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_gear_in(ushort CardNo,ref ushort master_axis, ushort slave_axis,ref ushort follow_source,ref double ratio_numerator,ref double ratio_denominator,ref double acc,ref double dec,ref double s_time,ref ushort buffer_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_update_gear_scale(ushort CardNo, ushort slave_axis, double ratio_numerator, double ratio_denominator, double acc, double dec, double s_time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_gear_in_pos(ushort CardNo, ushort master_axis, ushort slave_axis, ushort follow_source, double ratio_numerator, double ratio_denominator, double master_sync_pos, double slave_sync_pos, double master_start_dist, double velocity, double acc, double dec, double s_time, ushort buffer_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_gear_in_pos(ushort CardNo,ref ushort master_axis, ushort slave_axis, ref ushort follow_source,ref double ratio_numerator,ref double ratio_denominator,ref double master_sync_pos,ref double slave_sync_pos,ref double master_start_dist,ref double velocity,ref double acc,ref double dec,ref double s_time,ref ushort buffer_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_in_gear_state(ushort CardNo, ushort slave_axis,ref ushort in_gear);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_gear_aborted_state(ushort CardNo, ushort slave_axis, ref ushort aborted_state);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_gear_out(ushort CardNo, ushort slave_axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_trace_set_config(ushort CardNo, short trace_cycle, short lost_handle, short trace_type, short trigger_object_index, short trigger_type, int mask, long condition);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_trace_get_config(ushort CardNo,ref short trace_cycle,ref short lost_handle,ref short trace_type,ref short trigger_object_index,ref short trigger_type,ref int mask, ref long condition);




        /***********************************************************
             * ���òɼ�����һ�ο�������500���ɼ�����
             * data_type 	���ݵ����ͣ����ɼ�����˵����
             * data_index 	���ݵ�������������Ǹ�����أ���������ţ������IO������IO��ţ��������
             * data_sub_index ���ݵ�������������ǰ���ɼ�IO�����ʾIO��������š�
             * data_bytes 	�����ֽ��������вɼ����ͻ��Զ�ƥ�䣬�̶�Ϊ0��Ԥ��������չ����
        **********************************************************/
        [DllImport("LTDMC.dll")]
        public static extern short dmc_trace_reset_config_object(ushort CardNo );
        [DllImport("LTDMC.dll")]
        public static extern short dmc_trace_add_config_object(ushort CardNo, short data_type, short data_index, short data_sub_index, short slave_id, short data_bytes);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_trace_get_config_object(ushort CardNo, short object_index,ref short data_type,ref short data_index,ref short data_sub_index,ref short slave_id,ref short data_bytes);



        //����trace
        [DllImport("LTDMC.dll")]
        public static extern short dmc_trace_data_start(ushort CardNo);

        //ֹͣtrace
        [DllImport("LTDMC.dll")]
        public static extern short dmc_trace_data_stop(ushort CardNo);

        //��λtrace��ֹͣ�ɼ���ʱ����ܵ��ã�������Ѳɼ����������Լ������־λ
        [DllImport("LTDMC.dll")]
        public static extern short dmc_trace_data_reset(ushort CardNo);

        //trace�Ƿ��Ѿ�����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_trace_get_flag(ushort CardNo,ref short start_flag,ref short triggered_flag,ref short lost_flag);


        /***********************************************************
           *��ȡ�ɼ�״̬
           * valid_num 	�Ѳɼ���δ����ȡ�����ݸ���
           * free_num 	ʣ������ڱ���ɼ����ݵĸ���
           * object_total_bytes   �ɼ��������ֽ���
           * object_total_num 	�ɼ������ܸ���
       **********************************************************/
        [DllImport("LTDMC.dll")]
        public static extern short dmc_trace_get_state(ushort CardNo,ref int valid_num,ref int free_num,ref int object_total_bytes,ref int object_total_num);

        /***********************************************************
         *��ȡ�ɼ�����
         * bufsize 	���ݻ������ֽ���
         * data[1024] 	���ݻ�������
         * byte_size   ��ȡ�����ݵ��ֽ���
         **********************************************************/

        [DllImport("LTDMC.dll")]
        public static extern short dmc_trace_get_data(ushort CardNo, int bufsize, string data,ref int byte_size);


        //trace��λ����źţ�ֻ�Ǹ�λ��־λ
        [DllImport("LTDMC.dll")]
        public static extern short dmc_trace_reset_lost_flag(ushort CardNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_message_buffer_enable(ushort CardNo, ushort index, UInt32 buffer_size, byte console_enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_message_buffer_disable(ushort CardNo, ushort index);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_message_buffer_get_data(ushort CardNo, ushort index, long bufsize, ref byte data, ref UInt32 pbufsize);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_t_pmove_extern_softstart(ushort CardNo, ushort axis, double MidPos, double TargetPos, double start_Vel, double Max_Vel, double stop_Vel, UInt32 delay_ms, double Max_Vel2, double stop_vel2, double acc_time, double dec_time, ushort posi_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_t_pmove_extern_softstart_unit(ushort CardNo, ushort axis, double MidPos, double TargetPos, double start_Vel, double Max_Vel, double stop_Vel, UInt32 delay_ms, double Max_Vel2, double stop_vel2, double acc_time, double dec_time, ushort posi_mode);





        //PVT_continuous�ӿ�.
        //�·�PVT continuous���ڵ�����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pvt_table_continuous(ushort CardNo, ushort axis, UInt32 count, double[] pos, double[] vel, double[] percent, double[] vel_max, double[] acc, double[] dec);
        //���ݴ���Ĳ�������ȡ����λ�ýڵ��ʱ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pvt_continuous_calculate(ushort CardNo, ushort axis, double[] time);
        //����PVT continuous �˶�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pvt_continuous_start(ushort CardNo, ushort axis_num, double[] axis_list, double[] start_delay_time);



        //����λ�����������Χ����

        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmd_buf_set_allow_error(ushort CardNo, ushort group, double allow_error);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmd_buf_get_allow_error(ushort CardNo, ushort group,ref double allow_error);


        //����Բ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_arc_move_3points_multicoor(ushort CardNo, ushort Crd, ushort[] AxisList, double[] Target_Pos, double[] Mid_Pos, long Circle, ushort posi_mode);




        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_delay_outbit_to_start_path(ushort CardNo, ushort Crd, ushort bitno, ushort on_off, double delay_value, ushort delay_mode, double ReverseTime);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_delay_outbit_to_stop_path(ushort CardNo, ushort Crd, ushort bitno, ushort on_off, double delay_time, double ReverseTime);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_ahead_outbit_to_stop_path(ushort CardNo, ushort Crd, ushort bitno, ushort on_off, double ahead_value, ushort ahead_mode, double ReverseTime);



        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_line_section_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] pPosList, double Section_Dist, ushort Bitno, ushort On_Off, ushort Io_Mode, double Time_Dist_Value, double ReverseTime, ushort posi_mode, ushort mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_arc_move_center_section_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] Cen_Pos, ushort Arc_Dir, ushort Circle, double Section_Dist, ushort Bitno, ushort On_Off, ushort Io_Mode, double Time_Dist_Value, double ReverseTime, ushort posi_mode, ushort mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_arc_move_radius_section_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double Arc_Radius, ushort Arc_Dir, ushort Circle, double Section_Dist, ushort Bitno, ushort On_Off, ushort Io_Mode, double Time_Dist_Value, double ReverseTime, ushort posi_mode, ushort mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_arc_move_3points_section_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] Mid_Pos, ushort Circle, double Section_Dist, ushort Bitno, ushort On_Off, ushort Io_Mode, double Time_Dist_Value, double ReverseTime, ushort posi_mode, ushort mark);



        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_pci_int(ushort CardNo);


        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_ad_monitor_config(ushort CardNo, ushort Crd, ushort CANid, ushort channel, ushort ADEn, double ADValDown, double ADValUp);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_ad_monitor_config(ushort CardNo, ushort Crd,ref ushort CANid,ref ushort channel,ref ushort ADEn,ref double ADValDown,ref double ADValUp);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_ad_monitor_result(ushort CardNo, ushort Crd, ref ushort ch, ref double ADRet, ref ushort num, ref double pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_clear_ad_monitor_result(ushort CardNo, ushort Crd);


        [DllImport("LTDMC.dll")]
        public static extern short dmc_update_target_position_extern_unit(ushort CardNo, ushort axis, double mid_pos, double aim_pos, double vel, ushort posi_mode);



        //ָ����������λ���˶� ͬʱ�����ٶȺ�Sʱ��(����)
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pmove_extern_unit(ushort CardNo, ushort axis, double dist, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double stop_Vel, double s_para, ushort posi_mode);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_pmove_extern_acc_unit(ushort CardNo, ushort axis, double dist, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double stop_Vel, double s_para, ushort posi_mode);


        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmp_fifo_set_enable(ushort CardNo, ushort Crd, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmp_fifo_get_enable(ushort CardNo, ushort Crd , ref ushort enable);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmp_fifo_get_state(ushort CardNo, ushort Crd, ref long remained_space);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmp_fifo_clear_points(ushort CardNo, ushort Crd);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmp_fifo_set_config_params(ushort CardNo, ushort Crd, ushort Bitno, ushort On_Off, ushort Io_Mode, double Time_Dist_Value, double ReverseTime);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmp_fifo_get_config_params(ushort CardNo, ushort Crd,ref ushort Bitno,ref ushort On_Off,ref ushort Io_Mode,ref double Time_Dist_Value,ref double ReverseTime);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_line_add_cmp_fifo_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] cmp_pos, ushort num, ushort posi_mode, long mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_arc_move_3points_add_cmp_fifo_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] Mid_Pos, ushort Circle, double[] cmp_pos, ushort num, ushort posi_mode, long mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_arc_move_center_add_cmp_fifo_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] Cen_Pos, ushort Arc_Dir, ushort Circle, double[] cmp_pos, ushort num, ushort posi_mode, long mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_arc_move_radius_add_cmp_fifo_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double Arc_Radius, ushort Arc_Dir, ushort Circle, double[] cmp_pos, ushort num, ushort posi_mode, long mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmp_fifo_get_total_point(ushort CardNo, ushort Crd, ref long total_point);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmp_fifo_get_remain_point(ushort CardNo, ushort Crd, ref long remain_point);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmp_fifo_get_trig_point(ushort CardNo, ushort Crd, ref long trig_point);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmp_fifo_get_force_trig_point(ushort CardNo, ushort Crd, ref long force_trig_point);




        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_wait_node_input_delay_to_start(ushort CardNo, ushort Crd, ushort node_ID, ushort bitno, ushort on_off, double delay_value, ushort delay_mode, double TimeOut);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_wait_node_input_ahead_to_stop(ushort CardNo, ushort Crd, ushort node_ID, ushort bitno, ushort on_off, double delay_value, ushort ahead_mode, double TimeOut);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_delay_node_outbit_to_start(ushort CardNo, ushort Crd, ushort node_ID, ushort bitno, ushort on_off, double delay_value, ushort delay_mode, double ReverseTime);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_delay_node_outbit_to_stop(ushort CardNo, ushort Crd, ushort node_ID, ushort bitno, ushort on_off, double delay_time, double ReverseTime);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_ahead_node_outbit_to_stop(ushort CardNo, ushort Crd, ushort node_ID, ushort bitno, ushort on_off, double ahead_value, ushort ahead_mode, double ReverseTime);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_write_node_outbit(ushort CardNo, ushort Crd, ushort node_ID, ushort bitno, ushort on_off, double ReverseTime);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_clear_node_io_action(ushort CardNo, ushort Crd, ushort node_ID, UInt32 Io_Mask);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_connect_type(ushort CardNo,ref ushort ConnectType);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_board_init_eth(string IpAddr);


        //����ֹͣ����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_dec_stop_dist_unit(ushort CardNo, ushort axis, double dist);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_dec_stop_dist_unit(ushort CardNo, ushort axis,ref double dist);



        //����ٶ���������(���嵱��)
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_profile_limit_unit(ushort CardNo, ushort axis, double Limit_Max_Vel, double Limit_Max_Acc, double EvenTime);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_profile_limit_unit(ushort CardNo, ushort axis,ref double Limit_Max_Vel,ref double Limit_Max_Acc,ref double EvenTime);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_vector_profile_limit_unit(ushort CardNo, ushort axis, double Limit_Max_Vel, double Limit_Max_Acc, double EvenTime);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_vector_profile_limit_unit(ushort CardNo, ushort axis, ref double Limit_Max_Vel, ref double Limit_Max_Acc, ref double EvenTime);



        //���õ������ٹ���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_vector_profile_limit_by_axis(ushort CardNo, ushort Crd, ushort Enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_vector_profile_limit_by_axis(ushort CardNo, ushort Crd,ref ushort Enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_follow_line_enable(ushort CardNo, ushort Crd, ref ushort enable_flag);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_counter_reverse(ushort CardNo, ushort axis, ushort reverse);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_counter_reverse(ushort CardNo, ushort axis,ref ushort reverse);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_extra_counter_reverse(ushort CardNo, ushort axis, ushort reverse);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_extra_counter_reverse(ushort CardNo, ushort axis, ref ushort reverse);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_stop_axis(ushort CardNo, ushort Crd, ushort axis, double dec, int imark);


        //��ȡ�岹����

        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_vector_length_unit(ushort CardNo, ushort Crd,ref double total_length,ref double left_length);




        /*********************************************************************************************************
        ���׵���͹���˶�
        *********************************************************************************************************/
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cam_table_unit(ushort CardNo, ushort MasterAxisNo, ushort SlaveAxisNo, UInt32 Count, double[] pMasterPos, double[] pSlavePos, ushort SrcMode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cam_move(ushort CardNo, ushort axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cam_move_cycle(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_fairing_enable(ushort CardNo, ushort Crd, ushort enable, double fairing_length);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_fairing_enable(ushort CardNo, ushort Crd, ref ushort enable,ref double fairing_length);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_eth_timeout(int timems);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_extra_encoder_extern(ushort CardNo, ushort channel, int pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_extra_encoder_extern(ushort CardNo, ushort channel,ref int pos);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_smooth_contour_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList, ushort point_num, double[] x, double[] y, double[] z, double vel_coef, double eps, long mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_conti_smooth_contour_curve(ushort point_num, double[] x, double[] y, double[] z, double eps,ref double curve_x,ref double curve_y,ref double curve_z,ref double length);




        //����͹��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cam_in(ushort CardNo, ushort slave_axis, ushort master_axis, ushort execute, ushort conti_update, ushort cam_table, ushort periodic, ushort master_abs, ushort slave_abs, double master_offset, double slave_offset, double master_scaling, double slave_scaling, double master_start_dist, double master_sync_pos, double active_pos, ushort active_mode, ushort start_mode, double velocity, double acc, double dec, double jerk, ushort master_source, ushort buffer_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_cam_in_status(ushort CardNo, ushort slave_axis,ref ushort in_sync,ref ushort end_of_profile,ref ushort busy,ref ushort active,ref ushort cmd_aborted,ref ushort error,ref ushort error_id);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cam_out(ushort CardNo, ushort slave_axis, ushort execute);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_cam_out_status(ushort CardNo, ushort slave_axis,ref ushort done,ref ushort busy,ref ushort cmd_aborted,ref ushort error,ref UInt32 error_id);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cam_read_points(ushort CardNo, ushort execute, ushort cam_table, ushort cam_chg_point, UInt32 cam_point_num,  ushort[] done, ushort[] busy, ushort[] error, UInt32[]  error_id,ref double master_pos,ref double slave_pos,ref double slave_vel,ref double slave_acc);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cam_write_points(ushort CardNo, ushort execute, ushort cam_table, UInt32 cam_point_num, double master_pos, double slave_pos, double slave_vel, double slave_acc, ushort[] done, ushort[] busy, ushort[] error, UInt32[] error_id);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cam_set(ushort CardNo, ushort execute, ushort cam_table, ushort[] done, ushort[] busy, ushort[] error, UInt32[] error_id);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cam_read_tappet_status(ushort CardNo, ushort execute, ushort cam_table, UInt32 tappet_num1, UInt32 tappet_num2, UInt32 tappet_num3, UInt32 tappet_num4, UInt32 tappet_num5, UInt32 tappet_num6, UInt32 tappet_num7, UInt32 tappet_num8, ref ushort valid,ref ushort busy,ref ushort error,ref UInt32 error_id,ref ushort status1,ref ushort status2, ref ushort status3, ref ushort status4, ref ushort status5, ref ushort status6, ref ushort status7, ref ushort status8);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cam_read_tappet_value(ushort CardNo, ushort execute, ushort cam_table, UInt32 tappet_num, ref ushort valid, ref ushort busy, ref ushort error, ref UInt32 error_id,ref double master_pos, ref ushort positive_mode,ref ushort negative_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cam_write_tappet_value(ushort CardNo, ushort execute, ushort cam_table, UInt32 tappet_num, double master_pos, ushort positive_mode, ushort negative_mode, ushort[] done, ushort[] busy, ushort[] error, UInt32[] error_id);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cam_add_tappet(ushort CardNo, ushort execute, ushort cam_table, double master_pos, ushort positive_mode, ushort negative_mode, ushort[] done, ushort[] busy, ushort[] error, UInt32[] error_id, UInt32[] tappet_num);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cam_delete_tappet(ushort CardNo, ushort execute, ushort cam_table, ushort[] done, ushort[] busy, ushort[] error, UInt32[] error_id);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmd_buf_temp_delete(ushort CardNo, ushort group, ushort addr, ushort num, ushort delete_mode);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_wait_mode(ushort CardNo, ushort Crd, ushort wait_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_wait_mode(ushort CardNo, ushort Crd,ref ushort wait_mode);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_peak_config(ushort CardNo, ushort axis, ushort enable, double u_time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_peak_config(ushort CardNo, ushort axis,ref ushort enable,ref double u_time);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_axis_err_band(ushort CardNo, ushort axis, double err_band, ushort set_cycle);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_err_band(ushort CardNo, ushort axis,ref double err_band,ref ushort set_cycle);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_axis_err_band_unit(ushort CardNo, ushort axis, double err_band, ushort set_cycle);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_err_band_unit(ushort CardNo, ushort axis,ref double err_band,ref ushort set_cycle);

    



        //�������ģ����ٱȽ�ָ��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_hcmp_set_mode(ushort CardNo, ushort PortNum, ushort nodenum, ushort hcmp, ushort cmp_mode);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_hcmp_get_mode(ushort CardNo, ushort PortNum, ushort nodenum, ushort hcmp,ref ushort cmp_mode);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_hcmp_set_config(ushort CardNo, ushort PortNum, ushort nodenum, ushort hcmp, ushort channel, ushort cmp_source, ushort cmp_logic, long time);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_hcmp_get_config(ushort CardNo, ushort PortNum, ushort nodenum, ushort hcmp,ref ushort channel,ref ushort cmp_source,ref ushort cmp_logic,ref long time);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_hcmp_clear_points(ushort CardNo, ushort PortNum, ushort nodenum, ushort hcmp, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_hcmp_add_point(ushort CardNo, ushort PortNum, ushort nodenum, ushort hcmp, long cmp_pos);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_hcmp_set_liner(ushort CardNo, ushort PortNum, ushort nodenum, ushort hcmp, long Increment, long Count);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_hcmp_get_liner(ushort CardNo, ushort PortNum, ushort nodenum, ushort hcmp,ref long Increment,ref long Count);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_hcmp_get_current_state(ushort CardNo, ushort PortNum, ushort nodenum, ushort hcmp,ref long remained_points,ref long current_point,ref long runned_points);





        //�����������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_axis_follow_trajectory_displacement(ushort CardNo, ushort crd, ushort num, ushort[] Axis_list);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_follow_trajectory_displacement(ushort CardNo, ushort crd,ref ushort num, ushort[] Axis_list);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_tool_length_compensation_param(ushort CardNo, ushort axis, double length);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_tool_length_compensation_param(ushort CardNo, ushort axis,ref double length);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_tool_length_compensation_enable(ushort CardNo, ushort axis, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_tool_length_compensation_enable(ushort CardNo, ushort axis,ref ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_normal_direction_control(ushort CardNo, ushort crd, ushort axis, ushort mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_normal_direction_control(ushort CardNo, ushort crd,ref ushort axis,ref ushort mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_gap_cmp_param(ushort CardNo, ushort crd, ushort pin, ushort logic, ushort mode, ushort auxi_axis, ushort source, long rev_time, double[] gap);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_gap_cmp_param(ushort CardNo, ushort crd,ref ushort pin,ref ushort logic,ref ushort mode,ref ushort auxi_axis,ref ushort source,ref long rev_time, double[] gap);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_gap_cmp_enable(ushort CardNo, ushort crd, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_gap_cmp_enable(ushort CardNo, ushort crd,ref ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_normal_direction_control_enable(ushort CardNo, ushort crd, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_normal_direction_control_enable(ushort CardNo, ushort crd,ref ushort enable);


        [DllImport("LTDMC.dll")]
        public static extern short dmc_mc_gear_in(ushort CardNo, ushort slave_axis, ushort master_axis, ushort execute, ushort conti_update, ushort master_source, double ratio_numerator, double ratio_denominator, double acc, double dec, double jerk, ushort buffer_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_mc_gear_in(ushort CardNo, ushort slave_axis,ref ushort master_axis, ref ushort execute, ref ushort conti_update, ref ushort master_source, ref double ratio_numerator, ref double ratio_denominator, ref double acc, ref double dec, ref double jerk, ref ushort buffer_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_mc_gearin_status(ushort CardNo, ushort slave_axis,ref ushort in_gear,ref ushort busy,ref ushort active,ref ushort cmd_aborted,ref ushort error, ref UInt32 error_id);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_mc_gear_out(ushort CardNo, ushort slave_axis, ushort[] execute);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_mc_gear_out_status(ushort CardNo, ushort slave_axis,ref ushort done,ref ushort busy,ref ushort cmd_aborted,ref ushort error, ref UInt32 error_id);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_mc_combine_axes(ushort CardNo, ushort slave_axis, ushort master_axis1, ushort master_axis2, ushort execute, ushort conti_update, ushort master_source1, ushort master_source2, ushort combine_mode, double ratio_numerator1, double ratio_denominator1, double ratio_numerator2, double ratio_denominator2, double acc, double dec, double jerk, ushort buffer_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_mc_combine_axes(ushort CardNo, ushort slave_axis, ref ushort master_axis1, ref ushort master_axis2, ref ushort execute, ref ushort conti_update, ref ushort master_source1, ref ushort master_source2, ref ushort combine_mode, ref double ratio_numerator1, ref double ratio_denominator1, ref double ratio_numerator2, ref double ratio_denominator2, ref double acc, ref double dec, ref double jerk, ref ushort buffer_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_mc_combine_axes_status(ushort CardNo, ushort slave_axis,ref ushort in_sync,ref ushort busy,ref ushort active,ref ushort cmd_aborted,ref ushort error,ref UInt32 error_id);




        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_space_collision_zone_param(ushort CardNo, ushort axis_num, ushort[] axis_list, ushort zone_num, double[] neg_limit, double[] pos_limit, ushort stop_mode, ushort pos_source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_space_collision_zone_param(ushort CardNo,ref ushort axis_num, ushort[] axis_list, ref ushort zone_num, double[] neg_limit, double[] pos_limit, ref ushort stop_mode, ref ushort pos_source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_space_collision_zone_enable(ushort CardNo, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_space_collision_zone_enable(ushort CardNo,ref ushort enable);



        //������ȡ ��������20201016
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_position_extern(ushort CardNo, ushort axis,ref double pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_encoder_extern(ushort CardNo, ushort axis, ref double pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_current_speed_extern(ushort CardNo, ushort axis, ref double current_speed);






        //�ض�pmove�˶��滮��ʱ�估ʣ��ʱ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_plan_time_info(ushort CardNo, ushort axis,ref double sum_time,ref double remain_time);
        //���ò岹������������ٶ�ֵ
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_axis_max_interpo_speed(ushort CardNo, ushort axis, double max_speed);
        //�ض��岹������������ٶ�ֵ
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_max_interpo_speed(ushort CardNo, ushort axis,ref double max_speed);


        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_axis_max_interpo_speed_enable(ushort CardNo, ushort axis, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_max_interpo_speed_enable(ushort CardNo, ushort axis,ref ushort enable);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_diagnosis_log_enable(ushort CardNo, ushort Crd, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_diagnosis_log_enable(ushort CardNo, ushort Crd,ref ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_diagnosis_log_data(ushort CardNo, ushort Crd);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_reverse_outbit(ushort CardNo, ushort Channel, ushort NoteID, ushort IoBit, double reverse_time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sine_oscillate(ushort CardNo, ushort Axis, double Amplitude, double Frequency);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sine_oscillate_stop(ushort CardNo, ushort Axis);


        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_apf_rotary_cut_init(ushort CardNo, UInt32 rotary_cut_id, ushort execute, double rotary_axis_radius, UInt32 rotary_axis_knife_num, double feed_axis_radius, double cutlength, double sync_start_pos, double sync_stop_pos, double rot_start_pos, double fed_stop_pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_apf_rotary_cut_init(ushort CardNo, UInt32 rotary_cut_id,ref ushort execute,ref double rotary_axis_radius,ref UInt32 rotary_axis_knife_num,ref double feed_axis_radius,ref double cutlength,ref double sync_start_pos,ref double sync_stop_pos,ref double rot_start_pos,ref double fed_stop_pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_apf_rotary_cut_init_status(ushort CardNo, UInt32 rotary_cut_id, ref ushort done,ref ushort busy,ref ushort error,ref UInt32 error_id);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_apf_rotary_cut_in(ushort CardNo, UInt32 rotary_cut_id, ushort execute, ushort rotary_axis, ushort feed_axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_apf_rotary_cut_in_status(ushort CardNo, UInt32 rotary_cut_id, ref ushort done, ref ushort busy, ref ushort error, ref UInt32 error_id);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_apf_rotary_cut_in(ushort CardNo, UInt32 rotary_cut_id, ref ushort execute, ref ushort rotary_axis, ref ushort feed_axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_apf_rotary_cut_out(ushort CardNo, UInt32 rotary_cut_id, ushort execute, ushort rotary_axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_apf_rotary_cut_out_status(ushort CardNo, UInt32 rotary_cut_id, ref ushort done, ref ushort busy,ref ushort error, ref UInt32 error_id);




        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_clear_current_mark_mode(ushort CardNo, ushort Crd, ushort mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_clear_current_mark_mode(ushort CardNo, ushort Crd,ref ushort mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_clear_current_mark(ushort CardNo, ushort Crd);


        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_arc_translate_mode(ushort CardNo, ushort Crd, ushort mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_arc_translate_mode(ushort CardNo, ushort Crd,ref ushort mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_trace_set_source(ushort CardNo, ushort source);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_sync_set_profile_unit(ushort CardNo, ushort AxisNum, ushort[] AxisList, double[] Min_Vel, double[] Max_Vel, double[] Tacc, double[] Tdec, double[] Stop_Vel);



        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_rxpdo_extra_short(ushort CardNo, ushort PortNum, ushort address, ushort DataLen, ushort Value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_rxpdo_extra_short(ushort CardNo, ushort PortNum, ushort address, ushort DataLen, ref ushort Value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_txpdo_extra_short(ushort CardNo, ushort PortNum, ushort address, ushort DataLen, ref ushort Value);


        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_timeout(ushort CardNo, UInt32 timems);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_sync_pos_change_mode(ushort CardNo, ushort portno, ushort axis);




        [DllImport("LTDMC.dll")]
        public static extern short dmc_mc_gear_in_pos(ushort CardNo, ushort slave_axis, ushort master_axis, ushort execute, ushort conti_update, ushort master_source, double ratio_numerator, double ratio_denominator, double master_sync_pos, double slave_sync_pos, double master_start_dist, ushort buffer_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_mc_gear_in_pos(ushort CardNo, ushort slave_axis, ref ushort master_axis, ref ushort execute, ref ushort conti_update, ref ushort master_source, ref double ratio_numerator, ref double ratio_denominator, ref double master_sync_pos, ref double slave_sync_pos, ref double master_start_dist, ref ushort buffer_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_mc_gear_in_pos_status(ushort CardNo, ushort slave_axis, ref ushort start_sync, ref ushort in_sync, ref ushort busy, ref ushort active, ref ushort cmd_aborted, ref ushort error, ref UInt32 error_id);



        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_watchdog_trig_status(ushort CardNo,ref ushort status);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_reset_watchdog_trig_status(ushort CardNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_transarc_io_insert_mode(ushort CardNo, ushort Crd, ushort mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_transarc_io_insert_mode(ushort CardNo, ushort Crd,ref ushort mode);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_multi_axes_motion_sync_pmove_unit(ushort CardNo, ushort axis_num, ushort[] axis_list, double[] dist_list, double[] Min_Vel_list, double[] Max_Vel_list, double[] Tacc_list, double[] Tdec_list, double[] stop_Vel_list, double[] s_para_list, ushort[] posi_mode_list, ushort mode);




        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_ez_map_input(ushort CardNo, ushort axis, ushort enable, ushort mode, ushort index, ushort sub_index);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_ez_map_input(ushort CardNo, ushort axis,ref ushort enable,ref ushort mode,ref ushort index,ref ushort sub_index);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_etc_el_stop_mode(ushort CardNo, ushort axis, ushort el_control_mode, double diff_pos, UInt32 filter);




        [DllImport("LTDMC.dll")]
        public static extern short dmc_circle_move_center_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] Cen_Pos, ushort Arc_Dir, long Circle, ushort posi_mode);     
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_circle_move_center_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] Cen_Pos, ushort Arc_Dir, long Circle, ushort posi_mode, long mark);    
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_acuate_angle_config_params(ushort CardNo, ushort Crd, double acuate_angle, double angle_trans_speed, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_acuate_angle_config_params(ushort CardNo, ushort Crd,ref double acuate_angle,ref double angle_trans_speed,ref ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_axes_link_params(ushort CardNo, ushort master, ushort slave);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axes_link_params(ushort CardNo, ushort master,ref ushort slave);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_remove_axes_link_params(ushort CardNo, ushort master);





        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_alm_mode_ex(ushort CardNo, ushort axis, ushort enable, ushort alm_logic, ushort alm_action, ushort alm_all);//��������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_alm_mode_ex(ushort CardNo, ushort axis,ref ushort enable,ref ushort alm_logic,ref ushort alm_action,ref ushort alm_all);//��������





        //��ȡ����������

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_encoder_dir(ushort CardNo, ushort axis,ref ushort dir);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_download_configfile_ex(ushort CardNo,string FileName);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_s_profile_config(ushort CardNo, ushort axis, double acc_s_time, double dec_s_time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_s_profile_config(ushort CardNo, ushort axis,ref double acc_s_time,ref double dec_s_time);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_slave_state(ushort CardNo, ushort SlaveId, ushort SlaveState);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_slave_state(ushort CardNo, ushort SlaveId,ref ushort SlaveState);







        [DllImport("LTDMC.dll")]
        public static extern short dmc_sync_pmove_unit(ushort CardNo, ushort axis_num, ushort[] axis_list, double[] dist_list, ushort[] posi_mode_list, ushort mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_axis_abnormal_mode(ushort CardNo, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_abnormal_mode(ushort CardNo,ref ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_clear_axis_abnormal_state(ushort CardNo, ushort axis, ushort count);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_coordinate_abnormal_mode(ushort CardNo, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_coordinate_abnormal_mode(ushort CardNo,ref ushort enable);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_clear_crd_abnormal_state(ushort CardNo, ushort Crd, ushort count);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_coordinate_remainspace_mode(ushort CardNo, ushort Crd, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_coordinate_remainspace_mode(ushort CardNo, ushort Crd,ref ushort enable);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_add_linear_unit(ushort CardNo, ushort hcmp, int count, struct_hs_cmp_info[] cmp_str); 

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_axis_handwheel_encoder_filter_frequancy(ushort CardNo, ushort axis, double frequancy);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_handwheel_encoder_filter_frequancy(ushort CardNo, ushort axis,ref double frequancy);


        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_slave_alias(ushort CardNo, ushort portnum, ushort auto_address, ushort alias_address);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_slave_alias(ushort CardNo, ushort portnum, ushort auto_address,ref ushort alias_address);


        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_pwm_first_pulse_mode(ushort CardNo, ushort pwm_no, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pwm_first_pulse_mode(ushort CardNo, ushort pwm_no,ref ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_pwm_first_pulse_duty(ushort CardNo, ushort pwm_no, double duty);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pwm_first_pulse_duty(ushort CardNo, ushort pwm_no,ref double duty);


        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmp_fifo_set_hcmp2d_pos_ratio(ushort CardNo, ushort Crd, ushort hcmp2d, double xpos_ratio, double ypos_ratio);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmp_fifo_get_hcmp2d_pos_ratio(ushort CardNo, ushort Crd, ushort hcmp2d,ref double xpos_ratio,ref double ypos_ratio);



        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_leadscrew_comp_datasheet_enable(ushort CardNo, ushort axis, ushort enable, int point_num);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_leadscrew_comp_datasheet_enable(ushort CardNo, ushort axis,ref ushort enable,ref int point_num);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_pos_calibrate_config(ushort CardNo, ushort axis, ushort settle_time, double err_band, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pos_calibrate_config(ushort CardNo, ushort axis,ref ushort settle_time,ref double err_band,ref ushort enable);



        //�ļ�����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_userlib_loadlibrary(ushort CardNo,string  pLibname);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_userlib_set_parameter(ushort CardNo, int type, string pParameter,int length);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_userlib_get_parameter(ushort CardNo, int type, string pParameter, int length);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_userlib_imd_stop(ushort CardNo, ushort axis);


        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmp_fifo_get_fpga_receive_point(ushort CardNo, ushort cmp_no,ref long receive_point);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cmp_fifo_check_fpga_clear_status(ushort CardNo, ushort cmp_no,ref ushort clr_status,ref long clr_point);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_modify_slaveid(ushort CardNo, ushort index, ushort subindex, ushort newindex,string FileName);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_home_finish_map(ushort CardNo, ushort axis, ushort enable, ushort mode, ushort index, ushort sub_index, ushort bit_index, ushort bit_logic);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_home_finish_map(ushort CardNo, ushort axis,ref ushort enable,ref ushort mode,ref ushort index,ref ushort sub_index,ref ushort bit_index,ref ushort bit_logic);


        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_config_error_info(ushort CardNo,ref int axis,ref int liner,ref int type,ref int errorcode);



        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_t_pmove_extern_dectime(ushort CardNo, ushort axis, UInt32 dec_time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_t_pmove_extern_dectime(ushort CardNo, ushort axis,ref UInt32 dec_time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_trajectory_splicing_error(ushort CardNo, ushort crd, double error);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_trajectory_splicing_error(ushort CardNo, ushort crd,ref double error);


        [DllImport("LTDMC.dll")]
        public static extern short dmc_sine_oscillate_set_cycle_num(ushort CardNo, ushort Axis, UInt32 cycle_num);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sine_oscillate_get_cycle_num(ushort CardNo, ushort Axis,ref UInt32 cycle_num);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_wait_input_action(ushort CardNo, ushort Crd, ushort bitno, ushort on_off, double TimeOut, ushort action, long mark);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_line_change_pos_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] TargetPos);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_arc_move_angle_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Cen_Pos, double Angle, double[] Target_Pos, ushort posi_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_arc_move_center_angle_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] Cen_Pos, double Angle, ushort Arc_Dir, long Circle, ushort posi_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_line_change_pos_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] TargetPos, int mark);



        [DllImport("LTDMC.dll")]
        public static extern short nmc_sync_pmove_extern_unit(ushort CardNo, ushort AxisNum, ushort[] AxisList, double[] Dist, double[] Max_Vel, ushort Posimode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pvt_get_run_index(ushort CardNo, ushort axis, ref UInt32 index);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_firmware_auto_update();
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_blend_distance(ushort CardNo, ushort Crd, ushort Enable, double BlendDistance);


        //////////////////////////////////////////////////////////////////////////2022.08.11����

        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_dc_mode(ushort CardNo, ushort PortNo, ushort mode);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_dc_mode(ushort CardNo, ushort PortNo,ref ushort mode);




        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_gear_follow_ratio(ushort CardNo, ushort axis, double ratio);//˫Z��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_gear_follow_ratio(ushort CardNo, ushort axis, ref double ratio);


        //LTC�����������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_set_outbit(ushort CardNo, ushort latch, ushort enable, ushort bitno, ushort logic, double delaytime_s, double outtime_s);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_get_outbit(ushort CardNo, ushort latch,ref ushort enable,ref ushort bitno, ref ushort logic, ref double delaytime_s, ref double outtime_s);




        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_idle_crd_index(ushort CardNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_position_virtual(ushort CardNo, ushort axis,ref double pos);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_check_encoder_done(ushort CardNo, ushort axis,ref ushort state,ref double EncoderPos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_check_target_encoder(ushort CardNo, ushort axis, ushort TargetCheckEnable, double TargetError, double TargetCheckTime_s);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_check_target_encoder(ushort CardNo, ushort axis, ref ushort TargetCheckEnable, ref double TargetError, ref double TargetCheckTime_s);


        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_check_inp_encoder(ushort CardNo, ushort axis, ushort InpCheckEnable, double InpError, double InpCheckTime_s);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_check_inp_encoder(ushort CardNo, ushort axis,ref ushort InpCheckEnable, ref double InpError, ref double InpCheckTime_s);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_connect_to_encoder(ushort CardNo, ushort axis, ushort enable, double error);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_connect_to_encoder(ushort CardNo, ushort axis,ref ushort enable,ref double error);



        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_robot_config(ushort CardNo, ushort Crd, short robot_type, short elbow, short joint_num, short[] joint_list, double[] rx, double[] tx, double[] rz, double[] tz);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_robot_config(ushort CardNo, ushort Crd,ref short robot_type, ref short elbow, ref short joint_num, short[] joint_list, double[] rx, double[] tx, double[] rz, double[] tz);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_robot_enable(ushort CardNo, ushort Crd, short user_crd, short tool_crd, short enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_robot_ptp_move(ushort CardNo, ushort Crd, short joint_num, short[] joint_list, double[] joint_pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_robot_sts(ushort CardNo, ushort Crd,ref short complete,ref short user_crd,ref short tool_crd,ref short enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_robot_pos(ushort CardNo, ushort Crd,ref double pos);


        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_robot_kinematics_calib(ushort CardNo, ushort Crd, double[] delta_rx, double[] delta_tx, double[] delta_rz, double[] delta_tz);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_robot_kinematics_calib(ushort CardNo, ushort Crd, double[] delta_rx, double[] delta_tx, double[] delta_rz, double[] delta_tz);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_robot_kinematics_calib(ushort CardNo, ushort Crd, double[] ja, double[] jb, double[] jc, double[] jd, double[] je, double[] jf, double[] jg, double[] jh, double[] ji, double[] delta_x, double[] delta_y, double[] delta_z);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_robot_user_coordinate(ushort CardNo, ushort Crd, short user_crd, short complete, double[] mat);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_robot_user_coordinate(ushort CardNo, ushort Crd, short user_crd,ref short complete, double[] mat);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_robot_user_coordinate(ushort CardNo, ushort Crd, short user_crd, double[] p0, double[] px, double[] py);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_robot_tool_coordinate(ushort CardNo, ushort Crd, short tool_crd, short complete, double[] mat);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_robot_tool_coordinate(ushort CardNo, ushort Crd, short tool_crd,ref short complete, double[] mat);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_robot_tool_coordinate(ushort CardNo, ushort Crd, short tool_crd, double[] p1, double[] p2, double[] p3, double[] p4, double[] p5, double[] p6, double[] p0, double[] px, double[] py);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_robot_workspace_detect(ushort CardNo, ushort Crd, double[] pos);



        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_wait_flag(ushort CardNo, ushort Crd, int mark, ushort wait_flag);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_wait_flag(ushort CardNo, ushort Crd,ref int mark,ref ushort wait_flag);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_arc_blend_enable(ushort CardNo, ushort Crd, ushort Enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_arc_blend_enable(ushort CardNo, ushort Crd,ref ushort Enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_t_pmove_extern_unit_ex(ushort CardNo, ushort axis, double MidPos, double TargetPos, double Min_Vel, double Max_Vel, double stop_Vel, double acc, double dec, ushort posi_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_check_success_pulse_ex(ushort CardNo, ushort axis, int delay_ms);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_check_success_encoder_ex(ushort CardNo, ushort axis, int delay_ms);



        [DllImport("LTDMC.dll")]
        public static extern short dmc_cam_write_points_packet(ushort CardNo, ushort cam_table_id, ushort cam_point_num, double s_range_up, double s_range_dn, double[] master_pos, double[] slave_pos, double[] slave_vel, double[] slave_acc, double[] slave_jerk, ushort[] type);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cam_read_points_packet(ushort CardNo, ushort cam_table_id,ref ushort cam_point_num,ref double s_range_up,ref double s_range_dn, double[] master_pos, double[] slave_pos, double[] slave_vel, double[] slave_acc, double[] slave_jerk, ushort[] type);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_pwm_output_extern(ushort CardNo, ushort pwm, ushort enable, double width_us, double frequency, int number);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_spline_pmove(ushort CardNo, ushort axis, double pos, double vs, double vm, double ve, double as1, double ae, double rmd_as, double rmd_ae, int num_ts, int num_tm, int num_te, double cur_as, double cur_ae, ushort posi_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_plan_mode(ushort CardNo, ushort axis, ushort mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_plan_mode(ushort CardNo, ushort axis,ref ushort mode);



        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_emg_lock(ushort CardNo, ushort enable, ushort bit_no, ushort level, Int32 out_mark, Int32 out_level);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_emg_lock(ushort CardNo,ref ushort enable,ref ushort bit_no, ref ushort level,ref Int32 out_mark, ref Int32 out_level);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_emg_unlock(ushort CardNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_emg_lock_status(ushort CardNo,ref ushort lock_status,ref ushort lock_type);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_vector_profile_extern(ushort CardNo, ushort Crd, double Min_Vel, double Max_Vel, double Acc, double Dec, double Ajerk, double Djerk, double stop_vel);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_vector_profile_extern(ushort CardNo, ushort Crd,ref double Min_Vel,ref double Max_Vel,ref double Acc,ref double Dec,ref double Ajerk,ref double Djerk,ref double stop_vel);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_vector_plan_mode(ushort CardNo, ushort Crd, ushort mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_vector_plan_mode(ushort CardNo, ushort Crd,ref ushort mode);



        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_data_offset_time(ushort CardNo, int offset_us);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_data_offset_time(ushort CardNo,ref int offset_us);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_check_done_multicoor_extern(ushort CardNo, ushort Crd,ref ushort crd_state,ref UInt32 crd_stop_reason, ref UInt32 axis_stop_reason);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_error_description(int errcocode, byte[] description);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_write_outport_mask(ushort CardNo, ushort port, UInt32 mask, UInt32 state, UInt32 reverse_time_ms);



        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_pso_output_delay(ushort CardNo, ushort axis, UInt32 delay_cycle);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pso_output_delay(ushort CardNo, ushort axis,ref UInt32 delay_cycle);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_gap_cmp_space(ushort CardNo, ushort crd, double space);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_gap_cmp_space(ushort CardNo, ushort crd,ref double space);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_ecat_read_slave_register(ushort CardNo, ushort wSlaveAddress, ushort wRegisterOffset, ushort wLen, byte[] pdwData);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_ecat_write_slave_register(ushort CardNo, ushort wSlaveAddress, ushort wRegisterOffset, ushort wLen, byte[] pdwData);


        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_inp_map_input(ushort CardNo, ushort axis, ushort enable, ushort index, ushort sub_index, ushort bit_index, ushort inp_validvalue, ushort connect2checkdone);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_inp_map_input(ushort CardNo, ushort axis,ref ushort enable, ref ushort index, ref ushort sub_index, ref ushort bit_index, ref ushort inp_validvalue, ref ushort connect2checkdone);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pwm_state(ushort CardNo, ushort channel,ref ushort state);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_rotation_axis_transform_param(ushort CardNo, ushort axis, double rod_len);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_get_rotation_axis_transform_param(ushort CardNo, ushort axis,ref double rod_len);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_rotation_axis_transform_enable(ushort CardNo, ushort axis, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_rtcp_get_rotation_axis_transform_enable(ushort CardNo, ushort axis,ref ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_circle_move_3point_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] Mid_Pos, long Circle, ushort posi_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_circle_move_3point_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] Mid_Pos, long Circle, ushort posi_mode, long mark);


        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_cam_in(ushort CardNo, ushort slave_axis,ref ushort master_axis,ref ushort execute,ref ushort conti_update, ref ushort cam_table,ref ushort periodic, ref ushort master_abs,ref ushort slave_abs,ref double master_offset, ref double slave_offset, ref double master_scaling, ref double slave_scaling, ref double master_start_dist, ref double master_sync_pos, ref double active_pos,ref ushort acvive_mode,ref ushort start_mode,ref double velocity,ref double acc,ref double dec,ref double jerk,ref ushort master_source,ref ushort buffer_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_mc_phasing(ushort CardNo, ushort slave_axis, ushort master_axis, ushort execute, double phase_shift, double velocity, double acc, double dec, double jerk);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_mc_phasing_status(ushort CardNo, ushort slave_axis,ref ushort done, ref ushort busy, ref ushort cmd_aborted, ref ushort error, ref UInt32  error_id);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_mc_phasing(ushort CardNo, ushort slave_axis,ref ushort master_axis, ref ushort execute,ref double phase_shift,ref double velocity,ref double acc,ref double dec,ref double jerk);



        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_axis_pwm_follow_speed(ushort CardNo, ushort pwm_no, ushort axis, ushort mode, double max_vel, double min_vel, double max_value, double out_value, double min_value, ushort min_ctl_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_pwm_follow_speed(ushort CardNo, ushort pwm_no, ref ushort axis, ref ushort mode, ref double max_vel, ref double min_vel, ref double max_value, ref double out_value, ref double min_value, ref ushort min_ctl_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_axis_pwm_follow_speed_enable(ushort CardNo, ushort pwm_no, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_pwm_follow_speed_enable(ushort CardNo, ushort pwm_no,ref ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_umove_unit(ushort CardNo, ushort group, ushort mode, ushort sources, ushort io_index, ushort io_value, ushort up_axis, double up_pos, double up_safe_distance, ushort move_num, ushort[] move_axis_list, double[] move_pos, double[] move_safe_distance, ushort down_axis, double down_pos, ushort posi_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_umove_runsts(ushort CardNo, ushort group,ref ushort runsts);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_umove_stop(ushort CardNo, ushort group);



        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_knife_positioned(ushort CardNo, ushort Crd, double SecondVel, double SecondPos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_knife_positioned(ushort CardNo, ushort Crd,ref double SecondVel,ref double SecondPos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_knife_positioned_enable(ushort CardNo, ushort Crd, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_knife_positioned_enable(ushort CardNo, ushort Crd,ref ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_return_to_zero(ushort CardNo, ushort axis);



        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_lookahead_path_error(ushort CardNo, ushort Crd, double patherr);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_lookahead_path_error(ushort CardNo, ushort Crd,ref double patherr);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_safe_pause_list(ushort CardNo, ushort Crd, ushort safe_axis_num, ushort[] safe_axis_list, double[] distance, double[] vstart, double[] vsteady, double[] vend, double[] acc_time, double[] dec_time, ushort posi_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_axis_da_follow_speed(ushort CardNo, ushort da_channel, ushort axis, ushort mode, double max_vel, double min_vel, double max_value, double min_value, double offset);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_da_follow_speed(ushort CardNo, ushort da_channel, ref ushort axis,ref ushort mode,ref double max_vel,ref double min_vel,ref double max_value,ref double min_value,ref double offset);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_axis_da_follow_speed_enable(ushort CardNo, ushort da_channel, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_da_follow_speed_enable(ushort CardNo, ushort da_channel,ref ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_force_set_position(ushort CardNo, ushort Crd, ushort axis_num, ushort[] axis_list, double[] position);



        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_axis_da_follow_speed_extern(ushort CardNo, ushort da_channel, ushort axis, ushort mode, ushort segment, double[] vel, double[] value);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_da_follow_speed_extern(ushort CardNo, ushort da_channel,ref ushort axis,ref ushort mode,ref ushort segment, double[] vel, double[] value);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_node_da_enable(ushort CardNo, ushort Crd, ushort node_id, ushort channel, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_node_da_output(ushort CardNo, ushort Crd, ushort node_id, ushort channel, double Vout);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_gantry_move(ushort CardNo, ushort Crd, ushort master_axis, ushort slave_num, ushort[] slave_axis_list, ushort on_off);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_gantry_error_protect_unit(ushort CardNo, ushort Crd, ushort master_axis, double dstp_err, double emg_err, ushort on_off);





        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_sigaxis_moveseg_data_ex(ushort CardNo, ushort group, ushort Axis, double Target_pos, UInt32 mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_wait_event_data(ushort CardNo, ushort group, ushort event1, ushort num,ushort CompareOperator, double target_value, ushort mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_trigger_data(ushort CardNo, ushort group, ushort mode, ushort num, double Target_Value, UInt32 mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_time_delay(ushort CardNo, ushort group, double Time_delay, UInt32 mark);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_feedforward_profile(ushort CardNo, ushort Axis, double vel_offset_coef, double tor_offset_coef);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_feedforward_profile(ushort CardNo, ushort Axis,ref double vel_offset_coef,ref double tor_offset_coef);




    }
}
