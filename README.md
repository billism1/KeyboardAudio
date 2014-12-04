KeyboardAudio
=============

Spectrogram audio visualizer for Corsair K70 RGB keyboard for Windows, written in C# .Net.

This is based mostly on the following C++ project:
https://github.com/CalcProgrammer1/CorsairKeyboardSpectrograph

What is it
----------
This is a simple Windows program that analyzes sound from the default audio input device on your system and outputs a spectrogram to a connected Corsair K70 RGB keyboard. A vertical spectrogram is also displayed to the consule via asii.

Dependencies
------------
- OpenTK - This .Net assembly library provides a wrapper for OpenAL, which provides the audio input for the program.

Credits
-------
Thank you CalcProgrammer1 for reverse engineering the USB IO for this keyboard and for providing working C++ code. See: http://www.reddit.com/r/MechanicalKeyboards/comments/2ij2um/corsair_k70_rgb_usb_protocol_reverse_engineering/ and thanks to reddit.com/u/fly-hard for the mapping of LED to positions in a matrix.

Thank you Chris Lomont for providing a C# Fast Fourier transform (FFT) implementation that is easy to use. See: http://www.lomont.org/

Thank you Corsair for producing a sweet keyboard.
