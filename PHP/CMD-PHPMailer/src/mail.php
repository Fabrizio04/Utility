<?php
use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;
require 'vendor/autoload.php';

function sendMail ($mitt = '', $dest = '',$ogg = '', $mes = '') {
	
	$fileName = dirname(__FILE__).'\settings.csv';

	if ( file_exists($fileName) ) {
		
		$handle = fopen($fileName, "r");
		
		$data = fgetcsv($handle, 1000, ";");
		
		$SMTPDebug = $data[0];
		$Host = $data[1];
		$SMTPAuth = $data[2];
		$Username = $data[3];
		$Password = $data[4];
		$SMTPSecure = $data[5];
		$Port = trim($data[6]);
		
	} else {
		echo chr(27).chr(91).'H'.chr(27).chr(91).'J';
		echo "Nessun file di configurazione trovato";
		exit;
	}
	
	$mail = new PHPMailer(true);
	
	try {
		$mail->SMTPDebug = $SMTPDebug;
		$mail->isSMTP();
		$mail->Host = $Host;
		
		if ($SMTPAuth == 'si') {
			$mail->SMTPAuth = true;
			$mail->Username = $Username;
			$mail->Password = $Password;
		} else {
			$mail->SMTPAuth = false;
		}
		
		if ($SMTPSecure != 'no') $mail->SMTPSecure = $SMTPSecure;
		
		$mail->Port = $Port;

		$mail->setFrom($mitt, '');
		$mail->addAddress($dest, '');
	
		$mail->isHTML(true); 
		$mail->Subject = $ogg;
		$mail->Body    = $mes;
	 
		$mail->send();
		if ($SMTPDebug != '2') { echo chr(27).chr(91).'H'.chr(27).chr(91).'J'; }
		echo "Message has been sent";
	
	} catch (Exception $e) {
		echo chr(27).chr(91).'H'.chr(27).chr(91).'J';
		echo "Message could not be sent.\n";
		echo 'Mailer Error: ' . $mail->ErrorInfo;
	}

}