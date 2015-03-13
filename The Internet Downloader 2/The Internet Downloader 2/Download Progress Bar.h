using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class DownBar : public Control
{
public:
	DownBar(void)
	{
		InitializeComponent();
	}
	~DownBar()
	{
		if (components)
		{
			delete components;			
		}
	}
	private: System::Windows::Forms::Panel^  panel1;
	int X;
	int Y;
	int step;
	int maximum;
	int minimum;
	int value;
	System::ComponentModel::Container ^components;

	void InitializeComponent(void)
	{
		step=1;
		X=1;
		Y=13;
		maximum=100;
		minimum=0;
		value=0;
		//
		//
		//
		this->panel1 = (gcnew System::Windows::Forms::Panel());
		// 
		// panel1
		// 
		this->panel1->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
		this->panel1->Location = System::Drawing::Point(4, 5);
		this->panel1->Name = L"panel1";
		this->panel1->BackColor::set(Drawing::Color::Blue);
		this->panel1->Size = System::Drawing::Size(0, 0);
		this->panel1->TabIndex = 0;
		// 
		// Form1
		// 
		this->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
		this->BackColor = System::Drawing::Color::Black;
		this->Size = System::Drawing::Size(410, 20);
		this->Controls->Add(this->panel1);
	}
	void update()
	{
		if(maximum>0)
		{
			X=(this->Size::get().Width::get()-10)/maximum; 
		}
	}
public:
	void MakeStep()
	{
		update();
		value+=step;
		this->panel1->Size::set(Drawing::Size(value*X,Y));
	}
	property Image ^ ProcessImage
	{
		Image ^ get()
		{
			return this->panel1->BackgroundImage::get();
		}
		void set(Image ^ image)
		{
			this->panel1->BackgroundImage::set(image);
		}
	}
	property int Maximum
	{
		int get()
		{
			return maximum;
		}
		void set(int max)
		{
			if(max<=0)
				throw gcnew System::Exception("The Maximum Cannot be zero or less than");
			if(max<minimum)
				throw gcnew System::Exception("The Maximum Cannot be less than the minimum");
			maximum=max;
			update();
		}
	}
	property int Minimum
	{
		int get()
		{
			return minimum;
		}
		void set(int min)
		{
			if(min<0)
				throw gcnew System::Exception("The Minimum Cannot be less than Zero");
			if(min>maximum)
				throw gcnew System::Exception("The Minimum Cannot be More than the maximum");
			minimum=min;
			update();
		}
	}
	property int Step
	{
		int get()
		{
			return step;
		}
		void set(int s)
		{
			if(s<0)
				throw gcnew System::Exception("The Step Cannot be less than Zero");
			if(s>maximum)
				throw gcnew System::Exception("The Step Cannot be More than the maximum");
			step=s;
		}
	}
	property int Value
	{
		int get()
		{
			return value;
		}
		void set(int val)
		{
			if(val<maximum)
			{
				if(val<0)
					throw gcnew System::Exception("The Value Cannot be less than Zero");
				if(val<minimum)
					throw gcnew System::Exception("The Value Cannot be less than the minimum");
				if(val>maximum)
					throw gcnew System::Exception("The Value Cannot be more than the maximum");
			}
			value=val;
			if(val<=maximum)
			{
				update();
				this->panel1->Size::set(Drawing::Size(value*X,Y));
			}
		}
	}
};