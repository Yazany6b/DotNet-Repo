#pragma once
/*
+-------------------------------------------------------------------------+
|         XX   XX     X     XXXXXX         X       XXXXX     XXX          |
|          XX XX     XXX    XXXXXXX       XXX      XXXXXX    XXX          |
|           XXX     XX XX       XXX      XX XX     XXX XXX   XXX          |
|           XXX    XXX XXX     XXX      XXX XXX    XXX  XXX  XXX          |
|           XXX    XXXXXXX    XXX       XXXXXXX    XXX   XXX XXX          |
|           XXX    XX   XX    XXXXX     XX   XX    XXX    XXXXXX          |
|          XXXXX   XX   XX    XXXXXX    XX   XX    XXX     XXXXX          |
|                                                                         |
|  ALL RIGHTS RESEVED TO YAZAN BANIYOUNES SOFTWEARS I HOPE YOU ENGOIED IT |
+-------------------------------------------------------------------------+                                        
*/
#include "XXX.h"
#include "thum.h"
namespace YazanMideaPlayer {
	using namespace System::Runtime::InteropServices;
	[DllImport("user32")]
	extern "C++" int ShowCursor(bool show);
	public ref class MediaPlayer : public System::Windows::Forms::Form
	{
	public:
		MediaPlayer(void)
		{
			InitializeComponent();
			init();
		}
		MediaPlayer(array<String^>^arr)
		{
			InitializeComponent();
			init();
			Many=true;
			TheFiles=arr;
			count=TheFiles->Length;
			index=1;
			CommandArgsSent();
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~MediaPlayer()
		{
			if (components)
			{
				delete components;
			}
		}







	private: System::Windows::Forms::Button^  Pause;
	private: System::Windows::Forms::Button^  Prev;

	private: System::Windows::Forms::Button^  Stop;
	private: System::Windows::Forms::Button^  Next;
	private: System::Windows::Forms::Button^  Play;
	private: System::Windows::Forms::Panel^  ControlPanel;
	private: System::Windows::Forms::TrackBar^  TrackBar;
	private: System::Windows::Forms::Label^  Position;
	private: System::Windows::Forms::Button^  Full;
	private: System::Windows::Forms::Button^  Open;
	private: System::Windows::Forms::OpenFileDialog^  GetFiles;
	private: System::Windows::Forms::Label^  Unspported;
	private: System::Windows::Forms::Label^  PlayFile;
	private: System::Windows::Forms::Label^  Music;
	private: System::Windows::Forms::GroupBox^  ControlGroup;
	private: System::Windows::Forms::GroupBox^  PlayGroup;
	private: System::Windows::Forms::Panel^  PlayPanel;
	private: System::Windows::Forms::Label^  Program;
	private: System::Windows::Forms::Label^  Contact;
	private: System::Windows::Forms::Label^  Time;
	private: System::Windows::Forms::Panel^  FullPanel;
	private: System::Windows::Forms::TrackBar^  Volume;
	private: System::Windows::Forms::Panel^  panel1;


	private: System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
			 /// <summary>
			 /// Required method for Designer support - do not modify
			 /// the contents of this method with the code editor.
			 /// </summary>
			 void InitializeComponent(void)
			 {
				 System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(MediaPlayer::typeid));
				 this->Music = (gcnew System::Windows::Forms::Label());
				 this->Unspported = (gcnew System::Windows::Forms::Label());
				 this->Prev = (gcnew System::Windows::Forms::Button());
				 this->Next = (gcnew System::Windows::Forms::Button());
				 this->Play = (gcnew System::Windows::Forms::Button());
				 this->Pause = (gcnew System::Windows::Forms::Button());
				 this->Stop = (gcnew System::Windows::Forms::Button());
				 this->ControlPanel = (gcnew System::Windows::Forms::Panel());
				 this->Open = (gcnew System::Windows::Forms::Button());
				 this->Full = (gcnew System::Windows::Forms::Button());
				 this->Position = (gcnew System::Windows::Forms::Label());
				 this->TrackBar = (gcnew System::Windows::Forms::TrackBar());
				 this->PlayFile = (gcnew System::Windows::Forms::Label());
				 this->GetFiles = (gcnew System::Windows::Forms::OpenFileDialog());
				 this->ControlGroup = (gcnew System::Windows::Forms::GroupBox());
				 this->panel1 = (gcnew System::Windows::Forms::Panel());
				 this->PlayGroup = (gcnew System::Windows::Forms::GroupBox());
				 this->PlayPanel = (gcnew System::Windows::Forms::Panel());
				 this->Contact = (gcnew System::Windows::Forms::Label());
				 this->Program = (gcnew System::Windows::Forms::Label());
				 this->Time = (gcnew System::Windows::Forms::Label());
				 this->FullPanel = (gcnew System::Windows::Forms::Panel());
				 this->Volume = (gcnew System::Windows::Forms::TrackBar());
				 this->ControlPanel->SuspendLayout();
				 (cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->TrackBar))->BeginInit();
				 this->ControlGroup->SuspendLayout();
				 this->PlayGroup->SuspendLayout();
				 this->PlayPanel->SuspendLayout();
				 (cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->Volume))->BeginInit();
				 this->SuspendLayout();
				 // 
				 // Music
				 // 
				 this->Music->AutoSize = true;
				 this->Music->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 27.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
					 static_cast<System::Byte>(0)));
				 this->Music->ForeColor = System::Drawing::Color::Green;
				 this->Music->Location = System::Drawing::Point(234, 136);
				 this->Music->Name = L"Music";
				 this->Music->Size = System::Drawing::Size(116, 42);
				 this->Music->TabIndex = 1;
				 this->Music->Text = L"Music";
				 this->Music->Visible = false;
				 this->Music->Click += gcnew System::EventHandler(this, &MediaPlayer::Music_Click);
				 // 
				 // Unspported
				 // 
				 this->Unspported->AutoSize = true;
				 this->Unspported->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 27.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
					 static_cast<System::Byte>(0)));
				 this->Unspported->ForeColor = System::Drawing::Color::Green;
				 this->Unspported->Location = System::Drawing::Point(168, 136);
				 this->Unspported->Name = L"Unspported";
				 this->Unspported->Size = System::Drawing::Size(212, 42);
				 this->Unspported->TabIndex = 0;
				 this->Unspported->Text = L"Unspported";
				 this->Unspported->Visible = false;
				 this->Unspported->Click += gcnew System::EventHandler(this, &MediaPlayer::Unspported_Click);
				 // 
				 // Prev
				 // 
				 this->Prev->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Zoom;
				 this->Prev->Enabled = false;
				 this->Prev->Location = System::Drawing::Point(334, 25);
				 this->Prev->Name = L"Prev";
				 this->Prev->Size = System::Drawing::Size(75, 23);
				 this->Prev->TabIndex = 7;
				 this->Prev->Text = L"<<";
				 this->Prev->UseVisualStyleBackColor = true;
				 this->Prev->Click += gcnew System::EventHandler(this, &MediaPlayer::Prev_Click);
				 // 
				 // Next
				 // 
				 this->Next->Enabled = false;
				 this->Next->Location = System::Drawing::Point(435, 25);
				 this->Next->Name = L"Next";
				 this->Next->Size = System::Drawing::Size(75, 23);
				 this->Next->TabIndex = 6;
				 this->Next->Text = L">>";
				 this->Next->UseVisualStyleBackColor = true;
				 this->Next->Click += gcnew System::EventHandler(this, &MediaPlayer::Next_Click);
				 // 
				 // Play
				 // 
				 this->Play->Enabled = false;
				 this->Play->FlatStyle = System::Windows::Forms::FlatStyle::System;
				 this->Play->ForeColor = System::Drawing::Color::Fuchsia;
				 this->Play->ImageKey = L"(none)";
				 this->Play->Location = System::Drawing::Point(21, 25);
				 this->Play->Name = L"Play";
				 this->Play->Size = System::Drawing::Size(75, 23);
				 this->Play->TabIndex = 8;
				 this->Play->Text = L"Play";
				 this->Play->UseVisualStyleBackColor = true;
				 this->Play->Click += gcnew System::EventHandler(this, &MediaPlayer::Play_Click);
				 // 
				 // Pause
				 // 
				 this->Pause->Enabled = false;
				 this->Pause->Location = System::Drawing::Point(114, 25);
				 this->Pause->Name = L"Pause";
				 this->Pause->Size = System::Drawing::Size(75, 23);
				 this->Pause->TabIndex = 4;
				 this->Pause->Text = L"Pause";
				 this->Pause->UseVisualStyleBackColor = true;
				 this->Pause->Click += gcnew System::EventHandler(this, &MediaPlayer::Pause_Click);
				 // 
				 // Stop
				 // 
				 this->Stop->Enabled = false;
				 this->Stop->Location = System::Drawing::Point(219, 25);
				 this->Stop->Name = L"Stop";
				 this->Stop->RightToLeft = System::Windows::Forms::RightToLeft::No;
				 this->Stop->Size = System::Drawing::Size(75, 23);
				 this->Stop->TabIndex = 5;
				 this->Stop->Text = L"Stop";
				 this->Stop->UseVisualStyleBackColor = true;
				 this->Stop->Click += gcnew System::EventHandler(this, &MediaPlayer::Stop_Click);
				 // 
				 // ControlPanel
				 // 
				 this->ControlPanel->BackColor = System::Drawing::Color::OrangeRed;
				 this->ControlPanel->Controls->Add(this->Open);
				 this->ControlPanel->Controls->Add(this->Full);
				 this->ControlPanel->Controls->Add(this->Position);
				 this->ControlPanel->Controls->Add(this->Prev);
				 this->ControlPanel->Controls->Add(this->Play);
				 this->ControlPanel->Controls->Add(this->Next);
				 this->ControlPanel->Controls->Add(this->Pause);
				 this->ControlPanel->Controls->Add(this->Stop);
				 this->ControlPanel->Controls->Add(this->TrackBar);
				 this->ControlPanel->ForeColor = System::Drawing::Color::Black;
				 this->ControlPanel->Location = System::Drawing::Point(6, 13);
				 this->ControlPanel->Name = L"ControlPanel";
				 this->ControlPanel->Size = System::Drawing::Size(654, 73);
				 this->ControlPanel->TabIndex = 0;
				 // 
				 // Open
				 // 
				 this->Open->Location = System::Drawing::Point(537, 25);
				 this->Open->Name = L"Open";
				 this->Open->Size = System::Drawing::Size(75, 23);
				 this->Open->TabIndex = 11;
				 this->Open->Text = L"Open";
				 this->Open->UseVisualStyleBackColor = true;
				 this->Open->Click += gcnew System::EventHandler(this, &MediaPlayer::Open_Click);
				 // 
				 // Full
				 // 
				 this->Full->Enabled = false;
				 this->Full->Location = System::Drawing::Point(629, 38);
				 this->Full->Name = L"Full";
				 this->Full->Size = System::Drawing::Size(25, 23);
				 this->Full->TabIndex = 10;
				 this->Full->Text = L"F";
				 this->Full->UseVisualStyleBackColor = true;
				 this->Full->Click += gcnew System::EventHandler(this, &MediaPlayer::Full_Click);
				 // 
				 // Position
				 // 
				 this->Position->AutoSize = true;
				 this->Position->BackColor = System::Drawing::Color::Transparent;
				 this->Position->ForeColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(0)), static_cast<System::Int32>(static_cast<System::Byte>(64)), 
					 static_cast<System::Int32>(static_cast<System::Byte>(0)));
				 this->Position->Location = System::Drawing::Point(599, 2);
				 this->Position->Name = L"Position";
				 this->Position->Size = System::Drawing::Size(35, 13);
				 this->Position->TabIndex = 9;
				 this->Position->Text = L"00:00";
				 // 
				 // TrackBar
				 // 
				 this->TrackBar->AutoSize = false;
				 this->TrackBar->Enabled = false;
				 this->TrackBar->LargeChange = 0;
				 this->TrackBar->Location = System::Drawing::Point(3, 0);
				 this->TrackBar->Maximum = 100;
				 this->TrackBar->Name = L"TrackBar";
				 this->TrackBar->Size = System::Drawing::Size(599, 19);
				 this->TrackBar->TabIndex = 2;
				 this->TrackBar->TickFrequency = 100;
				 this->TrackBar->TickStyle = System::Windows::Forms::TickStyle::None;
				 // 
				 // PlayFile
				 // 
				 this->PlayFile->AutoSize = true;
				 this->PlayFile->ForeColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(0)), static_cast<System::Int32>(static_cast<System::Byte>(64)), 
					 static_cast<System::Int32>(static_cast<System::Byte>(0)));
				 this->PlayFile->Location = System::Drawing::Point(11, 9);
				 this->PlayFile->Name = L"PlayFile";
				 this->PlayFile->Size = System::Drawing::Size(41, 13);
				 this->PlayFile->TabIndex = 12;
				 this->PlayFile->Text = L"Playing";
				 // 
				 // GetFiles
				 // 
				 this->GetFiles->Multiselect = true;
				 this->GetFiles->Title = L"Choose Media Files";
				 // 
				 // ControlGroup
				 // 
				 this->ControlGroup->Controls->Add(this->ControlPanel);
				 this->ControlGroup->Controls->Add(this->panel1);
				 this->ControlGroup->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
				 this->ControlGroup->ForeColor = System::Drawing::SystemColors::ButtonHighlight;
				 this->ControlGroup->Location = System::Drawing::Point(8, 384);
				 this->ControlGroup->Name = L"ControlGroup";
				 this->ControlGroup->Size = System::Drawing::Size(666, 90);
				 this->ControlGroup->TabIndex = 1;
				 this->ControlGroup->TabStop = false;
				 this->ControlGroup->SizeChanged += gcnew System::EventHandler(this, &MediaPlayer::ControlGroup_SizeChanged);
				 // 
				 // panel1
				 // 
				 this->panel1->BackColor = System::Drawing::Color::OrangeRed;
				 this->panel1->ForeColor = System::Drawing::Color::Black;
				 this->panel1->Location = System::Drawing::Point(6, 11);
				 this->panel1->Name = L"panel1";
				 this->panel1->Size = System::Drawing::Size(654, 73);
				 this->panel1->TabIndex = 12;
				 // 
				 // PlayGroup
				 // 
				 this->PlayGroup->Controls->Add(this->PlayPanel);
				 this->PlayGroup->Location = System::Drawing::Point(8, 38);
				 this->PlayGroup->Name = L"PlayGroup";
				 this->PlayGroup->Size = System::Drawing::Size(666, 340);
				 this->PlayGroup->TabIndex = 2;
				 this->PlayGroup->TabStop = false;
				 // 
				 // PlayPanel
				 // 
				 this->PlayPanel->AllowDrop = true;
				 this->PlayPanel->BackColor = System::Drawing::Color::OrangeRed;
				 this->PlayPanel->Controls->Add(this->Contact);
				 this->PlayPanel->Controls->Add(this->Program);
				 this->PlayPanel->Controls->Add(this->Music);
				 this->PlayPanel->Controls->Add(this->Unspported);
				 this->PlayPanel->Location = System::Drawing::Point(6, 13);
				 this->PlayPanel->Name = L"PlayPanel";
				 this->PlayPanel->Size = System::Drawing::Size(654, 321);
				 this->PlayPanel->TabIndex = 0;
				 this->PlayPanel->DoubleClick += gcnew System::EventHandler(this, &MediaPlayer::PlayPanel_DoubleClick);
				 this->PlayPanel->DragDrop += gcnew System::Windows::Forms::DragEventHandler(this, &MediaPlayer::PlayPanel_DragDrop);
				 this->PlayPanel->DragEnter += gcnew System::Windows::Forms::DragEventHandler(this, &MediaPlayer::PlayPanel_DragEnter);
				 // 
				 // Contact
				 // 
				 this->Contact->AutoSize = true;
				 this->Contact->BackColor = System::Drawing::Color::Transparent;
				 this->Contact->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 13));
				 this->Contact->ForeColor = System::Drawing::Color::Black;
				 this->Contact->Location = System::Drawing::Point(147, 136);
				 this->Contact->Name = L"Contact";
				 this->Contact->Size = System::Drawing::Size(356, 44);
				 this->Contact->TabIndex = 3;
				 this->Contact->Text = L"This program  made  by yazan baniyounes\r\nyou can contact as at yazanse@yahoo.com";
				 this->Contact->Visible = false;
				 this->Contact->Click += gcnew System::EventHandler(this, &MediaPlayer::Contact_Click);
				 // 
				 // Program
				 // 
				 this->Program->AutoSize = true;
				 this->Program->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 27.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
					 static_cast<System::Byte>(0)));
				 this->Program->ForeColor = System::Drawing::Color::Crimson;
				 this->Program->Location = System::Drawing::Point(144, 136);
				 this->Program->Name = L"Program";
				 this->Program->Size = System::Drawing::Size(241, 42);
				 this->Program->TabIndex = 2;
				 this->Program->Text = L"Yazan Player";
				 this->Program->Click += gcnew System::EventHandler(this, &MediaPlayer::Program_Click);
				 // 
				 // Time
				 // 
				 this->Time->AutoSize = true;
				 this->Time->ForeColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(0)), static_cast<System::Int32>(static_cast<System::Byte>(64)), 
					 static_cast<System::Int32>(static_cast<System::Byte>(0)));
				 this->Time->Location = System::Drawing::Point(12, 22);
				 this->Time->Name = L"Time";
				 this->Time->Size = System::Drawing::Size(29, 13);
				 this->Time->TabIndex = 13;
				 this->Time->Text = L"Time";
				 // 
				 // FullPanel
				 // 
				 this->FullPanel->Location = System::Drawing::Point(664, 9);
				 this->FullPanel->Name = L"FullPanel";
				 this->FullPanel->Size = System::Drawing::Size(10, 20);
				 this->FullPanel->TabIndex = 14;
				 // 
				 // Volume
				 // 
				 this->Volume->AutoSize = false;
				 this->Volume->LargeChange = 0;
				 this->Volume->Location = System::Drawing::Point(505, 10);
				 this->Volume->Maximum = 100;
				 this->Volume->Name = L"Volume";
				 this->Volume->Size = System::Drawing::Size(141, 19);
				 this->Volume->TabIndex = 12;
				 this->Volume->TickFrequency = 100;
				 this->Volume->TickStyle = System::Windows::Forms::TickStyle::None;
				 this->Volume->Value = 100;
				 this->Volume->Visible = false;
				 this->Volume->ValueChanged += gcnew System::EventHandler(this, &MediaPlayer::Volume_ValueChanged);
				 // 
				 // MediaPlayer
				 // 
				 this->AllowDrop = true;
				 this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::None;
				 this->BackColor = System::Drawing::Color::Black;
				 this->ClientSize = System::Drawing::Size(682, 496);
				 this->Controls->Add(this->Volume);
				 this->Controls->Add(this->FullPanel);
				 this->Controls->Add(this->Time);
				 this->Controls->Add(this->PlayFile);
				 this->Controls->Add(this->PlayGroup);
				 this->Controls->Add(this->ControlGroup);
				 this->Icon = (cli::safe_cast<System::Drawing::Icon^  >(resources->GetObject(L"$this.Icon")));
				 this->MinimumSize = System::Drawing::Size(450, 450);
				 this->Name = L"MediaPlayer";
				 this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
				 this->Text = L"MediaPlayer";
				 this->Load += gcnew System::EventHandler(this, &MediaPlayer::MediaPlayer_Load);
				 this->DragDrop += gcnew System::Windows::Forms::DragEventHandler(this, &MediaPlayer::PlayPanel_DragDrop);
				 this->ControlPanel->ResumeLayout(false);
				 this->ControlPanel->PerformLayout();
				 (cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->TrackBar))->EndInit();
				 this->ControlGroup->ResumeLayout(false);
				 this->PlayGroup->ResumeLayout(false);
				 this->PlayPanel->ResumeLayout(false);
				 this->PlayPanel->PerformLayout();
				 (cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->Volume))->EndInit();
				 this->ResumeLayout(false);
				 this->PerformLayout();

			 }
