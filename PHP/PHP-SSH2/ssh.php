<?php
$host = '';
$port = ;
$username = '';
$password = '';

$connection = ssh2_connect($host, $port);
ssh2_auth_password($connection, $username, $password);
$stream = ssh2_exec($connection, '');
stream_set_blocking($stream, true);
$stream_out = ssh2_fetch_stream($stream, SSH2_STREAM_STDIO);
$stream_out = stream_get_contents($stream_out);

echo trim($stream_out);

ssh2_disconnect($connection);
unset($connection);
?>