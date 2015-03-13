#pragma once

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;


namespace YazanMideaPlayer {

	/// <summary>
	/// Summary for thum
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	using namespace System::Runtime::InteropServices;
	[DllImport("user32")]
	extern "C++" int ShowCursor(bool show);
	public ref class thum : public System::Windows::Forms::Form
	{
	public:
		thum(void)
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
		~thum()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Button^  button1;

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
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(thum::typeid));
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// button1
			// 
			this->button1->AllowDrop = true;
			this->button1->Location = System::Drawing::Point(67, 62);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(75, 23);
			this->button1->TabIndex = 0;
			this->button1->Text = L"button1";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &thum::button1_Click);
			// 
			// thum
			// 
			this->AllowDrop = true;
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"$this.BackgroundImage")));
			this->ClientSize = System::Drawing::Size(211, 137);
			this->Controls->Add(this->button1);
			this->Name = L"thum";
			this->Text = L"thum";
			this->DragDrop += gcnew System::Windows::Forms::DragEventHandler(this, &thum::thum_DragDrop);
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void thum_DragDrop(System::Object^  sender, System::Windows::Forms::DragEventArgs^  e) 
			 {
 				 System::Windows::Forms::MessageBox::Show("Drag");
				 if ( e->Data->GetDataPresent( System::Windows::Forms::DataFormats::FileDrop ) )
					{
					 // Assign the file names to a String* array, in
					 // case the user has selected multiple files.
						array<String^>^files = (array<String^>^)e->Data->GetData( System::Windows::Forms::DataFormats::FileDrop );
						try
						{
							System::Windows::Forms::MessageBox::Show(files[0]);
						}
						catch ( Exception^ ex ) 
						{
							MessageBox::Show( ex->Message );
							return;
						}
					}
			 }
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) 
			 {
				 ShowCursor(false);
			 }
	};
}
