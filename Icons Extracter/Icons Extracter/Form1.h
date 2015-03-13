#pragma once


namespace IconsExtracter {

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
	private: System::Windows::Forms::Button^  openButton;
	private: System::Windows::Forms::PictureBox^  iconPictureBox;
	private: System::Windows::Forms::TextBox^  pathTextBox;
	protected: 



	private: System::Windows::Forms::Button^  saveButton;
	private: System::Windows::Forms::OpenFileDialog^  openFileDialog;

	private: System::Windows::Forms::SaveFileDialog^  saveFileDialog;

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
			this->openButton = (gcnew System::Windows::Forms::Button());
			this->iconPictureBox = (gcnew System::Windows::Forms::PictureBox());
			this->pathTextBox = (gcnew System::Windows::Forms::TextBox());
			this->saveButton = (gcnew System::Windows::Forms::Button());
			this->openFileDialog = (gcnew System::Windows::Forms::OpenFileDialog());
			this->saveFileDialog = (gcnew System::Windows::Forms::SaveFileDialog());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->iconPictureBox))->BeginInit();
			this->SuspendLayout();
			// 
			// openButton
			// 
			this->openButton->Location = System::Drawing::Point(12, 12);
			this->openButton->Name = L"openButton";
			this->openButton->Size = System::Drawing::Size(180, 158);
			this->openButton->TabIndex = 0;
			this->openButton->Text = L"Choose File";
			this->openButton->UseVisualStyleBackColor = true;
			this->openButton->Click += gcnew System::EventHandler(this, &Form1::openButton_Click);
			// 
			// iconPictureBox
			// 
			this->iconPictureBox->Location = System::Drawing::Point(383, 12);
			this->iconPictureBox->Name = L"iconPictureBox";
			this->iconPictureBox->Size = System::Drawing::Size(321, 184);
			this->iconPictureBox->TabIndex = 2;
			this->iconPictureBox->TabStop = false;
			// 
			// pathTextBox
			// 
			this->pathTextBox->BackColor = System::Drawing::SystemColors::ButtonHighlight;
			this->pathTextBox->Location = System::Drawing::Point(12, 176);
			this->pathTextBox->Name = L"pathTextBox";
			this->pathTextBox->ReadOnly = true;
			this->pathTextBox->Size = System::Drawing::Size(365, 20);
			this->pathTextBox->TabIndex = 3;
			// 
			// saveButton
			// 
			this->saveButton->Location = System::Drawing::Point(193, 12);
			this->saveButton->Name = L"saveButton";
			this->saveButton->Size = System::Drawing::Size(180, 158);
			this->saveButton->TabIndex = 4;
			this->saveButton->Text = L"Save Icon";
			this->saveButton->UseVisualStyleBackColor = true;
			this->saveButton->Click += gcnew System::EventHandler(this, &Form1::saveButton_Click);
			// 
			// saveFileDialog
			// 
			this->saveFileDialog->Filter = L"Icon File *.ico|*.ico;";
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(716, 208);
			this->Controls->Add(this->saveButton);
			this->Controls->Add(this->pathTextBox);
			this->Controls->Add(this->iconPictureBox);
			this->Controls->Add(this->openButton);
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedSingle;
			this->Icon = (cli::safe_cast<System::Drawing::Icon^  >(resources->GetObject(L"$this.Icon")));
			this->MaximizeBox = false;
			this->Name = L"Form1";
			this->Text = L"Icons Extracter";
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->iconPictureBox))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion

		System::Drawing::Icon ^ currentIcon;
	private: System::Void openButton_Click(System::Object^  sender, System::EventArgs^  e) {

				 if(openFileDialog->ShowDialog() == System::Windows::Forms::DialogResult::OK)
				 {
					 pathTextBox->Text = openFileDialog->FileName;

					 currentIcon = System::Drawing::Icon::ExtractAssociatedIcon(pathTextBox->Text);

					 iconPictureBox->Image = gcnew Bitmap(Bitmap::FromHicon(currentIcon->Handle) , iconPictureBox->Size);
				 }
			 }
private: System::Void saveButton_Click(System::Object^  sender, System::EventArgs^  e) {

			 if(currentIcon == nullptr)
			 {
				 MessageBox::Show("No Extracted Icon Yet!","Error");
				 return;
			 }

			 if(saveFileDialog->ShowDialog() == System::Windows::Forms::DialogResult::OK)
			 {
				 System::IO::Stream ^ stream = System::IO::File::Open(saveFileDialog->FileName , System::IO::FileMode::OpenOrCreate);

				 currentIcon->Save(stream);

				 stream->Close();
			 }
		 }
};
}

