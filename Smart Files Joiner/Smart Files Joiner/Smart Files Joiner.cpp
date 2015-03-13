// Smart Files Joiner.cpp : main project file.

#include "stdafx.h"
#include "JoinerInterface.h"

using namespace SmartFilesJoiner;

[STAThreadAttribute]
int main(array<System::String ^> ^args)
{
	// Enabling Windows XP visual effects before any controls are created
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false); 

	// Create the main window and run it
	Application::Run(gcnew JoinerInterface());
	return 0;
}
