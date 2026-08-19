import socket

#connessione server socket tcp
TCP_IP = ''
TCP_PORT = 
BUFFER_SIZE = 1024

#messaggio
RISPOSTA = 'Ricevuto!'

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
s.bind((TCP_IP, TCP_PORT))
s.listen(2)
print "Socket listen . . ."

conn, addr = s.accept()
data = conn.recv(BUFFER_SIZE).decode("ascii")

print "Indirizzo ip client: ", addr
print "Messaggio ricevuto: ", data

conn.sendall(RISPOSTA)
conn.close()
s.close()