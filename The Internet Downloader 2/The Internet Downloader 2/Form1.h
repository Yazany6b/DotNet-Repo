#pragma once
#include"TheBox.h"
#include "Download Progress Bar.h"
namespace TheInternetDownloader2 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace System::Net;
	using namespace System::Web;

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
	private: System::Windows::Forms::Button^  start;
	private: System::Windows::Forms::Panel^  Panel1;
	private: System::Windows::Forms::TextBox^  DownURL;
	private: System::Windows::Forms::Panel^  Panel2;
	private: System::Windows::Forms::TextBox^  SaveTo;

	protected: 






	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::Button^  Browes;

	private: System::Windows::Forms::ErrorProvider^  errorProvider;
	private: System::Windows::Forms::FolderBrowserDialog^  FolderBrowes;
	//private: System::Windows::Forms::ProgressBar^  DownProg;
	private: System::Speech::Synthesis::SpeechSynthesizer ^ speech;
	private: System::Threading::Thread ^ TSpeech;
	private: System::Threading::ThreadStart ^ STSpeech;
			 DownBar ^ DownProg;



	private: System::Windows::Forms::Label^  BytesRec;
	private: System::Windows::Forms::Label^  TotalRec;
	private: System::Windows::Forms::Label^  DownProgress;
	private: System::Windows::Forms::Label^  ProgShow;
	private: System::Threading::Thread ^ thread;
	private: System::Threading::ThreadStart ^ SThread;
	private: System::Windows::Forms::Label^  TotalShow;
			 TheBox ^ box;
			 String ^ SomethingToSay;

	private: System::Windows::Forms::Label^  BytesShow;




	private: System::ComponentModel::IContainer^  components;
			 bool inThread;

	protected: 

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
			inThread=false;
			this->components = (gcnew System::ComponentModel::Container());
			box=gcnew TheBox();
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(Form1::typeid));
			this->start = (gcnew System::Windows::Forms::Button());
			this->Panel1 = (gcnew System::Windows::Forms::Panel());
			this->DownURL = (gcnew System::Windows::Forms::TextBox());
			this->Panel2 = (gcnew System::Windows::Forms::Panel());
			this->SaveTo = (gcnew System::Windows::Forms::TextBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->Browes = (gcnew System::Windows::Forms::Button());
			this->errorProvider = (gcnew System::Windows::Forms::ErrorProvider(this->components));
			this->FolderBrowes = (gcnew System::Windows::Forms::FolderBrowserDialog());
			//this->DownProg = (gcnew System::Windows::Forms::ProgressBar());
			this->DownProg = (gcnew DownBar());
			this->DownProgress = (gcnew System::Windows::Forms::Label());
			this->TotalRec = (gcnew System::Windows::Forms::Label());
			this->BytesRec = (gcnew System::Windows::Forms::Label());
			this->BytesShow = (gcnew System::Windows::Forms::Label());
			this->TotalShow = (gcnew System::Windows::Forms::Label());
			this->ProgShow = (gcnew System::Windows::Forms::Label());
			this->Panel1->SuspendLayout();
			this->Panel2->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->errorProvider))->BeginInit();
			this->SuspendLayout();
			// 
			// start
			// 
			this->start->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"start.BackgroundImage")));
			this->start->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
			this->start->Enabled = false;
			this->start->FlatStyle = System::Windows::Forms::FlatStyle::Popup;
			this->start->ForeColor = System::Drawing::SystemColors::Info;
			this->start->ImageAlign = System::Drawing::ContentAlignment::TopCenter;
			this->start->Location = System::Drawing::Point(440, 322);
			this->start->Name = L"start";
			this->start->Size = System::Drawing::Size(55, 30);
			this->start->TabIndex = 0;
			this->start->Text = L"Start";
			this->start->UseVisualStyleBackColor = true;
			this->start->Click += gcnew System::EventHandler(this, &Form1::start_Click);
			// 
			// Panel1
			// 
			this->Panel1->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"Panel1.BackgroundImage")));
			this->Panel1->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
			this->Panel1->Controls->Add(this->DownURL);
			this->Panel1->Location = System::Drawing::Point(12, 96);
			this->Panel1->Name = L"Panel1";
			this->Panel1->Size = System::Drawing::Size(410, 29);
			this->Panel1->TabIndex = 1;
			// 
			// DownURL
			// 
			this->DownURL->BackColor = System::Drawing::SystemColors::InfoText;
			this->DownURL->BorderStyle = System::Windows::Forms::BorderStyle::None;
			this->DownURL->ForeColor = System::Drawing::SystemColors::Info;
			this->DownURL->Location = System::Drawing::Point(11, 8);
			this->DownURL->Name = L"DownURL";
			this->DownURL->Size = System::Drawing::Size(388, 13);
			this->DownURL->TabIndex = 0;
			this->DownURL->Text = L"Enter The Link";
			this->DownURL->TextChanged += gcnew System::EventHandler(this, &Form1::DownURL_TextChanged);
			this->DownURL->Click += gcnew System::EventHandler(this, &Form1::textBox1_Clicked);
			// 
			// Panel2
			// 
			this->Panel2->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"Panel2.BackgroundImage")));
			this->Panel2->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
			this->Panel2->Controls->Add(this->SaveTo);
			this->Panel2->Location = System::Drawing::Point(12, 157);
			this->Panel2->Name = L"Panel2";
			this->Panel2->Size = System::Drawing::Size(410, 29);
			this->Panel2->TabIndex = 2;
			// 
			// SaveTo
			// 
			this->SaveTo->BackColor = System::Drawing::SystemColors::InfoText;
			this->SaveTo->BorderStyle = System::Windows::Forms::BorderStyle::None;
			this->SaveTo->ForeColor = System::Drawing::SystemColors::Info;
			this->SaveTo->Location = System::Drawing::Point(11, 7);
			this->SaveTo->Name = L"SaveTo";
			this->SaveTo->Size = System::Drawing::Size(388, 13);
			this->SaveTo->TabIndex = 0;
			this->SaveTo->Text = L"Save The File To";
			this->SaveTo->TextChanged += gcnew System::EventHandler(this, &Form1::SaveTo_TextChanged);
			this->SaveTo->Click += gcnew System::EventHandler(this, &Form1::textBox2_Clicked);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->BackColor = System::Drawing::SystemColors::ActiveCaptionText;
			this->label1->ForeColor = System::Drawing::SystemColors::Info;
			this->label1->Location = System::Drawing::Point(12, 75);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(158, 26);
			this->label1->TabIndex = 3;
			this->label1->Text = L"The File Address";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->BackColor = System::Drawing::SystemColors::ActiveCaptionText;
			this->label2->ForeColor = System::Drawing::SystemColors::Info;
			this->label2->Location = System::Drawing::Point(12, 140);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(103, 26);
			this->label2->TabIndex = 4;
			this->label2->Text = L"Save File To";
			// 
			// Browes
			// 
			this->Browes->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"Browes.BackgroundImage")));
			this->Browes->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
			this->Browes->FlatStyle = System::Windows::Forms::FlatStyle::Popup;
			this->Browes->ForeColor = System::Drawing::SystemColors::Info;
			this->Browes->ImageAlign = System::Drawing::ContentAlignment::TopCenter;
			this->Browes->Location = System::Drawing::Point(440, 157);
			this->Browes->Name = L"Browes";
			this->Browes->Size = System::Drawing::Size(55, 30);
			this->Browes->TabIndex = 5;
			this->Browes->Text = L"Browse";
			this->Browes->UseVisualStyleBackColor = true;
			this->Browes->Click += gcnew System::EventHandler(this, &Form1::Browes_Click);
			// 
			// errorProvider
			// 
			this->errorProvider->ContainerControl = this;
			// 
			// DownProg
			// 
			this->DownProg->Location = System::Drawing::Point(12, 286);
			this->DownProg->Name = L"DownProg";
			this->DownProg->Size = System::Drawing::Size(410, 23);
			this->DownProg->TabIndex= 6;
			this->DownProg->BackgroundImage=(cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"Panel1.BackgroundImage")));
			// 
			// DownProgress
			// 
			this->DownProgress->AutoSize = true;
			this->DownProgress->BackColor = System::Drawing::SystemColors::ActiveCaptionText;
			this->DownProgress->ForeColor = System::Drawing::SystemColors::Info;
			this->DownProgress->Location = System::Drawing::Point(12, 246);
			this->DownProgress->Name = L"DownProgress";
			this->DownProgress->Size = System::Drawing::Size(191, 26);
			this->DownProgress->TabIndex = 7;
			this->DownProgress->Text = L"Download Progress          :";
			// 
			// TotalRec
			// 
			this->TotalRec->AutoSize = true;
			this->TotalRec->BackColor = System::Drawing::SystemColors::ActiveCaptionText;
			this->TotalRec->ForeColor = System::Drawing::SystemColors::Info;
			this->TotalRec->Location = System::Drawing::Point(12, 220);
			this->TotalRec->Name = L"TotalRec";
			this->TotalRec->Size = System::Drawing::Size(190, 26);
			this->TotalRec->TabIndex = 8;
			this->TotalRec->Text = L"Total Bytes To Receive    :";
			// 
			// BytesRec
			// 
			this->BytesRec->AutoSize = true;
			this->BytesRec->BackColor = System::Drawing::SystemColors::ActiveCaptionText;
			this->BytesRec->ForeColor = System::Drawing::SystemColors::Info;
			this->BytesRec->Location = System::Drawing::Point(12, 194);
			this->BytesRec->Name = L"BytesRec";
			this->BytesRec->Size = System::Drawing::Size(189, 26);
			this->BytesRec->TabIndex = 9;
			this->BytesRec->Text = L"Bytes Received                :";
			// 
			// BytesShow
			// 
			this->BytesShow->AutoSize = true;
			this->BytesShow->BackColor = System::Drawing::SystemColors::ActiveCaptionText;
			this->BytesShow->ForeColor = System::Drawing::SystemColors::Info;
			this->BytesShow->Location = System::Drawing::Point(211, 194);
			this->BytesShow->Name = L"BytesShow";
			this->BytesShow->Size = System::Drawing::Size(19, 26);
			this->BytesShow->TabIndex = 10;
			this->BytesShow->Text = L"0";
			// 
			// TotalShow
			// 
			this->TotalShow->AutoSize = true;
			this->TotalShow->BackColor = System::Drawing::SystemColors::ActiveCaptionText;
			this->TotalShow->ForeColor = System::Drawing::SystemColors::Info;
			this->TotalShow->Location = System::Drawing::Point(211, 220);
			this->TotalShow->Name = L"TotalShow";
			this->TotalShow->Size = System::Drawing::Size(19, 26);
			this->TotalShow->TabIndex = 11;
			this->TotalShow->Text = L"0";
			// 
			// ProgShow
			// 
			this->ProgShow->AutoSize = true;
			this->ProgShow->BackColor = System::Drawing::SystemColors::ActiveCaptionText;
			this->ProgShow->ForeColor = System::Drawing::SystemColors::Info;
			this->ProgShow->Location = System::Drawing::Point(211, 246);
			this->ProgShow->Name = L"ProgShow";
			this->ProgShow->Size = System::Drawing::Size(30, 26);
			this->ProgShow->TabIndex = 12;
			this->ProgShow->Text = L"0%";
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"$this.BackgroundImage")));
			this->ClientSize = System::Drawing::Size(502, 363);
			this->Controls->Add(this->ProgShow);
			this->Controls->Add(this->TotalShow);
			this->Controls->Add(this->BytesShow);
			this->Controls->Add(this->BytesRec);
			this->Controls->Add(this->TotalRec);
			this->Controls->Add(this->DownProgress);
			this->Controls->Add(this->DownProg);
			this->Controls->Add(this->Browes);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->Panel2);
			this->Controls->Add(this->Panel1);
			this->Controls->Add(this->start);
			this->ForeColor = System::Drawing::SystemColors::WindowText;
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedDialog;
			this->HelpButton = true;
			this->MaximizeBox = false;
			this->Name = L"The Internet Downloader";
			this->Text = L"The Internet Downloader With The Fast Copy Feature (New Release)";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			this->Panel1->ResumeLayout(false);
			this->Panel1->PerformLayout();
			this->Closed +=gcnew System::EventHandler(this, &Form1::ProgramExit);
			this->Panel2->ResumeLayout(false);
			this->Panel2->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->errorProvider))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();
			//speechStarter();
		}
