#pragma once


namespace TheFlashCopier {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace Microsoft::Win32;

	/// <summary>
	/// Summary for Form1
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::ProgressBar^  CopyProg;
	protected: 

	private: System::Windows::Forms::Label^  Info;

	private: System::Windows::Forms::CheckBox^  IsClose;
	private: System::Windows::Forms::GroupBox^  Settings;


	private: System::Windows::Forms::TextBox^  SaveTo;

	private: System::Windows::Forms::Button^  Browes;
	private: System::Windows::Forms::NotifyIcon^  notifyIcon1;
	private: System::ComponentModel::IContainer^  components;
			 System::ComponentModel::ComponentResourceManager^  resources;
			 System::Windows::Forms::ContextMenu^ contextMenu1;
			 System::Windows::Forms::MenuItem^ menuItem1;
			 System::Windows::Forms::MenuItem^ menuItem2;
			 System::Threading::ThreadStart ^ TStart;
			 System::Threading::Thread ^ thread;
			 System::Threading::ThreadStart ^ TStart2;
			 System::Threading::Thread ^ thread2;
			 fastCopy::copy ^ newCopy;


	protected: 

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>


#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			resources = (gcnew System::ComponentModel::ComponentResourceManager(Form1::typeid));
			this->CopyProg = (gcnew System::Windows::Forms::ProgressBar());
			this->Info = (gcnew System::Windows::Forms::Label());
			this->IsClose = (gcnew System::Windows::Forms::CheckBox());
			this->Settings = (gcnew System::Windows::Forms::GroupBox());
			this->Browes = (gcnew System::Windows::Forms::Button());
			this->SaveTo = (gcnew System::Windows::Forms::TextBox());
			this->notifyIcon1 = (gcnew System::Windows::Forms::NotifyIcon(this->components));
			this->contextMenu1 = gcnew System::Windows::Forms::ContextMenu;
			this->menuItem1 = gcnew System::Windows::Forms::MenuItem;
			this->menuItem2 = gcnew System::Windows::Forms::MenuItem;
			this->Settings->SuspendLayout();
			this->SuspendLayout();
			// 
			// CopyProg
			// 
			this->CopyProg->Location = System::Drawing::Point(12, 127);
			this->CopyProg->Name = L"CopyProg";
			this->CopyProg->Size = System::Drawing::Size(342, 23);
			this->CopyProg->TabIndex = 0;
			// 
			// Info
			// 
			this->Info->AutoSize = true;
			this->Info->Location = System::Drawing::Point(81, 111);
			this->Info->Name = L"Info";
			this->Info->Size = System::Drawing::Size(184, 13);
			this->Info->TabIndex = 1;
			this->Info->Text = L"Searcing For Removable Drives . . . .";
			// 
			// IsClose
			// 
			this->IsClose->AutoSize = true;
			this->IsClose->Location = System::Drawing::Point(19, 19);
			this->IsClose->Name = L"IsClose";
			this->IsClose->Checked=true;
			this->IsClose->Size = System::Drawing::Size(141, 17);
			this->IsClose->TabIndex = 2;
			this->IsClose->Text = L"Stop Searching At Close";
			this->IsClose->UseVisualStyleBackColor = true;
			this->IsClose->CheckedChanged += gcnew System::EventHandler(this, &Form1::checkBox1_CheckedChanged);
			// 
			// Settings
			// 
			this->Settings->Controls->Add(this->Browes);
			this->Settings->Controls->Add(this->SaveTo);
			this->Settings->Controls->Add(this->IsClose);
			this->Settings->Location = System::Drawing::Point(9, 12);
			this->Settings->Name = L"Settings";
			this->Settings->Size = System::Drawing::Size(345, 83);
			this->Settings->TabIndex = 3;
			this->Settings->TabStop = false;
			this->Settings->Text = L"Settings";
			this->Settings->Enter += gcnew System::EventHandler(this, &Form1::Settings_Enter);
			// 
			// Browes
			// 
			this->Browes->Location = System::Drawing::Point(275, 49);
			this->Browes->Name = L"Browes";
			this->Browes->Size = System::Drawing::Size(64, 22);
			this->Browes->TabIndex = 4;
			this->Browes->Text = L"Browes";
			this->Browes->UseVisualStyleBackColor = true;
			// 
			// SaveTo
			// 
			this->SaveTo->Location = System::Drawing::Point(19, 49);
			this->SaveTo->Name = L"SaveTo";
			this->SaveTo->Size = System::Drawing::Size(250, 20);
			this->SaveTo->TabIndex = 3;
			this->SaveTo->Text = L"Save Files To";
			// 
			// notifyIcon1
			//
			this->notifyIcon1->Icon = (cli::safe_cast<System::Drawing::Icon^  >(resources->GetObject(L"$this.Icon")));
			this->notifyIcon1->BalloonTipText = L"The Flash Copier";
			this->notifyIcon1->Text = L"The Flash Copier";
			this->notifyIcon1->Visible = true;
			array<System::Windows::Forms::MenuItem^>^temp = {this->menuItem1,this->menuItem2};
			this->contextMenu1->MenuItems->AddRange( temp );
			//
			// Initialize menuItem1&2
			//
			this->menuItem1->Index = 0;
			this->menuItem1->Text = "Exit";
			this->menuItem1->Click += gcnew System::EventHandler( this, &Form1::menuItem1_Click );
			this->menuItem2->Index = 1;
			this->menuItem2->Text = "Show";
			this->menuItem2->Click += gcnew System::EventHandler( this, &Form1::menuItem2_Click );
			this->notifyIcon1->ContextMenu = this->contextMenu1;
			this->notifyIcon1->DoubleClick += gcnew System::EventHandler( this, &Form1::notifyIcon1_DoubleClick );
			//
			//Threads
			//
			this->TStart=gcnew System::Threading::ThreadStart(this,&Form1::TheStart);
			this->thread=gcnew System::Threading::Thread(TStart);
			// 
			// Form1
			// 
			//init();
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			//this->BackColor = System::Drawing::Color::HotPink;
			this->ClientSize = System::Drawing::Size(366, 161);
			this->Controls->Add(this->Settings);
			this->Controls->Add(this->Info);
			this->Controls->Add(this->CopyProg);
			this->Closed+=gcnew EventHandler(this,&Form1::menuItem1_Click);
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedDialog;
			this->Icon = (cli::safe_cast<System::Drawing::Icon^  >(resources->GetObject(L"$this.Icon")));
			this->BackgroundImage= (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"Back")));
			this->MaximizeBox = false;
			this->MinimizeBox = false;
			this->Name = L"YazanSoftwears";
			this->ShowInTaskbar = false;
			this->Text = L"The Flash Copier";
			this->TopMost = true;
			this->Settings->ResumeLayout(false);
			this->Settings->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();
			scanning();
		}
