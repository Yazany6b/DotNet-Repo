#pragma once

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;


namespace TheInternetDownloader2 {

	/// <summary>
	/// Summary for TheBox
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class TheBox : public System::Windows::Forms::Form
	{
	public:
		TheBox(void)
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
		~TheBox()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Button^  OK;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Panel^  panel1;
	protected: 

	protected: 

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(TheBox::typeid));
			this->OK = (gcnew System::Windows::Forms::Button());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->panel1 = (gcnew System::Windows::Forms::Panel());
			this->SuspendLayout();
			// 
			// OK
			// 
			this->OK->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"OK.BackgroundImage")));
			this->OK->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
			this->OK->Location = System::Drawing::Point(109, 79);
			this->OK->Name = L"OK";
			this->OK->Size = System::Drawing::Size(75, 31);
			this->OK->TabIndex = 0;
			this->OK->Text = L"OK";
			this->OK->UseVisualStyleBackColor = true;
			this->OK->Click += gcnew System::EventHandler(this, &TheBox::OK_Click);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->BackColor = System::Drawing::SystemColors::ActiveCaptionText;
			this->label1->Font = (gcnew System::Drawing::Font(L"Tahoma", 14.25F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(0)));
			this->label1->Location = System::Drawing::Point(58, 40);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(180, 23);
			this->label1->TabIndex = 1;
			this->label1->Text = L"The Prosess Is Done";
			// 
			// panel1
			// 
			this->panel1->Location = System::Drawing::Point(0, 0);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(306, 24);
			this->panel1->TabIndex = 2;
			// 
			// TheBox
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::SystemColors::ButtonHighlight;
			this->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"$this.BackgroundImage")));
			this->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
			this->ClientSize = System::Drawing::Size(306, 122);
			this->ControlBox = false;
			this->Controls->Add(this->panel1);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->OK);
			this->ForeColor = System::Drawing::SystemColors::ButtonFace;
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::None;
			this->MaximizeBox = false;
			this->MinimizeBox = false;
			this->Name = L"TheBox";
			this->ShowIcon = false;
			this->ShowInTaskbar = false;
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"TheBox";
			this->TopMost = true;
			this->Load += gcnew System::EventHandler(this, &TheBox::TheBox_Load);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void OK_Click(System::Object^  sender, System::EventArgs^  e) 
			 {
				 this->Close();
			 }
	private: System::Void TheBox_Load(System::Object^  sender, System::EventArgs^  e) 
			 {
				 System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(TheBox::typeid));
				 System::Media::SoundPlayer ^ sound=gcnew  System::Media::SoundPlayer((cli::safe_cast<System::IO::Stream^>(resources->GetObject(L"decide"))));
				 sound->Play();
			 }
	};
}
