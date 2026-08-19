<?php

require "./jwt/vendor/autoload.php";
use \Firebase\JWT\JWT;

header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Methods: GET");
header("Access-Control-Max-Age: 3600");
header("Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");

$jwt = null;
$headers = apache_request_headers();

$secret_key = 'miaChiaveSegreta';//chiave segreta per encode/decode

if(isset($headers['Authorization'])){
	
	$jwt = $headers['Authorization'];
	
	try {
		
		$decoded = JWT::decode($jwt, $secret_key, array('HS256'));
		
		//eseguo qualcosa
		echo "OK";
		
		http_response_code(200);

	}

	catch (Exception $e){

		if($e->getMessage() == "Expired token"){
			http_response_code(401);
			echo json_encode(array("messaggio" => "Token scaduto"));
			
		} else {

			http_response_code(401);
			echo json_encode(array("messaggio" => "Errore 401"));
		}
	}
	
} else {
	http_response_code(401);
	echo json_encode(array("messaggio" => "Errore 401"));
}

?>