#pragma endregion
private: System::Void checkBox1_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {

		 }
private: System::Void Settings_Enter(System::Object^  sender, System::EventArgs^  e) {
		 }
		void KeepNotifay()
		{
		}
		void notifyIcon1_DoubleClick(Object ^ s,EventArgs ^ e)
		{
			this->Visible=true;
			this->Activate();
			this->CenterToScreen();
		}
		void menuItem1_Click (Object ^ s,EventArgs ^ e)
		{
			if(this->IsClose->Checked::get())
			{
				thread->Abort();
				Application::ExitThread();
				Application::Exit();
			}
		}
		void menuItem2_Click (Object ^ s,EventArgs ^ e)
		{
			this->Visible=true;
			this->Activate();
		}
		void scanning()
		{
			newCopy=gcnew fastCopy::copy();
			newCopy->setProgressTo(this->CopyProg);
			thread->Start();
		}
		void TheStart()
		{
			array<System::IO::DriveInfo^>^ arr;//=System::IO::DriveInfo::GetDrives();
			bool e=false;
			String ^ to=gcnew String(L"D:\\Flash\\");
			while(1)
			{
				arr=System::IO::DriveInfo::GetDrives();
				for(int i=0;i<arr->Length::get();i++)
				{
					if((arr[i]->DriveType::get()==System::IO::DriveType::Removable)&&arr[i]->IsReady::get())
					{
						newCopy->startThread(arr[i]->Name::get(),to);
					}
				}
				Application::DoEvents();
			}
		}

};
}
/*


*/
