import socket

#connessione server socket tcp
TCP_IP = ''
TCP_PORT = 
BUFFER_SIZE = 1024

#messaggio
MESSAGE = 'Ciao Mondo!'

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.connect((TCP_IP, TCP_PORT))
s.send(MESSAGE)

print 'Messaggio inviato: ', MESSAGE

data = s.recv(BUFFER_SIZE)
s.close()

print "Messaggio ricevuto: ", data