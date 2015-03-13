typedef enum _DWMWINDOWATTRIBUTE {
    DWMWA_NCRENDERING_ENABLED = 1 ,
    DWMWA_NCRENDERING_POLICY,
    DWMWA_TRANSITIONS_FORCEDISABLED,
    DWMWA_ALLOW_NCPAINT,
    DWMWA_CAPTION_BUTTON_BOUNDS,
    DWMWA_NONCLIENT_RTL_LAYOUT,
    DWMWA_FORCE_ICONIC_REPRESENTATION,
    DWMWA_FLIP3D_POLICY,
    DWMWA_EXTENDED_FRAME_BOUNDS,
    DWMWA_HAS_ICONIC_BITMAP,
    DWMWA_DISALLOW_PEEK,
    DWMWA_EXCLUDED_FROM_PEEK,
    DWMWA_LAST
} DWMWINDOWATTRIBUTE;
typedef enum _DWMNCRENDERINGPOLICY {
    DWMNCRP_USEWINDOWSTYLE,
    DWMNCRP_DISABLED,
    DWMNCRP_ENABLED,
    DWMNCRP_LAST
} DWMNCRENDERINGPOLICY;
typedef enum _DWMFLIP3DWINDOWPOLICY {
    DWMFLIP3D_DEFAULT,
    DWMFLIP3D_EXCLUDEBELOW,
    DWMFLIP3D_EXCLUDEABOVE,
    DWMFLIP3D_LAST
} DWMFLIP3DWINDOWPOLICY;
using namespace System::Runtime::InteropServices;
[DllImport("dwmapi")]
extern "C++" long DwmSetWindowAttribute(System::IntPtr h,unsigned int x,System::Void * v,unsigned int xx);
void Set(System::IntPtr h)
{
	DWMNCRENDERINGPOLICY ncrp = DWMNCRP_ENABLED;
	DWMFLIP3DWINDOWPOLICY flip=DWMFLIP3D_DEFAULT;
	int isTrue=0;
	//DwmSetWindowAttribute(h,DWMWA_TRANSITIONS_FORCEDISABLED,&ncrp,sizeof(ncrp));
	//DwmSetWindowAttribute(h,DWMWA_TRANSITIONS_FORCEDISABLED,&isTrue,sizeof(isTrue));
	//DwmSetWindowAttribute(h,DWMWA_ALLOW_NCPAINT,&isTrue,sizeof(isTrue));
	//DwmSetWindowAttribute(h,DWMWA_NONCLIENT_RTL_LAYOUT,&isTrue,sizeof(isTrue));
	//DwmSetWindowAttribute(h,DWMWA_FLIP3D_POLICY,&flip,sizeof(flip));
	//DwmSetWindowAttribute(h,DWMWA_DISALLOW_PEEK,&isTrue,sizeof(isTrue));
	DwmSetWindowAttribute(h,DWMWA_EXCLUDED_FROM_PEEK,&isTrue,sizeof(isTrue));

}
[DllImport("dwmapi")]
extern "C++" long DwmSetIconicThumbnail(System::IntPtr h,System::IntPtr v,unsigned int d);
void Bit(System::IntPtr h)
{
	System::IO::FileStream ^ v=gcnew System::IO::FileStream("D:\\Test\\XXX.bmp",System::IO::FileMode::Open);
	DwmSetIconicThumbnail(h,v->Handle,0x00000001);
}
class Marg
{
public:
	int x;
	int y;
	int x1;
	int y1;
};
[DllImport("dwmapi")]
extern "C++" long DwmExtendFrameIntoClientArea(System::IntPtr h,Marg*d);
void glass(System::IntPtr h,int in=-1)
{
	Marg d;
	d.x=0;
	d.y=in;
	d.x1=0;
	d.y1=0;
	DwmExtendFrameIntoClientArea(h,&d);
}
void Sizeing(System::IntPtr ^ h)
{
}
class DWM_BLURBEHIND {
public:
    unsigned int dwFlags;
    bool fEnable;
	void * r;
    bool fTransitionOnMaximized;
};
[DllImport("dwmapi")]
extern "C++" long DwmEnableBlurBehindWindow(System::IntPtr h,DWM_BLURBEHIND * d);
void EnableBlur(System::IntPtr h,bool isEnabeld=true)
{
	DWM_BLURBEHIND x;
	x.dwFlags=0x00000001;
	x.fEnable=isEnabeld;
	x.fTransitionOnMaximized=true;
	DwmEnableBlurBehindWindow(h,&x);
}
typedef struct tagRECT { 
   long left;
   long top;
   long right;
   long bottom;
} RECT;
typedef struct _DWM_THUMBNAIL_PROPERTIES {
    unsigned int dwFlags;
    RECT rcDestination;
    RECT rcSource;
	System::Byte opacity;
    bool fVisible;
    bool fSourceClientAreaOnly;
} DWM_THUMBNAIL_PROPERTIES, *PDWM_THUMBNAIL_PROPERTIES;
[DllImport("dwmapi")]
extern "C++" bool DwmRegisterThumbnail(System::IntPtr hwndDestination,System::IntPtr *hwndSource,System::IntPtr * phThumbnailId);
[DllImport("dwmapi")]
extern "C++" long DwmUpdateThumbnailProperties(System::IntPtr hThumbnailId,const DWM_THUMBNAIL_PROPERTIES *ptnProperties);
void thumbnail(System::IntPtr h,System::IntPtr * d)
{
	System::IntPtr t;
	bool x=DwmRegisterThumbnail(h,d,&t);
	if(x)
	{
		System::Windows::Forms::MessageBox::Show("");
		RECT dest = {0,50,100,150};
		DWM_THUMBNAIL_PROPERTIES dskThumbProps;
		dskThumbProps.dwFlags = 0x00000010 | 0x00000008 | 0x00000004 | 0x00000001;
		dskThumbProps.fSourceClientAreaOnly = false; 
		dskThumbProps.fVisible = true;
		dskThumbProps.opacity = (255 * 70)/100;
		dskThumbProps.rcDestination = dest;
		DwmUpdateThumbnailProperties(t,&dskThumbProps);
	}
}
namespace FullScreenStaff
{
	public ref class clientRect
	{
	public:
		System::Drawing::Point WLoc;
		System::Drawing::Point PLoc;
		System::Drawing::Size WSize;
		System::Drawing::Size PSize;
		int x;
		int y;
	};
}