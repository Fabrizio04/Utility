<?php
require_once 'mail.php';

$condizione = TRUE;
echo chr(27).chr(91).'H'.chr(27).chr(91).'J';
echo "Inserisci il mittente: ";


while($condizione){
	
	$mitt = rtrim(fgets(STDIN));

	if(strpos($mitt, "@") !== false) {
    
		$p = explode("@", $mitt);
	
		if( strpos( $p[1], "." ) !== false) {
			echo chr(27).chr(91).'H'.chr(27).chr(91).'J';
			$condizione = FALSE;
		} else {
			echo chr(27).chr(91).'H'.chr(27).chr(91).'J';
			echo "Inserisci il mittente: ";
		}
	
	} else {
		echo chr(27).chr(91).'H'.chr(27).chr(91).'J';
		echo "Inserisci il mittente: ";
	}

}

$condizione = TRUE;
echo chr(27).chr(91).'H'.chr(27).chr(91).'J';
echo "Inserisci il destinatario: ";

while($condizione){
	
	$dest = rtrim(fgets(STDIN));

	if(strpos($dest, "@") !== false) {
    
		$p = explode("@", $dest);
	
		if( strpos( $p[1], "." ) !== false) {
			echo chr(27).chr(91).'H'.chr(27).chr(91).'J';
			$condizione = FALSE;
		} else {
			echo chr(27).chr(91).'H'.chr(27).chr(91).'J';
			echo "Inserisci il destinatario: ";
		}
	
	} else {
		echo chr(27).chr(91).'H'.chr(27).chr(91).'J';
		echo "Inserisci il destinatario: ";
	}

}

echo "Inserisci l'oggetto: ";
$ogg = rtrim(fgets(STDIN));
echo chr(27).chr(91).'H'.chr(27).chr(91).'J';
echo "Inserisci il testo: ";
$mess = rtrim(fgets(STDIN));
if($mess == "") { $mess = '(Prova da terminale)'; }
echo chr(27).chr(91).'H'.chr(27).chr(91).'J';

sendMail($mitt, $dest, $ogg, $mess);