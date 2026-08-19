<?php

require "./jwt/vendor/autoload.php";
use \Firebase\JWT\JWT;

header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Methods: POST");
header("Access-Control-Max-Age: 3600");
header("Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");

//credenziali di login per richiesta
$apiuser = '';
$apipass = '';

$expired = 60*180;//validità token
$secret_key = 'miaChiaveSegreta';//chiave segreta per encode/decode

$data = json_decode(file_get_contents("php://input"));

if(isset($data->utente) && ($data->password)) {
	
	$utente = $data->utente;
	$password = $data->password;

	if($utente == $apiuser && $password == $apipass) {
		
		$issuer_claim = "http://emittente.est";
		$audience_claim = "http://destinatario.est";
		$issuedat_claim = time();
		$notbefore_claim = $issuedat_claim + 1;
		$expire_claim = $issuedat_claim + $expired;
		$token = array(
			"iss" => $issuer_claim,
			"aud" => $audience_claim,
			"iat" => $issuedat_claim,
			"nbf" => $notbefore_claim,
			"exp" => $expire_claim,
			"data" => array("id" => "test")
			);
		
		$jwt = JWT::encode($token, $secret_key);
		
		
		if($jwt === null){
			http_response_code(401);
			echo json_encode(array("messaggio" => "Errore 401"));
		}
		else {
			
			http_response_code(200);
			echo json_encode(
			array(
				"messaggio" => "OK",
				"token" => $jwt,
				"scadenza" => date('d/m/Y H:i:s', $expire_claim)
			));
		}
			
	} else {

		http_response_code(401);
		echo json_encode(array("messaggio" => "Errore 401"));
	}
	
} else {
	
	http_response_code(401);
	echo json_encode(array("messaggio" => "Errore 401-"));
}

?>