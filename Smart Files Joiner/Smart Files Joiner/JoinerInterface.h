#pragma once


namespace SmartFilesJoiner {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for JoinerInterface
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class JoinerInterface : public System::Windows::Forms::Form
	{
	public:
		JoinerInterface(void)
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
		~JoinerInterface()
		{
			if (components)
			{
				delete components;
			}
		}

	protected: 

	private: System::Windows::Forms::ProgressBar^  currentProgressBar;
	private: System::Windows::Forms::ProgressBar^  totalProgressBar;


	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::Button^  addButton;
	private: System::Windows::Forms::Button^  removeButton;
	private: System::Windows::Forms::Button^  moveUpButton;
	private: System::Windows::Forms::Button^  moveDownButton;
	private: System::Windows::Forms::Button^  joinButton;
	private: System::Windows::Forms::OpenFileDialog^  openFileDialog;

	private: System::Windows::Forms::SaveFileDialog^  saveFileDialog;
	private: System::Windows::Forms::ListBox^  filesListBox;
	private: System::Windows::Forms::Panel^  panel1;
	private: System::Windows::Forms::Button^  removeAllButton;
	private: System::Windows::Forms::Button^  addSaveButton;
	private: System::Windows::Forms::Button^  remSaveButton;
	private: System::Windows::Forms::Button^  showSaveButton;
	private: System::Windows::Forms::CheckBox^  backgroundCheckBox;
	private: System::Windows::Forms::CheckBox^  deleteAJheckBox;














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
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(JoinerInterface::typeid));
			this->currentProgressBar = (gcnew System::Windows::Forms::ProgressBar());
			this->totalProgressBar = (gcnew System::Windows::Forms::ProgressBar());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->addButton = (gcnew System::Windows::Forms::Button());
			this->removeButton = (gcnew System::Windows::Forms::Button());
			this->moveUpButton = (gcnew System::Windows::Forms::Button());
			this->moveDownButton = (gcnew System::Windows::Forms::Button());
			this->joinButton = (gcnew System::Windows::Forms::Button());
			this->openFileDialog = (gcnew System::Windows::Forms::OpenFileDialog());
			this->saveFileDialog = (gcnew System::Windows::Forms::SaveFileDialog());
			this->filesListBox = (gcnew System::Windows::Forms::ListBox());
			this->panel1 = (gcnew System::Windows::Forms::Panel());
			this->showSaveButton = (gcnew System::Windows::Forms::Button());
			this->remSaveButton = (gcnew System::Windows::Forms::Button());
			this->addSaveButton = (gcnew System::Windows::Forms::Button());
			this->removeAllButton = (gcnew System::Windows::Forms::Button());
			this->backgroundCheckBox = (gcnew System::Windows::Forms::CheckBox());
			this->deleteAJheckBox = (gcnew System::Windows::Forms::CheckBox());
			this->panel1->SuspendLayout();
			this->SuspendLayout();
			// 
			// currentProgressBar
			// 
			this->currentProgressBar->Location = System::Drawing::Point(62, 347);
			this->currentProgressBar->Name = L"currentProgressBar";
			this->currentProgressBar->Size = System::Drawing::Size(663, 19);
			this->currentProgressBar->TabIndex = 1;
			// 
			// totalProgressBar
			// 
			this->totalProgressBar->Location = System::Drawing::Point(62, 372);
			this->totalProgressBar->Name = L"totalProgressBar";
			this->totalProgressBar->Size = System::Drawing::Size(663, 19);
			this->totalProgressBar->TabIndex = 2;
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(12, 349);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(44, 13);
			this->label1->TabIndex = 3;
			this->label1->Text = L"Current";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(12, 374);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(31, 13);
			this->label2->TabIndex = 4;
			this->label2->Text = L"Total";
			// 
			// addButton
			// 
			this->addButton->Location = System::Drawing::Point(9, 7);
			this->addButton->Name = L"addButton";
			this->addButton->Size = System::Drawing::Size(78, 23);
			this->addButton->TabIndex = 5;
			this->addButton->Text = L"Add File";
			this->addButton->UseVisualStyleBackColor = true;
			this->addButton->Click += gcnew System::EventHandler(this, &JoinerInterface::addButton_Click);
			// 
			// removeButton
			// 
			this->removeButton->Location = System::Drawing::Point(9, 39);
			this->removeButton->Name = L"removeButton";
			this->removeButton->Size = System::Drawing::Size(78, 23);
			this->removeButton->TabIndex = 6;
			this->removeButton->Text = L"Rmove";
			this->removeButton->UseVisualStyleBackColor = true;
			this->removeButton->Click += gcnew System::EventHandler(this, &JoinerInterface::removeButton_Click);
			// 
			// moveUpButton
			// 
			this->moveUpButton->Location = System::Drawing::Point(9, 103);
			this->moveUpButton->Name = L"moveUpButton";
			this->moveUpButton->Size = System::Drawing::Size(78, 23);
			this->moveUpButton->TabIndex = 7;
			this->moveUpButton->Text = L"Move Up";
			this->moveUpButton->UseVisualStyleBackColor = true;
			this->moveUpButton->Click += gcnew System::EventHandler(this, &JoinerInterface::moveUpButton_Click);
			// 
			// moveDownButton
			// 
			this->moveDownButton->Location = System::Drawing::Point(9, 135);
			this->moveDownButton->Name = L"moveDownButton";
			this->moveDownButton->Size = System::Drawing::Size(78, 23);
			this->moveDownButton->TabIndex = 8;
			this->moveDownButton->Text = L"Move Down";
			this->moveDownButton->UseVisualStyleBackColor = true;
			this->moveDownButton->Click += gcnew System::EventHandler(this, &JoinerInterface::moveDownButton_Click);
			// 
			// joinButton
			// 
			this->joinButton->Location = System::Drawing::Point(9, 263);
			this->joinButton->Name = L"joinButton";
			this->joinButton->Size = System::Drawing::Size(78, 23);
			this->joinButton->TabIndex = 9;
			this->joinButton->Text = L"Join";
			this->joinButton->UseVisualStyleBackColor = true;
			this->joinButton->Click += gcnew System::EventHandler(this, &JoinerInterface::joinButton_Click);
			// 
			// openFileDialog
			// 
			this->openFileDialog->Multiselect = true;
			// 
			// filesListBox
			// 
			this->filesListBox->FormattingEnabled = true;
			this->filesListBox->Location = System::Drawing::Point(15, 11);
			this->filesListBox->Name = L"filesListBox";
			this->filesListBox->Size = System::Drawing::Size(710, 329);
			this->filesListBox->TabIndex = 10;
			// 
			// panel1
			// 
			this->panel1->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->panel1->Controls->Add(this->deleteAJheckBox);
			this->panel1->Controls->Add(this->showSaveButton);
			this->panel1->Controls->Add(this->remSaveButton);
			this->panel1->Controls->Add(this->addSaveButton);
			this->panel1->Controls->Add(this->removeAllButton);
			this->panel1->Controls->Add(this->joinButton);
			this->panel1->Controls->Add(this->addButton);
			this->panel1->Controls->Add(this->removeButton);
			this->panel1->Controls->Add(this->moveDownButton);
			this->panel1->Controls->Add(this->moveUpButton);
			this->panel1->Location = System::Drawing::Point(728, 11);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(98, 329);
			this->panel1->TabIndex = 11;
			// 
			// showSaveButton
			// 
			this->showSaveButton->Location = System::Drawing::Point(9, 231);
			this->showSaveButton->Name = L"showSaveButton";
			this->showSaveButton->Size = System::Drawing::Size(78, 23);
			this->showSaveButton->TabIndex = 14;
			this->showSaveButton->Text = L"Show Save";
			this->showSaveButton->UseVisualStyleBackColor = true;
			this->showSaveButton->Click += gcnew System::EventHandler(this, &JoinerInterface::showSaveButton_Click);
			// 
			// remSaveButton
			// 
			this->remSaveButton->Location = System::Drawing::Point(9, 199);
			this->remSaveButton->Name = L"remSaveButton";
			this->remSaveButton->Size = System::Drawing::Size(78, 23);
			this->remSaveButton->TabIndex = 13;
			this->remSaveButton->Text = L"Rem Save";
			this->remSaveButton->UseVisualStyleBackColor = true;
			this->remSaveButton->Click += gcnew System::EventHandler(this, &JoinerInterface::remSaveButton_Click);
			// 
			// addSaveButton
			// 
			this->addSaveButton->Location = System::Drawing::Point(9, 167);
			this->addSaveButton->Name = L"addSaveButton";
			this->addSaveButton->Size = System::Drawing::Size(78, 23);
			this->addSaveButton->TabIndex = 12;
			this->addSaveButton->Text = L"Add Save";
			this->addSaveButton->UseVisualStyleBackColor = true;
			this->addSaveButton->Click += gcnew System::EventHandler(this, &JoinerInterface::button2_Click);
			// 
			// removeAllButton
			// 
			this->removeAllButton->Location = System::Drawing::Point(9, 70);
			this->removeAllButton->Name = L"removeAllButton";
			this->removeAllButton->Size = System::Drawing::Size(78, 23);
			this->removeAllButton->TabIndex = 10;
			this->removeAllButton->Text = L"Rmove All";
			this->removeAllButton->UseVisualStyleBackColor = true;
			this->removeAllButton->Click += gcnew System::EventHandler(this, &JoinerInterface::removeAllButton_Click);
			// 
			// backgroundCheckBox
			// 
			this->backgroundCheckBox->AutoSize = true;
			this->backgroundCheckBox->Location = System::Drawing::Point(731, 361);
			this->backgroundCheckBox->Name = L"backgroundCheckBox";
			this->backgroundCheckBox->Size = System::Drawing::Size(82, 17);
			this->backgroundCheckBox->TabIndex = 12;
			this->backgroundCheckBox->Text = L"Background";
			this->backgroundCheckBox->UseVisualStyleBackColor = true;
			// 
			// deleteAJheckBox
			// 
			this->deleteAJheckBox->AutoSize = true;
			this->deleteAJheckBox->CheckAlign = System::Drawing::ContentAlignment::TopCenter;
			this->deleteAJheckBox->Location = System::Drawing::Point(4, 292);
			this->deleteAJheckBox->Name = L"deleteAJheckBox";
			this->deleteAJheckBox->Size = System::Drawing::Size(92, 31);
			this->deleteAJheckBox->TabIndex = 15;
			this->deleteAJheckBox->Text = L"Delete After Join";
			this->deleteAJheckBox->UseVisualStyleBackColor = true;
			// 
			// JoinerInterface
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(828, 397);
			this->Controls->Add(this->backgroundCheckBox);
			this->Controls->Add(this->panel1);
			this->Controls->Add(this->filesListBox);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->totalProgressBar);
			this->Controls->Add(this->currentProgressBar);
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedSingle;
			this->Icon = (cli::safe_cast<System::Drawing::Icon^  >(resources->GetObject(L"$this.Icon")));
			this->MaximizeBox = false;
			this->Name = L"JoinerInterface";
			this->Text = L"JoinerInterface";
			this->FormClosing += gcnew System::Windows::Forms::FormClosingEventHandler(this, &JoinerInterface::JoinerInterface_FormClosing);
			this->panel1->ResumeLayout(false);
			this->panel1->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion

		System::Collections::Generic::List<String^> ^ files;
		System::Collections::Generic::Dictionary<int , String^> ^ saves;


	private: System::Void addButton_Click(System::Object^  sender, System::EventArgs^  e) {
				 if(files == nullptr)
				 {
					 files = gcnew System::Collections::Generic::List<String^>();
				 }

			     if(saves == nullptr)
				 {
					 saves = gcnew System::Collections::Generic::Dictionary<int , String^>();
				 }

				 if(openFileDialog->ShowDialog() == System::Windows::Forms::DialogResult::OK)
				 {
					 filesListBox->Items->AddRange(openFileDialog->FileNames);
					 files->AddRange(openFileDialog->FileNames);
				 }

			 }
	private: System::Void removeButton_Click(System::Object^  sender, System::EventArgs^  e) {
				 if(filesListBox->SelectedItems->Count > 0)
				 {
					 Object ^ item = filesListBox->SelectedItems[0];
					 filesListBox->Items->Remove(item);
					 files->Remove(item->ToString());
				 }

			 }
	private: System::Void moveUpButton_Click(System::Object^  sender, System::EventArgs^  e) {
				 if(filesListBox->SelectedItems->Count > 0)
				 {
					 int index = filesListBox->SelectedIndex;
					 if(index == 0)
						 return;

					 Object ^ item = filesListBox->SelectedItems[0];
					 filesListBox->Items->Remove(item);

					 index--;

					 filesListBox->Items->Insert(index,item);
					 files->Insert(index,item->ToString());

					 filesListBox->SelectedIndex = index;
				 }

			 }
	private: System::Void moveDownButton_Click(System::Object^  sender, System::EventArgs^  e) {
				 if(filesListBox->SelectedItems->Count > 0)
				 {
					 int index = filesListBox->SelectedIndex;
					 if(index == filesListBox->Items->Count - 1)
						 return;

					 Object ^ item = filesListBox->SelectedItems[0];
					 filesListBox->Items->Remove(item);

					 index++;

					 filesListBox->Items->Insert(index,item);
					 files->Insert(index,item->ToString());

					 filesListBox->SelectedIndex = index;
				 }
			 }
	private: System::Threading::Thread ^ thread;
	private: System::Void joinButton_Click(System::Object^  sender, System::EventArgs^  e) {

				 panel1->Enabled = false;
				 filesListBox ->Enabled = false;

				 buffer = gcnew array<Byte>(100000);

				 String  ^ save = "";
				 if(saves->ContainsKey(0))
				 {
					 save = saves[0];
				 }else
				 {
					 if (saveFileDialog->ShowDialog() == System::Windows::Forms::DialogResult::OK)
					 {
						 save = saveFileDialog->FileName;
					 }
					 else
						 return;
				 }

				 thread = gcnew System::Threading::Thread(gcnew System::Threading::ParameterizedThreadStart(this,&JoinerInterface::StartThread));

				 thread->Start(save);

				 //StartThread();
			 }
			 array<Byte> ^ buffer;
	private : System::Void StartThread(Object ^ f)
			  {
				  if(files->Count == 0)
					  return ;

				  totalProgressBar->Value = 0;
				  totalProgressBar->Maximum = files->Count;

				  String ^ save = f->ToString();

				  System::IO::FileStream ^ writter = gcnew System::IO::FileStream(save, System::IO::FileMode::OpenOrCreate);

				  for (int i = 0 ; i < files->Count ; i++)
				  {
					  String ^ file = files[i];
					  if(saves->ContainsKey(i))
					  {
						  writter->Close();
						  save = saves[i];
						  writter = gcnew System::IO::FileStream(save, System::IO::FileMode::OpenOrCreate);
					  }

					  try
					  {
						  System::IO::FileStream ^ reader = gcnew System::IO::FileStream(file, System::IO::FileMode::Open);

						  if(!backgroundCheckBox->Checked)
						  {
							  currentProgressBar->Minimum = 0;
							  currentProgressBar->Maximum = (int)reader->Length;
							  currentProgressBar->Value = 0;
						  }

						  int read = reader->Read(buffer, 0, buffer->Length);

						  filesListBox->SelectedIndex = i;

						  this->Text = "Join Files " + FormatDouble(((double)i / ((double)files->Count/100.0)) , 2)+"%  , Buffer Size = "+ToString((int)buffer->Length);

						  while (read > 0)
						  {
							  if(!backgroundCheckBox->Checked)
								currentProgressBar->Value += read;

							  writter->Write(buffer, 0, read);

							  if(read >= buffer->Length)
								  buffer = gcnew array<Byte>(buffer->Length + (buffer->Length / 2));

							  read = reader->Read(buffer, 0, buffer->Length);
						  }

						  if(!backgroundCheckBox->Checked)
							totalProgressBar->Value = i + 1;

						  reader->Close();

						  if(deleteAJheckBox->Checked)
							  System::IO::File::Delete(file);

					  }
					  catch(Exception ^exce) { System::Windows::Forms::MessageBox::Show(exce->Message); }
				  }

				  writter->Close();

				  if(!backgroundCheckBox->Checked){
					  totalProgressBar->Value = 0;
					  currentProgressBar->Value=0;
				  }

				  panel1->Enabled = true;
				  filesListBox ->Enabled = true;

				  System::Media::SystemSounds::Exclamation->Play();
			  }

	private: System::Void removeAllButton_Click(System::Object^  sender, System::EventArgs^  e) {
				 files->Clear();
				 filesListBox->Items->Clear();
				 saves->Clear();
			 }