#pragma endregion
	private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) {
			 }
private: System::Void ProgramExit(System::Object^  sender, System::EventArgs^  e)
		 {
			 if(inThread)
				thread->Abort();
			 Application::ExitThread();
			 Application::Exit();
		 }
private: System::Void TheStart()
		 {
			 inThread=true;
 			 this->DownURL->Enabled=false;
			 this->SaveTo->Enabled=false;
			 this->start->Enabled=false;
			 this->StartDownload(this->DownURL->Text::get());
		 }
private: System::Void speechStarter()
		 {
			 STSpeech=gcnew System::Threading::ThreadStart(this,&Form1::startSpeech);
			 TSpeech=gcnew System::Threading::Thread(STSpeech);
			 speech=gcnew System::Speech::Synthesis::SpeechSynthesizer();
			 speech->SelectVoice("Microsoft Anna");
			 speech->Volume::set(100);
			 SomethingToSay="Welcome  To  The  Downloader   This  Program  made  by  Yazan  baniyounes";
			 TSpeech->Start();
		 }
private: System::Void startSpeech()
		 {
			 speech->Speak(SomethingToSay);
			 TSpeech->Abort();
		 }
private: System::Void textBox1_Clicked(System::Object^  sender, System::EventArgs^  e) 
		 {
			 if(this->DownURL->Text=="Enter The Link")
				 this->DownURL->Text="";
		 }
