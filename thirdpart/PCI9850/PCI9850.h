#ifndef	PCI_9850_DLL_H
#define	PCI_9850_DLL_H

#include <Windows.h>

//AD采集初始化参数
#ifndef _PCI9850_PARA_INIT
typedef struct _PCI9850_PARA_INIT    
{
	LONG    ClkDiv;              //时钟分频/抽取，PCI9850目前不支持 
	LONG	TriggerMode;         //触发模式
	LONG	TriggerSource;	     //触发源 
	LONG    TriggerDelay;        //触发延时
	LONG    TriggerLength;       //触发长度
	LONG    TriggerLevel;        //模拟触发电平
	LONG    lADFmt;              //AD输出数据格式      
} PCI9850_PARA_INIT,*PPCI9850_PARA_INIT;
#endif

//采样钟选择，内钟或外钟 
typedef enum EmADClkSel
{
	ADCLK_INT        = 0, 
	ADCLK_EXT        = 1,
} ADCLK_SEL;

//AD数据输出格式
typedef enum EmADFormat
{
	ADFMT_STBIN    = 0, //直接二进制输出
	ADFMT_2SBIN    = 1  //二进制补码输出
} AD_FORMAT;

//触发模式
typedef enum EmTriggerMode
{
	TRIG_MODE_CONTINUE        = 0, //连续采集
	TRIG_MODE_POST            = 1, //后触发		
	TRIG_MODE_DELAY           = 2, //延时触发
	TRIG_MODE_PRE			  = 3, //前触发	 reserved	
	TRIG_MODE_MIDDLE          = 4, //中触发	 reserved	
} TRIGGER_MODE;

//触发源
typedef enum EmTriggerSource
{
	TRIG_SRC_EXT_RISING      = 0,  //外正沿触发
	TRIG_SRC_EXT_FALLING     = 1,  //外负沿触发	
	TRIG_SRC_SOFT            = 2,  //软件触发
} TRIGGER_SOURCE;

//读/写零偏
#define WRITEOFFSET 0 //写零偏
#define READOFFSET  1 //读零偏

//最大读采集点长度
#define   READ_MAX_LEN     0x800000 //8M个采样点，也就是8M字节

//***********************************************************
#ifndef DEFINING
#define DEVAPI __declspec(dllimport)
#else
#define DEVAPI __declspec(dllexport)
#endif


#ifdef __cplusplus
extern "C" {
#endif

//连接设备
DEVAPI HANDLE FAR PASCAL PCI9850_Link(UCHAR DeviceNO);
//断开设备
DEVAPI BOOL FAR PASCAL PCI9850_UnLink(HANDLE hdl);
//初始化AD参数，并开始采集
DEVAPI BOOL FAR PASCAL PCI9850_initAD(HANDLE hdl, PPCI9850_PARA_INIT para_init);
//读取AD数据
DEVAPI BOOL FAR PASCAL PCI9850_ReadAD(HANDLE hdl,PUCHAR pBuf,ULONG nCount, ULONG* bBufOver);
//读/写AD零偏
DEVAPI BOOL FAR PASCAL PCI9850_ADoffset(HANDLE hdl,LONG bRdWt,LONG* pOffsetVal);
//停止AD采集
DEVAPI BOOL FAR PASCAL PCI9850_StopAD(HANDLE hdl);
//设置DO
DEVAPI BOOL FAR PASCAL PCI9850_SetDO(HANDLE hdl, ULONG nDO);
//读取DI
DEVAPI BOOL FAR PASCAL PCI9850_GetDI(HANDLE hdl, ULONG* nDI);
//读取缓冲区数据数目
DEVAPI LONG FAR PASCAL PCI9850_GetBufCnt(HANDLE hdl);
//软件触发
DEVAPI BOOL FAR PASCAL PCI9850_ExeSoftTrig(HANDLE hdl);



#ifdef __cplusplus
}
#endif

#endif
