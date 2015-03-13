// Yazan Midea Player.cpp : main project file.

#include "stdafx.h"
#include "MediaPlayer.h"
#include "thum.h"
using namespace YazanMideaPlayer;

[STAThreadAttribute]
int main(array<System::String ^> ^args)
{
	// Enabling Windows XP visual effects before any controls are created
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false); 

	// Create the main window and run it
	if(args->Length>=1)
	{
		//
		//MessageBox::Show(args[0]);
		Application::Run(gcnew MediaPlayer(args));
		return 1;
	}else
	{
		Application::Run(gcnew MediaPlayer());
		return 0;
	}
}