private: System::Void textBox2_Clicked(System::Object^  sender, System::EventArgs^  e) 
		 {
			 if(this->SaveTo->Text=="Save The File To")
				 this->SaveTo->Text="";
		 }
private: System::Void Browes_Click(System::Object^  sender, System::EventArgs^  e) 
		 {
			 System::Windows::Forms::DialogResult  dialog;
			 dialog=FolderBrowes->ShowDialog();
			 if(dialog==System::Windows::Forms::DialogResult::OK)
			 {
				 String ^ path=FolderBrowes->SelectedPath::get();
				 if(path[path->Length::get()-1]=='\\')
					this->SaveTo->Text::set(path);
				 else
					 this->SaveTo->Text::set(path+IO::Path::DirectorySeparatorChar);
			 }
		 }
private: System::Void start_Click(System::Object^  sender, System::EventArgs^  e) 
		 {
			this->SThread = (gcnew System::Threading::ThreadStart(this,&Form1::TheStart));
			this->thread = (gcnew System::Threading::Thread(SThread));
			thread->Start();
			//TheStart();
		 }
private: System::Void Check()
		 {
			 if(this->SaveTo->Text!="Save The File To"&&this->DownURL->Text!="Enter The Download Link")
				 this->start->Enabled=true;

		 }
private: System::Void DownURL_TextChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			 Check();
		 }
