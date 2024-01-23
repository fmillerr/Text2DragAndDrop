#Requires AutoHotkey v2.0
$^c::{
	Send "^c"
	ClipWait  ; Wait for the clipboard to contain text.
	KeyWait('c')
	IF(KeyWait('c', 'DT.3')){
		Run('C:/CustomPrograms/TextToClippyFile/Text2DragAndDrop.exe open')
	}
}