#pragma endregion
			 bool paused;
			 bool Many;
			 bool isStop;
			 bool isVideo;
			 bool Maxi;
			 bool isFull;
			 FullScreenStaff::clientRect restore;
			 array<String^>^TheFiles;
			 int count;
			 int index;
			 String^ file;
			 void init()
			 {
				 glass(this->Handle);
				 timer = gcnew System::Threading::Timer(gcnew System::Threading::TimerCallback(this,&MediaPlayer::HideAfter3Seconds),nullptr,-1,7000);;
				 this->Music->Location=System::Drawing::Point((PlayPanel->Size.Width/2)-(Music->Size.Width/2)+3,(PlayPanel->Size.Height/2)-24);
				 this->Program->Location=System::Drawing::Point((PlayPanel->Size.Width/2)-(Program->Size.Width/2)+3,(PlayPanel->Size.Height/2)-24);
				 this->Unspported->Location=System::Drawing::Point((PlayPanel->Size.Width/2)-(Unspported->Size.Width/2)+3,(PlayPanel->Size.Height/2)-24);
				 this->Contact->Location=System::Drawing::Point((PlayPanel->Size.Width/2)-(Contact->Size.Width/2)+3,(PlayPanel->Size.Height/2)-24);
				 paused=false;
				 isVideo=false;
				 isStop=false;
				 isFull=false;
				 Maxi=false;
				 FullPanel->DoubleClick+=gcnew System::EventHandler(this,&MediaPlayer::PlayPanel_DoubleClick);
				 this->SizeChanged+=gcnew EventHandler(this,&MediaPlayer::FSized);
				 TrackBar->Scroll+=gcnew EventHandler(this,&MediaPlayer::BarScrolled);
				 //TrackBar->MouseClick+=gcnew MouseEventHandler(this,&MediaPlayer::BarScrolled);
				 this->Closed+=gcnew EventHandler(this,&MediaPlayer::FClosed);	
				 index=0;
				 GetFiles->FileOk+=gcnew System::ComponentModel::CancelEventHandler(this,&MediaPlayer::OpenOkClicked);
				 GetFiles->Filter=L"Audio Files(*.Mp3;*.Acc;*.Amr;*.Wav)|*.Mp3;*.Acc;*.Amr;*.Wav|"+
					 "Video Files(*.Mp4;*.Avi;*.Mov;*.Vob;*.3Gp;*.Flv;*.Wmv;*.rmvb)|*.Mp4;*.Avi;*.Mov;*.Vob;*.3Gp;*.Flv;*.Wmv;*.rmvb|All files (*.*)|*.*";
				 MadeRegion();
				 KeyPressing();
			 }
			 void MyTimer(Object^ x)
			 {

			 }
			 void MadeRegion()
			 {
				 //System::Threading::Timer ^ v = gcnew System::Threading::Timer(gcnew System::Threading::TimerCallback(this,&MediaPlayer::MyTimer));
				 
				 System::Drawing::Drawing2D::GraphicsPath ^ path=gcnew System::Drawing::Drawing2D::GraphicsPath();
				 path->AddEllipse(2,2,45,45);

				 Play->Size=System::Drawing::Size(50,50);
				 this->Play->Region::set(gcnew System::Drawing::Region(path));

				 Stop->Size=System::Drawing::Size(50,50);
				 this->Stop->Region::set(gcnew System::Drawing::Region(path));

				 Pause->Size=System::Drawing::Size(50,50);
				 this->Pause->Region::set(gcnew System::Drawing::Region(path));

				 Next->Size=System::Drawing::Size(50,50);
				 this->Next->Region::set(gcnew System::Drawing::Region(path));

				 Prev->Size=System::Drawing::Size(50,50);
				 this->Prev->Region::set(gcnew System::Drawing::Region(path));

				 Open->Size=System::Drawing::Size(50,50);
				 this->Open->Region::set(gcnew System::Drawing::Region(path));
			 }
			 void KeyPressing()
			 {
				 this->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->ControlPanel->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->Play->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->PlayPanel->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->FullPanel->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->Stop->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->Pause->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->Next->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->Prev->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->TrackBar->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->ControlGroup->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->PlayGroup->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->Full->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->PlayFile->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->Time->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->Position->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->Open->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->Music->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->Unspported->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->Contact->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
				 this->Program->KeyPress+=gcnew KeyPressEventHandler(this,&MediaPlayer::KeyIsPressed);
			 }
			 void KeyIsPressed(Object^,KeyPressEventArgs^e)
			 {
				 switch((int)e->KeyChar)
				 {
				 case Keys::Escape :
					 if(isFull)
						 Full_Click(nullptr,nullptr);
					 break;
				 case Keys::F: case ((int)Keys::F + 32):
					 if(!isFull)
						 Full_Click(nullptr,nullptr);
					 break;
				 case Keys::O :case ((int)Keys::O + 32):
					 Open_Click(nullptr,nullptr);
					 break;
				 case Keys::P : case ((int)Keys::P + 32): case Keys::Space: 
					 if(Play->Enabled)
						 Play_Click(nullptr,nullptr);
					 else
						 if(Pause->Enabled)
							 Pause_Click(nullptr,nullptr);
					 break;
				 case Keys::S : case ((int)Keys::S + 32):
					 if(Stop->Enabled)
						 Stop_Click(nullptr,nullptr);
					 break;
				 case Keys::N : case ((int)Keys::N + 32):
					 if(Next->Enabled)
						 Next_Click(nullptr,nullptr);
					 break;
				 case Keys::B : case ((int)Keys::B + 32):
					 if(Prev->Enabled)
						 Prev_Click(nullptr,nullptr);
					 break;
					 /*
					 case Keys::Add :
					 if(!Play->Enabled&&Pause->Enabled)
					 TrackBar->Value=TrackBar->Value+4;
					 break;
					 case Keys::Subtract :
					 if(!Play->Enabled&&Pause->Enabled)
					 TrackBar->Value=TrackBar->Value-4;
					 break;
					 */
				 }
			 }
			 void FSized(Object^,EventArgs^)
			 {

				 if(this->Size.Height>220)
				 {
					 this->PlayGroup->Size=Drawing::Size(this->Size.Width-33,this->Size.Height-194);
					 this->PlayPanel->Size=Drawing::Size(this->PlayGroup->Size.Width-14,this->PlayGroup->Size.Height-20);
					 this->ControlPanel->Update();
					 this->ControlGroup->Location=System::Drawing::Point(PlayGroup->Location.X,PlayGroup->Size.Height+45);
					 this->ControlGroup->Size=Drawing::Size(this->Size.Width-33,100);
					 this->ControlPanel->Location=System::Drawing::Point(((ControlGroup->Size.Width-(ControlGroup->Size.Width/2))-(ControlPanel->Size.Width/2)),11);
					 this->Music->Location=System::Drawing::Point((PlayPanel->Size.Width/2)-(Music->Size.Width/2)+3,(PlayPanel->Size.Height/2)-24);
					 this->Program->Location=System::Drawing::Point((PlayPanel->Size.Width/2)-(Program->Size.Width/2)+3,(PlayPanel->Size.Height/2)-24);
					 this->Unspported->Location=System::Drawing::Point((PlayPanel->Size.Width/2)-(Unspported->Size.Width/2)+3,(PlayPanel->Size.Height/2)-24);
					 this->Contact->Location=System::Drawing::Point((PlayPanel->Size.Width/2)-(Contact->Size.Width/2)+3,(PlayPanel->Size.Height/2)-24);
				 }else
				 {
					 //	MessageBox::Show("");
					 if(this->WindowState==System::Windows::Forms::FormWindowState::Normal)
						 this->Size=Drawing::Size(this->Size.Width,220);
				 }
				 this->ControlPanel->Update();
				 this->ControlPanel->Visible=false;
				 this->ControlPanel->Visible=true;
			 }
			 void OpenOkClicked (Object^,System::ComponentModel::CancelEventArgs^)
			 {
				 if(GetFiles->Multiselect)
				 {
					 TheFiles=GetFiles->FileNames;
					 count=TheFiles->Length;
					 index=1;
					 file=TheFiles[index-1];
					 if(tBar!=nullptr)
						 Stop_Click(nullptr,nullptr);
					 this->Play->Enabled=true;
					 if(count>1)
						 this->Next->Enabled=true;
					 else
						 this->Next->Enabled=false;
					 Play_Click(nullptr,nullptr);
				 }else
				 {
					 if(1)
					 {
						 file=GetFiles->FileName;
						 count=1;
						 index=1;
						 Stop_Click(nullptr,nullptr);
						 this->Play->Enabled=true;
						 this->Next->Enabled=false;
						 Play_Click(nullptr,nullptr);
					 }
				 }
			 }
			 void FClosed(Object^,EventArgs^)
			 {
				 if(tBar!=nullptr)
				 {
					 if(isVideo)
					 {
						 if(video->Playing)
							 tBar->Abort();
					 }else
						 if(audio->Playing)
							 tBar->Abort();
				 }
				 Application::ExitThread();
				 Application::Exit();
			 }
			 void CommandArgsSent()
			 {
				 if(TheFiles->Length>1)
				 {
					 this->Next->Enabled=true;
				 }
				 file=TheFiles[0];
				 this->Program->Visible=false;
				 this->Play->Enabled=true;
				 Play_Click(nullptr,nullptr);
			 }
			 void BarScrolled(Object^,EventArgs^e)
			 {
				 if(isVideo)
				 {
					 if(video->Playing)
						 video->CurrentPosition=TrackBar->Value;
				 }else
				 {
					 if(audio->Playing)
						 audio->CurrentPosition=TrackBar->Value;
				 }
			 }
	private: System::Void MediaPlayer_Load(System::Object^  sender, System::EventArgs^  e) {
			 }
			 ::Microsoft::DirectX::AudioVideoPlayback::Audio ^ audio;
			 ::Microsoft::DirectX::AudioVideoPlayback::Video ^ video;
			 System::Threading::Thread ^ tBar;
	private: System::Void Play_Click(System::Object^  sender, System::EventArgs^  e) 
			 {
				 isStop=false;
				 switch(isSupported(file))
				 {
				 case Supported::Video:
					 this->Full->Enabled=true;
					 PlayPanel->DoubleClick+=gcnew System::EventHandler(this,&MediaPlayer::Panel_Double_Click);
					 FullPanel->DoubleClick+=gcnew System::EventHandler(this,&MediaPlayer::Panel_Double_Click);
					 PlayFile->Text=IO::Path::GetFileName(file);
					 //this->PlayPanel->BackColor = System::Drawing::Color::MediumBlue;
					 if(!paused)
					 {
						 video=::Microsoft::DirectX::AudioVideoPlayback::Video::FromFile(file);
						 video->Ending+=gcnew EventHandler(this,&MediaPlayer::MediaEnd);
						 if(!isFull)
						 {
							 Drawing::Size x=this->PlayPanel->Size;
							 video->Owner::set(this->PlayPanel);
							 this->PlayPanel->Size=x;
						 }
						 else
						 {
							 Drawing::Size x=this->FullPanel->Size;
							 video->Owner::set(this->FullPanel);
							 this->FullPanel->Size=x;
							 video->Size=x;
						 }
						 TrackBar->Maximum=(int)video->Duration;
						 Time->Text=TimeInMinutes((int)video->Duration);
						 tBar=gcnew System::Threading::Thread(gcnew System::Threading::ThreadStart(this,&MediaPlayer::TrackBarMove));
						 try
						 {
							 video->Play();
						 }catch(Exception^e)
						 {
							 MessageBox::Show(e->Message,"Error",MessageBoxButtons::OK,MessageBoxIcon::Error);
						 }
					 }else
					 {
						 video->Play();
						 Play->Enabled=false;
						 Pause->Enabled=true;
						 this->Full->Enabled=true;
						 paused=false;
						 tBar=gcnew System::Threading::Thread(gcnew System::Threading::ThreadStart(this,&MediaPlayer::TrackBarMove));
					 }
					 isVideo=true;
					 break;
				 case Supported::Audio:
					 PlayFile->Text=IO::Path::GetFileName(file);
					 Unspported->Visible=false;
					 this->Full->Enabled=false;
					 Program->Visible=false;
					 Contact->Visible=false;
					 Music->Visible=true;
					 //this->PlayPanel->BackColor = System::Drawing::Color::MediumBlue;
					 this->Full->Enabled=false;
						

					 if(!paused)
					 {

						 audio=::Microsoft::DirectX::AudioVideoPlayback::Audio::FromFile(file);
						 audio->Ending+=gcnew EventHandler(this,&MediaPlayer::MediaEnd);
						 Drawing::Size x=this->PlayPanel->Size;
						 this->PlayPanel->Size=x;
						 TrackBar->Maximum=(int)audio->Duration;
						 Time->Text=TimeInMinutes((int)audio->Duration);
						 tBar=gcnew System::Threading::Thread(gcnew System::Threading::ThreadStart(this,&MediaPlayer::TrackBarMove));
						 try
						 {
							 audio->Play();
						 }catch(Exception^e)
						 {
							 MessageBox::Show(e->Message,"Error",MessageBoxButtons::OK,MessageBoxIcon::Error);
						 }
					 }else
					 {
						 audio->Play();
						 Play->Enabled=false;
						 Pause->Enabled=true;
						 paused=false;
						 tBar=gcnew System::Threading::Thread(gcnew System::Threading::ThreadStart(this,&MediaPlayer::TrackBarMove));
					 }
					 isVideo=false;
					 break;
				 case Supported::Other:
					 PlayFile->Text=IO::Path::GetFileName(file);
					 this->Full->Enabled=false;
					 this->Play->Enabled=false;
					 this->Stop->Enabled=false;
					 this->Pause->Enabled=false;
					 this->TrackBar->Enabled=false;
					 Unspported->Visible=true;
					 Contact->Visible=false;
					 Program->Visible=false;
					 Music->Visible=false;
					 return;
				 }
				 if(tBar!=nullptr)
				 {
					 Unspported->Visible=false;
					 Play->Enabled=false;
					 Pause->Enabled=true;
					 Stop->Enabled=true;
					 TrackBar->Enabled=true;
					 //Full->Enabled=true;
					 PlayPanel->Update();
					 tBar->Start();
					 //Full->Enabled=false;
				 }
			 }
			 void MediaEnd(Object^,EventArgs^)
			 {
				 tBar->Abort();
				 TrackBar->Value=0;
				 Position->Text="00:00";
				 paused=false;
				 Pause->Enabled=false;
				 Stop->Enabled=false;
				 TrackBar->Enabled=false;
				 //Full->Enabled=false;
				 Play->Enabled=true;
				 PlayPanel->Update();
				 if(!isStop&&Next->Enabled)
					 Next_Click(nullptr,nullptr);
			 }
			 void TrackBarMove()
			 {
				 if(isVideo)
				 {
					 while(video->Playing)
					 {
						 TrackBar->Value=(int)video->CurrentPosition;
						 Position->Text=TimeInMinutes(TrackBar->Value);
					 }
				 }else
				 {
					 while(audio->Playing)
					 {
						 TrackBar->Value=(int)audio->CurrentPosition;
						 Position->Text=TimeInMinutes(TrackBar->Value);
					 }
				 }
			 }
			 String ^ TimeInMinutes(int second)
			 {
				 int m=0;
				 int h=0;
				 String^ss,^sm,^sh;
				 if(second<=60)
				 {
					 if(second>9)
						 return "00:"+second.ToString();
					 else
						 return "00:0"+second.ToString();
				 }else
				 {
					 while(1)
					 {
						 if(second>60)
						 {
							 m++;
							 second-=60;
						 }else
							 break;
					 }
					 if(m>60)
					 {
						 while(1)
						 {
							 h++;
							 m-=60;
						 }
						 if(h>9)
							 sh=h.ToString();
						 else
							 sh="0"+h.ToString();
						 if(m>9)
							 sm=m.ToString();
						 else
							 sm="0"+m.ToString();
						 if(second>9)
							 ss=second.ToString();
						 else
							 ss="0"+second.ToString();
						 return sh+":"+sm+":"+ss;
					 }else
					 {
						 if(m>9)
							 sm=m.ToString();
						 else
							 sm="0"+m.ToString();
						 if(second>9)
							 ss=second.ToString();
						 else
							 ss="0"+second.ToString();
						 return sm+":"+ss;
					 }
				 }
				 return "XXX";
			 }
	private: System::Void Pause_Click(System::Object^  sender, System::EventArgs^  e) 
			 {
				 isStop=false;
				 Play->Enabled=true;
				 tBar->Abort();
				 tBar=nullptr;
				 if(isVideo)
					 video->Pause();
				 else
					 audio->Pause();
				 Pause->Enabled=false;
				 paused=true;
			 }
	private: System::Void Stop_Click(System::Object^  sender, System::EventArgs^  e) 
			 {
				 isStop=true;
				 if(isVideo)
					 video->Stop();
				 else
					 audio->Stop();
				 MediaEnd(nullptr,nullptr);
			 }
			 System::Drawing::Point cursorPoint;
	private: System::Void Full_Click(System::Object^  sender, System::EventArgs^  e) 
			 {
				 if(isVideo)
				 {
					 if(!isFull)
					 {
						 timer->Change(3000,7000);
						 cursorPoint = this->FullPanel->Cursor->Position;
						 PlayPanel->Visible=false;
						 this->FullPanel->Visible=true;
						 this->restore.WLoc = this->Location;
						 this->restore.WSize=this->Size;
						 this->restore.PLoc=this->ControlPanel->Location;
						 this->restore.x = this->Width;
						 this->restore.y = this->Height;
						 this->TopMost = true;
						 this->FullPanel->Location=System::Drawing::Point(0,10);
						 this->Location = System::Drawing::Point(0,0);
						 this->FormBorderStyle = Windows::Forms::FormBorderStyle::None;                              
						 this->Width = Screen::PrimaryScreen->Bounds.Width;
						 this->Height = Screen::PrimaryScreen->Bounds.Height;
						 video->Owner=this->FullPanel;
						 hidden = false;
						 this->FullPanel->MouseMove += gcnew System::Windows::Forms::MouseEventHandler(this,&MediaPlayer::MouseMovedOverFullPanel);
						 this->ControlGroup->Visible=false;
						 this->FullPanel->Size=System::Drawing::Size(this->Width,this->Height/*-83*/);
						 this->ControlPanel->Location=System::Drawing::Point((this->Size.Width/2)-(this->Size.Width/4),this->Size.Height-73);
						 this->FullPanel->Controls->Add(this->ControlPanel);
						 this->PlayFile->Location=System::Drawing::Point((this->Size.Width/2)-(this->Size.Width/4)+ControlPanel->Size.Width+20,this->Size.Height-73);
						 this->Time->Location=System::Drawing::Point((this->Size.Width/2)-(this->Size.Width/4)+ControlPanel->Size.Width+20,this->Size.Height-60);
						 this->video->Size.Width=this->Size.Width;
						 this->video->Size.Height=this->Size.Height/*-83*/;
						 this->FullPanel->Visible=true;
						 glass(this->Handle,0);
						 isFull=true;
					 }else
					 {
						 timer->Change(-1,0);
						 PlayPanel->Visible=true;
						 this->Time->Location = System::Drawing::Point(12, 22);
						 this->PlayFile->Location = System::Drawing::Point(12, 9);
						 this->Location=this->restore.WLoc;
						 this->Width=this->restore.x;
						 this->ControlPanel->Location=this->restore.PLoc;
						 this->Controls->Remove(this->ControlPanel);
						 this->ControlGroup->Controls->Clear();
						 this->ControlGroup->Controls->Add(this->ControlPanel);
						 this->ControlGroup->Controls->Add(this->panel1);
						 this->Height=this->restore.y;
						 this->ControlGroup->Visible=true;
						 this->Size=this->restore.WSize;
						 video->Owner=this->PlayPanel;
						 video->Size=PlayPanel->Size;
						 this->TopMost = false;                                
						 this->FormBorderStyle = Windows::Forms::FormBorderStyle::Sizable; 
						 isFull=false;
						 this->FullPanel->Visible=false;
						 glass(this->Handle,-1);
					 }
				 }
			 } 
			 void HideAfter3Seconds(Object^)
			 {
							 cursorPoint = this->FullPanel->Cursor->Position;
							 this->FullPanel->Cursor->Position = System::Drawing::Point(this->Width,0);
							 hidden = true;
							 timer->Change(-1,7000);
			 }
			 System::Threading::Timer ^ timer;
			 bool hidden;
	private: void MouseMovedOverFullPanel(System::Object^,System::Windows::Forms::MouseEventArgs^e)
			 {
				 if(hidden)
				 {
					 hidden = false;
					 this->FullPanel->Cursor->Position = cursorPoint;
				 }
				 if((e->Y > (this->FullPanel->Height - 100)) && (e->X > this->ControlPanel->Location.X-30 && e->X < this->ControlPanel->Location.X+this->ControlPanel->Width+20))
				 {
					 this->ControlPanel->Visible = true;
				 }else
					 this->ControlPanel->Visible = false;
				 timer->Change(3000,7000);
			 }
	private: System::Void Prev_Click(System::Object^  sender, System::EventArgs^  e) 
			 {
				 index--;
				 file=TheFiles[index-1];
				 reinit();
			 }
	private: System::Void Next_Click(System::Object^  sender, System::EventArgs^  e) 
			 {
				 index++;
				 file=TheFiles[index-1];
				 reinit();
			 }
	private: System::Void Open_Click(System::Object^  sender, System::EventArgs^  e) 
			 {
				 GetFiles->ShowDialog();
			 }
			 void reinit()
			 {
				 if(tBar!=nullptr)
				 {
					 tBar->Abort();
					 if(isVideo)
						 video->Stop();
					 else
						 audio->Stop();
				 }
				 paused=false;
				 this->Play->Enabled=true;
				 if(count==1)
				 {
					 this->Next->Enabled=false;
					 this->Prev->Enabled=false;
				 }else
				 {
					 if(index<count)
						 this->Next->Enabled=true;
					 else
						 this->Next->Enabled=false;
					 if(index>1)
						 this->Prev->Enabled=true;
					 else
						 this->Prev->Enabled=false;
				 }
				 this->Pause->Enabled=false;
				 this->Stop->Enabled=false;
				 Play_Click(nullptr,nullptr);
			 }
			 void Panel_Double_Click(System::Object^,System::EventArgs^)
			 {
				 this->Full_Click(nullptr,nullptr);
			 }
			 enum class Supported
			 {
				 Audio = 1,
				 Video = 2,
				 Other = 3
			 };
			 Supported isSupported(String ^ theFile)
			 {
				 if(IO::Path::GetExtension(theFile)->Equals(".mp3",StringComparison::OrdinalIgnoreCase))
					 return Supported::Audio;
				 else
					 if(IO::Path::GetExtension(theFile)->Equals(".acc",StringComparison::OrdinalIgnoreCase))
						 return Supported::Audio;
					 else
						 if(IO::Path::GetExtension(theFile)->Equals(".amr",StringComparison::OrdinalIgnoreCase))
							 return Supported::Audio;
						 else
							 if(IO::Path::GetExtension(theFile)->Equals(".wav",StringComparison::OrdinalIgnoreCase))
								 return Supported::Audio;
							 else
								 if(IO::Path::GetExtension(theFile)->Equals(".mov",StringComparison::OrdinalIgnoreCase))
									 return Supported::Video;
								 else
									 if(IO::Path::GetExtension(theFile)->Equals(".vob",StringComparison::OrdinalIgnoreCase))
										 return Supported::Video;
									 else
										 if(IO::Path::GetExtension(theFile)->Equals(".avi",StringComparison::OrdinalIgnoreCase))
											 return Supported::Video;
										 else
											 if(IO::Path::GetExtension(theFile)->Equals(".3gp",StringComparison::OrdinalIgnoreCase))
												 return Supported::Video;
											 else
												 if(IO::Path::GetExtension(theFile)->Equals(".flv",StringComparison::OrdinalIgnoreCase))
													 return Supported::Video;
				 if(IO::Path::GetExtension(theFile)->Equals(".wmv",StringComparison::OrdinalIgnoreCase))
					 return Supported::Video;
				 if(IO::Path::GetExtension(theFile)->Equals(".mp4",StringComparison::OrdinalIgnoreCase))
					 return Supported::Video;
				 if(IO::Path::GetExtension(theFile)->Equals(".rmvb",StringComparison::OrdinalIgnoreCase))
					 return Supported::Video;
 				 if(IO::Path::GetExtension(theFile)->Equals(".mkv",StringComparison::OrdinalIgnoreCase))
					 return Supported::Video;
  				 if(IO::Path::GetExtension(theFile)->Equals(".rm",StringComparison::OrdinalIgnoreCase))
					 return Supported::Video;
  				 if(IO::Path::GetExtension(theFile)->Equals(".mpg",StringComparison::OrdinalIgnoreCase))
					 return Supported::Video;
				 return Supported::Other;
			 }
	private: System::Void Program_Click(System::Object^  sender, System::EventArgs^  e) 
			 {
				 Contact->Visible=true;
			 }
	private: System::Void Music_Click(System::Object^  sender, System::EventArgs^  e) 
			 {
				 Contact->Visible=true;
			 }
	private: System::Void Unspported_Click(System::Object^  sender, System::EventArgs^  e) 
			 {
				 Contact->Visible=true;
			 }
	private: System::Void Contact_Click(System::Object^  sender, System::EventArgs^  e) 
			 {
				 Contact->Visible=false;
				 if(file==nullptr)
				 {
					 this->Program->Visible=true;
				 }else
				 {
					 switch(isSupported(file))
					 {
					 case Supported::Audio:
						 this->Music->Visible=true;
						 break;
					 case Supported::Other:
						 this->Unspported->Visible=true;
						 break;
					 }
				 }
			 }
	private: System::Void PlayPanel_DragDrop(System::Object^  sender, System::Windows::Forms::DragEventArgs^  e) 
			 {
				 if ( e->Data->GetDataPresent( System::Windows::Forms::DataFormats::FileDrop ) )
					{
					 // Assign the file names to a String* array, in
					 // case the user has selected multiple files.
						array<String^>^files = (array<String^>^)e->Data->GetData( System::Windows::Forms::DataFormats::FileDrop );
						try
						{
							
							if(files->Length>1)
							{
								//System::Windows::Forms::MessageBox::Show(files->Length.ToString());
								Many = true;
								count = 4;
								index = 1;
								TheFiles = files;
								this->Next->Enabled = true;
								isStop = false;
								paused= false;
								//reinit();
							}
							else
							{
								Many = false;
								isStop = false;
								paused= false;
							}
							if(video!=nullptr)
								if(video->Playing || video->Paused)
									Stop_Click(nullptr,nullptr);
							if(audio!=nullptr)
								if(audio->Playing || audio->Paused)
									Stop_Click(nullptr,nullptr);
							file = files[0];
							Play_Click(nullptr,nullptr);
						}
						catch ( Exception^) 
						{
							//MessageBox::Show( ex->Message );
							return;
						}
					}

			 }
	private: System::Void PlayPanel_DragEnter(System::Object^  sender, System::Windows::Forms::DragEventArgs^  e) 
			 {
				 if (e->Data->GetDataPresent( System::Windows::Forms::DataFormats::FileDrop ) )
				 {
					 e->Effect = DragDropEffects::Copy;
				 }
				 else
				 {
					 e->Effect = DragDropEffects::None;
				 }

			 }
private: System::Void Volume_Scroll(System::Object^  sender, System::EventArgs^  e) 
		 {
		 }
private: System::Void Volume_ValueChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
 			 if(isVideo)
			 {
				 video->Audio->Volume = this->Volume->Value;
			 }else
			 {
				 if(audio != nullptr)
					 audio->Volume = 10;
			 }
		 }

private: System::Void ControlGroup_SizeChanged(System::Object^  sender, System::EventArgs^  e) 
		 {
			 panel1->Size = System::Drawing::Size(ControlGroup->Size.Width -10,ControlGroup->Size.Height-16);
		 }
private: System::Void PlayPanel_DoubleClick(System::Object^  sender, System::EventArgs^  e) 
		 {
			 Full_Click(nullptr,nullptr);
		 }
};

}