private: System::Void SaveTo_TextChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			 Check();
		 }
 private: System::Void StartDownload( String ^ address )
		    {
				String ^ To;
				System::Net::WebClient^ client = gcnew System::Net::WebClient;
				try
				{
					Uri ^uri = gcnew Uri(address);
					
					//System::Net::Sockets::
					client->DownloadFileCompleted += gcnew AsyncCompletedEventHandler(this,&Form1::DownloadFileCallback );
					client->DownloadProgressChanged += gcnew DownloadProgressChangedEventHandler(this,&Form1::DownloadProgressCallback );
					if(SaveTo->Text::get()==""||SaveTo->Text::get()=="Save The File To")
					{
						IO::Directory::CreateDirectory("Downloads");
						To="Downloads\\"+IO::Path::GetFileNameWithoutExtension(address)+IO::Path::GetExtension(address);
					}
					else
						To=SaveTo->Text::get()+IO::Path::GetFileNameWithoutExtension(address)+IO::Path::GetExtension(address);
					client->DownloadFileAsync( uri, To );
				}catch(Exception ^ exp)
				{
					this->DownURL->Enabled=true;
					this->start->Enabled=true;
					errorProvider->SetError(Panel1,exp->Message);
				}
		    }
 private: System::Void DownloadProgressCallback(Object^ sender, DownloadProgressChangedEventArgs ^ e)
		{
			this->DownProg->Value=e->ProgressPercentage::get();
			this->BytesShow->Text::set(((double)(e->BytesReceived)).ToString()+" Byte/S");
			this->TotalShow->Text::set(((double)(e->TotalBytesToReceive)).ToString()+" Byte");
			this->ProgShow->Text::set((e->ProgressPercentage).ToString()+" %");
		}
private: System::Void DownloadFileCallback(Object^ sender, AsyncCompletedEventArgs^ e)
		{
			this->DownURL->Enabled=true;
			this->start->Enabled=true;
			this->SaveTo->Enabled=true;
			box->ShowDialog();
			this->DownProg->Value=0;
			this->ProgShow->Text::set("0%");
			this->BytesShow->Text::set("0");
			this->TotalShow->Text::set("0");
	  }
	};
}

