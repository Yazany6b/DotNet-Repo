#pragma once


namespace FlashsFixer {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

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
	private: System::Windows::Forms::Button^  button1;
	private: System::Windows::Forms::FolderBrowserDialog^  getFlash;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::ProgressBar^  pbar;



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
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(Form1::typeid));
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->getFlash = (gcnew System::Windows::Forms::FolderBrowserDialog());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->pbar = (gcnew System::Windows::Forms::ProgressBar());
			this->SuspendLayout();
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(135, 45);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(75, 23);
			this->button1->TabIndex = 0;
			this->button1->Text = L"Browes";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->BackColor = System::Drawing::Color::Transparent;
			this->label1->Font = (gcnew System::Drawing::Font(L"Rockwell Condensed", 18, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(0)));
			this->label1->ForeColor = System::Drawing::Color::AliceBlue;
			this->label1->Location = System::Drawing::Point(42, 13);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(267, 29);
			this->label1->TabIndex = 1;
			this->label1->Text = L"Click To Choose The Flash Drive";
			// 
			// pbar
			// 
			this->pbar->Location = System::Drawing::Point(47, 74);
			this->pbar->Name = L"pbar";
			this->pbar->Size = System::Drawing::Size(262, 23);
			this->pbar->TabIndex = 2;
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::SaddleBrown;
			this->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"$this.BackgroundImage")));
			this->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Stretch;
			this->ClientSize = System::Drawing::Size(344, 102);
			this->Controls->Add(this->pbar);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->button1);
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedSingle;
			this->Icon = (cli::safe_cast<System::Drawing::Icon^  >(resources->GetObject(L"$this.Icon")));
			this->Name = L"Form1";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"The Flashs Fixer";
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) 
			 {
				 if(getFlash->ShowDialog()==System::Windows::Forms::DialogResult::OK)
				 {
					System::IO::DriveInfo ^ dinfo=gcnew System::IO::DriveInfo(getFlash->SelectedPath->Substring(0,1));
					if(dinfo->DriveType==System::IO::DriveType::Removable)
					{
						 System::IO::DirectoryInfo ^ info=gcnew System::IO::DirectoryInfo(dinfo->Name);
						 array<System::IO::DirectoryInfo^>^dlist=info->GetDirectories();
						 array<System::IO::FileInfo^>^flist=info->GetFiles();
						 pbar->Maximum=dlist->Length+flist->Length;
						 this->UseWaitCursor=true;
						 pbar->Step=1;
						 for each(System::IO::DirectoryInfo^ d in dlist)
						 {
							 d->Attributes=System::IO::FileAttributes::Normal;
							 pbar->PerformStep();
						 }
						 for each(System::IO::FileInfo^ f in flist)
						 {
							 f->Attributes=System::IO::FileAttributes::Normal;
							 pbar->PerformStep();
						 }
						 this->UseWaitCursor=false;
						 MessageBox::Show("Done ","Good",MessageBoxButtons::OK,MessageBoxIcon::Information);
						 pbar->Value=0;
					}
					else
					{
						System::Windows::Forms::MessageBox::Show("This Not Removable Drive","Error",System::Windows::Forms::MessageBoxButtons::OK,
							 System::Windows::Forms::MessageBoxIcon::Error);
						return;
					}
				 }
			 }
	private: System::Void button2_Click(System::Object^  sender, System::EventArgs^  e) 
			 {
				 getFlash->ShowDialog();
				 System::Windows::Forms::MessageBox::Show(getFlash->SelectedPath->Substring(0,1));
			 }
	};
}