private: System::Void button2_Click(System::Object^  sender, System::EventArgs^  e) {

			 if(filesListBox->SelectedItems->Count == 0)
				 return;

			 if (saveFileDialog->ShowDialog() == System::Windows::Forms::DialogResult::OK)
			 {
				 if(saves->ContainsKey(filesListBox->SelectedIndex))
				 {
					 if(MessageBox::Show(String::Format("Do you want to replace \n{0}\n with \n{1}\n", 
						 saves[filesListBox->SelectedIndex] ,saveFileDialog->FileName), "Q" ,MessageBoxButtons::YesNo, MessageBoxIcon::Warning)
						 == System::Windows::Forms::DialogResult::OK)
					 {
						 saves[filesListBox->SelectedIndex] = saveFileDialog->FileName;
					 }
				 }else
				 {
					 saves->Add(filesListBox->SelectedIndex,saveFileDialog->FileName);
				 }
			 }
			
		 }

		public: static double FormatDouble(double number, int presition)
        {
			String ^ num = number.ToString();//convert to string

            if (num->Contains("."))
            {
                if (num->Substring(num->IndexOf('.') + 1)->Length > presition)//if number of digits after the dot more the presition
                {
                    double dnum;
					double::TryParse(num->Substring(0, num->IndexOf('.') + presition + 1), dnum);//only take the wanted value
                    return dnum;
                }
            }

            return number;
        }

		public: static String ^ ToString(long bytes)
        {
            if (bytes >= 1024 && bytes < (1024*1024))
                return FormatDouble((double)((double)bytes / (double)(1024)), 2) +"KB";

            if (bytes >= (1024*1024) && bytes < (1024*1024 *1024))
                return FormatDouble((double)((double)bytes / (double)(1024*1024)), 2) + "MB";

            if (bytes >= (1024*1024 *1024))
                return FormatDouble((double)((double)bytes / (double)(1024*1024*1024)), 2) + "GB";

            return bytes + "Byte";
        }

private: System::Void remSaveButton_Click(System::Object^  sender, System::EventArgs^  e) {
			 
			 if(filesListBox->SelectedItems->Count == 0)
				 return;
			 if(saves->ContainsKey(filesListBox->SelectedIndex))
			 {
				 saves->Remove(filesListBox->SelectedIndex);
			 }

		 }
private: System::Void showSaveButton_Click(System::Object^  sender, System::EventArgs^  e) {
			 if(filesListBox->SelectedItems->Count == 0)
				 return;
			 if(saves->ContainsKey(filesListBox->SelectedIndex))
			 {
				 MessageBox::Show(saves[filesListBox->SelectedIndex]);
			 }else
			 {
				 MessageBox::Show("No Save");
			 }
		 }
private: System::Void JoinerInterface_FormClosing(System::Object^  sender, System::Windows::Forms::FormClosingEventArgs^  e) {
			 try{
				 thread->Abort();}catch(Exception^){}
		 }
};
}

